using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ED_Monitor.Data.Models;

[Table("AirQualityData")]
public class AirQualityData
{
    public required string Site_Name { get; set; } // Foreign key to air metadata table
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public float NO2 { get; set; } // nitrogen dioxide 
    public float SO2 { get; set; } // suplhur dioxide 
    public float PM25 { get; set; } // particulate matter 
    public float PM10 { get; set; }
}
