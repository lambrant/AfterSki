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
        public float heightProg18 { get; set; }
        public float heightProg1630 { get; set; }
        public float heightForSpecificDateAndTime { get; set; }
        double hoursBetween;
        double hoursToEnd18;
        double hoursToEnd1630;
        RideStatisticDBContext rideStats = new RideStatisticDBContext();
        RideStatistic firstTimeOfSwipeOnDate;
        DateTime endOfDay18 = new DateTime();
        TimeSpan endDay18 = new TimeSpan(18, 00, 00);
        DateTime endOfDay1630 = new DateTime();
        TimeSpan endDay1630 = new TimeSpan(16, 30, 00);

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
                heightProg18 = 0;
                heightProg1630 = 0;
                return;
            }

            heightForSpecificDateAndTime = rideStats.RideStatistic.Where(x => x.swipeTime.Date ==
                                                            ((DateTime)currentDate).Date).Sum(x => x.height);

            hoursBetween = (firstTimeOfSwipeOnDate.swipeTime - (DateTime)currentDate).TotalHours;

            //If the day ends at 18.00----------------------------------------------------------------
            endOfDay18 = ((DateTime)currentDate).Date + endDay18;
            hoursToEnd18 = (endOfDay18 - (DateTime)currentDate).TotalHours;
            if (hoursBetween < 0 || hoursToEnd18 < 0)
            {
                heightProg18 = heightForSpecificDateAndTime / (float)hoursBetween *
                                           (float)hoursToEnd18 + heightForSpecificDateAndTime;
            }
            //If the day ends at 16.30-----------------------------------------------------------------
            endOfDay1630 = ((DateTime)currentDate).Date + endDay1630;
            hoursToEnd1630 = (endOfDay1630 - (DateTime)currentDate).TotalHours;
            if (hoursBetween < 0 || hoursToEnd1630 < 0)
            {
                heightProg1630 = heightForSpecificDateAndTime / (float)hoursBetween *
                                            (float)hoursToEnd1630 + heightForSpecificDateAndTime;
            }
            
        }
    }
}
