using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ED_Monitor.Models;
using ED_Monitor.Interfaces;
using ED_Monitor.Services;

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

        public SensorViewModel(ISensorService sensorService)
        {
            _sensorService = sensorService;

            LoadSensors();

            AddSensorCommand = new Command(AddSensor);
            RemoveSensorCommand = new Command<Sensor>(RemoveSensor);
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
