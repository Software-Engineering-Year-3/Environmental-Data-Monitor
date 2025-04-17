using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.Extensions.Configuration;


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

var a = Assembly.GetExecutingAssembly();
using var stream = a.GetManifestResourceStream("ED_Monitor.appsettings.json");
    
var config = new ConfigurationBuilder()
    .AddJsonStream(stream)
    .Build();
    
builder.Configuration.AddConfiguration(config);

var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection");
// to be uncommented when they can properly fit in code 
// builder.Services.AddDbContext<ED_MonitorDbContext>(options => options.UseSqlServer(connectionString));

// builder.Services.AddSingleton<AllNotesViewModel>();
// builder.Services.AddTransient<NoteViewModel>();

// builder.Services.AddSingleton<AllNotesPage>();
// builder.Services.AddTransient<NotePage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
