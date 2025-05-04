using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ED_Monitor;


// This attribute configures how Android launches and manages main activity
[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,                    // This is the entry point of the app
    LaunchMode = LaunchMode.SingleTop,      // Reuse the activity if it’s already at the top
    ConfigurationChanges = ConfigChanges.ScreenSize
                       | ConfigChanges.Orientation
                       | ConfigChanges.UiMode
                       | ConfigChanges.ScreenLayout
                       | ConfigChanges.SmallestScreenSize
                       | ConfigChanges.Density)]            // Handle these config changes without restarting
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        // In .NET MAUI 9.0+ the maps and other platform services auto-initialize,
        // so no manual setup is needed here.    
    }
}
