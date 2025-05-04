namespace ED_Monitor.Models;

public class BackupRecord
{
    // The ID of the backup record.
    public Guid Id { get; set; }
    // The date and time when the backup was created.
    public DateTime CreatedOn { get; set; }
    // The path to the backup file.
    public string FilePath { get; set; } = string.Empty; 
}