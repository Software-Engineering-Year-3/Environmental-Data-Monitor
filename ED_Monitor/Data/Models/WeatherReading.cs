namespace ED_Monitor.Data.Models;

public class WeatherReading
{
    public DateOnly Date { get; set; }
    public float Temperature { get; set; }
    public int Humidity { get; set; }
    public float WindSpeed { get; set; }

    public string WindStatus => WindSpeed > 20 ? "🌬️ Windy" : "✅ Calm";
    public Color WindColor => WindSpeed > 20 ? Colors.OrangeRed : Colors.Green;
}
