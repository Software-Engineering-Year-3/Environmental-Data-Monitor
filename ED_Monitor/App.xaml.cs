using ED_Monitor.Data;

namespace ED_Monitor;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Load users when app starts
        MockUserStore.LoadUsers();

        MainPage = new AppShell();
    }
}
