﻿using AfterSki.Models.RideModels;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace AfterSki.Models
{
    public class RideStatisticDBContext : DbContext
    {
        public RideStatisticDBContext()
        {

        }
        public RideStatisticDBContext(DbContextOptions options)
            : base(options) { }

        public DbSet<RideStatistic> RideStatistic { get; set; }
       

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Server=127.0.0.1;Database=AfterSki;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}
    }
}