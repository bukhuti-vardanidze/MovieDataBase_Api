using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace MovieDataBase_Api.Db
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            Console.WriteLine(args[0]);
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(args[0]);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
