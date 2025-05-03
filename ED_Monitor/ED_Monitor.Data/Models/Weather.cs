using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ED_Monitor.Data.Models;

[Table("WheatherData")]
[PrimaryKey(nameof(StationID))]

public class WeatherData
{
    public int StationID { get; set; }
    public DateTime Time { get; set; }
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float Wind_speed { get; set; }
    public float Wind_direction { get; set; }

    public string WindStatus => Wind_speed > 20 ? "🌬️ Windy" : "✅ Calm";
    public Color WindColor => Wind_speed > 20 ? Colors.OrangeRed : Colors.Green;
    
}
