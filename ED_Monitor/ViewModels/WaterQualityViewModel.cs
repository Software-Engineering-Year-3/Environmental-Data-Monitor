using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Database.Data;
using ED_Monitor.Database.Data.Services;
using ED_Monitor.Database.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ED_Monitor.ViewModels
{
    public partial class WaterQualityViewModel : BaseViewModel
    {
        private readonly DatabaseService db;

        public WaterQualityViewModel(DatabaseService databaseService)
        {
            db = databaseService;
            Title = "Water Quality";
            WaterReadings = new ObservableCollection<Water_quality>();
        }

        [ObservableProperty]
        ObservableCollection<Water_quality> waterReadings;

        [RelayCommand]
        async Task LoadDataAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var data = await db.GetWaterQualityAsync();
                WaterReadings.Clear();
                foreach (var item in data)
                    WaterReadings.Add(item);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}