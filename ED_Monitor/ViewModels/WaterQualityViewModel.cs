using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Data;
using ED_Monitor.Data.Services;
using ED_Monitor.Data.Models;
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
            WaterReadings = new ObservableCollection<WaterQualityData>();
        }

        [ObservableProperty]
        ObservableCollection<WaterQualityData> waterReadings;

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
                    WaterReadings.Add((WaterQualityData)item);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}