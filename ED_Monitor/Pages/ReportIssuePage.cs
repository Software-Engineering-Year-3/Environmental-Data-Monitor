using Microsoft.Maui.Controls;

namespace ED_Monitor.Pages;

public partial class ReportIssuePage : ContentPage
{
    public ReportIssuePage()
    {
        InitializeComponent();
    }

    // Go back to the previous page when “Back” is tapped
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    // Handle the “Submit Report” button
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        // TODO: validate inputs here before proceeding

        // Show confirmation and navigate back
        await DisplayAlert("Success", "Issue reported.", "OK");
        await Shell.Current.GoToAsync("..");
    }
}
