using ED_Monitor.Models;

namespace ED_Monitor.Services
{
    public interface IBackupService
    {
        /// <summary>
        /// Creates a backup of the database and returns a record of the backup.
        /// </summary>
        Task<BackupRecord> CreateBackupAsync();

        /// <summary>
        /// Restores the database from the given backup file.
        /// </summary>
        Task RestoreBackupAsync(string filePath);

        /// <summary>
        /// Retrieves a list of backup records.
        /// </summary>
        Task<List<BackupRecord>> GetBackupsAsync();
    }
}