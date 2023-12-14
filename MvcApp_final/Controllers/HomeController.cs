using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
            if (!db.Passenger_types.Any())
            {
                Passenger_type old = new Passenger_type { Name_passenger_type = "Пожилой" };
                Passenger_type baby = new Passenger_type { Name_passenger_type = "Ребенок" };
                Passenger_type adult = new Passenger_type { Name_passenger_type = "Взрослый" };
                Passenger_type disabled = new Passenger_type { Name_passenger_type = "Инвалид" };

                db.Passenger_types.AddRange(old, baby, adult, disabled);

                db.SaveChanges();
            }
        }

        public async Task<IActionResult> Index(string passenger_name, int passenger_age, int passenger_type = 0, int page = 1)
        {
            int pageSize = 3;

            //фильтрация
            IQueryable<Passenger> passengers = db.Passengers.Include(x => x.Passenger_type);

            if (passenger_type != 0)
            {
                passengers = passengers.Where(p => p.Id_type_passenger == passenger_type);
            }
            if (!string.IsNullOrEmpty(passenger_name))
            {
                passengers = passengers.Where(p => p.Passenger_name!.Contains(passenger_name));
            }
            if (passenger_age != 0)
            {
                passengers = passengers.Where(p => p.Passenger_age == passenger_age);
            }
            // пагинация
            var count = await passengers.CountAsync();
            var items = await passengers.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(db.Passenger_types.ToList(), passenger_type, passenger_name, passenger_age)
            );
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Passenger_types = new SelectList(db.Passenger_types, "Id", "Name_passenger_type");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Passenger passenger)
        {
            passenger.Passenger_type = db.Passenger_types.FirstOrDefault(e => e.Id == passenger.Id_type_passenger);
            db.Passengers.Add(passenger);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");//редирект на индекс
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Passenger passenger = new Passenger { Id = id.Value };
                db.Entry(passenger).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}