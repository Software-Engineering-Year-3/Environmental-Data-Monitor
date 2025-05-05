using Microsoft.Maui.Controls;

namespace ED_Monitor.Views
{
    public partial class BackupPage : ContentPage
    {
        public BackupPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // auto-load on appear
            (BindingContext as ViewModels.BackupViewModel)?
                .LoadBackupsCommand
                .Execute(null);
        }
    }
}
