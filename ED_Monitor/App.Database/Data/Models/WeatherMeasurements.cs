using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ED_Monitor.AppDatabase.Data;
using ED_Monitor.AppDatabase.Data.Models;
namespace ED_Monitor.AppDatabase.Data;


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
