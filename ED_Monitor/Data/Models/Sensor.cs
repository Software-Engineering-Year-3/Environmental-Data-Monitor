namespace ED_Monitor.Models;

public class Sensor
{
    public int    SensorID  { get; set; } // Unique identifier for the sensor
    public string Name      { get; set; } = ""; // name of the sensor
    public string Type      { get; set; } = "";   // Category or type of sensor (e.g., Air, Water, Weather)
    public double Latitude  { get; set; }  // Latitude coordinate of the sensor’s location
    public double Longitude { get; set; } // Longitude coordinate of the sensor’s location
    public string Status    { get; set; } = ""; // Operational status (e.g., Active, Offline, Maintenance)
}
