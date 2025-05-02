using Microcharts; // library for charts 
using SkiaSharp; // graphics library for charts
using System.Collections.ObjectModel;
using System.Globalization;
using ED_Monitor.Data;
using ED_Monitor.Database;
namespace ED_Monitor;

// Unfortunately coded on a nonexisting database - this is a mockup of the data
public partial class ViewData : ContentPage
{
    private readonly IDataService _dataService;

    public DashboardPage(IDataService dataService)
    {
        InitializeComponent();
        _dataService = dataService;
        LoadDashboardData();
    }

	// load data 
    private async void LoadDashboardData()
    {
        DateTime endDate = DateTime.Now;
		// Calculate start date for data display set to one month before the current date
		// My choice for data display in the main dashboard 
        DateTime startDate = endDate.AddMonths(-1);

		// Get data
        var AirData = await _dataService.GetAirQualityData(startDate, endDate);
        var WaterData = await _dataService.GetWaterQualityData(startDate, endDate);
        var WeatherData = await _dataService.GetWeatherData(startDate, endDate);

		// Methods to update the summaries on the dashboard
        UpdateAirQualitySummary(AirData);
        UpdateWaterQualitySummary(WaterData);
        UpdateWeatherSummary(WeatherData);

		// Same thing for the charts
        GenerateAirQualityChart(AirData);
        GenerateWaterQualityChart(WaterData);
        GenerateWeatherChart(WeatherData);
    }

	// Helper method to generate line charts for all data types + handle common logic 
	// While singular methods allow fort clarity and seprations of concerns, and organise data fielsds for each data type + customisation
	// Can be used by all data types for reusabiluty and maintainability
	private GraphicsView GenerateLineChart<Chart>(
		ObservableCollection<Chart> data,
		// function to choose what time frame for grouping
		Func<Chart, DateTime> dateSelector,
		// Function to select the data value 
		Func<Chart, double> valueSelector,
		// Same thing for the coulour
		string colorHex,
		// Optional parameter for formatting for the values lables- the default is F1
		string valueLabelFormat = "F1")
	{
		// Check if data is null or empty and return a message if so
		if (data == null || !data.Any())
		{
			return new GraphicsView { Content = new Label { Text = "No data available for chart." } };
		}

		var chartEntries = data
			// Group data by date and calculate average values
			.GroupBy(dateSelector)
			.Select(g => new ChartEntry((float)g.Average(valueSelector))
			{
				// Format the label and value label for the chart entry
				Label = g.Key.ToString("MMM dd"),
				ValueLabel = $"{g.Average(valueSelector):valueLabelFormat}",
				Color = SKColor.Parse(colorHex)
			})
			.ToList();

		var chart = new LineChart
		{
			Entries = chartEntries,
			LineMode = LineMode.Straight,
			LineSize = 4,
			PointMode = PointMode.Circle,
			PointSize = 8
		};
		// Render graph
		return new GraphicsView { Drawable = chart };
	}

	// Generate the chart for Air Quality data
    private void GenerateAirQualityChart(ObservableCollection<AirQualityReading> data)
    {
		// NO2
		AirQualityChartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.NO2,
			"#FF9800" // Orange
		); 

		// SO2
		AirQualitychartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.SO2,
			"#FF5722" // Red
		);

		// PM2.5
		AirQualityChartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.PM2_5,
			"#3F51B5" // Dark blue
		);

		// PM10
		AirQualityChartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.PM10,
			"#009688" // light Blue
		);
    }

	
	// Generate the chart for Water Quality data
    private void GenerateWaterQualityChart(ObservableCollection<WaterQualityData> data)
    {
		// Nitrate
		WaterQualityChartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.Nitrate,
			"#2196F3" // More blue
		); 

		// Nitrite
		WaterQualityChartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.Nitrite,
			"#673AB7" // Purple
		);

		// Phosphate
		WaterQualityChartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.Phosphate,
			"#FFEB3B" // Yellow
		);

		// E coli
		WaterQualitychartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.E_coli,
			"#FF5722" // Red
		);
    }

 private void GenerateWeatherQualityChart(ObservableCollection<WheatherData> data)
    {
		// Temperature
		WeatherQualityChartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.Temperature,
			"#FF9800" // Orange
		);

		// Humidity
		WeatherQualityChartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.Humidity,
			"#FF5722" // Red
		);

		// Wind Speed
		WeatherQualityChartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.WindSpeed,
			"#3F51B5" // Dark blue
		);
		
		// Wind Direction
		WeatherQualityChartView.Content = GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.WindDirection,
			"#009688" // light Blue
		);
	}
// For the sake of the code - and mine - i have used a fake instance of a database in order to be able to create the code for the user stpry 
public interface IDataService
{
    Task<ObservableCollection<AirQualityReading>> GetAirQualityData(DateTime startDate, DateTime endDate);
    Task<ObservableCollection<WaterQualityData>> GetWaterQualityData(DateTime startDate, DateTime endDate);
    Task<ObservableCollection<WheatherData>> GetWeatherData(DateTime startDate, DateTime endDate);
}
}