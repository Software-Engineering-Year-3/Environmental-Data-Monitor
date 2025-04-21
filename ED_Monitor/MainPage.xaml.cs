using ED_Monitor.Pages;

namespace ED_Monitor;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAirQualityClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AirQualityPage));
    }

    private async void OnWaterQualityClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(WaterQualityPage));
    }

    private async void OnWeatherClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(WeatherPage));
    }
}
