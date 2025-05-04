using ED_Monitor.Data;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace ED_Monitor.Pages
{
    public partial class SignUpPage : ContentPage
    {
        // The roles the user can choose from
        public List<string> RoleOptions { get; } = new() { "Scientist", "Manager", "Admin" };

        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = this; // wire up the picker
        }

        // Called when the user taps "Sign Up"
        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            // grab and normalize inputs
            string name            = (FullNameEntry.Text    ?? "").Trim();
            string email           = (EmailEntry.Text       ?? "").Trim().ToLower();
            string password        =  PasswordEntry.Text    ?? "";
            string confirmPassword =  ConfirmPasswordEntry.Text ?? "";
            string role            =  RolePicker.SelectedItem?.ToString() ?? "";

            // check for any missing fields
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(role))
            {
                await DisplayAlert("Missing Info", "Please fill in all fields.", "OK");
                return;
            }

            // verify passwords match
            if (password != confirmPassword)
            {
                await DisplayAlert("Password Mismatch", "Passwords do not match.", "OK");
                return;
            }

            // store the new user in mock store
            MockUserStore.Users[email] = new MockUser
            {
                Name     = name,
                Email    = email,
                Password = password,
                Role     = role
            };
            MockUserStore.SaveUsers();

            // let them know it worked…
            await DisplayAlert("Success", $"Account created for {name}.", "OK");
            // …and go back to login
            await Shell.Current.GoToAsync("//LoginPage");
        }

        // Called when the user taps "Cancel"
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            // Back one page
            await Shell.Current.GoToAsync("..");
        }
    }
}
