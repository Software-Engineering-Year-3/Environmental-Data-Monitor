using System.Reflection;
using System.Text.Json;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls;
using ED_Monitor.Models;

namespace ED_Monitor.Pages;

public partial class SensorMapPage : ContentPage
{
    public SensorMapPage()
    {
        InitializeComponent();
        LoadSensors();
    }

    private async void LoadSensors()
    {
        try
        {
            var assembly = Assembly.GetExecutingAssembly();

            // See available embedded resources for debug
            var resources = assembly.GetManifestResourceNames();
            string jsonFileName = resources.FirstOrDefault(r => r.EndsWith("Mock_Sensors_Metadata.json"));

            if (string.IsNullOrEmpty(jsonFileName))
            {
                await DisplayAlert("Error", "Mock_Sensors_Metadata.json not found in resources.", "OK");
                return;
            }

            using Stream stream = assembly.GetManifestResourceStream(jsonFileName);
            using var reader = new StreamReader(stream);
            string json = await reader.ReadToEndAsync();

            var sensors = JsonSerializer.Deserialize<List<Sensor>>(json);

            if (sensors == null || sensors.Count == 0)
            {
                await DisplayAlert("Info", "No sensors found in JSON.", "OK");
                return;
            }

            foreach (var sensor in sensors)
            {
                var pin = new Pin
                {
                    Location = new Location(sensor.Latitude, sensor.Longitude),
                    Label = sensor.Name,
                    Address = $"{sensor.Type} - {sensor.Status}"
                };

                SensorMap.Pins.Add(pin);
            }

            var first = sensors.First();
            SensorMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Location(first.Latitude, first.Longitude),
                Distance.FromKilometers(2)
            ));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Exception", ex.ToString(), "OK");
        }
    }
}