using ED_Monitor.ViewModels;
using Microsoft.Maui.Storage;

namespace ED_Monitor.Views;

public partial class SensorFirmwareUpdatePage : ContentPage
{
    public SensorFirmwareUpdatePage(SensorFirmwareUpdateViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnPickFileClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Select a configuration or firmware file"
        });

        if (result != null && BindingContext is SensorFirmwareUpdateViewModel vm)
        {
            using var stream = await result.OpenReadAsync();
            vm.SetSelectedFile(result.FileName, stream);
        }
    }
}
