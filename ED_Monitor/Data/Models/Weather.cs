namespace ED_Monitor.Data.Models
{
    public class WeatherData
    {
        //public DateTime Date { get; set; }
        public int measurementID { get; set; }
        public float temperature { get; set; }
        public float humidity { get; set; }
        public float windSpeed { get; set; }
        public float windDirection { get; set; }
    }
}