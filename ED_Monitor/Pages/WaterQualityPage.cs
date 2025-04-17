using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ED_Monitor.Pages;

public partial class WaterQualityPage : ContentPage
{
    public ObservableCollection<WaterSample> WaterData { get; set; }
    public ICommand RefreshCommand { get; set; }

    public WaterQualityPage()
    {
        InitializeComponent();

        WaterData = new ObservableCollection<WaterSample>
        {
            new WaterSample { Date = DateOnly.FromDateTime(DateTime.Today), PH = 7.2f, EC = 440, Nitrate = 2.1f, Nitrite = 0.4f },
            new WaterSample { Date = DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), PH = 6.0f, EC = 510, Nitrate = 3.2f, Nitrite = 0.6f },
        };

        RefreshCommand = new Command(() => OnRefresh());
        BindingContext = this;
        WaterDataView.ItemsSource = WaterData;
    }

    private async void OnRefresh()
    {
        await Task.Delay(1000); // Simulated refresh
        RefreshControl.IsRefreshing = false;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}

public class WaterSample
{
    public DateOnly Date { get; set; }
    public float PH { get; set; }
    public float EC { get; set; }
    public float Nitrate { get; set; }
    public float Nitrite { get; set; }

    public string PHStatus => PH >= 6.5f && PH <= 8.5f ? $"🟢 pH: {PH} – ✅ Normal" : $"🟠 pH: {PH} – ⚠️ Unusual";
    public string ECStatus => EC > 500 ? $"⚠️ EC: {EC} µS/cm – High Conductivity" : $"✅ EC: {EC} µS/cm – Safe";
    public string NitrateStatus => Nitrate > 3 ? $"🟠 Nitrate: {Nitrate} mg/L – Watch" : $"🟢 Nitrate: {Nitrate} mg/L";
    public string NitriteStatus => Nitrite > 0.5f ? $"🟠 Nitrite: {Nitrite} mg/L – Caution" : $"🟢 Nitrite: {Nitrite} mg/L";

    public Color PHColor => PH >= 6.5f && PH <= 8.5f ? Colors.Green : Colors.OrangeRed;
}
