using System;

namespace ED_Monitor.Pages;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        try
        {
            string name = (FullNameEntry.Text ?? "").Trim();
            string email = (EmailEntry.Text ?? "").Trim().ToLower();
            string password = PasswordEntry.Text ?? "";
            string confirmPassword = ConfirmPasswordEntry.Text ?? "";
            string role = RolePicker.SelectedItem?.ToString() ?? "";

            // Quick sanity check
            await DisplayAlert("Test", "Sign Up Clicked!", "OK");

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(role))
            {
                await DisplayAlert("Missing Info", "Please fill in all fields.", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Password Mismatch", "Passwords do not match.", "OK");
                return;
            }

            await DisplayAlert("Success", $"Account created for {name} as {role}.", "OK");

            // Safe navigation back to login page
            Application.Current.MainPage = new LoginPage(); // or Login Shell route
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Cancelled", "Returning to login.", "OK");
        Application.Current.MainPage = new LoginPage();
    }
}
