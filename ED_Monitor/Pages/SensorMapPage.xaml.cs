using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System;
using System.Linq;
using ED_Monitor.Data.Services;

namespace ED_Monitor.Pages
{
    [QueryProperty(nameof(Latitude), "latitude")]
    [QueryProperty(nameof(Longitude), "longitude")]
    [QueryProperty(nameof(SensorName), "name")]
    public partial class SensorMapPage : ContentPage
    {
        // bound when you navigate with ?latitude=…&longitude=…&name=…
        public double Latitude  { get; set; }
        public double Longitude { get; set; }
        public string SensorName { get; set; } = "";

        public SensorMapPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // reload in-memory list
            SensorService.LoadMockSensors();

            SensorMap.Pins.Clear();

            if (!string.IsNullOrWhiteSpace(SensorName))
            {
                // single-sensor mode
                SensorMap.Pins.Add(new Pin {
                    Label    = SensorName,
                    Address  = "",
                    Location = new Location(Latitude, Longitude)
                });
                SensorMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Location(Latitude, Longitude),
                    Distance.FromKilometers(2)
                ));
            }
            else
            {
                // all-sensors mode
                foreach (var sensor in SensorService.Sensors)
                {
                    SensorMap.Pins.Add(new Pin {
                        Label    = sensor.Name,
                        Address  = $"{sensor.Type} – {sensor.Status}",
                        Location = new Location(sensor.Latitude, sensor.Longitude)
                    });
                }
                var first = SensorService.Sensors.FirstOrDefault();
                if (first != null)
                {
                    SensorMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Location(first.Latitude, first.Longitude),
                        Distance.FromKilometers(2)
                    ));
                }
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
            => await Shell.Current.GoToAsync("..");
    }
}
