using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using ED_Monitor.Data;
using ED_Monitor.Data.Models;

namespace ED_Monitor.Data;

public class DatabaseService : DbContext
{

    public DatabaseService() { }
    public DatabaseService(DbContextOptions<DatabaseService> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var a = Assembly.GetExecutingAssembly();
        var resources = a.GetManifestResourceNames();
        using var stream = a.GetManifestResourceStream("ED_Monitor.Database.appsettings.json");

        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        optionsBuilder.UseSqlServer(
            config.GetConnectionString("LocalConnection"),
            m => m.MigrationsAssembly("ED_Monitor.Migrations")
            );
        
        return;
    }
    
    public DbSet<AirQualityReading> AirQuality { get; set; }
    public DbSet<SensorData> Sensor { get; set; }
    public DbSet<WaterQualityData> WaterQuality { get; set; }
    public DbSet<WeatherData> Weather { get; set; }
    public DbSet<UserSession> UserSession { get; set; }


}

