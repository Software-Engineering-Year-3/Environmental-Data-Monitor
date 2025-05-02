namespace ED_Monitor.Models;

public enum TaskStatus { Pending, Completed, Overdue }

public class MaintenanceTask
{
    public Guid   Id         { get; set; }
    public Guid   SensorId   { get; set; }
    public DateTime DueDate  { get; set; }
    public string Technician { get; set; } = string.Empty;
    public TaskStatus Status  { get; set; } = TaskStatus.Pending;
}
