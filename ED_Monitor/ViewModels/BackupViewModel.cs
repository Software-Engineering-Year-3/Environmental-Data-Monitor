using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Models;
using ED_Monitor.Services;
using System.Collections.ObjectModel;

namespace ED_Monitor.ViewModels
{
    public partial class BackupViewModel : ObservableObject
    {
        readonly IBackupService _backupSvc;

        [ObservableProperty]
        ObservableCollection<BackupRecord> backups = new();

        [ObservableProperty]
        bool isBusy;

        public BackupViewModel(IBackupService backupSvc) 
            => _backupSvc = backupSvc;

        [RelayCommand]
        public async Task LoadBackupsAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            var list = await _backupSvc.GetBackupsAsync();
            Backups = new ObservableCollection<BackupRecord>(list);
            IsBusy = false;
        }

        [RelayCommand]
        public async Task CreateBackupAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            var record = await _backupSvc.CreateBackupAsync();
            Backups.Insert(0, record);

            IsBusy = false;
        }

        [RelayCommand]
        public async Task RestoreBackupAsync(BackupRecord record)
        {
            if (IsBusy) return;
            IsBusy = true;

            await _backupSvc.RestoreBackupAsync(record.FilePath);
            // optional: notify user of success
            IsBusy = false;
        }
    }
}
