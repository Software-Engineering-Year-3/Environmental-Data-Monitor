using System.Collections.ObjectModel;

namespace ED_Monitor.Data.Models;

public interface IQualityReading 
{
	DataStatus Status { get; set; }
    ObservableCollection<DataLog> Logs { get; set; }
}