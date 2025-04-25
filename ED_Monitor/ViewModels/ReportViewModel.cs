using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Maui;
using Microsoft.Maui.Storage;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using ED_Monitor.Models;
using ED_Monitor.Services;

namespace ED_Monitor.ViewModels
{
    /// <summary>
    /// ViewModel for generating and exporting environmental trend reports
    /// </summary>
    public partial class ReportViewModel : ObservableObject
    {
        private readonly IReportService _reportService;

        /// <summary>
        /// Collection of chart series to be displayed in the report
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<ISeries> chartSeries = new();

        /// <summary>
        /// Indicates whether the report generation is in progress
        /// </summary>
        [ObservableProperty]
        private bool isBusy;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportViewModel"/> class.
        /// </summary>
        /// <param name="reportService"></param>
        public ReportViewModel(IReportService reportService)
        {
            _reportService = reportService;
        }
        /// <summary>
        /// Generates a report by fetching trend data and populating the chart series
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task GenerateReportAsync()
        {
            if (IsBusy) 
            {
                // If a report is already being generated, do not proceed
                return;
            }
        
            try
            {
                IsBusy = true;
                var data = await _reportService.FetchTrendDataAsync(TimeSpan.FromDays(30));

                ChartSeries.Clear();
                ChartSeries.Add(new LineSeries<double>
                {
                    Name = "Air Quality",
                    Values = data.AirQualityLevels
                });
                ChartSeries.Add(new LineSeries<double>
                {
                    Name = "Water pH",
                    Values = data.WaterPhLevels
                });
                ChartSeries.Add(new LineSeries<double>
                {
                    Name = "Temperature",
                    Values = data.Temperatures
                });
            }
            catch (Exception ex)
            {
                // Handle exception and shows an error message to the user
                Console.WriteLine($"Error generating report: {ex.Message}");
            }
            finally 
            { 
                // Reset the IsBusy flag to allow further actions
                IsBusy = false; 
            }
        }

        [RelayCommand]
        async Task ExportReportAsync()
        {
            // Check if the report is already being generated or exported
            var data     = await _reportService.FetchTrendDataAsync(TimeSpan.FromDays(30));
            var pdfBytes = await _reportService.BuildPdfReportAsync(data);

            // save the PDF to a temporary file
            // Note: FileSystem.CacheDirectory is used for temporary storage. You may want to use a different location based on your requirements.
            var file = Path.Combine(FileSystem.CacheDirectory, "EnvironmentalTrends.pdf");
            File.WriteAllBytes(file, pdfBytes);

            // share the PDF file using the platform's sharing capabilities
            await Share.RequestAsync(new ShareFileRequest
            {
                // Set the title of the share dialog
                Title = "Environmental Trends Report",
                File  = new ShareFile(file)
            });
        }
    }
}
