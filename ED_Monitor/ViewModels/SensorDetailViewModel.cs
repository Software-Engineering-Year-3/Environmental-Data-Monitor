using System.Windows.Input;
using ED_Monitor.Core.Models;
using ED_Monitor.Core.Interfaces;

namespace ED_Monitor.ViewModels;

public class SensorDetailViewModel
{
    private readonly ISensorService _sensorService;

    public Sensor Sensor { get; set; }

    public ICommand SaveCommand { get; }

    public SensorDetailViewModel(Sensor sensor, ISensorService sensorService)
    {
        _sensorService = sensorService;
        Sensor = sensor;
        SaveCommand = new Command(Save);
    }

    private async void Save()
    {
        _sensorService.UpdateSensor(Sensor);
        await Shell.Current.GoToAsync(".."); // Go back
    }
}
