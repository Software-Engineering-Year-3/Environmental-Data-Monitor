using ED_Monitor.Data.Models;

namespace ED_Monitor.Data.Data.Services;

public class WaterQualityService 
{
	public void FlagData(WaterQualityData reading)
	{
		// Check if the readings are out of the expected range
		if (reading.Nitrate < 0 || reading.Nitrate > 40 
			|| reading.Nitrite < 0 || reading.Nitrite > 1 
			|| reading.Phosphate < 0 || reading.Phosphate > 5 
			|| reading.EC < 0 || reading.EC > 2)
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

	public void CompareSensorData(WaterQualityData reading1, WaterQualityData reading2)
	{
		// Compare the readig from the two sensors to check for inconsistencies 
		// Maths.Abs to calculate the absolute difference 
		if (Math.Abs(reading1.Nitrate - reading2.Nitrate) > 200 
			|| Math.Abs(reading1.Nitrite - reading2.Nitrite) > 350 
			|| Math.Abs(reading1.Phosphate - reading2.Phosphate) > 25 
			|| Math.Abs(reading1.EC - reading2.EC) > 50)
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
	public void ValidateData(WaterQualityData reading, string user, string reason)
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
	
}