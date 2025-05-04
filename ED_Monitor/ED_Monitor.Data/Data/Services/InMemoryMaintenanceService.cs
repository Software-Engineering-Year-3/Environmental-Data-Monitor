using ED_Monitor.Models;
using Microsoft.EntityFrameworkCore; 

namespace ED_Monitor.Services;

/// <summary>
/// Temporary in-memory implementation of IMaintenanceService.
/// Replace with DatabaseMaintenanceService when your DbContext is ready.
/// </summary>
public class InMemoryMaintenanceService : IMaintenanceService
{

    /// <summary>
    /// In-memory store of maintenance tasks.
    /// This will be replaced with a database context in the future.
    /// </summary>
    readonly List<MaintenanceTask> _store = new();

    /// <summary>
    /// Get all upcoming maintenance tasks.
    /// </summary>
    public Task<List<MaintenanceTask>> GetUpcomingAsync()
    {
        // For database
        // return await _db.MaintenanceTasks
        //               .OrderBy(t => t.DueDate)
        //               .ToListAsync();

        // Filter out tasks that are not due yet
        var list = _store 
            .OrderBy(t => t.DueDate)
            .ToList();
        return Task.FromResult(list);
    }

    public Task AddOrUpdateAsync(MaintenanceTask task)
    {
        // For database
        // if (task.Id == Guid.Empty)
        // {
        //     _db.MaintenanceTasks.Add(task);
        // }
        // else
        // {
        //     _db.MaintenanceTasks.Update(task);
        // }
        // await _db.SaveChangesAsync();

        // For in-memory store
        if (task.Id == Guid.Empty)
            task.Id = Guid.NewGuid();
        _store.RemoveAll(t => t.Id == task.Id);
        _store.Add(task);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid taskId)
    {
        // For database
        // var entity = await _db.MaintenanceTasks.FindAsync(taskId);
        // if (entity != null)
        // {
        //     _db.MaintenanceTasks.Remove(entity);
        //     await _db.SaveChangesAsync();
        // }

        // For in-memory store
        _store.RemoveAll(t => t.Id == taskId);
        return Task.CompletedTask;
    }
}
