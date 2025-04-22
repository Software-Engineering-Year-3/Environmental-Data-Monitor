using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ED_Monitor.Data.Models;

[Table("WaterMetadata")]
public class WaterMetadata
{
    public int SiteName { get; set; }
    public required string Sample_Period { get; set; }
    public required string Location { get; set; }    
}
