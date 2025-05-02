
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ED_Monitor.Data;

[Table("AirQualityReading")]
[PrimaryKey(nameof(Site_Name))]


public class AirQualityReading
{
    public required string Site_Name { get; set; } 
    public DateTime Time { get; set; } // Assuming a common Time or DateTime field
    public double NO2 { get; set; }
    public double SO2 { get; set; }
    public double PM2_5 { get; set; }
    public double PM10 { get; set; }
    // ... other properties
}