using ED_Monitor.ViewModels;
using Microsoft.Maui.Controls;

namespace ED_Monitor.Views;

public partial class ReportPage : ContentPage
{
    public ReportPage(ReportViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}