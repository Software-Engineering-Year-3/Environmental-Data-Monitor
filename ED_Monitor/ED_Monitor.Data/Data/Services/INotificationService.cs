using System.Threading.Tasks;
using ED_Monitor.Models;

namespace ED_Monitor.Services
{
    /// <summary>
    /// Schedules (and cancels) local reminders for maintenance tasks.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Schedule a reminder at task.DueDate.
        /// </summary>
        Task ScheduleAsync(MaintenanceTask task);

        /// <summary>
        /// Cancel any scheduled reminder for that task.
        /// </summary>
        Task CancelAsync(Guid taskId);
    }
}
