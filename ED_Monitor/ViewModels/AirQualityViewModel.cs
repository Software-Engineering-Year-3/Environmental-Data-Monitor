using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Data;
using ED_Monitor.Data.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ED_Monitor.Database;
using ED_Monitor.Data.Services;

namespace ED_Monitor.ViewModels
{
    public partial class AirQualityViewModel : BaseViewModel
    {
        readonly DatabaseService db;

        public AirQualityViewModel(DatabaseService databaseService)
        {
            db = databaseService;
            Title = "Air Quality";
            AirReadings = new ObservableCollection<AirMetadata>();
        }

        [ObservableProperty]
        ObservableCollection<AirMetadata> airReadings;

        [RelayCommand]
        async Task LoadDataAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var data = await db.GetAirQualityAsync();   
                AirReadings.Clear();
                foreach (var item in data)
                    AirReadings.Add((AirMetadata)item);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}