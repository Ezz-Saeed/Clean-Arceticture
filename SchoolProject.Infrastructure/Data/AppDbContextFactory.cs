using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SchoolProject.Infrastructure;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // Update the path if your database file is elsewhere
            optionsBuilder.UseSqlite("Data Source=SchoolProject.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }