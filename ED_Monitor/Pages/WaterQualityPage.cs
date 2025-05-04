using ED_Monitor.ViewModels;
using Microsoft.Maui.Controls;

namespace ED_Monitor.Pages
{
    public partial class WaterQualityPage : ContentPage
    {

    // Quick access to the bound VM
        WaterQualityViewModel ViewModel => (WaterQualityViewModel)BindingContext;

        public WaterQualityPage()
        {
            InitializeComponent();// Initialize the XAML-defined UI
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Trigger data load when page appears
            _ = ViewModel.LoadAsync();
        }
    }
}
