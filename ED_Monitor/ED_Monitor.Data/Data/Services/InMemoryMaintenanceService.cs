using ED_Monitor.Models;
using Microsoft.EntityFrameworkCore; // for future DbContext calls

namespace ED_Monitor.Services;

/// <summary>
/// Temporary in-memory implementation of IMaintenanceService.
/// Replace with DatabaseMaintenanceService when your DbContext is ready.
/// </summary>
public class InMemoryMaintenanceService : IMaintenanceService
{
    // TODO: When using EF Core, inject your DbContext here instead:
    // private readonly ED_MonitorDbContext _db;
    // public InMemoryMaintenanceService(ED_MonitorDbContext db) => _db = db;

    readonly List<MaintenanceTask> _store = new();

    public Task<List<MaintenanceTask>> GetUpcomingAsync()
    {
        // For database
        // return await _db.MaintenanceTasks
        //               .OrderBy(t => t.DueDate)
        //               .ToListAsync();

        // CURRENT IN-MEMORY BEHAVIOR:
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

        // CURRENT IN-MEMORY BEHAVIOR:
        if (task.Id == Guid.Empty)
            task.Id = Guid.NewGuid();
        _store.RemoveAll(t => t.Id == task.Id);
        _store.Add(task);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid taskId)
    {
        // FUTURE DB CALL:
        // var entity = await _db.MaintenanceTasks.FindAsync(taskId);
        // if (entity != null)
        // {
        //     _db.MaintenanceTasks.Remove(entity);
        //     await _db.SaveChangesAsync();
        // }

        // CURRENT IN-MEMORY BEHAVIOR:
        _store.RemoveAll(t => t.Id == taskId);
        return Task.CompletedTask;
    }
}
