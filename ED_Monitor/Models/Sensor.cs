using System;

namespace ED_Monitor.Models
{
    public class Sensor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Model { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
