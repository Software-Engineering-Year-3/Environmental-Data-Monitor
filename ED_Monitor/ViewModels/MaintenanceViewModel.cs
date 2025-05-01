using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Models;
using ED_Monitor.Services;

namespace ED_Monitor.ViewModels;

public partial class MaintenanceViewModel : ObservableObject
{
    readonly IMaintenanceService _svc;

    [ObservableProperty]
    ObservableCollection<MaintenanceTask> tasks = new();

    [ObservableProperty]
    bool isBusy;

    public MaintenanceViewModel(IMaintenanceService svc)
        => _svc = svc;

    [RelayCommand]
    public async Task LoadTasksAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        var list = await _svc.GetUpcomingAsync();
        Tasks = new ObservableCollection<MaintenanceTask>(list);
        IsBusy = false;
    }

    [RelayCommand]
    public async Task AddOrEditTaskAsync(MaintenanceTask task)
    {
        await _svc.AddOrUpdateAsync(task);
        await LoadTasksAsync();
    }

    [RelayCommand]
    public async Task DeleteTaskAsync(MaintenanceTask task)
    {
        await _svc.DeleteAsync(task.Id);
        await LoadTasksAsync();
    }
}
