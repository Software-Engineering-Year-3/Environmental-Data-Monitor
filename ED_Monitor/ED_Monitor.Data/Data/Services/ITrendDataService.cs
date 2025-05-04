using ED_Monitor.Models;

namespace ED_Monitor.Services;

public interface ITrendDataService
{
    /// <summary>
    /// Load and aggregate measurements from the DB over the given period.
    /// </summary>
    Task<TrendData> GetTrendDataAsync(TimeSpan period);
}
