using AfterSki.Models.RideModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models
{
    public class FallingData
    {
        private RideStatisticDBContext _context;

        public FallingData(RideStatisticDBContext context)
        {
            _context = context;
        }
        public class FallData
        {
            public int y { get; set; }
            public string label { get; set; }
            public int x { get; set; }
        }
        public static List<RideStatistic> fd = new List<RideStatistic>();
        //public static IEnumerable<FallData> FallingProperty(string rideDate)
        //{
        //    var swipeDA = fd.Select(u => new { u.swipeDate, u.height }).GroupBy(u => u.swipeDate).OrderBy(u => u.Key).Select(group =>
        //    new FallData { x = group.Count(), label = group.Key.ToString() }).ToArray();

        //    return swipeDA;
        //}
        //public static IEnumerable<FallData> FallingHeightPerDay(string rideDate)
        //{
        //    var swipeDateArray = fd.Select(x => x.swipeTime).GroupBy(x => x.Hour).OrderBy(x => x.Key).Select(group =>
        //    new FallData { y = group.Count(), label = group.Key.ToString() })
        //    .ToArray();

        //    return swipeDateArray;
        //}
        
    }
}
