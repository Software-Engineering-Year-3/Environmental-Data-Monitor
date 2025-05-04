using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Models;
using ED_Monitor.Services;

namespace ED_Monitor.ViewModels
{
    public partial class MaintenanceViewModel : ObservableObject
    {
        // The service that handles the data (CRUD operations)
        readonly IMaintenanceService   _svc;
        // The service that handles the local notifications
        readonly INotificationService  _notifier;

        [ObservableProperty]
        ObservableCollection<MaintenanceTask> tasks = new();

        [ObservableProperty]
        bool isBusy;


        // The constructor is called when the view model is created.
        public MaintenanceViewModel(
            IMaintenanceService svc,
            INotificationService notifier)
        {
            _svc = svc;
            _notifier = notifier;
        }

        [RelayCommand]
        public async Task LoadTasksAsync()
        {
            // Check if the view model is already busy with another operation
            if (IsBusy) return;
            IsBusy = true;

            // Load the list of tasks from the repository
            var list = await _svc.GetUpcomingAsync();
            Tasks = new ObservableCollection<MaintenanceTask>(list);

            IsBusy = false;
        }

        [RelayCommand]
        public async Task AddOrEditTaskAsync(MaintenanceTask task)
        {
            // Check if the view model is already busy with another operation
            if (IsBusy) return;
            IsBusy = true;

            // Save/update in the repository
            await _svc.AddOrUpdateAsync(task);

            // Schedule a local reminder for that due date
            await _notifier.ScheduleAsync(task);

            // Refresh the list
            await LoadTasksAsync();

            IsBusy = false;
        }

        [RelayCommand]
        public async Task DeleteTaskAsync(MaintenanceTask task)
        {
            // Check if the view model is already busy with another operation
            if (IsBusy) return;
            IsBusy = true;

            // Remove from repository
            await _svc.DeleteAsync(task.Id);

            // Cancel any pending notification
            await _notifier.CancelAsync(task.Id);

            // Refresh the list
            await LoadTasksAsync();

            IsBusy = false;
        }
    }
}
