using Microsoft.EntityFrameworkCore;

namespace MvcApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; } = null!;
        public DbSet<Passenger_type> Passenger_types { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}