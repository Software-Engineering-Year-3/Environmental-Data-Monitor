namespace ED_Monitor.Models;

using System.Text.Json.Serialization;

public class Sensor
{

    
    public int SensorID { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Status { get; set; } = string.Empty;
    
}
