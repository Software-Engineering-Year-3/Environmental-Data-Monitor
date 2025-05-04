// ViewModels/ReportViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Maui;
using Microsoft.Maui.Storage;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using ED_Monitor.Models;
using ED_Monitor.Services;

namespace ED_Monitor.ViewModels
{
    /// <summary>
    /// ViewModel for generating and exporting environmental trend reports.
    /// Now follows SRP by using:
    ///  • ITrendDataService  – for data retrieval,
    ///  • IReportPdfGenerator – for PDF creation.
    /// </summary>
    public partial class ReportViewModel : ObservableObject
    {
        private readonly ITrendDataService   _trendDataService;
        private readonly IReportPdfGenerator _pdfGenerator;

        /// <summary>
        /// Collection of chart series to be displayed in the report.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<ISeries> chartSeries = new();

        /// <summary>
        /// Indicates whether an operation is in progress.
        /// </summary>
        [ObservableProperty]
        private bool isBusy;

        /// <summary>
        /// Constructor takes exactly two services, each with a single responsibility.
        /// </summary>
        public ReportViewModel(
            ITrendDataService trendDataService,
            IReportPdfGenerator pdfGenerator)
        {
            _trendDataService = trendDataService;
            _pdfGenerator     = pdfGenerator;
        }

        /// <summary>
        /// Fetches trend data and populates the chart series.
        /// </summary>
        [RelayCommand]
        async Task GenerateReportAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;

                // 1) Retrieve aggregated trend data (e.g. last 30 days)
                var data = await _trendDataService.GetTrendDataAsync(TimeSpan.FromDays(30));

                // 2) Map into chart series
                ChartSeries.Clear();
                ChartSeries.Add(new LineSeries<double>
                {
                    Name   = "Air Quality",
                    Values = data.AirQualityLevels
                });
                ChartSeries.Add(new LineSeries<double>
                {
                    Name   = "Water pH",
                    Values = data.WaterPhLevels
                });
                ChartSeries.Add(new LineSeries<double>
                {
                    Name   = "Temperature",
                    Values = data.Temperatures
                });
            }
            catch (Exception ex)
            {
                // TODO: replace with user-facing error dialog
                Console.WriteLine($"[ReportViewModel] GenerateReportAsync failed: {ex}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Generates a PDF from the latest trend data and invokes the share dialog.
        /// </summary>
        [RelayCommand]
        async Task ExportReportAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;

                // 1) Get the same trend data
                var data = await _trendDataService.GetTrendDataAsync(TimeSpan.FromDays(30));

                // 2) Generate PDF bytes
                var pdfBytes = await _pdfGenerator.GeneratePdfAsync(data);

                // 3) Save to a temporary file
                var filePath = Path.Combine(FileSystem.CacheDirectory, "EnvironmentalTrends.pdf");
                File.WriteAllBytes(filePath, pdfBytes);

                // 4) Invoke platform share sheet
                await Share.RequestAsync(new ShareFileRequest
                {
                    Title = "Environmental Trends Report",
                    File  = new ShareFile(filePath)
                });
            }
            catch (Exception ex)
            {
                // TODO: replace with user-facing error dialog
                Console.WriteLine($"[ReportViewModel] ExportReportAsync failed: {ex}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
