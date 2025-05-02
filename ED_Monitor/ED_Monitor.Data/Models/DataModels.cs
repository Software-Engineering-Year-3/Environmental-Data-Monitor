using System;

namespace ED_Monitor.Data.Models
{
    // Metadata definitions from Metadata.xlsx
    public class SensorMetadata
    {
        public string Category { get; set; } = null!;
        public string Quantity { get; set; } = null!;          // e.g. "Nitrogen dioxide"
        public string Symbol { get; set; } = null!;            // e.g. "NO2"
        public string Unit { get; set; } = null!;
        public string UnitDescription { get; set; } = null!;
        public string MeasurementFrequency { get; set; } = null!;
        public double SafeLevel { get; set; }
        public string Reference { get; set; } = null!;
        public string Sensor { get; set; } = null!;
        public string URL { get; set; } = null!;
    }

    // Air quality station metadata (from Air_quality.xlsx header)
    public class AirStation
    {
        public string SiteName { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string SiteType { get; set; } = null!;
        public string Zone { get; set; } = null!;
        public string Agglomeration { get; set; } = null!;
        public string LocalAuthority { get; set; } = null!;
    }

    // Hourly air quality readings
    public class AirQualityReading
    {
        public DateTime Date { get; set; }            // from "Date" column
        public TimeSpan Time { get; set; }            // from "Time" column
        public double NO2 { get; set; }               // "Nitrogen dioxide"
        public double SO2 { get; set; }               // "Sulphur dioxide"
        public double PM2_5 { get; set; }             // "PM2.5 particulate matter"
        public double PM10 { get; set; }              // "PM10 particulate matter"
    }

    // Water site metadata (from Water_quality.xlsx header)
    public class WaterSite
    {
        public string SiteName { get; set; } = null!;
        public string SamplePeriod { get; set; } = null!;
        public string Location { get; set; } = null!;
    }

    // Hourly water quality readings
    public class WaterQualityReading
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public double Nitrate { get; set; }           // "Nitrate (mg l-1)"
        public double Nitrite { get; set; }           // "Nitrite (mg l-1)"
        public double Phosphate { get; set; }         // "Phosphate (mg l-1)"
        public double EC { get; set; }                // "EC (cfu/100ml)"
    }

    // Weather station metadata (from Weather.xlsx header)
    public class WeatherStation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; }
        public int UtcOffsetSeconds { get; set; }
        public string Timezone { get; set; } = null!;
        public string TimezoneAbbreviation { get; set; } = null!;
    }

    // Hourly weather measurements
    public class WeatherReading
    {
        public DateTime Time { get; set; }
        public double Temperature2m { get; set; }         // "temperature_2m (°C)"
        public double RelativeHumidity2m { get; set; }    // "relative_humidity_2m (%)"
        public double WindSpeed10m { get; set; }          // "wind_speed_10m (m/s)"
        public double WindDirection10m { get; set; }      // "wind_direction_10m (°)"
    }
}
