namespace ED_Monitor.Models
{
    // <summary>
    // Represents a maintenance task for a sensor.
    // </summary>
    public enum TaskStatus { Pending, Completed, Overdue }

    public class MaintenanceTask
    {
        // The unique identifier for the task
        public Guid     Id         { get; set; }
        // The unique identifier for the sensor associated with the task
        public Guid     SensorId   { get; set; }
        // The name of the sensor associated with the task
        public DateTime DueDate    { get; set; }
        // The date and time when the task was created
        public string   Technician { get; set; } = string.Empty;
        // The name of the technician who created the task
        public TaskStatus Status   { get; set; } = TaskStatus.Pending;
    }
}