using AfterSki.Models.RideModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models
{
    public class WriteData
    {


        public IEnumerable<Javaobject> swipeDateArray { get; set; }

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
            public int temp { get; set; }
        }



        public void PopulateRidesPerDayArray(string rideDate)
        {
            List<RideStatistic> ds = new List<RideStatistic>();
            RideStatisticDBContext dsdb = new RideStatisticDBContext();
            ds = dsdb.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();

            swipeDateArray = ds.GroupBy(x => x.swipeTime.Hour).OrderBy(x => x.Key).Select(groupObject => new Javaobject
            {
                label = groupObject.Key.ToString(),
                y = groupObject.Sum(u => u.height)

            }).ToArray();


            List<RideStatistic> ld = new List<RideStatistic>();
            RideStatisticDBContext lddb = new RideStatisticDBContext();
            ld = lddb.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();

            for (int i = 0; i < ld.Count; i++)
            {
                int intHeight = ld.Select(u => u.height).Sum();
            }

            fallDateArray = ld.GroupBy(x => x.swipeTime.Hour).OrderBy(x => x.Key).Select(groupObject =>

            new FallingDataObject
            {
                label = groupObject.Key.ToString(),
                //temp = groupObject.Sum(u => u.height),
                y = groupObject.Sum(u => u.height)

            }).ToArray();
            
            int temcAccu = 0;
            foreach (var item in fallDateArray)
            {
                temcAccu += item.y;
                item.y = temcAccu;
            }







            // fallDateArray = ds.Select(x => x.swipeTime).GroupBy(x => x.Hour).OrderBy(x => x.Key).Select(group =>
            //new FallingDataObject { y = group.Count(), label = group.Key.ToString() })
            // .ToArray();






        }
    }
}
