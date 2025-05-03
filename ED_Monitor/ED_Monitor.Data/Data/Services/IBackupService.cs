using ED_Monitor.Models;

namespace ED_Monitor.Services
{
    public interface IBackupService
    {
        /// <summary>
        /// Creates a backup, returns a record you can store or show in UI.
        /// </summary>
        Task<BackupRecord> CreateBackupAsync();

        /// <summary>
        /// Restores the database from the given backup file.
        /// </summary>
        Task RestoreBackupAsync(string filePath);

        /// <summary>
        /// Returns all past backups (e.g. by scanning a folder or DB table).
        /// </summary>
        Task<List<BackupRecord>> GetBackupsAsync();
    }
}