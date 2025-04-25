using System;
using ED_Monitor.Data;
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

            // Simulate storing user (use real DB or file later)
            MockUserStore.Users[email] = new MockUser
            {
                Name = name,
                Email = email,
                Password = password,
                Role = role
            };
            
            // Save to device
            MockUserStore.SaveUsers();

           await DisplayAlert("Saved", $"Users stored: {MockUserStore.Users.Count}", "OK");

            // Navigate back to LoginPage via Shell
            await Shell.Current.GoToAsync(".."); // Return to login
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); // Return to login
    }
}
