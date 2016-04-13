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
        double hoursToEndOfDay;
        RideStatisticDBContext rideStats = new RideStatisticDBContext();
        RideStatistic firstTimeOfSwipeOnDate;
        DateTime endOfDay = new DateTime();
        TimeSpan endTime = new TimeSpan();

        public void HeightPrognos(string radioBtnValue, DateTime? currentDate = null)
        {
            if (currentDate == null)
            {
                currentDate = DateTime.Now;
            }

            ConvertStringToTimeSpan(radioBtnValue);

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

            endOfDay = ((DateTime)currentDate).Date + endTime;
            hoursToEndOfDay = (endOfDay - (DateTime)currentDate).TotalHours;
            if (hoursBetween < 0 || hoursToEndOfDay < 0)
            {
                heightProg = 0;
            }
            else
            {
                heightProg = heightForSpecificDateAndTime / (float)hoursBetween *
                                                (float)hoursToEndOfDay + heightForSpecificDateAndTime;
            }
        }

        public void ConvertStringToTimeSpan(string radioBtnConvert)
        {
            endTime = TimeSpan.Parse(radioBtnConvert);            
        }
    }
}
