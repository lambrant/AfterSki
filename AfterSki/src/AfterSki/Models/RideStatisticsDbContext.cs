﻿using AfterSki.Models.RideModels;
using Microsoft.Data.Entity;

namespace AfterSki.Models
{
    public class RideStatisticDBContext : DbContext
    {
        public DbSet<RideStatistic> RideStatistic { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=127.0.0.1;Database=AfterSki;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}