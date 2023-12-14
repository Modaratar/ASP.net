namespace MvcApp.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public int Id_type_passenger { get; set; }
        public Passenger_type? Passenger_type { get; set; }//тип пассажира
        public string? Passenger_name { get; set; }//имя пассажира
        public double? Passenger_age { get; set; }//возраст пассажира

    }

    public class Passenger_type
    {
        public int Id { get; set; }
        public string? Name_passenger_type { get; set; }
        public List<Passenger> Passengers { get; set; } = new();
    }
}

