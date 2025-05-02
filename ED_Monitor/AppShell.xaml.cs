using ED_Monitor.Pages; 
namespace ED_Monitor;


public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
                
		Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
	    Routing.RegisterRoute(nameof(AirQualityPage), typeof(AirQualityPage));
        Routing.RegisterRoute(nameof(WaterQualityPage), typeof(WaterQualityPage));
        Routing.RegisterRoute(nameof(WeatherPage), typeof(WeatherPage));
        

	}
}
