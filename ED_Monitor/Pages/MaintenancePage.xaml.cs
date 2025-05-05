using Microsoft.Maui.Controls;
using ED_Monitor.ViewModels;
using Microsoft.Maui.Controls;

namespace ED_Monitor.Views
{
    public partial class MaintenancePage : ContentPage
    {
        public MaintenancePage(MaintenanceViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadTasksCommand.Execute(null);
        }
    }
}