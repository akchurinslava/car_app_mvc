using System;
using System.Collections.Generic;
using car_app_core.Domain;
using Microsoft.EntityFrameworkCore;

namespace car_app_data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}

