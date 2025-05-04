using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


using ED_Monitor.Models;          // for Sensor
using ED_Monitor.Data.Models;     // for AirQualityData, WaterQualityData

namespace ED_Monitor.Data.Services
{


    // Static helper for querying SQL Server tables directly.
    public static class DatabaseService
    {
        // real connection string 
        private static readonly string _cs = 
            "Server=localhost\\SQLEXPRESS;" +
            "Database=EnvironmentalDB;" +
            "Trusted_Connection=True;TrustServerCertificate=True;";

        public static async Task<List<Sensor>> GetSensorsAsync()
        {
            var results = new List<Sensor>();
            try
            {
                using var con = new SqlConnection(_cs);
                await con.OpenAsync();

                using var cmd = new SqlCommand("SELECT * FROM Sensors", con);
                using var rdr = await cmd.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    results.Add(new Sensor
                    {
                        SensorID  = rdr.GetInt32   (rdr.GetOrdinal("SensorID")),
                        Name      = rdr.GetString  (rdr.GetOrdinal("Name")),
                        Type      = rdr.GetString  (rdr.GetOrdinal("Type")),
                        Latitude  = rdr.GetDouble  (rdr.GetOrdinal("Latitude")),
                        Longitude = rdr.GetDouble  (rdr.GetOrdinal("Longitude")),
                        Status    = rdr.GetString  (rdr.GetOrdinal("Status")),
                    });
                }
            }
            catch (Exception ex)
            {
              // If something goes wrong, log and return empty list

                Console.WriteLine($"DB[Sensors] error: {ex.Message}");
            }
            return results;
        }

        public static async Task<List<AirQualityData>> GetAirQualityDataAsync()
        {
            var list = new List<AirQualityData>();
            try
            {
                using var con = new SqlConnection(_cs);
                await con.OpenAsync();

                using var cmd = new SqlCommand("SELECT * FROM AirQualityData", con);
                using var rdr = await cmd.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    list.Add(new AirQualityData
                    {
                        StationID = rdr.GetInt32   (rdr.GetOrdinal("StationID")),
                        Date      = rdr.GetDateTime(rdr.GetOrdinal("Date"))
                                          .ToString("yyyy-MM-dd"),
                        Time      = rdr.GetTimeSpan (rdr.GetOrdinal("Time"))
                                          .ToString(@"hh\:mm\:ss"),
                        NO2       = (float)rdr.GetDouble(rdr.GetOrdinal("NO2")),
                        SO2       = (float)rdr.GetDouble(rdr.GetOrdinal("SO2")),
                        PM25      = (float)rdr.GetDouble(rdr.GetOrdinal("PM25")),
                        PM10      = (float)rdr.GetDouble(rdr.GetOrdinal("PM10")),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DB[AirQuality] error: {ex.Message}");
            }
            return list;
        }

        public static async Task<List<WaterQualityData>> GetWaterQualityDataAsync()
        {
            var list = new List<WaterQualityData>();
            try
            {
                using var con = new SqlConnection(_cs);
                await con.OpenAsync();

                using var cmd = new SqlCommand("SELECT * FROM WaterQualityData", con);
                using var rdr = await cmd.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    list.Add(new WaterQualityData
                    {
                        SiteName  = rdr.GetInt32   (rdr.GetOrdinal("SiteName")),
                        Date      = rdr.GetDateTime(rdr.GetOrdinal("Date"))
                                          .ToString("yyyy-MM-dd"),
                        Time      = rdr.GetTimeSpan (rdr.GetOrdinal("Time"))
                                          .ToString(@"hh\:mm\:ss"),
                        Nitrate   = (float)rdr.GetDouble(rdr.GetOrdinal("Nitrate")),
                        Nitrite   = (float)rdr.GetDouble(rdr.GetOrdinal("Nitrite")),
                        Phosphate = (float)rdr.GetDouble(rdr.GetOrdinal("Phosphate")),
                        EC        = (float)rdr.GetDouble(rdr.GetOrdinal("EC")),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DB[WaterQuality] error: {ex.Message}");
            }
            return list;
        }
    }
}
