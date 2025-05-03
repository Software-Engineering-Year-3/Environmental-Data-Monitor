using Microsoft.Extensions.Logging;
using ED_Monitor.Core.ViewModels;
using ED_Monitor.Services;
using ED_Monitor.Core.Interfaces;
using ED_Monitor.Views;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// ✅ Dependency Injection setup
		builder.Services.AddSingleton<ISensorService, SensorService>();  // Shared service
		builder.Services.AddTransient<SensorViewModel>();               // ViewModel (new per use)
		builder.Services.AddTransient<SensorDetailPage>();
		builder.Services.AddTransient<SensorDetailViewModel>();


		return builder.Build();
	}
}
