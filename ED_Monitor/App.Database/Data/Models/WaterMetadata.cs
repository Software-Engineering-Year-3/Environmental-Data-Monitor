using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ED_Monitor.AppDatabase.Data;
using ED_Monitor.AppDatabase.Data.Models;
namespace ED_Monitor.AppDatabase.Data;

[Table("WaterMetadata")]
public class WaterMetadata
{
    public int SiteName { get; set; }
    public required string Sample_Period { get; set; }
    public required string Location { get; set; }    
}
