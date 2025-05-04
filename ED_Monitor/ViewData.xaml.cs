using System.Collections.ObjectModel;
using ED_Monitor.Data.Models;
using Microcharts;
using SkiaSharp;
namespace ED_Monitor;

/// <summary>
///  Main dashboard page for displaying environmental data: air, water and weather quality
///  And class to define a label to render text for mesage dispaly
/// </summary>
 
public class LabelDrawable : IDrawable
{
    private readonly string _text;

    public LabelDrawable(string text)
    {
        _text = text;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FontColor = Colors.Black;
        canvas.FontSize = 16;
        canvas.DrawString(_text, dirtyRect.Center.X, dirtyRect.Center.Y, HorizontalAlignment.Center);
    }
}
public partial class ViewData : ContentPage
{	
	// Unfortunately coded on a nonexisting database - this is a mockup of the data
    private readonly IDataService _dataService;

// observable collections for data binding to list views in xaml
	public ObservableCollection<AirQualityReading> AirQualityReadings { get; set; } = new ObservableCollection<AirQualityReading>();
	public ObservableCollection<WaterQualityData> WaterQualityReadings { get; set; } = new ObservableCollection<WaterQualityData>(); 
	public ObservableCollection<WeatherData> WeatherQualityReadings { get; set; } = new ObservableCollection<WeatherData>();

	/// <summary>
	/// New instance of the dashboard page
	/// </summary>
	/// <param name="dataService">The data service used to fetch the data necessary</param>
    public ViewData(IDataService dataService)
    {
        InitializeComponent();
        _dataService = dataService;
		// Set binding context for data binding 
		BindingContext = this;
        LoadDashboardData();
    }
	/// <summary>
	/// Load the data for the dashboard
	/// </summary>
	// load data 
    private async void LoadDashboardData()
    {
        DateTime endDate = DateTime.Now;
		// Calculate start date for data display set to one month before the current date
		// My choice for data display in the main dashboard 
        DateTime startDate = endDate.AddMonths(-1);

		// Get data
        var airData = await _dataService.GetAirQualityData(startDate, endDate);
		foreach (var reading in airData)
		{
			AirQualityReadings.Add(reading);
		}

        var waterData = await _dataService.GetWaterQualityData(startDate, endDate);
		foreach (var reading in waterData)
		{
			WaterQualityReadings.Add(reading);
		}

        var weatherData = await _dataService.GetWeatherData(startDate, endDate);
		foreach (var reading in weatherData)
		{
			WeatherQualityReadings.Add(reading);
		}

		// Same thing for the charts
        GenerateAirQualityChart(AirQualityReadings);
        GenerateWaterQualityChart(WaterQualityReadings);
        GenerateWeatherChart(WeatherQualityReadings);
    }

	// Reusable method to validate data - used for all data types
	private void ValidateCommand<Command>(Command reading, string user, string reason) where Command : IQualityReading
	{
		// Check if the data is valid and exit if it is already
		if (reading.Status == DataStatus.Valid)
		{
			return;
		}
		// Set the status of the entry to valid and add to log
		reading.Status = DataStatus.Valid;
		// Add a logfor teh validation action
		reading.Logs.Add(new DataLog
		{
			TimeStamp = DateTime.Now,
			Action = "Validated",
			User = user,
			Reason = reason
		});
	
	}

	// Reusable method to flag data 
	private void FlagCommand<Command>(Command reading, string user, string reason) where Command : IQualityReading
	{
		reading.Status = DataStatus.Flagged;
		reading.Logs.Add(new DataLog
		{
			TimeStamp = DateTime.Now,
			Action = "Flagged",
			User = user,
			Reason = reason
		});
	}

	// Commands for water quality validation/flagging
	public Command<AirQualityReading> ValidateAirQualityCommand => new Command<AirQualityReading>(reading =>
		ValidateCommand(reading, "User", "Validated"));
	public Command<AirQualityReading> FlagAirQualityCommand => new Command<AirQualityReading>(reading =>
		FlagCommand(reading, "User", "Flagged"));

