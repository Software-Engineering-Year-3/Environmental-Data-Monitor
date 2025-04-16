namespace ED_Monitor.Data.Models
{
    public class AirQualityData
    {
        //public DateTime Date { get; set; }
        public int MeasurementID { get; set; }
        public float NO2 { get; set; }
        public float SO2 { get; set; }
        public float PM25 { get; set; }
        public float PM10 { get; set; }
    }
}