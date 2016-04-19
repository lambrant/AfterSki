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
            List<RideStatistic> ld = new List<RideStatistic>();
            RideStatisticDBContext lddb = new RideStatisticDBContext();
            ld = lddb.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();

            for (int i = 0; i < ld.Count; i++)
            {
                int intHeight = ld.Select(u => u.height).Sum();
            }

            List<RideStatistic> ds1 = new List<RideStatistic>();
            RideStatisticDBContext dsdb1 = new RideStatisticDBContext();
            int tempSum = 0;
            ds1 = dsdb1.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();

            fallDateArray = ds1.GroupBy(x => x.swipeTime.Hour).Select(groupObject => new FallingDataObject
            {
                label = groupObject.Key.ToString(),
                y = groupObject.Sum(u => u.height)


            }).ToArray();

            for (int i = 0; i < ds1.Count; i++)
            {
                if (i != 0)
                    ds1[i].height = ds1[i].height + ds1[i - 1].height;
                
            } 

            //fallDateArray = ld.GroupBy(x => x.swipeTime.Hour).OrderBy(x => x.Key).Select(groupObject =>

            //    new FallingDataObject
            //    {


            //        label = groupObject.Key.ToString(),
            //        temp = groupObject.Sum(u => u.height),
            //        y = groupObject.Aggregate((groupObjecta, groupObjectb) => groupObjecta + groupObjectb)
            //        )

            //        //First().height + groupObject.Where(x => x.height = groupObject.ElementAt(groupObject.Aggregate)) )

            //}).ToArray();



            List<RideStatistic> ds = new List<RideStatistic>();
            RideStatisticDBContext dsdb = new RideStatisticDBContext();
            ds = dsdb.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();

            fallDateArray = ds.GroupBy(x => x.swipeTime.Hour).Select(groupObject => new FallingDataObject
            {
                label = groupObject.Key.ToString(),
                y = groupObject.Sum(u => u.height)

            }).ToArray();






        }
    }
}

/*ds.Select(x => x.swipeTime).GroupBy(x => x.Hour).OrderBy(x => x.Key).Select(group =>
      new FallingDataObject { y = group.Count(), label = group.Key.ToString() })
       .ToArray();

        var fallHeightArray = 
           .*/
