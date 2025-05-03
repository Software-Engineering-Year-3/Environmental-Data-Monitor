using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ED_Monitor.Data.Models;

[Table("WaterQualityData")]
[PrimaryKey(nameof(SiteName))]
public class WaterQualityData
{
    public int SiteName { get; set; }
    // public DateOnly Date { get; set; }
    public DateTime Time { get; set; }
    public float Nitrate { get; set; }
    public float Nitrite { get; set; }
    public float Phosphate { get; set; }
    public float EC { get; set; }
    
}
