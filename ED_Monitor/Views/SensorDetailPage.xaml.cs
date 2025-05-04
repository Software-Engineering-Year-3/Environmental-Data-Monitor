using ED_Monitor.Core.Models;
using ED_Monitor.ViewModels;
using ED_Monitor.Core.Interfaces;

namespace ED_Monitor.Views;

[QueryProperty(nameof(Sensor), "Sensor")]
public partial class SensorDetailPage : ContentPage
{
    public Sensor Sensor
    {
        set
        {
            var sensorService = App.Services.GetService<ISensorService>();
            BindingContext = new SensorDetailViewModel(value, sensorService);
        }
    }

    public SensorDetailPage()
    {
        InitializeComponent();
    }
}
