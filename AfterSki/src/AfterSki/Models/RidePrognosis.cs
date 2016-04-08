using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfterSki.Models.RideModels;

namespace AfterSki.Models
{
    public class RidePrognosis
    {
        RideStatisticDBContext rideStats = new RideStatisticDBContext();
        List<RideStatistic> temp = new List<RideStatistic>();

        public RidePrognosis()
        {
            temp = rideStats.RideStatistic.ToList();

        }

    }
}
