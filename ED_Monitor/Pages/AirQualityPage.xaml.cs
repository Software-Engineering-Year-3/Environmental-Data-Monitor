using ED_Monitor.ViewModels;
using Microsoft.Maui.Controls;

namespace ED_Monitor.Pages
{
    public partial class AirQualityPage : ContentPage
    {
        // Shortcut to the bound ViewModel
        AirQualityViewModel ViewModel => (AirQualityViewModel)BindingContext;

        public AirQualityPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Kick off loading data when the page comes into view
            _ = ViewModel.LoadAsync();
        }
    }
}
