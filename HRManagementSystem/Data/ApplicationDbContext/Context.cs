using HRManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Data.ApplicationDbContext;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
     : base(options)
    {
    }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
