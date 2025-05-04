using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ED_Monitor.Database;
using ED_Monitor.Models;

namespace ED_Monitor.Services;

public class TrendDataService : ITrendDataService
{
    // The database context for accessing the measurements
    readonly ED_MonitorDbContext _db;

    // Constructor that initializes the database context
    public TrendDataService(ED_MonitorDbContext db) => _db = db;

    // Method to get trend data for a specified period
    // It retrieves average values for air quality, water pH, and temperature measurements
    // Used copilot to generate method
    public async Task<TrendData> GetTrendDataAsync(TimeSpan period)
    {
        // Calculate the start date based on the specified period
        var startDate = DateTime.UtcNow.Date.Subtract(period);

        // Retrieve average air quality, water pH, and temperature measurements grouped by date
        var airData = await _db.Measurements
            .OfType<AirQualityMeasurement>()
            .Where(m => m.Timestamp >= startDate)
            .GroupBy(m => m.Timestamp.Date)
            .Select(g => new { g.Key, Avg = g.Average(x => x.Value) })
            .ToListAsync();
        // Retrieve average water pH measurements grouped by date
        var waterData = await _db.Measurements
            .OfType<WaterQualityMeasurement>()
            .Where(m => m.Timestamp >= startDate)
            .GroupBy(m => m.Timestamp.Date)
            .Select(g => new { g.Key, Avg = g.Average(x => x.Value) })
            .ToListAsync();

        // Retrieve average temperature measurements grouped by date
        var tempData = await _db.Measurements
            .OfType<WeatherMeasurement>()
            .Where(m => m.Timestamp >= startDate)
            .GroupBy(m => m.Timestamp.Date)
            .Select(g => new { g.Key, Avg = g.Average(x => x.Value) })
            .ToListAsync();

        // Create a new TrendData object to hold the results
        var trend = new TrendData();
        for (var date = startDate; date <= DateTime.UtcNow.Date; date = date.AddDays(1))
        {
            // Add the date and corresponding average values to the TrendData object
            trend.Timestamps.Add(date);
            trend.AirQualityLevels.Add(airData.FirstOrDefault(x => x.Key == date)?.Avg ?? 0);
            trend.WaterPhLevels.Add(waterData.FirstOrDefault(x => x.Key == date)?.Avg ?? 0);
            trend.Temperatures.Add(tempData.FirstOrDefault(x => x.Key == date)?.Avg ?? 0);
        }

        return trend;
    }
}
