using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ED_Monitor.AppDatabase.Data;
using ED_Monitor.AppDatabase.Data.Models;
namespace ED_Monitor.AppDatabase.Data;

[Table("WaterQualityData")]
public class WaterQualityData
{
    public int SiteName { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public float Nitrate { get; set; }
    public float Nitrite { get; set; }
    public float Phosphate { get; set; }
    public float EC { get; set; }
}
