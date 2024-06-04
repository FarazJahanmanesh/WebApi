using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Context;
public class ApplicationDbContext:IdentityDbContext<User,Role,int>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
	{
	}

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyInMemoryDatabase");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

        foreach (var type in types)
        {
            dynamic configurationInstance = Activator.CreateInstance(type);
            modelBuilder.ApplyConfiguration(configurationInstance);
        }
    }
}
