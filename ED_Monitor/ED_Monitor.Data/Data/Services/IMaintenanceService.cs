using ED_Monitor.Models;

namespace ED_Monitor.Services;

public interface IMaintenanceService
{
    Task<List<MaintenanceTask>> GetUpcomingAsync();
    Task AddOrUpdateAsync(MaintenanceTask task);
    Task DeleteAsync(Guid taskId);
}