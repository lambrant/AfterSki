using AfterSki.Models.RideModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki
{
    public class RideData
    {
       
        public static int[] ridesPerHourArray = new int[1];

        public int[] PopulateRidesPerDayArray(string rideDate)
        {
            List<RideStatistic> rs = new List<RideStatistic>();
            RideStatisticDBContext rsdb = new RideStatisticDBContext();
            var theSwipeDate = rsdb.RideStatistic.Where(u => u.swipeTime.ToString().Contains(rideDate));
            int[] swipeDateArray = theSwipeDate.Select(x => x.swipeTime).GroupBy(x =>  x.Hour).Select(group=>group.Count()).ToArray();
            
            return swipeDateArray;
           
           
            //return rs.SelectheSwipeDate.Contains(rideDate)));(z => z.swipeTime).GroupBy(x => new { x.Day, x.Hour }).Select(x => new RideStatistic { swipeTime = x.Key.Day, swipeTime = x.Key.Hour });

        
        }
        



        


    }

    

    

}