	// Same thing for water and weather 
	public Command<WaterQualityData> ValidateWaterQualityCommand => new Command<WaterQualityData>(reading =>
		ValidateCommand(reading, "User", "Validated"));
	public Command<WaterQualityData> FlagWaterQualityCommand => new Command<WaterQualityData>(reading =>
		FlagCommand(reading, "User", "Flagged"));
	
	public Command<WeatherData> ValidateWeatherQualityCommand => new Command<WeatherData>(reading =>
		ValidateCommand(reading, "User", "Validated"));
	public Command<WeatherData> FlagWeatherQualityCommand => new Command<WeatherData>(reading =>
		FlagCommand(reading, "User", "Flagged"));

    /// <summary>
    /// Generates a line chart for the given data
    /// </summary>
    /// <typeparam name="Chart">The tipe of data that is being handled to be put in the chart</typeparam>
    /// <param name="data">The data to be put in the chart</param>
    /// <param name="dateSelector">Selects the date range for grouping the data accordingly</param>
    /// <param name="valueSelector">Selects the values to chart</param>
    /// <param name="colorHex">Colour of the chart line</param>
    /// <param name="valueLabelFormat">Optional format for value lables</param>
    /// <returns>Returns a GraphicView that contains the chart</returns>

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
			return new GraphicsView { 
				Drawable = new LabelDrawable ("No data available for chart.")
				};
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

	/// <summary>
	/// Generates the chart for air quality data
	/// </summary>
	/// <param name="data">The data to be put in the chart</param>

    private void GenerateAirQualityChart(ObservableCollection<AirQualityReading> data)
    {
		// Clear any existing charts
		AirQualityView.Children.Clear();

		// NO2
		AirQualityView.Children.Add(GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.NO2,
			"#FF9800" // Orange
		)); 

		// SO2
		AirQualityView.Children.Add(GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.SO2,
			"#FF5722" // Red
		));

		// PM2.5
		AirQualityView.Children.Add(GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.PM2_5,
			"#3F51B5" // Dark blue
		));

		// PM10
		AirQualityView.Children.Add(GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.PM10,
			"#009688" // light Blue
		));

    }

	/// <summary>
	/// Generates the chart for water quality data
	/// </summary>
	/// <param name="data">The data to be put in the chart</param>	
    private void GenerateWaterQualityChart(ObservableCollection<WaterQualityData> data)
    {
		// Clear any existing charts
		WaterQualityView.Children.Clear();
		// Nitrate
		WaterQualityView.Children.Add(GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.Nitrate,
			"#2196F3" // More blue
		)); 

		// Nitrite
		WaterQualityView.Children.Add(GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.Nitrite,
			"#673AB7" // Purple
		));

		// Phosphate
		WaterQualityView.Children.Add(GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.Phosphate,
			"#FFEB3B" // Yellow
		));

		// E coli
		WaterQualityView.Children.Add(GenerateLineChart
		(
			data,
			data => data.Time.Date,
			data => data.EC,
			"#FF5722" // Red
		));
    }

	/// <summary>
	/// Generates the chart for weather quality data
	/// </summary>
	/// <param name="data">The data to be put in the chart</param>

	private void GenerateWeatherChart(ObservableCollection<WeatherData> data)
		{
			// Clear any existing charts
			WeatherQualityView.Children.Clear();

			// Temperature
			WeatherQualityView.Children.Add(GenerateLineChart
			(
				data,
				data => data.Time.Date,
				data => data.Temperature,
				"#FF9800" // Orange
			));

			// Humidity
			WeatherQualityView.Children.Add(GenerateLineChart
			(
				data,
				data => data.Time.Date,
				data => data.Humidity,
				"#FF5722" // Red
			));

			// Wind Speed
			WeatherQualityView.Children.Add(GenerateLineChart
			(
				data,
				data => data.Time.Date,
				data => data.Wind_speed,
				"#3F51B5" // Dark blue
			));
			
			// Wind Direction
			WeatherQualityView.Children.Add(GenerateLineChart
			(
				data,
				data => data.Time.Date,
				data => data.Wind_direction,
				"#009688" // light Blue
			));
		}

}

