using System.Collections.Generic;
using System.Threading.Tasks;
using ED_Monitor.Data.Services;
using ED_Monitor.Models;

namespace ED_Monitor.Data.Services
{
    public class MockEnvironmentalDataService : IEnvironmentalDataService
    {

        // Return loaded sensors from SensorService
        public Task<List<Sensor>> GetSensorsAsync()
            => Task.FromResult(SensorService.Sensors); 
    }
}
