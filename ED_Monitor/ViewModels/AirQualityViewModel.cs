using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ED_Monitor.Data.Models;
using Microsoft.Maui.Storage;

namespace ED_Monitor.ViewModels
{
    public class AirQualityViewModel : INotifyPropertyChanged
    {

        // Collection that the UI binds to for displaying measurements
        public ObservableCollection<AirQualityData> Measurements { get; }
            = new ObservableCollection<AirQualityData>();

        bool _isLoading;

         // Indicates whether data is currently being loaded (drives the activity indicator)

        public bool IsLoading
        {
            get => _isLoading;
            private set { _isLoading = value; OnPropertyChanged(); }
        }

        // A simple set of fallback readings if the CSV load fails or is empty
        static readonly AirQualityData[] _mock = {
           new() { StationID = 0, Date = "2025-02-01", Time = "01:00:00", NO2 = 26.3925f, SO2 = 1.59654f, PM25 = 5.094f,  PM10 = 8.3f  },
           new() { StationID = 0, Date = "2025-02-01", Time = "02:00:00", NO2 = 22.5675f, SO2 = 1.33045f, PM25 = 5.094f,  PM10 = 7.9f  },
           new() { StationID = 0, Date = "2025-02-01", Time = "03:00:00", NO2 = 14.5350f, SO2 = 1.46350f, PM25 = 5.755f,  PM10 = 8.5f  },
           new() { StationID = 0, Date = "2025-02-01", Time = "04:00:00", NO2 = 17.9775f, SO2 = 1.33045f, PM25 = 5.943f,  PM10 = 9.9f  },
           new() { StationID = 0, Date = "2025-02-01", Time = "05:00:00", NO2 = 12.2400f, SO2 = 1.33045f, PM25 = 6.132f,  PM10 = 10.7f },
    };


// Public method to load data. Will populate Measurements, show loading state,
        // and fall back to mock data on error or empty CSV.
        public async Task LoadAsync()
        {
            if (IsLoading) return;
            IsLoading = true;
            try
            {
                // Try reading real data from the bundled CSV
                var list = await LoadFromCsvAsync();

                // If CSV was empty, use mock data instead
                if (list.Count == 0) list.AddRange(_mock);

                // Refresh the bound collection
                Measurements.Clear();
                foreach (var x in list) Measurements.Add(x);
            }
            catch
            {
              // If anything goes wrong, show the mock readings                Measurements.Clear();
                foreach (var x in _mock) Measurements.Add(x);
            }
            finally { IsLoading = false; }
        }



// Reads and parses the AirQualityData.csv file from the app bundle.
        //Returns a list of parsed records.
        async Task<List<AirQualityData>> LoadFromCsvAsync()
        {
            var result = new List<AirQualityData>();
          
            // Open the CSV that's been bundled as a MauiAsset
            using var stream = await FileSystem.OpenAppPackageFileAsync("AirQualityData.csv");
            using var reader = new StreamReader(stream);

            // Skip over the header line
            await reader.ReadLineAsync();
 
           // Read each subsequent line and parse columns
            while (!reader.EndOfStream)
            {
                var line = (await reader.ReadLineAsync())?.Trim();
                if (string.IsNullOrEmpty(line)) continue;
                var parts = line.Split(',');
                if (parts.Length < 7) continue;

                if (!int.TryParse(parts[0], out var id)) continue;
                var date = parts[1];
                var time = parts[2];

                // Parse numeric fields (defaults to 0 on failure)
                float.TryParse(parts[3], out var no2);
                float.TryParse(parts[4], out var so2);
                float.TryParse(parts[5], out var pm25);
                float.TryParse(parts[6], out var pm10);

                result.Add(new AirQualityData {
                    StationID = id,
                    Date      = date,
                    Time      = time,
                    NO2       = no2,
                    SO2       = so2,
                    PM25      = pm25,
                    PM10      = pm10
                });
            }

            return result;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
