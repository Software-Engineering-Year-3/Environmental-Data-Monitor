using ED_Monitor.ViewModels;
using ED_Monitor.Pages;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace ED_Monitor;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // MAUI & fonts
        builder
            .UseMauiApp<App>()          // hook up App.xaml
            .UseMauiMaps()              // enable built-in map support
            .ConfigureFonts(fonts =>
            {
                // embed OpenSans, use it in XAML
                fonts.AddFont("OpenSans-Regular.ttf",   "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf",  "OpenSansSemibold");
            });

#if DEBUG
        // write logs out over debugger when running in DEBUG
        builder.Logging.AddDebug();
#endif

        // every time someone asks for an AirQualityViewModel, give them a fresh one
        builder.Services.AddTransient<AirQualityViewModel>();
        builder.Services.AddTransient<WaterQualityViewModel>();
        builder.Services.AddTransient<WeatherViewModel>();
        builder.Services.AddTransient<SensorDashboardViewModel>();

        // pages are transient so they get new view-model instances each time
        builder.Services.AddTransient<AirQualityPage>();
        builder.Services.AddTransient<WaterQualityPage>();
        builder.Services.AddTransient<WeatherPage>();
        builder.Services.AddTransient<SensorDashboardPage>();
        builder.Services.AddTransient<SensorMapPage>();
        builder.Services.AddTransient<ReportIssuePage>();
        builder.Services.AddTransient<UserManagementPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<SignUpPage>();
        builder.Services.AddTransient<MainPage>();

        return builder.Build();
    }
}
