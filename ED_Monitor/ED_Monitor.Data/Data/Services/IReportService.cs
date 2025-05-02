using ED_Monitor.Models;

namespace ED_Monitor.Data.Services;

public interface IReportService
{
    /// <summary>
    /// Fetches the measurements over the given time period, aggregated by day.
    /// </summary>
    Task<TrendData> FetchTrendDataAsync(TimeSpan period);

    /// <summary>
    /// Builds a PDF from the given trend data.
    /// </summary>
    Task<byte[]> BuildPdfReportAsync(TrendData data);
}