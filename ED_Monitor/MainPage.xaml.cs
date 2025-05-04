using ED_Monitor.Data;
using ED_Monitor.Pages;
using Microsoft.Maui.Controls;

namespace ED_Monitor.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Hide or show buttons based on the user's role as soon as the page is created
            ConfigureButtonsBasedOnRole();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Re-check visibility every time the page reappears (in case role has changed)
            ConfigureButtonsBasedOnRole();
        }

        
        // Shows or hides the Report Issue and User Management buttons
        // depending on whether the user is a manager or admin.
        
        private void ConfigureButtonsBasedOnRole()
        {
            var role = UserSession.Role?.ToLowerInvariant() ?? "";

            // managers and admins can submit issues
            ReportIssueButton.IsVisible    = role == "manager" || role == "admin";
            // only admins can manage users
            UserManagementButton.IsVisible = role == "admin";
        }

        // Navigate to the Air Quality page when tapped
        private async void OnAirQualityClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new AirQualityPage());

        // Navigate to the Water Quality page using Shell routing
        private async void OnWaterQualityClicked(object sender, EventArgs e)
             => await Shell.Current.GoToAsync(nameof(WaterQualityPage));

        // Navigate to the Weather page when tapped
        private async void OnWeatherClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new WeatherPage());

        // Navigate to the Map page when tapped
        private async void OnMapClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new SensorMapPage());

        // Navigate to the Report Issue page when tapped
        private async void OnReportIssueClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new ReportIssuePage());

        // Navigate to the User Management page when tapped
        private async void OnUserManagementClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new UserManagementPage());

        // Navigate to the Sensor Dashboard page when tapped
        private async void OnSensorDashboardClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new SensorDashboardPage());

        // Ask for confirmation, then log out and go back to the login screen
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            var confirm = await DisplayAlert(
                "Log Out",
                "Return to login screen?",
                "Yes",
                "Cancel");

            if (confirm)
            {
                // Clear user session so they have to log in again
                UserSession.Name = "";
                UserSession.Email = "";
                UserSession.Role = "";

                // Use an absolute route to go back to the login page
                await Shell.Current.GoToAsync("//LoginPage");
            }
        }
    }
}
