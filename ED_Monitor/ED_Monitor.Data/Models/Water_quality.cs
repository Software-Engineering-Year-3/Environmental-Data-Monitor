using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ED_Monitor.Data.Models;

[Table("WaterQualityData")]
[PrimaryKey(nameof(SiteName))]
public class WaterQualityData : IQualityReading
{
    // Additional fields for 2nd  user story - NF
    // This can be: valid, flagged, or missing
    public DataStatus Status { get; set; }
    // Listto store deatils of the log - time, user, action, reason
    public ObservableCollection<DataLog> Logs { get; set; } = new ObservableCollection<DataLog>();

    public int SiteName { get; set; }
    // public DateOnly Date { get; set; }
    public DateTime Time { get; set; }
    public float Nitrate { get; set; }
    public float Nitrite { get; set; }
    public float Phosphate { get; set; }
    public float EC { get; set; }

      }
    
