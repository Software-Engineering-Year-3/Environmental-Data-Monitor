using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace ED_Monitor;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; }

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        Services = serviceProvider;

        MainPage = new AppShell(); // or whatever your main page is
    }
}
