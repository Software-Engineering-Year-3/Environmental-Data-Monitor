namespace ED_Monitor.Models;

public class TrendData
{
    public List<DateTime> Timestamps { get; set; } = new();
    public List<double> AirQualityLevels { get; set; } = new();
    public List<double> WaterPhLevels   { get; set; } = new();
    public List<double> Temperatures    { get; set; } = new();
}