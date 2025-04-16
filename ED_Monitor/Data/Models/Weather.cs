using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ED_Monitor.Data.Models;

[Table("WheatherData")]
[PrimaryKey(nameof(StationID))]
public class WeatherData
{
    public int StationID { get; set; }
    public TimeOnly Time { get; set; }
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float Wind_speed { get; set; }
    public float Wind_direction { get; set; }
}
