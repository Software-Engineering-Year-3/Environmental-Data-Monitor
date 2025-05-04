using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ED_Monitor.ViewModels
{
    public class WeatherViewModel : ObservableObject
    {

        // Collection bound to the UI, holds weather readings
        public ObservableCollection<WeatherSample> Items { get; } = new();

        bool _isBusy;
        // Indicates whether data is currently being loaded
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public WeatherViewModel() { }

       // Asynchronously loads weather data.
       // Uses a delay to mimic fetching from an external source.
        public async Task LoadAsync()
        {
            if (IsBusy) return;   // prevent concurrent loads
            IsBusy = true;
            try
            {
                // simulate data fetch
                await Task.Delay(500);

                // Clear out any old entries
                Items.Clear();

                // Add sample data for today and the two previous days
                // real weather readings from 2025-02-01T00:00 to 2025-02-01T04:00
                Items.Add(new WeatherSample { Date = DateOnly.Parse("2025-02-01"), Temperature = 0.6f,  Humidity = 98, WindSpeed = 1.18f });
                Items.Add(new WeatherSample { Date = DateOnly.Parse("2025-02-01"), Temperature = 2.4f,  Humidity = 96, WindSpeed = 0.93f });
                Items.Add(new WeatherSample { Date = DateOnly.Parse("2025-02-01"), Temperature = 2.5f,  Humidity = 97, WindSpeed = 1.08f });
                Items.Add(new WeatherSample { Date = DateOnly.Parse("2025-02-01"), Temperature = 2.4f,  Humidity = 97, WindSpeed = 1.53f });
                Items.Add(new WeatherSample { Date = DateOnly.Parse("2025-02-01"), Temperature = 1.9f,  Humidity = 96, WindSpeed = 2.15f });

                Items.Add(new WeatherSample { Date = DateOnly.FromDateTime(DateTime.Today), Temperature = 24.5f, Humidity = 60, WindSpeed = 18 });
                Items.Add(new WeatherSample { Date = DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), Temperature = 30.1f, Humidity = 72, WindSpeed = 22 });
                Items.Add(new WeatherSample { Date = DateOnly.FromDateTime(DateTime.Today.AddDays(-2)), Temperature = 16.8f, Humidity = 55, WindSpeed = 10 });
            }
            finally
            {
                 // Always reset the busy flag so the UI stops showing a spinner

                IsBusy = false;
            }
        }


    // Simple model representing one weather reading
        public class WeatherSample
        {
            public DateOnly Date       { get; set; }
            public float    Temperature { get; set; }
            public int      Humidity    { get; set; }
            public float    WindSpeed   { get; set; }


         // Returns a descriptive string for temperature
            public string TempStatus =>
                Temperature > 30 ? $" Temp: {Temperature}°C – Hot"
              : Temperature < 15 ? $" Temp: {Temperature}°C – Cold"
              : $"Temp: {Temperature}°C – Mild";

        // Returns a descriptive string for humidity
            public string HumidityStatus =>
                Humidity > 70 ? $" Humidity: {Humidity}% – High"
              : Humidity < 30 ? $" Humidity: {Humidity}% – Dry"
              : $"Humidity: {Humidity}% – Comfortable";

          // Returns a descriptive string for wind conditions
            public string WindStatus =>
                WindSpeed > 20 ? $"Wind: {WindSpeed} km/h – Windy"
              : $" Wind: {WindSpeed} km/h – Calm";
        }
    }
}
