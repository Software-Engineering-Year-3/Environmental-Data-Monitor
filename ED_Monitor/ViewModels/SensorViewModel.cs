using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ED_Monitor.Core.Models;
using ED_Monitor.Core.Interfaces;
using ED_Monitor.Views;
using ED_Monitor.Core.Services;

namespace ED_Monitor.ViewModels
{
    public class SensorViewModel : INotifyPropertyChanged
    {
        private readonly ISensorService _sensorService;

        public ObservableCollection<Sensor> Sensors { get; set; } = new ObservableCollection<Sensor>();

        private string _newSensorModel;
        public string NewSensorModel
        {
            get => _newSensorModel;
            set => SetProperty(ref _newSensorModel, value);
        }

        private string _newSensorLocation;
        public string NewSensorLocation
        {
            get => _newSensorLocation;
            set => SetProperty(ref _newSensorLocation, value);
        }

        public ICommand AddSensorCommand { get; }
        public ICommand RemoveSensorCommand { get; }

        public ICommand EditSensorCommand { get; }

        public SensorViewModel(ISensorService sensorService)
        {
            _sensorService = sensorService;

            LoadSensors();

            AddSensorCommand = new Command(AddSensor);
            RemoveSensorCommand = new Command<Sensor>(RemoveSensor);
            EditSensorCommand = new Command<Sensor>(async (sensor) => await NavigateToEdit(sensor));
        }

        private void LoadSensors()
        {
            var sensors = _sensorService.GetSensors();
            Sensors.Clear();
            foreach (var sensor in sensors)
                Sensors.Add(sensor);
        }

        private void AddSensor()
        {
            if (string.IsNullOrWhiteSpace(NewSensorModel) || string.IsNullOrWhiteSpace(NewSensorLocation))
                return;

            var newSensor = new Sensor
            {
                Id = Guid.NewGuid(),
                Model = NewSensorModel,
                Location = NewSensorLocation
            };

            _sensorService.AddSensor(newSensor);
            Sensors.Add(newSensor);

            NewSensorModel = string.Empty;
            NewSensorLocation = string.Empty;
        }

        private void RemoveSensor(Sensor sensor)
        {
            _sensorService.RemoveSensor(sensor.Id);
            Sensors.Remove(sensor);
        }

        private async Task NavigateToEdit(Sensor sensor)
{
    if (sensor == null)
        return;

    await Shell.Current.GoToAsync(nameof(SensorDetailPage), true,
        new Dictionary<string, object> { { "Sensor", sensor } });
}

        // === INotifyPropertyChanged Boilerplate ===
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
