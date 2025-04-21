using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ED_Monitor.Data.Models;

[Table("AirQualityData")]
//[PrimaryKey(nameof(SiteName))]
public class AirQualityData
{
    public int StationID { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public float NO2 { get; set; }
    public float SO2 { get; set; }
    public float PM25 { get; set; }
    public float PM10 { get; set; }
}
