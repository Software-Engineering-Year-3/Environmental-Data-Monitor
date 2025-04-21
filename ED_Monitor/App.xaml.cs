using ED_Monitor.Pages;

namespace ED_Monitor;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new SignUpPage();
		//This is done by Abdullah for getting signup page, may can be change in future! 
    }
}
