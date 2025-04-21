using Microsoft.Maui.Controls;
using ED_Monitor.Pages; 

namespace ED_Monitor.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = (EmailEntry.Text ?? "").Trim().ToLower();
        string password = PasswordEntry.Text ?? "";

        if (email == "scientist@demo.com" && password == "1234")
        {
          
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid email or password.", "OK");
        }
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        // Shell-based navigation
        await Shell.Current.GoToAsync(nameof(SignUpPage));

       
    }
}
