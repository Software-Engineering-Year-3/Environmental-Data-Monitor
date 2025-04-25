using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using ED_Monitor.ViewModels;


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
			

var a = Assembly.GetExecutingAssembly();
using var stream = a.GetManifestResourceStream("ED_Monitor.appsettings.json")
    ?? throw new InvalidOperationException("Could not find 'appsettings.json' in resources.");

builder.Configuration.AddConfiguration(new ConfigurationBuilder().AddJsonStream(stream).Build());

var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection");
// to be uncommented when they can properly fit in code 
// builder.Services.AddDbContext<ED_MonitorDbContext>(options => options.UseSqlServer(connectionString));

// builder.Services.AddSingleton<AllNotesViewModel>();
// builder.Services.AddTransient<NoteViewModel>();

// builder.Services.AddSingleton<AllNotesPage>();
// builder.Services.AddTransient<NotePage>();

//Register reporting services (added by Devan)
//builder.Services.AddSingleton<IReportService, ReportService>();
builder.Services.AddTransient<ReportViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
