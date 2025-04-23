using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using ED_Monitor.ViewModels;
using ED_Monitor.App.Database.Data.Services;
using Microsoft.EntityFrameworkCore;  


namespace ED_Monitor;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // ——— Configuration: prefer AddJsonFile over embedded-stream unless you need encryption
        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        // ——— EF Core DbContext registration
        var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection");
        builder.Services.AddDbContext<ED_MonitorDbContext>(options =>
            options.UseSqlServer(connectionString),
            // In MAUI there’s no "Scoped" lifetime, so DbContext will behave as Transient
            ServiceLifetime.Transient);

        // ——— Wrap your DbContext in a DatabaseService
        builder.Services.AddTransient<DatabaseService>();

        // ——— ViewModels (Transient so each page gets a fresh VM instance)
        builder.Services.AddTransient<AirQualityViewModel>();
        builder.Services.AddTransient<WaterQualityViewModel>();
        builder.Services.AddTransient<WeatherViewModel>();

        #if DEBUG
        builder.Logging.AddDebug();
        #endif

        return builder.Build();
    }
}