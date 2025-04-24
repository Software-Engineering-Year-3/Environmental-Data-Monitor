using System.Reflection;
using System.Text.Json;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls;
using ED_Monitor.Models;

namespace ED_Monitor.Pages;

public partial class SensorMapPage : ContentPage
{
    public SensorMapPage()
    {
        InitializeComponent();
        LoadSensors();
    }

    private async void LoadSensors()
{
    try
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resources = assembly.GetManifestResourceNames();

        await DisplayAlert("DEBUG", "Resources:\n" + string.Join("\n", resources), "OK");
        // Stop here — don't load map until we're sure it's embedded
    }
    catch (Exception ex)
    {
        await DisplayAlert("ERROR", ex.ToString(), "OK");
    }
}

}
