using System.Collections.ObjectModel;
using System.Windows.Input;
using ED_Monitor.Data.Models;
using ED_Monitor.ViewModels;

namespace ED_Monitor.Pages;

public partial class AirQualityPage : ContentPage
{
    public ObservableCollection<AirQualitySample> AirData { get; set; }
    public ICommand RefreshCommand { get; set; }

    public AirQualityPage()
    {
        BindingContext = this;
        InitializeComponent();

        AirData = new ObservableCollection<AirQualitySample>
        {
            new AirQualitySample { Date = DateOnly.FromDateTime(DateTime.Today), NO2 = 45, SO2 = 4, PM25 = 10, PM10 = 58 },
            new AirQualitySample { Date = DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), NO2 = 28, SO2 = 2.5f, PM25 = 7, PM10 = 32 },
        };

        RefreshCommand = new Command(() => OnRefresh());
        AirDataView.ItemsSource = AirData;
    }

    private async void OnRefresh()
    {
        await Task.Delay(1000);
        RefreshControl.IsRefreshing = false;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); // navigate back
    }
}

public class AirQualitySample
{
    public DateOnly Date { get; set; }
    public float NO2 { get; set; }
    public float SO2 { get; set; }
    public float PM25 { get; set; }
    public float PM10 { get; set; }

    public string NO2Emoji => NO2 > 40 ? $"🟠 NO₂: {NO2} µg/m³ – ⚠️ High" : $"🟢 NO₂: {NO2} µg/m³ – ✅ Safe";
    public string SO2Emoji => SO2 > 20 ? $"🟠 SO₂: {SO2} µg/m³ – ⚠️ Elevated" : $"🟢 SO₂: {SO2} µg/m³ – ✅ Normal";
    public string PM25Emoji => PM25 > 25 ? $"🟠 PM2.5: {PM25} – ⚠️ High" : $"🟢 PM2.5: {PM25} – ✅ Low";
    public string PM10Emoji => PM10 > 50 ? $"🟠 PM10: {PM10} – ⚠️ Moderate" : $"🟢 PM10: {PM10} – ✅ Low";

    public Color NO2Color => NO2 > 40 ? Colors.OrangeRed : Colors.Green;
    public Color SO2Color => SO2 > 20 ? Colors.Orange : Colors.Green;
    public Color PM25Color => PM25 > 25 ? Colors.Orange : Colors.Green;
    public Color PM10Color => PM10 > 50 ? Colors.Orange : Colors.Green;
}
