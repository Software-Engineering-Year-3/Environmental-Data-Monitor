using ED_Monitor.Models;

namespace ED_Monitor.Data.Services;

public class ReportService : IReportService
{
    public async Task<TrendData> FetchTrendDataAsync(TimeSpan period)
    {
        // TODO: replace this stub with real data access (e.g. via EF Core or your API client)
        var now = DateTime.UtcNow;
        var days = (int)period.TotalDays;
        var rnd = Random.Shared;

        var trend = new TrendData();
        for (int i = 0; i < days; i++)
        {
            trend.Timestamps.Add(now.AddDays(-i));
            trend.AirQualityLevels.Add(rnd.NextDouble() * 100);
            trend.WaterPhLevels.Add(7 + rnd.NextDouble());
            trend.Temperatures.Add(rnd.NextDouble() * 35);
        }

        // Ensure oldest-first ordering
        trend.Timestamps.Reverse();
        trend.AirQualityLevels.Reverse();
        trend.WaterPhLevels.Reverse();
        trend.Temperatures.Reverse();

        return trend;
    }

    public Task<byte[]> BuildPdfReportAsync(TrendData data)
    {
        // TODO: wire up a PDF library (e.g. PdfSharpCore, Syncfusion) here
        throw new NotImplementedException();
    }
}