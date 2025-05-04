using ED_Monitor.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ED_Monitor.Data.Services;

    public class SensorService
    {
        public Task<List<SensorData>> GetSensorsAsync()
        {
            // Mock data
            var sensors = new List<SensorData>
            {
                new SensorData { SensorID = 1, Name = "Sensor A", Type = "Air", Latitude = 55.9533, Longitude = -3.1883, Status = "Active" },
                new SensorData { SensorID = 2, Name = "Sensor B", Type = "Water", Latitude = 55.8609, Longitude = -4.2514, Status = "Maintenance Required" },
                new SensorData { SensorID = 3, Name = "Sensor C", Type = "Weather", Latitude = 56.4907, Longitude = -4.2026, Status = "Active" }
            };

            return Task.FromResult(sensors);
        }
    }

