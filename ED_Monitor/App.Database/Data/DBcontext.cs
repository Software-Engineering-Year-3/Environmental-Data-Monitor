using Microsoft.EntityFrameworkCore;
using ED_Monitor.Database.Models;
    
namespace ED_Monitor.App.Database.Data;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var a = Assembly.GetExecutingAssembly();
            var resources = a.GetManifestResourceNames();
            using var stream = a.GetManifestResourceStream("ED_Monitor.App.Database.appsettings.json");

            var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

            optionsBuilder.UseSqlServer(
            config.GetConnectionString("DevelopmentConnection")
            );
        }

    }
}

