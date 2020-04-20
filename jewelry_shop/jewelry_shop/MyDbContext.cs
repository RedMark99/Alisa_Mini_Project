using System;
using System.Data.Entity;

namespace jewelry_shop
{
    public class MyDbContext: DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Title> Titles { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<User> Users { get; set; }


    }
}
