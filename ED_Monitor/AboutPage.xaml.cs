using Microsoft.Maui.Controls;
namespace ED_Monitor;

// AboutPage shows basic info and links to documentation
public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

  // When the user taps "Learn more...", open the MAUI docs in the browser
	private async void LearnMore_Clicked(object sender, EventArgs e)
	{
        // Launch the default system browser to the .NET MAUI home page
    await Launcher.Default.OpenAsync("https://aka.ms/maui");
	}

}