using System.Collections.Generic;
using System.Threading.Tasks;
using ED_Monitor.Models;

namespace ED_Monitor.Data.Services
{
    public interface IEnvironmentalDataService 

    {
        Task<List<Sensor>> GetSensorsAsync(); // Fetch sensors for environment context
      
    }
}
