using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using ED_Monitor.Data.Models;


namespace ED_Monitor.Data.Services;

public class DatabaseService : EDMDatabse
{

    public ED_MonitorDbContext() { }
    public ED_MonitorDbContext(DbContextOptions<ED_MonitorDbContext> options) : base(options) { }

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
    }
    
    public DbSet AirQuality { get; set; }
    public DbSet Sensor { get; set; }
    public DbSet WaterQuality { get; set; }
    public DbSet Weather { get; set; }
    public DbSet User { get; set; }


}

