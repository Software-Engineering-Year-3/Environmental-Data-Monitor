using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ED_Monitor.AppDatabase.Data;
// using ED_Monitor.AppDatabase.Data.Models;
namespace ED_Monitor.AppDatabase.Data;

[Table("Users")]
public class Users
{
    public int UserID { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    // public required string Role { get; set; }
    public required DateTime DateRegistration { get; set; }
}
