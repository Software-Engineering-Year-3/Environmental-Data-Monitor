using System;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using ED_Monitor.Models;

namespace ED_Monitor.Services
{
    /// <summary>
    /// Schedules (and cancels) local reminders for maintenance tasks
    /// </summary>
    public class LocalNotificationService : INotificationService
    {
        /// <summary>
        /// Schedule a reminder at task.DueDate
        /// </summary>
        public Task ScheduleAsync(MaintenanceTask task)
        {
            // Create a new notification request
            var request = new NotificationRequest
            {
                // Set the notification ID to a unique value (e.g., task ID)
                // This ID is used to cancel the notification later
                NotificationId = task.Id.GetHashCode(),
                Title          = "Maintenance Reminder",
                Description    = $"Sensor {task.SensorId} maintenance is due now.",
                Schedule = new NotificationRequestSchedule
                {
                    // Schedule the notification for the task's due date
                    NotifyTime = task.DueDate,
                    // Android-specific options (optional)
                    Android = new AndroidOptions
                    {
                        // Set the notification channel ID (must match the one defined in AndroidManifest.xml)
                        Priority = NotificationPriority.High
                    }
                }
            };
            // Show the notification using the LocalNotificationCenter
            LocalNotificationCenter.Current.Show(request);
            return Task.CompletedTask;
        }

        public Task CancelAsync(Guid taskId)
        {
            // Cancel the notification using the task ID
            LocalNotificationCenter.Current.Cancel(taskId.GetHashCode());
            return Task.CompletedTask;
        }
    }
}
