using HRManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Data.ApplicationDbContext;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
    {
    }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
