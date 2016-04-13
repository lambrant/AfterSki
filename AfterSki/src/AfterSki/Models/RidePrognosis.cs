using System;
using System.Collections.Generic;
using System.Linq;
using AfterSki.Models.RideModels;

namespace AfterSki.Models
{
    public class RidePrognosis
    {
        public float heightProg { get; set; }
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

        public void HeightPrognos(string radioBtnValue, DateTime? currentDate = null)
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

            hoursBetween = ((DateTime)currentDate - firstTimeOfSwipeOnDate.swipeTime).TotalHours;

            if (radioBtnValue == "1630")
            {
                //If the day ends at 16.30-----------------------------------------------------------------
                endOfDay1630 = ((DateTime)currentDate).Date + endDay1630;
                hoursToEnd1630 = (endOfDay1630 - (DateTime)currentDate).TotalHours;
                if (hoursBetween < 0 || hoursToEnd1630 < 0)
                {
                    heightProg = 0;
                }
                else
                {
                    heightProg = heightForSpecificDateAndTime / (float)hoursBetween *
                                                (float)hoursToEnd1630 + heightForSpecificDateAndTime;
                }
            }
            else if (radioBtnValue == "1800")
            {
                //If the day ends at 18.00----------------------------------------------------------------
                endOfDay18 = ((DateTime)currentDate).Date + endDay18;
                hoursToEnd18 = (endOfDay18 - (DateTime)currentDate).TotalHours;
                if (hoursBetween < 0 || hoursToEnd18 < 0)
                {
                    heightProg = 0;
                }
                else
                {
                    heightProg = heightForSpecificDateAndTime / (float)hoursBetween *
                                               (float)hoursToEnd18 + heightForSpecificDateAndTime;
                }
            }
        }
    }
}
