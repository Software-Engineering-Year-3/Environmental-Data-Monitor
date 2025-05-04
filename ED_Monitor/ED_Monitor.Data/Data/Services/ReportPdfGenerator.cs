using System.IO;
using System.Threading.Tasks;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using ED_Monitor.Models;

namespace ED_Monitor.Services;

public class ReportPdfGenerator : IReportPdfGenerator
{
    public Task<byte[]> GeneratePdfAsync(TrendData data)
    {
        // Validate input data
        using var document = new PdfDocument();
        var page = document.AddPage();
        var gfx  = XGraphics.FromPdfPage(page);
        var font = new XFont("Arial", 12);

        // Set page size and orientation
        gfx.DrawString("Environmental Trends Report", font, XBrushes.Black, new XPoint(40, 40));

        // Draw the table header
        int y = 80;
        for (int i = 0; i < data.Timestamps.Count; i++)
        {
            // Draw the table rows
            var ts  = data.Timestamps[i];
            var aq  = data.AirQualityLevels[i];
            var ph  = data.WaterPhLevels[i];
            var tmp = data.Temperatures[i];
            string line = $"Date: {ts:yyyy-MM-dd}, AQ: {aq:F2}, pH: {ph:F2}, T: {tmp:F2}°C";
            gfx.DrawString(line, font, XBrushes.Black, new XPoint(40, y));
            y += 20;
        }

        // Draw the table footer
        using var ms = new MemoryStream();
        document.Save(ms, false);
        return Task.FromResult(ms.ToArray());
    }
}
