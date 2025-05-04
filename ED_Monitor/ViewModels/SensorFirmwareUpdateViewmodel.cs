using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Core.Interfaces;
using ED_Monitor.Core.Models;

namespace ED_Monitor.ViewModels;

public partial class SensorFirmwareUpdateViewModel : ObservableObject
{
    private readonly ISensorFirmwareService _firmwareService;
    private readonly ISensorService _sensorService;
    private Stream? _selectedFileStream;

    [ObservableProperty]
    private ObservableCollection<Sensor> sensors = new();

    [ObservableProperty] private Sensor? selectedSensor;
    [ObservableProperty] private string selectedFileName = string.Empty;
    [ObservableProperty] private string statusMessage = string.Empty;

    public ICommand UploadCommand { get; }

    public SensorFirmwareUpdateViewModel(ISensorFirmwareService firmwareService, ISensorService sensorService)
    {
        _firmwareService = firmwareService;
        _sensorService = sensorService;
        UploadCommand = new AsyncRelayCommand(UploadFirmwareAsync);
        LoadSensors();
    }

    public void SetSelectedFile(string fileName, Stream stream)
    {
        SelectedFileName = fileName;
        _selectedFileStream = stream;
    }

    private async Task UploadFirmwareAsync()
    {
        if (SelectedSensor == null || _selectedFileStream == null)
        {
            StatusMessage = "Please select a sensor and file.";
            return;
        }

        
        var result = await _firmwareService.UploadFirmwareAsync(SelectedSensor!.Id, _selectedFileStream);
        StatusMessage = result ? "Upload successful." : "Upload failed.";
    }

   private void LoadSensors()
{
    var sensors = _sensorService.GetSensors();
    Sensors = new ObservableCollection<Sensor>(sensors);
}

}
