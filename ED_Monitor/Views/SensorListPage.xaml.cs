using ED_Monitor.ViewModels;

namespace ED_Monitor.Views;

public partial class SensorListPage : ContentPage
{
    public SensorListPage(SensorViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
