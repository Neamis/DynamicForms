using DynamicForms.Database.EfCore.Configuration;
using DynamicForms.Domain;
using DynamicForms.Domain.Forms;
using DynamicForms.Domain.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DynamicForms.Database.EfCore;

public class
    DynamicFormsContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public DbSet<InputForm> InputForms { get; set; }
    public DbSet<FormFields> FormFields { get; set; }

    public DynamicFormsContext(DbContextOptions<DynamicFormsContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FormFieldConfiguration());
        modelBuilder.ApplyConfiguration(new InputFormConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.Now;
                    break;
            }
        }

        await base.SaveChangesAsync(cancellationToken);
        return 1;
    }
}