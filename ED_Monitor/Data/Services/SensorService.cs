using ED_Monitor.Models;

namespace ED_Monitor.Data.Services;

public static class SensorService
{
    // In-memory cache of sensors
    public static List<Sensor> Sensors { get; private set; } = new();

    // Populate the in-memory list with sample sensors
    public static void LoadMockSensors()
    {
        // Real station coordinates:
        // – Air quality at Edinburgh Nicolson Street
        const double baseAirLat     = 55.94476;
        const double baseAirLon     = -3.183991;

        // – Water quality at Glencorse Reservoir (Glencorse B)
        const double baseWaterLat   = 55.861111;   // 55°51′40″N
        const double baseWaterLon   = -3.253889;   // 3°15′14″W

        // – Weather at Edinburgh Airport
        const double baseWeatherLat = 55.949000;
        const double baseWeatherLon = -3.372000;

        Sensors = new List<Sensor>
        {
            // — Air quality sensors (ug/m3, hourly)
            new Sensor {
                SensorID  = 1,
                Name      = "Nitrogen dioxide (NO₂)",
                Type      = "Air quality",
                Status    = "Active",
                // center pin
                Latitude  = baseAirLat + 0.0040,
                Longitude = baseAirLon + 0.0300
            },
            new Sensor {
                SensorID  = 2,
                Name      = "Sulphur dioxide (SO₂)",
                Type      = "Air quality",
                Status    = "Active",
                // slightly north-east
                Latitude  = baseAirLat + 0.0032,
                Longitude = baseAirLon + 0.0001
            },
            new Sensor {
                SensorID  = 3,
                Name      = "Particulate Matter 2.5μm (PM2.5)",
                Type      = "Air quality",
                Status    = "Active",
                // slightly south-west
                Latitude  = baseAirLat - 0.0002,
                Longitude = baseAirLon - 0.0091
            },
            new Sensor {
                SensorID  = 4,
                Name      = "Particulate Matter 10μm (PM10)",
                Type      = "Air quality",
                Status    = "Active",
                // slightly north-west
                Latitude  = baseAirLat + 0.0003,
                Longitude = baseAirLon - 0.0012
            },

            // — Water quality sensors (mg/L or cfu/100mL)
            new Sensor {
                SensorID  = 5,
                Name      = "Nitrite (NO₂⁻)",
                Type      = "Water quality",
                Status    = "Active",
                // cluster around Glencorse
                Latitude  = baseWaterLat + 0.0000,
                Longitude = baseWaterLon + 0.0000
            },
            new Sensor {
                SensorID  = 6,
                Name      = "Nitrate (NO₃⁻)",
                Type      = "Water quality",
                Status    = "Active",
                Latitude  = baseWaterLat + 0.0001,
                Longitude = baseWaterLon + 0.0001
            },
            new Sensor {
                SensorID  = 7,
                Name      = "Phosphate (PO₄³⁻)",
                Type      = "Water quality",
                Status    = "Active",
                Latitude  = baseWaterLat - 0.0001,
                Longitude = baseWaterLon - 0.0001
            },
            new Sensor {
                SensorID  = 8,
                Name      = "E. coli (EC)",
                Type      = "Water quality",
                Status    = "Active",
                Latitude  = baseWaterLat + 0.0002,
                Longitude = baseWaterLon - 0.0002
            },
            new Sensor {
                SensorID  = 9,
                Name      = "Enterococci (IE)",
                Type      = "Water quality",
                Status    = "Active",
                Latitude  = baseWaterLat - 0.0002,
                Longitude = baseWaterLon + 0.0002
            },

            // — Weather sensors
            new Sensor {
                SensorID  = 10,
                Name      = "Temperature (T)",
                Type      = "Weather",
                Status    = "Active",
                // cluster around airport
                Latitude  = baseWeatherLat + 0.0000,
                Longitude = baseWeatherLon + 0.0000
            },
            new Sensor {
                SensorID  = 11,
                Name      = "Humidity (H)",
                Type      = "Weather",
                Status    = "Active",
                Latitude  = baseWeatherLat + 0.0001,
                Longitude = baseWeatherLon - 0.0001
            },
            new Sensor {
                SensorID  = 12,
                Name      = "Wind Speed (WS)",
                Type      = "Weather",
                Status    = "Active",
                Latitude  = baseWeatherLat - 0.0001,
                Longitude = baseWeatherLon + 0.0201
            },
            new Sensor {
                SensorID  = 13,
                Name      = "Wind Direction (WD)",
                Type      = "Weather",
                Status    = "Active",
                Latitude  = baseWeatherLat + 0.00015,
                Longitude = baseWeatherLon - 0.00215
            },
        };
    }
}
