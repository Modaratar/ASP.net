using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcApp.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Passenger_type> passenger_types, int passenger_type, string passenger_name, double passenger_age)
        {
            passenger_types.Insert(0, new Passenger_type { Name_passenger_type = "Все", Id = 0 });
            Passenger_types = new SelectList(passenger_types, "Id", "Name_passenger_type", passenger_type);
            Selected_Passenger_type = passenger_type;
            SelectedName = passenger_name;
            SelectedAge = passenger_age;
        }
        public SelectList Passenger_types { get; } // список всех видов пассажиров
        public int Selected_Passenger_type { get; } // выбранный пассажир
        public string SelectedName { get; } // выбранное имя
        public double SelectedAge { get; } // возраст пассажира
    }
}