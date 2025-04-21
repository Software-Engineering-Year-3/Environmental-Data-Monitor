using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Java.Sql;

namespace ED_Monitor.Data.Models;

[Table("Users")]
public class Users
{
    public int UserID { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public required Date DateRegistration { get; set; }
}
