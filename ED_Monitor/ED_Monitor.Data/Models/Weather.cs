using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ED_Monitor.Data.Services;

namespace ED_Monitor.Data.Models;

[Table("WheatherData")]
[PrimaryKey(nameof(StationID))]

public class WeatherData : IQualityReading
{
    public int StationID { get; set; }
    public DateTime Time { get; set; }
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float Wind_speed { get; set; }
    public float Wind_direction { get; set; }

    public string WindStatus => Wind_speed > 20 ? "🌬️ Windy" : "✅ Calm";
    public Color WindColor => Wind_speed > 20 ? Colors.OrangeRed : Colors.Green;
    
    // Additional fields for 2nd  user story - NF
    // This can be: valid, flagged, or missing
    public DataStatus Status { get; set; }
    // List to store deatils of the log - time, user, action, reason
    public ObservableCollection<DataLog> Logs { get; set; } = new ObservableCollection<DataLog>();
}

