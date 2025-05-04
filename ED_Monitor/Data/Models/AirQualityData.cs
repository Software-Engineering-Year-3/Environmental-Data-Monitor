namespace ED_Monitor.Data.Models
{
    public class AirQualityData
    {
        
    // ID of the monitoring station
        public int StationID  { get; set; }

    // Measurement date in YYYY-MM-DD format
        public string Date    { get; set; } = "";   

      // Measurement time in HH:mm:ss format
        public string Time    { get; set; } = "";  

     // Nitrogen dioxide concentration
        public float  NO2     { get; set; }

     // Sulphur dioxide concentration
        public float  SO2     { get; set; } 

    // Particulate matter (PM2.5) concentration
        public float  PM25    { get; set; }
        
     // Particulate matter (PM10) concentration
        public float  PM10    { get; set; }
    }
}
