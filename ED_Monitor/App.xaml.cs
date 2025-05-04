using ED_Monitor.Data.Services;

namespace ED_Monitor;

// App is the entry point for our MAUI application
public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        // Pre-load in-memory sensor list so it's ready when pages need it
        SensorService.LoadMockSensors();

        // Set the root page of the app to our Shell-based navigation structure
        MainPage = new AppShell();
    }
}
