namespace ED_Monitor.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; } // e.g., "Air", "Water", "Weather"
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Status { get; set; } // e.g., "Active", "Maintenance Required"
    }
}
