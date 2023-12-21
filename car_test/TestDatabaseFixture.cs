using System;
using car_app.Models;
using car_app_data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Xunit;

namespace car_test
{

    public class TestDatabaseFixture : IDisposable
    {
        public ApplicationDbContext DbContext { get; private set; }

        public TestDatabaseFixture()
        {
            DbContext = DbContextFactory.CreateDbContext();
            
        }

        public void ClearDatabase()
        {
            
            DbContext.Cars.RemoveRange(DbContext.Cars);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            
            DbContext.Dispose();
        }
    }
}

