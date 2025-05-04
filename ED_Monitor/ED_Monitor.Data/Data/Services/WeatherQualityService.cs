using ED_Monitor.Data.Models;

namespace ED_Monitor.Data.Data.Services;

public class WeatherQualityService 
{
	public void FlagData(WeatherData reading)
	{
		// Check if the readings are out of the expected range
		if (reading.Temperature < -50 || reading.Temperature > 50 
			|| reading.Humidity < 0 || reading.Humidity > 100 
			|| reading.Wind_speed < 0 || reading.Wind_speed > 150)
		{
			// Add to the log
			reading.Status = DataStatus.Flagged;
			reading.Logs.Add(new DataLog
			{
				TimeStamp = DateTime.Now,
				Action = "Flagged",
				User = "System",
				Reason = "Data out of range"
			});
		}
		// If data is within the expected range, set status to valid
		else
		{
			reading.Status = DataStatus.Valid;
		}
	}

	public void CompareSensorData(WeatherData reading1, WeatherData reading2)
	{
		// Compare the readig from the two sensors to check for inconsistencies 
		// Maths.Abs to calculate the absolute difference 
		if (Math.Abs(reading1.Temperature - reading2.Temperature) > 200 
			|| Math.Abs(reading1.Humidity - reading2.Humidity) > 350 
			|| Math.Abs(reading1.Wind_speed - reading2.Wind_speed) > 25)
		{
			// Add to the log if data is inconsistent
			reading1.Status = DataStatus.Flagged;
			reading1.Logs.Add(new DataLog
			{
				TimeStamp = DateTime.Now,
				Action = "Flagged",
				User = "System",
				Reason = "Sensor data mismatch"
			});
		}
		// If data is consistent, set status to valid
		else
		{
			reading1.Status = DataStatus.Valid;
		}
	}

	// Method to manually validate data
	// This is called when the user reviews a flagged data entry and 
	// determines it is actually correct - system error
	public void ValidateData(WeatherData reading, string user, string reason)
	{
		// Set the status of the entry to valid and add to log 
		reading.Status = DataStatus.Valid;
		reading.Logs.Add(new DataLog
		{
			TimeStamp = DateTime.Now,
			Action = "Validated",
			User = user,
			Reason = reason
		});
	}
	// Method to manually flag data 
	// Used for flagging data entries manually - if system missed 
	public void FlagData(WeatherData reading, string user, string reason)
	{
		// Set the status of the entry to flagged and add to log 
		reading.Status = DataStatus.Flagged;
		reading.Logs.Add(new DataLog
		{
			TimeStamp = DateTime.Now,
			Action = "Flagged",
			User = user,
			Reason = reason
		});
	}


	
}