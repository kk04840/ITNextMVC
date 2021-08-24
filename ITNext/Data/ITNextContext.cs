using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITNext.Models;

namespace ITNext.Data
{
    public class ITNextContext : DbContext
    {
        public ITNextContext (DbContextOptions<ITNextContext> options)
            : base(options)
        {
        }
        public DbSet<Laptops> Laptops { get; set; }
        public DbSet<YourLaptops> YourLaptops { get; set; }
        public DbSet<Authenticate> Authenticate { get; set; }
    }
}
