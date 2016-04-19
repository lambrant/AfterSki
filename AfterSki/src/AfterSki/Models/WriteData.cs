using AfterSki.Models.RideModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models
{
    public class WriteData
    {

        
        public IEnumerable<Javaobject> swipeDateArray{ get; set; }

        public IEnumerable<FallingDataObject> fallDateArray { get; set; }



        public class Javaobject
        {
            public int y { get; set; }
            public string label { get; set; }
        }

        public class FallingDataObject
        {
            public int y { get; set; }
            public string label { get; set; }
        }

     

        public void PopulateRidesPerDayArray(string rideDate)
        {
            List<RideStatistic> rs = new List<RideStatistic>();
            RideStatisticDBContext rsdb = new RideStatisticDBContext();
            rs = rsdb.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();

            swipeDateArray = rs.Select(x => x.swipeTime).GroupBy(x => x.Hour).OrderBy( x => x.Key).Select(group =>
            new Javaobject{ y = group.Count(),label = group.Key.ToString() })
            .ToArray();



            List<RideStatistic> ds = new List<RideStatistic>();
            RideStatisticDBContext dsdb = new RideStatisticDBContext();
            ds = rsdb.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();

            fallDateArray = ds.Select(x => x.swipeTime).GroupBy(x => x.Hour).OrderBy(x => x.Key).Select(group =>
           new FallingDataObject { y = group.Count(), label = group.Key.ToString() })
            .ToArray();



        


        }
    }
}
