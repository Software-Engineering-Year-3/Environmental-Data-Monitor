using ED_Monitor.ViewModels;
using Microsoft.Maui.Controls;

namespace ED_Monitor.Pages;

public partial class WeatherPage : ContentPage
{

    // Cast BindingContext once for easy access
    WeatherViewModel ViewModel => (WeatherViewModel)BindingContext;

    public WeatherPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Kick off data load when the page appears
        _ = ViewModel.LoadAsync();
    }
}
