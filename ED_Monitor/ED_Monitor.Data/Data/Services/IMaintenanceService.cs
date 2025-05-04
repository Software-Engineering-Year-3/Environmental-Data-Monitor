using ED_Monitor.Models;

namespace ED_Monitor.Services;

public interface IMaintenanceService
{
    // Retrieves all maintenance tasks
    Task<List<MaintenanceTask>> GetUpcomingAsync();
    // Retrieves a specific maintenance task by its ID
    Task AddOrUpdateAsync(MaintenanceTask task);
    // Deletes a specific maintenance task by its ID
    Task DeleteAsync(Guid taskId);
}