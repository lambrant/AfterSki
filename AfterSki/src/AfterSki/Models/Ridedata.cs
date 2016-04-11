using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki
{
    public class RideData
    {
        public int ID { get; set; }
        public int WeekDay { get; set; }
        public int RidesPerDay { get; set; }
        public int ridesPerHour { get; set; }

        public static int[] ridesPerHourArray = new int[1];

        public int[] PopulateRidesPerDayArray()
        {
            RideStatisticsDBContext 
            rideStatistics rideDataDatabase = new rideStatistics




            return null;
        }
        



        


    }

    

    

}

