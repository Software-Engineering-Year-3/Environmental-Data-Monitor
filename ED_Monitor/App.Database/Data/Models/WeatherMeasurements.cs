using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ED_Monitor.Data.Models;

[Table("WeatherData")]
public class WeatherData
{
    public int ID {get; set;} // Primary Key
	public DateTime Timestamp { get; set; }
	public float Temperature { get; set; }
	public float Humidity { get; set; }
	public float WindSpeed { get; set; }
	public float WindDirection { get; set; }
}
