using ED_Monitor.Data.Models;
using Microsoft.Data.SqlClient; 
using Dapper; // For Queries 

namespace ED_Monitor.Data.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString = "<your Azure connection string>";

        public async Task<IEnumerable<AirQualityData>> GetAirQualityDataAsync()
        {
            var connection = new SqlConnection("DevelopmentConnection");
            var query = "SELECT Date, NO2, SO2, PM25, PM10 FROM AirQualityData";
            return await connection.QueryAsync<AirQualityData>(query);
        }
    }
}

