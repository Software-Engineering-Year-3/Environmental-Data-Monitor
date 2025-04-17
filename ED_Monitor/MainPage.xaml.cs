using System.Collections.ObjectModel;
using ED_Monitor.Data.Models;
using ED_Monitor.Data.Services;
namespace ED_Monitor;



public partial class MainPage : ContentPage
{
    private readonly DatabaseService _dbService = new DatabaseService();
    public ObservableCollection<AirQualityData> AirData { get; set; }

    public MainPage()
    {
        InitializeComponent();
        AirData = new ObservableCollection<AirQualityData>();
        DataView.ItemsSource = AirData;
    }

    private async void OnLoadDataClicked(object sender, EventArgs e)
    {
        var data = await _dbService.GetAirQualityDataAsync();
        AirData.Clear();
        foreach (var item in data)
        {
            AirData.Add(item);
        }
    }
}
