using Microsoft.EntityFrameworkCore;
using ED_Monitor.Models;         //  Sensor POCO
using ED_Monitor.Data.Models;   

namespace ED_Monitor.Data
{
   
   // DbContext for our SQL Server database (tried this approach first)
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sensor> Sensors { get; set; } = null!;
        public DbSet<AirQualityData> AirQualityData { get; set; } = null!;
        public DbSet<WaterQualityData> WaterQualityData { get; set; } = null!;
        public DbSet<WeatherData> WeatherData { get; set; } = null!;
    }
}
