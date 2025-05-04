using ED_Monitor.Database;
using ED_Monitor.Models;
using Microsoft.EntityFrameworkCore;

namespace ED_Monitor.Services
{
    /// <summary>
    /// Backup service that stores backups in the file system.
    /// </summary>
    public class FileSystemBackupService : IBackupService
    {
        readonly ED_MonitorDbContext _db;
        readonly string _backupDir;

        public FileSystemBackupService(ED_MonitorDbContext db)
        {
            _db = db;
            // Store backups in AppDataDirectory\Backups
            _backupDir = Path.Combine(FileSystem.AppDataDirectory, "Backups");
            Directory.CreateDirectory(_backupDir);
        }

        public Task<List<BackupRecord>> GetBackupsAsync()
        {
            var records = Directory.GetFiles(_backupDir, "*.sql")
                .Select(fp => new BackupRecord
                {
                    Id       = Guid.NewGuid(),
                    RunOn    = File.GetCreationTimeUtc(fp),
                    FilePath = fp
                })
                .OrderByDescending(r => r.RunOn)
                .ToList();
            return Task.FromResult(records);
        }

        public async Task<BackupRecord> CreateBackupAsync()
        {
            // Generate SQL script of current schema & data
            var script = _db.Database.GenerateCreateScript();

            // Write to file
            var timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
            var filePath  = Path.Combine(_backupDir, $"backup_{timestamp}.sql");
            await File.WriteAllTextAsync(filePath, script);

            return new BackupRecord
            {
                Id       = Guid.NewGuid(),
                RunOn    = DateTime.UtcNow,
                FilePath = filePath
            };
        }

        public async Task RestoreBackupAsync(string filePath)
        {
            // Read script
            var script = await File.ReadAllTextAsync(filePath);

            // 2) Execute against the Azure SQL DB
            var conn = _db.Database.GetDbConnection();
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = script;
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
