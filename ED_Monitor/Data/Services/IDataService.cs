using System.Collections.Generic;
using System.Threading.Tasks;
using ED_Monitor.Data.Models;
using ED_Monitor.Models;

namespace ED_Monitor.Data.Services
{
    public interface IDataService
    {
        Task<List<Sensor>>            GetSensorsAsync();  // Fetch all sensors
        Task<List<AirQualityData>>    GetAirQualityDataAsync(); // Fetch air quality readings
        Task<List<WaterQualityData>>  GetWaterQualityDataAsync(); // Fetch water quality readings

    }
}
