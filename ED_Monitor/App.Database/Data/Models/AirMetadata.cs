
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


using ED_Monitor.AppDatabase.Data;
using ED_Monitor.AppDatabase.Data.Models;

namespace ED_Monitor.AppDatabase.Data;

[Table("AirMetadata")]
public class AirMetadata
{
    public required string Site_Name { get; set; } // Foreign key to air measurement
    public float Latitude { get; set; } 
	public float Longitude { get; set; }
	public int Elevation { get; set; } 
	public int Utc_offset { get; set; }
	public required string LocalAuthority { get; set; } // city name
}
