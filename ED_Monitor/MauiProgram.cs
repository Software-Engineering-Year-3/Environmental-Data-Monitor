
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

// to be uncommented when they can properly fit in code 
builder.Services.AddDbContext<ED_MonitorDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSingleton<ED_MonitorViewModel>(); 
builder.Services.AddTransient<ViewModel>();

builder.Services.AddSingleton<AllNotesPage>();
 builder.Services.AddTransient<NotePage>();

#if DEBUG
		builder.Services.AddDbContext();
#endif

		return builder.Build();
	}
}
