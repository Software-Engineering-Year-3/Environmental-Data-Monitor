using Microsoft.Maui.Controls;
using ED_Monitor.Data;
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

        if (MockUserStore.Users.TryGetValue(email, out var user))
        {
            if (user.Password == password)
            {
                UserSession.Name = user.Name;
                UserSession.Email = user.Email;
                UserSession.Role = user.Role;

                await DisplayAlert("Success", $"Welcome {user.Name}", "OK");

                // ✅ Use Shell to navigate to MainPage
                await Shell.Current.GoToAsync("//MainPage");
                return;
            }
            else
            {
                await DisplayAlert("Password Error", "Incorrect password.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Login Failed", "User not found.", "OK");
        }
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignUpPage));
    }
}
