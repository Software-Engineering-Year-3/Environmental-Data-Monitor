using Microsoft.Maui.Controls;
using ED_Monitor.Models;
using ED_Monitor.ViewModels;

namespace ED_Monitor.Views;

public partial class MaintenancePage : ContentPage
{
    public MaintenancePage()
    {
        InitializeComponent();
    }

    // Show a simple prompt to create a new task.
    async void OnAddTaskClicked(object sender, EventArgs e)
    {
        var vm = (MaintenanceViewModel)BindingContext;
        // For simplicity, using a prompt. In a real app, you'd push a proper form page.
        var sensorIdInput = await DisplayPromptAsync("New Task", "Enter Sensor GUID:");
        var dueInput      = await DisplayPromptAsync("New Task", "Enter due date (yyyy-MM-dd HH:mm):");
        if (Guid.TryParse(sensorIdInput, out var sid) && DateTime.TryParse(dueInput, out var dt))
        {
            var task = new MaintenanceTask
            {
                SensorId = sid,
                DueDate  = dt,
                Technician = "TBD"
            };
            await vm.AddOrEditTaskAsync(task);
        }
    }
}