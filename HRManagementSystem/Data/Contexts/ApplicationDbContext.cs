using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Data.Models.Scopes;
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
    public DbSet<Bank> Banks { get; set; }
    public DbSet<RequestType> RequestTypes { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Employee> Employees { get; set; }

    // New Configuration Models
    public DbSet<Penalty> Penalties { get; set; }
    public DbSet<EndOfService> EndOfServices { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<SalaryItem> SalaryItems { get; set; }
    public DbSet<Bonus> Bonuses { get; set; }
    public DbSet<Scope> Scopes { get; set; }
    public DbSet<ShiftScope> ShiftScopes { get; set; }
}
