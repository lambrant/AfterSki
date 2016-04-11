using System;
using System.Collections.Generic;
using System.Linq;
using AfterSki.Models.RideModels;

namespace AfterSki.Models
{
    //Add two buttons that shows the current height and the prognosis height
    //based on which closing time. If user presses closing 16.30, calculate 
    //based on that. If user presses closing at 18.00 calculate based on that.

    //end of day 16.30 or/and 18.00

    public class RidePrognosis
    {
        //float heightForSpecificDate;
        //float heightProg;
        public float heightProg { get; set; }
        public float heightForSpecificDateAndTime { get; set; }
        double hoursBetween;
        double hoursToEnd;
        RideStatisticDBContext rideStats = new RideStatisticDBContext();
        List<RideStatistic> rideDataList = new List<RideStatistic>();
        RideStatistic firstTimeOfSwipeOnDate;
        DateTime endOfDay = new DateTime();
        TimeSpan endDay18 = new TimeSpan(18, 00, 00);
        //TimeSpan endDay1630 = new TimeSpan(16, 30, 00);

        public void HeightPrognos(DateTime? currentDate = null)
        {
            if (currentDate == null)
            {
                currentDate = DateTime.Now;
            }
            
            firstTimeOfSwipeOnDate = rideStats.RideStatistic.Where(x => x.swipeTime.Date ==
                        ((DateTime)currentDate).Date).OrderBy(x => x.swipeTime).FirstOrDefault();

            if (firstTimeOfSwipeOnDate == null)
            {
                heightForSpecificDateAndTime = 0;
                heightProg = 0;
                return;
            }

            heightForSpecificDateAndTime = rideStats.RideStatistic.Where(x => x.swipeTime.Date ==
                                                            ((DateTime)currentDate).Date).Sum(x => x.height);

            hoursBetween = (firstTimeOfSwipeOnDate.swipeTime - (DateTime)currentDate).TotalHours;
            endOfDay = ((DateTime)currentDate).Date + endDay18;
            hoursToEnd = (endOfDay - (DateTime)currentDate).TotalHours;

            if (hoursBetween < 0 || hoursToEnd < 0)
            {
                heightProg = heightForSpecificDateAndTime / (float)hoursBetween *
                                           (float)hoursToEnd + heightForSpecificDateAndTime;
            }
        }
    }
}
