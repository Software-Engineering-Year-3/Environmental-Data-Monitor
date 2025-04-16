namespace ED_Monitor.Data.Models
{
    public class WaterQualityData
    {
        //public DateTime Date { get; set; }
        public int measurementID { get; set; }
        public float nitrate { get; set; }
        public float nitrite { get; set; }
        public float phosphate { get; set; }
        public float eColi { get; set; }
    }
}