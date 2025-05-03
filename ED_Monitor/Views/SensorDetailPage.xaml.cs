using ED_Monitor.Models;
using ED_Monitor.ViewModels;

namespace ED_Monitor.Views;

[QueryProperty(nameof(Sensor), "Sensor")]
public partial class SensorDetailPage : ContentPage
{
    public Sensor Sensor
    {
        set => BindingContext = new SensorDetailViewModel(value);
    }

    public SensorDetailPage()
    {
        InitializeComponent();
    }
}
