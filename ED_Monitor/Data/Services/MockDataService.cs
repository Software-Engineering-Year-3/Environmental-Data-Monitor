using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ED_Monitor.Data.Models;
using ED_Monitor.Models;

namespace ED_Monitor.Data.Services
{
    public static class MockDataService
    {


        // Return hard-coded list of sensors
            public static Task<List<Sensor>> GetSensorsAsync() =>
            Task.FromResult(new List<Sensor> {
                new Sensor { SensorID = 1, Name = "Air Station 1", Type = "Air", Latitude = 55.9533, Longitude = -3.1883, Status = "Active" },
                new Sensor { SensorID = 2, Name = "Water Site 1", Type = "Water", Latitude = 55.95, Longitude = -3.19, Status = "Maintenance Required" }
            });
           

        // Return hard-coded air quality data   
        public static Task<List<AirQualityData>> GetAirQualityDataAsync() =>
            Task.FromResult(new List<AirQualityData> {
                new AirQualityData { StationID=1, Date="2024-04-01", Time="08:00:00", NO2=15.2f, SO2=5.1f, PM25=22.3f, PM10=35.4f },
                new AirQualityData { StationID=2, Date="2024-04-01", Time="09:00:00", NO2=18.7f, SO2=4.9f, PM25=25f,   PM10=40.2f }
            });


        // Return hard-coded water quality data
        public static Task<List<WaterQualityData>> GetWaterQualityDataAsync() =>
            Task.FromResult(new List<WaterQualityData> {
                new WaterQualityData { SiteName=1, Date="2024-04-01", Time="08:00:00", Nitrate=2.5f, Nitrite=0.3f, Phosphate=0.1f, EC=500f },
                new WaterQualityData { SiteName=1, Date="2024-04-01", Time="09:00:00", Nitrate=2.7f, Nitrite=0.4f, Phosphate=0.1f, EC=505f }
            });
    }
}
