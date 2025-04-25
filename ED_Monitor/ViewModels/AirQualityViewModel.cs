using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
// using ED_Monitor.App.Database.Data.Services;
// using ED_Monitor.App.Database.Data.Models;
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
            AirReadings = new ObservableCollection<Air_quality>();
        }

        [ObservableProperty]
        ObservableCollection<Air_quality> airReadings;

        [RelayCommand]
        async Task LoadDataAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var data = await db.GetAirQualityAsync();    // make sure your DatabaseService has this
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