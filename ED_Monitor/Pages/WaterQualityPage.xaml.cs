using System.Collections.ObjectModel;
using System.Windows.Input;
using ED_Monitor.ViewModels;

namespace ED_Monitor.Pages;

public partial class WaterQualityPage : ContentPage
{
    private readonly WaterQualityViewModel vm;

    public WaterQualityPage(WaterQualityViewModel viewModel)
    {
        InitializeComponent();

        vm = viewModel;            // store injected VM
        BindingContext = vm;        // bind page to VM

        // load initial data when page appears
        this.Loaded += async (_, __) => await vm.LoadDataCommand.ExecuteAsync(null);
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
