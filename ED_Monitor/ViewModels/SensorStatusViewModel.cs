using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using ED_Monitor.Core.Interfaces;
using ED_Monitor.Core.Models;
using ED_Monitor.Core.Services;

namespace ED_Monitor.ViewModels
{
    public class SensorStatusViewModel : INotifyPropertyChanged
    {
        private readonly ISensorStatusService _sensorStatusService;

        public ObservableCollection<SensorStatus> SensorStatuses { get; set; } = new();

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadStatusesCommand { get; }

        public SensorStatusViewModel(ISensorStatusService sensorStatusService)
        {
            _sensorStatusService = sensorStatusService;
            LoadStatusesCommand = new Command(async () => await LoadStatusesAsync());
        }

        private async Task LoadStatusesAsync()
        {
            if (IsLoading) return;

            IsLoading = true;

            var statuses = await _sensorStatusService.GetAllStatusesAsync();

            SensorStatuses.Clear();
            foreach (var status in statuses)
            {
                SensorStatuses.Add(status);
            }

            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
