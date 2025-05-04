using Microsoft.Maui.Controls;
using ED_Monitor.Data;
using ED_Monitor.Pages;

namespace ED_Monitor.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        // Fired when user taps "Login"
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // grab and normalize inputs
            string email    = (EmailEntry.Text ?? "").Trim().ToLower();
            string password = PasswordEntry.Text ?? "";

            // try to find a matching user
            if (MockUserStore.Users.TryGetValue(email, out var user))
            {
                if (user.Password == password)
                {
                    // store session info
                    UserSession.Name  = user.Name;
                    UserSession.Email = user.Email;
                    UserSession.Role  = user.Role;

                    await DisplayAlert("Success", $"Welcome {user.Name}", "OK");

                    // jump to the main page
                    await Shell.Current.GoToAsync("//MainPage");
                    return;
                }
                else
                {
                    // wrong password
                    await DisplayAlert("Password Error", "Incorrect password.", "OK");
                }
            }
            else
            {
                // no such user
                await DisplayAlert("Login Failed", "User not found.", "OK");
            }
        }

        // Fired when user taps "Sign Up"
        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            // navigate to the SignUpPage
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }
    }
}
