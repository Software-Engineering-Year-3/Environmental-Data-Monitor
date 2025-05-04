using ED_Monitor.Pages;

namespace ED_Monitor;

// AppShell defines the navigation structure via Shell routes
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

    // Register each page with its route so Shell navigation can resolve them
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(AirQualityPage), typeof(AirQualityPage));
        Routing.RegisterRoute(nameof(WaterQualityPage), typeof(WaterQualityPage));
        Routing.RegisterRoute(nameof(WeatherPage), typeof(WeatherPage));
        Routing.RegisterRoute(nameof(SensorDashboardPage), typeof(SensorDashboardPage));
        Routing.RegisterRoute(nameof(SensorMapPage), typeof(SensorMapPage));
        Routing.RegisterRoute(nameof(ReportIssuePage), typeof(ReportIssuePage));
        Routing.RegisterRoute(nameof(UserManagementPage), typeof(UserManagementPage));
    }
}
