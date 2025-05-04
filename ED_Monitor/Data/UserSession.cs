namespace ED_Monitor.Data;


// Tracks the currently logged-in user's info in memory
public static class UserSession
{
    public static string Name { get; set; } = "";
    public static string Email { get; set; } = "";
    public static string Role { get; set; } = "";
}
