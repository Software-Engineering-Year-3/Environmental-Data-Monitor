
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ED_Monitor.ViewModels
{
    public class WaterQualityViewModel : ObservableObject
    {

        // Collection bound to the UI for displaying water quality samples
       public ObservableCollection<WaterSample> Items { get; } = new();

        bool _isBusy;
    
        // Indicates if a load operation is in progress (drives the RefreshView)

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public WaterQualityViewModel() { }


     // Loads water quality data asynchronously.
    // Uses a small delay to simulate network or file access.
        public async Task LoadAsync()
        {
            // Prevent overlapping calls
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                // Simulate a data fetch
                await Task.Delay(500);

                // Clear out old data
                Items.Clear();

                 // Populate with example readings
               Items.Add(new WaterSample { Date = DateOnly.Parse("2025-02-01"), SiteName = "Glencorse B", Nitrate = 26.33f, Nitrite = 1.33f, Phosphate = 0.07f, EC = 0f });
               Items.Add(new WaterSample { Date = DateOnly.Parse("2025-02-01"), SiteName = "Glencorse B", Nitrate = 23.40f, Nitrite = 1.52f, Phosphate = 0.06f, EC = 0f });
               Items.Add(new WaterSample { Date = DateOnly.Parse("2025-02-01"), SiteName = "Glencorse B", Nitrate = 28.90f, Nitrite = 1.32f, Phosphate = 0.05f, EC = 0f });
               Items.Add(new WaterSample { Date = DateOnly.Parse("2025-02-01"), SiteName = "Glencorse B", Nitrate = 22.54f, Nitrite = 1.41f, Phosphate = 0.05f, EC = 0f });
               Items.Add(new WaterSample { Date = DateOnly.Parse("2025-02-01"), SiteName = "Glencorse B", Nitrate = 29.36f, Nitrite = 1.61f, Phosphate = 0.02f, EC = 0f });
    }
            finally
            {

                // Always clear the busy flag so UI can stop the spinner
                IsBusy = false;
            }
        }

        // Simple data model for a single water quality reading.

        public class WaterSample
        {
            public DateOnly Date      { get; set; }
            public string   SiteName  { get; set; } = "";
            public float    Nitrate   { get; set; }
            public float    Nitrite   { get; set; }
            public float    Phosphate { get; set; }
            public float    EC        { get; set; }

            public string NitrateStatus   => $"Nitrate: {Nitrate} mg/L";
            public string NitriteStatus   => $"Nitrite: {Nitrite} mg/L";
            public string PhosphateStatus => $"Phosphate: {Phosphate} mg/L";
            public string ECStatus        => $"EC: {EC} μS/cm";
        }
    }
}