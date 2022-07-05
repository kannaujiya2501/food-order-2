

using food_order_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace food_order_2.Models
{
    public class FoodsDbContext : DbContext
    {

        string connectionString;
        public DbSet<food> foods { get; set; }

        public FoodsDbContext()
        {
            connectionString = "server=.;database=onlinefood;integrated security=true;MultipleActiveResultSets=True;trustservercertificate=true";

        }

        public FoodsDbContext(string path) : base()
        {
            connectionString = path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

