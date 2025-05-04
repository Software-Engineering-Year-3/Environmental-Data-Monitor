namespace ED_Monitor.Data.Models
{
    public class WaterQualityData
    {
        public int    SiteName  { get; set; }  // Identifier for the sampling site   
        public string Date      { get; set; } = ""; // Measurement date in YYYY-MM-DD format
        public string Time      { get; set; } = "";   // Measurement time in HH:mm:ss format
        public float  Nitrate   { get; set; } // Nitrate level in the water
        public float  Nitrite   { get; set; } // Nitrite level in the water
        public float  Phosphate { get; set; } // Phosphate level in the water
        public float  EC        { get; set; } // Electrical conductivity reading
    }
}
