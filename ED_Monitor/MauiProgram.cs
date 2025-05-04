using Microsoft.Extensions.Logging;



namespace ED_Monitor;

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


	builder.Services.AddDbContext();

// to be uncommented when they can properly fit in code 
	builder.Services.AddDbContext<ED_MonitorDbContext>(options => options.UseSqlServer(connectionString));
	builder.Services.AddDbContext<ED_MonitorDbContext>(options => options.UseSqlServer(connectionString));

	// Register ViewModels
	builder.Services.AddSingleton<SensorViewModel>();
	builder.Services.AddTransient<WaterQualityViewModel>();
	builder.Services.AddTransient<WeatherViewModel>();
	builder.Services.AddTransient<UserViewModel>();
	builder.Services.AddTransient<ReportViewModel>();
	builder.Services.AddTransient<MaintenanceViewModel>();
	builder.Services.AddScoped<ITrendDataService, TrendDataService>();
	builder.Services.AddScoped<IReportPdfGenerator, ReportPdfGenerator>();
	builder.Services.AddSingleton<IMaintenanceService, InMemoryMaintenanceService>();
	builder.Services.AddTransient<MaintenanceViewModel>();
	

	// Register Pages
	builder.Services.AddSingleton<SensorPage>();
	builder.Services.AddTransient<WaterQualityPage>();
	builder.Services.AddTransient<WeatherPage>();
	builder.Services.AddTransient<UserPage>();
	builder.Services.AddTransient<ReportPage>();
	builder.Services.AddTransient<MaintenancePage>();
	
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
