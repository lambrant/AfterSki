using AfterSki.Models;
using AfterSki.Models.RideModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.ViewModels
{
    public class RidePrognosisVM
    {
        RidePrognosis rpm = new RidePrognosis();
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
                rpm.heightForSpecificDateAndTime = 0;
                rpm.heightProg18 = 0;
                rpm.heightProg1630 = 0;
                return;
            }

            rpm.heightForSpecificDateAndTime = rideStats.RideStatistic.Where(x => x.swipeTime.Date ==
                                                            ((DateTime)currentDate).Date).Sum(x => x.height);

            hoursBetween = ((DateTime)currentDate - firstTimeOfSwipeOnDate.swipeTime).TotalHours;

            if (radioBtnValue == "1630")
            {
                //If the day ends at 16.30-----------------------------------------------------------------
                endOfDay1630 = ((DateTime)currentDate).Date + endDay1630;
                hoursToEnd1630 = (endOfDay1630 - (DateTime)currentDate).TotalHours;
                if (hoursBetween < 0 || hoursToEnd1630 < 0)
                {
                    rpm.heightProg1630 = 0;
                }
                else
                {
                    rpm.heightProg1630 = rpm.heightForSpecificDateAndTime / (float)hoursBetween *
                                                (float)hoursToEnd1630 + rpm.heightForSpecificDateAndTime;
                }
            }
            else if (radioBtnValue == "1800")
            {
                //If the day ends at 18.00----------------------------------------------------------------
                endOfDay18 = ((DateTime)currentDate).Date + endDay18;
                hoursToEnd18 = (endOfDay18 - (DateTime)currentDate).TotalHours;
                if (hoursBetween < 0 || hoursToEnd18 < 0)
                {
                    rpm.heightProg18 = 0;
                }
                else
                {
                    rpm.heightProg18 = rpm.heightForSpecificDateAndTime / (float)hoursBetween *
                                               (float)hoursToEnd18 + rpm.heightForSpecificDateAndTime;
                }
            }
        }
    }
}
