using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ED_Monitor.Data.Models;

using System.Text.Json.Serialization;

[Table("SensorData")]
[PrimaryKey(nameof(SensorID))]
public class SensorData
{

    
    public int SensorID { get; set; }
    public string Name { get; set; } 
    public string Type { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Status { get; set; }
    
}
