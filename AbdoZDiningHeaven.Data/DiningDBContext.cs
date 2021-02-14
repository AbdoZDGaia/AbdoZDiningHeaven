﻿using AbdoZDiningHeaven.Core;
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
    }
}