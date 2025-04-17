using Microsoft.UI.Xaml;

namespace ED_Monitor.WinUI;

public partial class App : MauiWinUIApplication
{
    public App()
    {
        // DO NOT set MainPage here!
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
