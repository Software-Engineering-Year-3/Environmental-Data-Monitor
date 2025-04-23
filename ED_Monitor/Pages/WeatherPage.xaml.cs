using System.Collections.ObjectModel;
using System.Windows.Input;
using ED_Monitor.ViewModels;

namespace ED_Monitor.Pages;

public partial class WeatherPage : ContentPage
{
    private readonly WeatherViewModel vm;

    public WeatherPage(WeatherViewModel viewModel)
    {
        InitializeComponent();

        vm = viewModel;
        BindingContext = vm;

        this.Loaded += (_, __) => vm.LoadDataCommand.Execute(null);
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
