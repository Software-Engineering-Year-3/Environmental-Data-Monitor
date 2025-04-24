using ED_Monitor.Data.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace ED_Monitor.Data.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString = "<your Azure connection string>";

        public async Task<IEnumerable<AirQualityData>> GetAirQualityDataAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT Date, NO2, SO2, PM25, PM10 FROM AirQualityData";
            return await connection.QueryAsync<AirQualityData>(query);
        }

        public async Task<IEnumerable<WaterQualityData>> GetWaterQualityDataAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            const string sql = "SELECT SiteName, Date, Nitrate, Nitrite, Phosphate FROM WaterQualityData";
            return await conn.QueryAsync<WaterQualityData>(sql);
        }

        public async Task<IEnumerable<WeatherData>> GetWeatherDataAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            const string sql = "SELECT ID, Timestamp, Temperature, Humidity, WindSpeed, WindDirection FROM WeatherData";
            return await conn.QueryAsync<WeatherData>(sql);
        }

    }
}