using Newtonsoft.Json;
using Microsoft.Maui.Storage;

namespace ED_Monitor.Data
{

     // Persists user dictionary to app preferences as JSON
    public static class MockUserStore
    {
        public static Dictionary<string, MockUser> Users { get; private set; } = new();

        // Save the current user list into device storage
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

}
