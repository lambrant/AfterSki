using System;
using System.Collections.Generic;
using System.Linq;
using AfterSki.Models.RideModels;
using System.Threading.Tasks;

namespace AfterSki.Models
{
    public class RidePrognosis
    {
        private RideStatisticDBContext _context;

        public RidePrognosis(RideStatisticDBContext context)

        {
            _context = context;
        }
        public float heightProg1530 { get; set; }
        public float heightProg1630 { get; set; }
        public float heightProg1800 { get; set; }
        public float heightForSpecificDateAndTime { get; set; }
        double hoursBetween;
        double hoursToEndOfDay;
        RideModels.RideStatistic firstTimeOfSwipeOnDate;
        DateTime endOfDay1530 = new DateTime();
        TimeSpan endTime1530 = new TimeSpan(15, 30, 00);
        DateTime endOfDay1630 = new DateTime();
        TimeSpan endTime1630 = new TimeSpan(16, 30, 00);
        DateTime endOfDay1800 = new DateTime();
        TimeSpan endTime1800 = new TimeSpan(18, 00, 00);

        public async Task HeightPrognos(string radioBtnValue, DateTime? currentDate = null)
        {
            if (currentDate == null)
            {
                currentDate = DateTime.Now;
            }
            
            firstTimeOfSwipeOnDate = _context.RideStatistic.Where(x => x.swipeTime.Date ==
                        ((DateTime)currentDate).Date).OrderBy(x => x.swipeTime).FirstOrDefault();

            if (firstTimeOfSwipeOnDate == null)
            {
                heightForSpecificDateAndTime = 0;
                heightProg1530 = 0;
                heightProg1630 = 0;
                heightProg1800 = 0;
                return;
            }

            heightForSpecificDateAndTime = _context.RideStatistic.Where(x => x.swipeTime.Date ==
                                                            ((DateTime)currentDate).Date).Sum(x => x.height);

            hoursBetween = ((DateTime)currentDate - firstTimeOfSwipeOnDate.swipeTime).TotalHours;

            //End of day at 15.30-------------------------------------------------------------------------------
            endOfDay1530 = ((DateTime)currentDate).Date + endTime1530;
            hoursToEndOfDay = (endOfDay1530 - (DateTime)currentDate).TotalHours;
            if (hoursBetween < 0 || hoursToEndOfDay < 0)
            {
                heightProg1530 = 0;
            }
            else
            {
                heightProg1530 = heightForSpecificDateAndTime / (float)hoursBetween *
                                                (float)hoursToEndOfDay + heightForSpecificDateAndTime;
            }
            //End of day at 15.30-------------------------------------------------------------------------------

            //End of day at 16.30-------------------------------------------------------------------------------
            endOfDay1630 = ((DateTime)currentDate).Date + endTime1630;
            hoursToEndOfDay = (endOfDay1630 - (DateTime)currentDate).TotalHours;
            if (hoursBetween < 0 || hoursToEndOfDay < 0)
            {
                heightProg1630 = 0;
            }
            else
            {
                heightProg1630 = heightForSpecificDateAndTime / (float)hoursBetween *
                                                (float)hoursToEndOfDay + heightForSpecificDateAndTime;
            }
            //End of day at 16.30-------------------------------------------------------------------------------

            //End of day at 18.00-------------------------------------------------------------------------------
            endOfDay1800 = ((DateTime)currentDate).Date + endTime1800;
            hoursToEndOfDay = (endOfDay1800 - (DateTime)currentDate).TotalHours;
            if (hoursBetween < 0 || hoursToEndOfDay < 0)
            {
                heightProg1800 = 0;
            }
            else
            {
                heightProg1800 = heightForSpecificDateAndTime / (float)hoursBetween *
                                                (float)hoursToEndOfDay + heightForSpecificDateAndTime;
            }
            //End of day at 18.00-------------------------------------------------------------------------------
        }
    }
}
