using ED_Monitor.Models;

namespace ED_Monitor.Services;

public interface IReportPdfGenerator
{
    /// <summary>
    /// Turn trend data into a formatted PDF byte array.
    /// </summary>
    Task<byte[]> GeneratePdfAsync(TrendData data);
}
