using car_app.Models;
using car_app_data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace car_test
{
    internal class DbContextFactory
    {
        public static ApplicationDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}