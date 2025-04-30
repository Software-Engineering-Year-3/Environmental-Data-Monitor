
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ED_Monitor.Data;

[Table("AirMetadata")]
[PrimaryKey(nameof(Site_Name))]
public class AirMetadata
{
    public required string Site_Name { get; set; } 
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public int Elevation { get; set; }
    public int Utc_offset { get; set; }
    public required string LocalAuthority { get; set; }
}