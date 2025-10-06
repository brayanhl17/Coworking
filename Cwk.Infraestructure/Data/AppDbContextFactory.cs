using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cwk.Infraestructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CWKDB2;Trusted_Connection=true;MultipleActiveResultSets=true");
            return new AppDbContext(optionBuilder.Options);
        }
    }
}