using Microsoft.EntityFrameworkCore;
using EDMonitor.Models;

namespace Edm.Data;
public class EdmDbContext : DbContext
{

    public EdmDbContext()
    { }
    public EdmDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet EDMonitor { get; set; }

}