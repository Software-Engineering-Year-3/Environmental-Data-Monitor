using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Core.Models;
using System.Collections.ObjectModel;

namespace ED_Monitor.ViewModels
{
    public partial class AddSensorViewModel : ObservableObject
    {
        // These will be data-bound to the Entry controls
        [ObservableProperty]
        private string sensorName = string.Empty;

        [ObservableProperty]
        private string sensorLocation = string.Empty;

        public ObservableCollection<Sensor> Sensors { get; set; } = new();

        public AddSensorViewModel()
        {
            // In a real app, you'd likely inject a data service here
        }

        [RelayCommand]
        private async void Save()
        {
            if (string.IsNullOrWhiteSpace(SensorName) || string.IsNullOrWhiteSpace(SensorLocation))
            {
                await Shell.Current.DisplayAlert("Validation", "Please enter all fields.", "OK");
                return;
            }

            var newSensor = new Sensor
            {
                Model = SensorName,
                Location = SensorLocation
            };

            Sensors.Add(newSensor); // You would normally save to a service or database

            // Navigate back or to another page
            await Shell.Current.GoToAsync("..");
        }
    }
}
