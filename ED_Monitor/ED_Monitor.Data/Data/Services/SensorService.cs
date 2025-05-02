using ED_Monitor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ED_Monitor.Data.Models
{
    public class SensorService
    {
       public Task<List<Sensor>> GetSensorsAsync()
        {
            // Mock data
            var sensors = new List<Sensor>
            {
                new Sensor { SensorID = 1, Name = "Sensor A", Type = "Air", Latitude = 55.9533, Longitude = -3.1883, Status = "Active" },
                new Sensor { SensorID = 2, Name = "Sensor B", Type = "Water", Latitude = 55.8609, Longitude = -4.2514, Status = "Maintenance Required" },
                new Sensor { SensorID = 3, Name = "Sensor C", Type = "Weather", Latitude = 56.4907, Longitude = -4.2026, Status = "Active" }
            };
            return Task.FromResult(sensors);
        } 
    }
}
