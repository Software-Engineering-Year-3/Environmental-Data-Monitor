using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ED_Monitor.Models;
using ED_Monitor.Services;
using System.Collections.ObjectModel;

namespace ED_Monitor.ViewModels
{
    /// <summary>
    /// ViewModel for managing backups.
    /// </summary>
    public partial class BackupViewModel : ObservableObject
    {
        /// <summary>
        /// The backup service used to manage backups.
        /// </summary>
        readonly IBackupService _backupSvc;

        [ObservableProperty]
        ObservableCollection<BackupRecord> backups = new();

        [ObservableProperty]
        bool isBusy;

        // This property is used to indicate whether the ViewModel is currently busy performing an operation.
        public BackupViewModel(IBackupService backupSvc) 
            => _backupSvc = backupSvc;

        [RelayCommand]
        public async Task LoadBackupsAsync()
        {
            // This method loads the list of backups from the backup service.
            if (IsBusy) return;
            IsBusy = true;

            // This method retrieves the list of backups from the backup service.
            var list = await _backupSvc.GetBackupsAsync();
            Backups = new ObservableCollection<BackupRecord>(list);
            IsBusy = false;
        }

        [RelayCommand]
        public async Task CreateBackupAsync()
        {
            // This method creates a new backup using the backup service.
            if (IsBusy) return;
            IsBusy = true;

            // This method creates a new backup and returns the record of the backup.
            var record = await _backupSvc.CreateBackupAsync();
            Backups.Insert(0, record);

            IsBusy = false;
        }

        [RelayCommand]
        public async Task RestoreBackupAsync(BackupRecord record)
        {
            // This method restores a backup using the backup service.
            if (IsBusy) return;
            IsBusy = true;

            await _backupSvc.RestoreBackupAsync(record.FilePath);
            // notify user of success
            IsBusy = false;
        }
    }
}