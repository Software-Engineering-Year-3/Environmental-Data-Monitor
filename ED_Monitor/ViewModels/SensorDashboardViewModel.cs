using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Pages;
using ED_Monitor.Data.Services;
using Microsoft.Maui.Controls;

namespace ED_Monitor.ViewModels
{
    public partial class SensorDashboardViewModel : ObservableObject
    {
        public ObservableCollection<SensorViewModel> Sensors { get; } = new();

        [ObservableProperty] bool isBusy;

        public IAsyncRelayCommand LoadSensorsCommand       { get; }
        public IAsyncRelayCommand<SensorViewModel> MapCommand    { get; }
        public IAsyncRelayCommand<SensorViewModel> ReportCommand { get; }
        public IAsyncRelayCommand ShowAllSensorsCommand   { get; }

        public SensorDashboardViewModel()
        {
            LoadSensorsCommand     = new AsyncRelayCommand(LoadSensorsAsync);
            MapCommand             = new AsyncRelayCommand<SensorViewModel>(GoToMapAsync);
            ReportCommand          = new AsyncRelayCommand<SensorViewModel>(GoToReportAsync);
            ShowAllSensorsCommand  = new AsyncRelayCommand(() =>
                // absolute route to bring up the map with all pins:
                Shell.Current.GoToAsync($"//{nameof(SensorMapPage)}")
            );
        }

        private async Task LoadSensorsAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            try
            {
                Sensors.Clear();
                foreach (var s in SensorService.Sensors)
                {
                    Sensors.Add(new SensorViewModel {
                        Name      = s.Name,
                        Type      = s.Type,
                        Status    = s.Status,
                        Latitude  = s.Latitude,
                        Longitude = s.Longitude
                    });
                }
            }
            finally { IsBusy = false; }
        }

        private Task GoToMapAsync(SensorViewModel vm)
        {
            // single-sensor absolute route:
            var route = $"//{nameof(SensorMapPage)}" +
                        $"?latitude={vm.Latitude}" +
                        $"&longitude={vm.Longitude}" +
                        $"&name={Uri.EscapeDataString(vm.Name)}";
            return Shell.Current.GoToAsync(route);
        }

        private Task GoToReportAsync(SensorViewModel _) =>
            Shell.Current.GoToAsync($"//{nameof(ReportIssuePage)}");

        public class SensorViewModel
        {
            public string  Name      { get; set; } = "";
            public string  Type      { get; set; } = "";
            public string  Status    { get; set; } = "";
            public double  Latitude  { get; set; }
            public double  Longitude { get; set; }
        }
    }
}
