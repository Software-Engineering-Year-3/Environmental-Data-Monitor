using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Data;
using ED_Monitor.Data.Services;
using ED_Monitor.Data.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ED_Monitor.ViewModels
{
    public partial class WeatherViewModel : BaseViewModel
    {
        private readonly DatabaseService db;

        public WeatherViewModel(DatabaseService databaseService)
        {
            db = databaseService;
            Title = "Weather";
            WeatherReadings = new ObservableCollection<WeatherData>();
        }

        [ObservableProperty]
        ObservableCollection<WeatherData> weatherReadings;

        [RelayCommand]
        async Task LoadDataAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var data = await db.GetWeatherAsync();
                WeatherReadings.Clear();
                foreach (var item in data)
                    WeatherReadings.Add((WeatherData)item);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}