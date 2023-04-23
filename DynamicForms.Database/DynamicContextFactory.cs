using DynamicForms.Database.EfCore;
using DynamicForms.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DynamicForms.Database;

public class DynamicContextFactory : IDesignTimeDbContextFactory<DynamicFormsContext>
{
    public DynamicFormsContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DynamicFormsContext>();
        optionsBuilder.UseSqlServer("Data Source = localhost\\SQLEXPRESS;Initial Catalog =dynamicDB;TrustServerCertificate=True;User ID =sa;Password=363758;");
   

        return new DynamicFormsContext(optionsBuilder.Options);
    }
}