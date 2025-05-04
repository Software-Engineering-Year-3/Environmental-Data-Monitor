using ED_Monitor.ViewModels;
using Microsoft.Maui.Controls;

namespace ED_Monitor.Pages
{
    public partial class SensorDashboardPage : ContentPage
    {
        public SensorDashboardPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
         // Trigger the ViewModel to load sensors
            (BindingContext as SensorDashboardViewModel)?.LoadSensorsCommand.Execute(null);
        }
    }
}
