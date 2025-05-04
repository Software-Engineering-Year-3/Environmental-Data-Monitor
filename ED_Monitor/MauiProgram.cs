using Microsoft.Extensions.Logging;
using ED_Monitor.Data;


namespace ED_Monitor.Pages;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>();
			builder.UseMauiMaps()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


	// sbuilder.Services.AddDatabaseService();

// to be uncommented when they can properly fit in code 
	// builder.Services.AddDbContext<DatabaseService>(options => options.UseSqlServer(connectionString));
	// builder.Services.AddDbContext<DatabaseService>(options => options.UseSqlServer(connectionString));

	// Register ViewModels
	builder.Services.AddSingleton<SensorViewModel>();
    builder.Services.AddTransient<AirQualityViewModel>();
	builder.Services.AddTransient<WaterQualityViewModel>();
	builder.Services.AddTransient<WeatherViewModel>();
	builder.Services.AddTransient<UserViewModel>();
	builder.Services.AddTransient<ReportViewModel>();
	builder.Services.AddTransient<MaintenanceViewModel>();
	
	// Register Services
	builder.Services.AddScoped<ITrendDataService, TrendDataService>();
	builder.Services.AddScoped<IReportPdfGenerator, ReportPdfGenerator>();
	builder.Services.AddSingleton<IMaintenanceService, InMemoryMaintenanceService>();
	builder.Services.AddTransient<MaintenanceViewModel>();
	builder.Services.AddSingleton<IMaintenanceService, InMemoryMaintenanceService>();
    builder.Services.AddSingleton<INotificationService, LocalNotificationService>();
	

	// Register Pages
	builder.Services.AddSingleton<IDataService>();
	builder.Services.AddSingleton<SensorMapPage>();
	builder.Services.AddTransient<WaterQualityPage>();
	builder.Services.AddTransient<WeatherPage>();
	builder.Services.AddTransient<ReportPage>();
	builder.Services.AddTransient<MaintenancePage>();
	builder.Services.AddTransient<SignUpPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
