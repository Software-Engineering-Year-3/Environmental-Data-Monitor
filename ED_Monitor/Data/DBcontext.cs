using Microsoft.EntityFrameworkCore;
using ED_Monitor.Data;

namespace ED_Monitor.Data;
public class ED_MonitorDbContext : DbContext
{

    public ED_MonitorDbContext()
    { }
    public ED_MonitorDbContext(DbContextOptions options) : base(options)
    { }

    // DBSet is a set of record of a specif type returned from the db
     public DbSet ED_Monitor { get; set; }

}

