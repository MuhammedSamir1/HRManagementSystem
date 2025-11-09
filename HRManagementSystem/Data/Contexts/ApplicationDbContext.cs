using HRManagementSystem.Data.Models.AddressEntity;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Data.Contexts.ApplicationDbContext;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleFeature> RoleFeatures { get; set; }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public DbSet<Country> Country { get; set; }
    public DbSet<State> State { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<ProbationPeriod> ProbationPeriods { get; set; }
}
