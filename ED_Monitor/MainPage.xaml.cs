using ED_Monitor.Pages;

namespace ED_Monitor.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAirQualityClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AirQualityPage());
    }

    private async void OnWaterQualityClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WaterQualityPage());
    }

    private async void OnWeatherClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WeatherPage());
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Log Out", "Return to login screen?", "Yes", "Cancel");
        if (confirm)
        {
            // ✅ Reset Shell to Login
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
      
      private async void OnMapClicked(object sender, EventArgs e)
{
    await DisplayAlert("DEBUG", "Map button clicked", "OK");
    await Shell.Current.GoToAsync(nameof(SensorMapPage));
}

    
}
