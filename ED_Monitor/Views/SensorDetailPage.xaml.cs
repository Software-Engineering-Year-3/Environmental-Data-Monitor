using ED_Monitor.Core.Models;
using ED_Monitor.Core.ViewModels;

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
