﻿using AfterSki.Models.RideModels;
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
            //public string label { get; set; }

        }
        //public class fallHeightDataPerHour
        //{
        //    public int key { get; set; }
        //    public int fallHeight { get; set; }
        //}
        public class FallingDataObject
        {
            public int y { get; set; }
            //public string label { get; set; }
            
        }


        public IEnumerable<FallData> FallHeightSumPerHour(string rideDate)
        {
            var fd = _context.RideStatistic.Where(u => u.swipeDate.Equals(rideDate));

            //gruppera ihop swipetimes med dess heights efter swipedate och sen summera ihop heights
            var fallHeightArray = fd.GroupBy(x => x.swipeTime.Hour).Select(groupObject => new FallData
            {
                y = groupObject.Sum(u => u.height)
            });

            return fallHeightArray;

            //FallData myFallData = new FallData();
            //myFallData.y = fallHeightArray.Select(z => z.fallHeight);
            //myFallData.label = fallHeightArray.Select(i => i.key.ToString())
            //groupObject.Sum(u => u.height));
            //fallHeightArray.Sum(u => u.)
        }

        public IEnumerable<FallingDataObject> FallHeightSumPerDay(string rideDate)
        {
            var chosenDayArrayQuery = _context.RideStatistic.Where(u => u.swipeDate.Equals(rideDate));

            //gruppera ihop swipetimes med dess heights efter swipedate och sen summera ihop heights
            IEnumerable<FallingDataObject> fallHeightPerDay = chosenDayArrayQuery
                .GroupBy(x => x.swipeTime.Hour)
                .Select(groupObject => new FallingDataObject
            {
                y = groupObject.Sum(u => u.height)
            }).OrderBy(x=>x.y).ToArray();

            int temcAccu = 0;
            foreach (var item in fallHeightPerDay)
            {
                temcAccu += item.y;
                item.y = temcAccu;
            }

            return fallHeightPerDay;
        }


            //    public IEnumerable<FallData> FallingHeightPerDay(IEnumerable<fallHeightDataPerHour> sumObject)
            //    {
            //        FallData myFallData = new FallData();


            //        List<RideStatistic> fd;

            //        fd = _context.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();

            //        //gruppera ihop swipetimes med dess heights efter swipedate och sen summera ihop heights

            //        var fallHeightArray = fd.Sum(x => x.height);
            //        var fallHeightArray = fd.GroupBy(x => x.swipeTime.Hour).Select(groupObject => groupObject.Sum(u => u.height));
            //        fallHeightArray.Sum(u => u.)

            //        .OrderBy(x => x.Key); 

            //        /*var swipeDA = fd.Select(u => new { u.swipeDate, u.height }).GroupBy(u => u.swipeDate).OrderBy(u => u.Key).Select(group =>
            //        new FallData { x = group.Count(), label = group.Key.ToString() }).ToArray();

            //        */

            //        .Select(group =>
            //        new FallData { y = group.Count(), label = group.Key.ToString() })
            //        .ToArray();
            //        int[] intArray = new int[1];
            //        intArray[0] = fallHeightArray;

            //        return null;//fallHeightArray;

            //    }
        }
}
