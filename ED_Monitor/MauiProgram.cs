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
	// builder.Services.AddSingleton<SensorViewModel>();
	// builder.Services.AddTransient<AirQualityViewModel>();
	// builder.Services.AddTransient<WeatherViewModel>();

	// Register Pages
	// builder.Services.AddSingleton<IDataService>();
	builder.Services.AddSingleton<SensorMapPage>();
	builder.Services.AddTransient<WaterQualityPage>();
	builder.Services.AddTransient<WeatherPage>();
	builder.Services.AddTransient<SignUpPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
