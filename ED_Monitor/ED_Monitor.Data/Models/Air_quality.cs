
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;
using ED_Monitor.Data.Services;
using System.Collections.ObjectModel;

namespace ED_Monitor.Data.Models;

[Table("AirQualityReading")]
[PrimaryKey(nameof(Site_Name))]
public class AirQualityReading : IQualityReading
{
    
     // Additional fields for 2nd  user story - NF
    // This can be: valid, flagged, or missing
    public DataStatus Status { get; set; }
    // Listto store deatils of the log - time, user, action, reason
    public ObservableCollection<DataLog> Logs { get; set; } = new ObservableCollection<DataLog>();
    public required string Site_Name { get; set; } 
    public DateTime Time { get; set; } 
    public double NO2 { get; set; }
    public double SO2 { get; set; }
    public double PM2_5 { get; set; }
    public double PM10 { get; set; }

}
