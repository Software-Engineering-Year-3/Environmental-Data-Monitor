namespace ED_Monitor.Core.Models
{
    public class SensorStatus
    {
        public string SensorId { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public string LastChecked { get; set; }
    }
}
