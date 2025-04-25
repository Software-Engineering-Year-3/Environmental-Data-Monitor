using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ED_Monitor.Pages;

public partial class WeatherPage : ContentPage
{
    public ObservableCollection<WeatherSample> WeatherData { get; set; }
    public ICommand RefreshCommand { get; set; }

    public WeatherPage()
    {
        InitializeComponent();

        WeatherData = new ObservableCollection<WeatherSample>
        {
            new WeatherSample { Date = DateOnly.FromDateTime(DateTime.Today), Temperature = 24.5f, Humidity = 60, WindSpeed = 18 },
            new WeatherSample { Date = DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), Temperature = 30.1f, Humidity = 72, WindSpeed = 22 },
            new WeatherSample { Date = DateOnly.FromDateTime(DateTime.Today.AddDays(-2)), Temperature = 16.8f, Humidity = 55, WindSpeed = 10 }
        };

        RefreshCommand = new Command(OnRefresh);
        BindingContext = this;
        WeatherDataView.ItemsSource = WeatherData;
    }

    private async void OnRefresh()
    {
        await Task.Delay(1000); // Simulate data refresh
        RefreshControl.IsRefreshing = false;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}

public class WeatherSample
{
    public DateOnly Date { get; set; }
    public float Temperature { get; set; }
    public int Humidity { get; set; }
    public float WindSpeed { get; set; }

    public string TempStatus =>
        Temperature > 30 ? $"🔥 Temp: {Temperature}°C – Hot"
      : Temperature < 15 ? $"❄️ Temp: {Temperature}°C – Cold"
      : $"🌤 Temp: {Temperature}°C – Mild";

    public string HumidityStatus =>
        Humidity > 70 ? $"💧 Humidity: {Humidity}% – High"
      : Humidity < 30 ? $"💨 Humidity: {Humidity}% – Dry"
      : $"✅ Humidity: {Humidity}% – Comfortable";

    public string WindStatus =>
        WindSpeed > 20 ? $"🌬️ Wind: {WindSpeed} km/h – Windy"
      : $"✅ Wind: {WindSpeed} km/h – Calm";

    public Color WindColor => WindSpeed > 20 ? Colors.OrangeRed : Colors.Green;
}
