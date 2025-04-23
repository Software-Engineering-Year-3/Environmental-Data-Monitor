using Microsoft.EntityFrameworkCore;
using ED_Monitor.AppDatabase.Data.Models;
using Microsoft.Data.SqlClient; 
using Dapper; // For Queries 

namespace ED_Monitor.AppDatabase.Data;
{
    public class DatabaseService
    {
        private readonly string _connectionString = "Server=localhost,1433;Database=environmentmonitor;User Id=sa;Password=ED_M0nitor;TrustServerCertificate=True;Encrypt=True;";

        /* public async Task<IEnumerable<AirQualityData>> GetAirQualityDataAsync()
        {
            var connection = new SqlConnection("DevelopmentConnection");
            var query = "SELECT Date, NO2, SO2, PM25, PM10 FROM AirQualityData";
            return await connection.QueryAsync<AirQualityData>(query);
        }*/

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var a = Assembly.GetExecutingAssembly();
            var resources = a.GetManifestResourceNames();
            using var stream = a.GetManifestResourceStream("ED_Monitor.AppDatabase.appsettings.json");
            
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            
            optionsBuilder.UseSqlServer(
                config.GetConnectionString("DevelopmentConnection")
            );
        }

    }
}

