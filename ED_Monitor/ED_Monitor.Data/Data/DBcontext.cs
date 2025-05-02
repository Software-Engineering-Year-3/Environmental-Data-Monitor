using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using ED_Monitor.Data;

namespace ED_Monitor.Data.Services;

public class DatabaseService : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        /*optionsBuilder.UseSqlite("Filename=EDMonitorLocal.db");
        var a = Assembly.GetExecutingAssembly();
        var resources = a.GetManifestResourceNames();
        using var stream = a.GetManifestResourceStream("ED_Monitor.Database.appsettings.json");

        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        optionsBuilder.UseSqlServer(
            config.GetConnectionString("LocalConnection"),
            m => m.MigrationsAssembly("ED_Monitor.Migrations")
            );*/

        // Use the SQLite database for local development
        optionsBuilder.UseSqlite("Filename=EDMonitorLocal.db");
    }

    internal async Task<IEnumerable<object>> GetAirQualityAsync()
    {
        throw new NotImplementedException();
    }

    internal async Task<IEnumerable<object>> GetWaterQualityAsync()
    {
        throw new NotImplementedException();
    }

    internal async Task<IEnumerable<object>> GetWeatherAsync()
    {
        throw new NotImplementedException();
    }

    //   public DbSet AirQuality { get; set; }
    // public DbSet Sensor { get; set; }
    //   public DbSet WaterQuality { get; set; }
    //   public DbSet Weather { get; set; }
    //    public DbSet User { get; set; }


}

