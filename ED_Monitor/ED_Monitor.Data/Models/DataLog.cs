namespace ED_Monitor.Data.Models;

// Class to reprsent a log entry that summaries when, what, who and why the log exists
public class DataLog 
{
	public DateTime TimeStamp { get; set; }
	public string Action { get; set; }
	public string User { get; set; } 
	public string Reason { get; set; } 

}