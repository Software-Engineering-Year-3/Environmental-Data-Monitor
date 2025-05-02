using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ED_Monitor.Data.Models;

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
