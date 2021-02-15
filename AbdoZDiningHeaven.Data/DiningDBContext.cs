using AbdoZDiningHeaven.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbdoZDiningHeaven.Data
{
    public class DiningDBContext : DbContext
    {
        public DiningDBContext(DbContextOptions<DiningDBContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasQueryFilter(r => !r.IsDeleted);
            base.OnModelCreating(modelBuilder);
        }
    }
}
