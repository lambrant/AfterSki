using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AfterSki.Models.JsonData;

namespace AfterSki.Models.RideModels
{
    public class RideStatistic
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime swipeTime { get; set; }
        public string liftName { get; set; }
        public int height { get; set; }
        public string swipeDate { get; set; }
        public Destination destination { get; set; }
    }

    public class RideStatisticDBContext : DbContext
    {
        public DbSet<RideStatistic> RideStatistic { get; set; }
    }

}
