using ED_Monitor.Data.Models;

namespace ED_Monitor.Data.Data.Services;

public class AirQualityService 
{
	public void FlagData(AirQualityReading reading)
	{
		// Check if the readings are out of the expected range
		if (reading.NO2 < 40 || reading.NO2 > 200 
			|| reading.SO2 < 125 || reading.SO2 > 350 
			|| reading.PM2_5 < 0 || reading.PM2_5 > 25 
			|| reading.PM10 < 0 || reading.PM10 > 50)
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

	public void CompareSensorData(AirQualityReading reading1, AirQualityReading reading2)
	{
		// Compare the readig from the two sensors to check for inconsistencies 
		// Maths.Abs to calculate the absolute difference 
		if (Math.Abs(reading1.NO2 - reading2.NO2) > 200 
			|| Math.Abs(reading1.SO2 - reading2.SO2) > 350 
			|| Math.Abs(reading1.PM2_5 - reading2.PM2_5) > 25 
			|| Math.Abs(reading1.PM10 - reading2.PM10) > 50)
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
	public void ValidateData(AirQualityReading reading, string user, string reason)
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
	public void FlagData(AirQualityReading reading, string user, string reason)
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