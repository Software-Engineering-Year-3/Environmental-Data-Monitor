using Android.App;
using Android.Runtime;

namespace ED_Monitor;

// Marks this class as the Android application entry point
[Application]
public class MainApplication : MauiApplication
{


    // Called by the Android runtime to create the application instance
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}


    // Hook up our MauiProgram to build the MAUI app when the Android app starts
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
