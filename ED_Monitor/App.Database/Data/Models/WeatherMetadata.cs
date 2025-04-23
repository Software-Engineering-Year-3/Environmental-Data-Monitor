using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ED_Monitor.AppDatabase.Data;
using ED_Monitor.AppDatabase.Data.Models;
namespace ED_Monitor.AppDatabase.Data;

[Table("WheatherMetadata")]

public class WheatherMetadata
{
    public int ID { get; set; } // Primary Key
    public required string Latitude { get; set; }
    public required string Longitude { get; set; }
    public required string Elevation { get; set; }
    public required string Utc_offset { get; set; }
    public required string Timezone { get; set; }
    public required string Timezone_abbrevation { get; set; }
}
