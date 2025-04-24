using Newtonsoft.Json;
using Microsoft.Maui.Storage;

namespace ED_Monitor.Data
{
    public static class MockUserStore
    {
        public static Dictionary<string, MockUser> Users { get; private set; } = new();

        public static void SaveUsers()
        {
            var json = JsonConvert.SerializeObject(Users);
            Preferences.Set("SavedUsers", json);
        }

        public static void LoadUsers()
        {
            var json = Preferences.Get("SavedUsers", "");
            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    Users = JsonConvert.DeserializeObject<Dictionary<string, MockUser>>(json) ?? new();
                }
                catch
                {
                    Users = new(); // fallback in case of error
                }
            }
        }
    }

    public class MockUser
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "";
    }
}
