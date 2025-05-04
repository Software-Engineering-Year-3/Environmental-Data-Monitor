using System.Collections.ObjectModel;
using System.Threading.Tasks;
namespace ED_Monitor.Data.Models;
public interface IDataService
{
    Task<ObservableCollection<AirQualityReading>> GetAirQualityData(DateTime startDate, DateTime endDate);
    Task<ObservableCollection<WaterQualityData>> GetWaterQualityData(DateTime startDate, DateTime endDate);
    Task<ObservableCollection<WeatherData>> GetWeatherData(DateTime startDate, DateTime endDate);
}