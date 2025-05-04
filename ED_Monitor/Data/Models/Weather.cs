using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ED_Monitor.Data.Models;

[Table("WheatherData")]
[PrimaryKey(nameof(StationID))]

public class WeatherData
{
    public int StationID { get; set; } // ID of the weather station
    public TimeOnly Time { get; set; } // Time of the reading
    public float Temperature { get; set; } // Temperature in °C
    public float Humidity { get; set; } // Relative humidity in %
    public float Wind_speed { get; set; } // Wind speed in km/h
    public float Wind_direction { get; set; }  // Wind direction in degrees
    
      // True if wind is above 20 km/h
    public string WindStatus => Wind_speed > 20 ? "Windy" : "Calm";
    
    // Color to represent windiness
    public Color WindColor => Wind_speed > 20 ? Colors.OrangeRed : Colors.Green;
}
