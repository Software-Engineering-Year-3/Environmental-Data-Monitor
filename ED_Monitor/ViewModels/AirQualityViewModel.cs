using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Data.Services;
using ED_Monitor.Data.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ED_Monitor.ViewModels
{
    public partial class AirQualityViewModel : BaseViewModel
    {
        readonly DatabaseService db;

        public AirQualityViewModel(DatabaseService databaseService)
        {
            db = databaseService;
            Title = "Air Quality";
            AirReadings = new ObservableCollection<AirQualityData>();
        }

        [ObservableProperty]
        ObservableCollection<AirQualityData> airReadings;

        [RelayCommand]
        async Task LoadDataAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var data = await db.GetAirQualityDataAsync();    // make sure your DatabaseService has this
                AirReadings.Clear();
                foreach (var item in data)
                    AirReadings.Add(item);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
