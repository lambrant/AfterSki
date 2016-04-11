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
       
        public static int[] PopulateRidesPerDayArray(string rideDate)
        {
            List<RideStatistic> rs = new List<RideStatistic>();
            RideStatisticDBContext rsdb = new RideStatisticDBContext();
            rs = rsdb.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();
            int[] swipeDateArray = rs.Select(x => x.swipeTime).GroupBy(x =>  x.Hour).Select(group=>group.Count()).ToArray();
            
            return swipeDateArray;
                           
        }
        
            //return rs.SelectheSwipeDate.Contains(rideDate)));(z => z.swipeTime).GroupBy(x => new { x.Day, x.Hour }).Select(x => new RideStatistic { swipeTime = x.Key.Day, swipeTime = x.Key.Hour });



        


    }

    

    

}

