using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ED_Monitor.Data;

using System.Text.Json.Serialization;

[Table("SensorMetadata")]
[PrimaryKey(nameof(Id))]
public class Sensor
{

    
    public int SensorID { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Status { get; set; } = string.Empty;
    
}
