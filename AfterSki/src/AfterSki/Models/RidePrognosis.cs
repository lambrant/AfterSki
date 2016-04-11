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
        RideStatisticDBContext rideStats = new RideStatisticDBContext();
        List<RideStatistic> rideDataList = new List<RideStatistic>();
        float heightForSpecificDate;
        double hoursBetween;
        double hoursToEnd;
        float heightProg;
        RideStatistic firstTimeOfSwipeOnDate;
        DateTime endOfDay = new DateTime();
        TimeSpan endDay18 = new TimeSpan(18, 00, 00);
        //TimeSpan endDay1630 = new TimeSpan(16, 30, 00);

        public void HeightPrognos(DateTime? currentDate = null)
        {
            //currentHeight/hoursBet*(EndOfday-currentDate)+currentHeight
            if (currentDate == null)
            {
                currentDate = DateTime.Now;
            }

            heightForSpecificDate = rideStats.RideStatistic.Where(x => x.swipeTime.Date == 
                                                            ((DateTime)currentDate).Date).Sum(x => x.height);
            try
            {
                firstTimeOfSwipeOnDate = rideStats.RideStatistic.Where(x => x.swipeTime.Date ==
                            ((DateTime)currentDate).Date).OrderBy(x => x.swipeTime).First();
            }
            catch (Exception)
            {
                firstTimeOfSwipeOnDate = new RideStatistic();
            }

            hoursBetween = Math.Abs((firstTimeOfSwipeOnDate.swipeTime - (DateTime)currentDate).TotalHours);
            endOfDay = ((DateTime)currentDate).Date + endDay18;
            hoursToEnd = Math.Abs((endOfDay - (DateTime)currentDate).TotalHours);

            heightProg = heightForSpecificDate / (float)hoursBetween * (float)hoursToEnd + heightForSpecificDate;
            
        }
    }
}
