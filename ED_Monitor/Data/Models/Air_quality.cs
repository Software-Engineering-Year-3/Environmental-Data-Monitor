namespace ED_Monitor.Data.Models
{
    public class AirQualityData
    {
        public DateTime Date { get; set; }
        public double NO2 { get; set; }
        public double SO2 { get; set; }
        public double PM25 { get; set; }
        public double PM10 { get; set; }
    }
}