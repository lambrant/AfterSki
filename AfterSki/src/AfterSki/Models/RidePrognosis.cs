using System;
using System.Collections.Generic;
using System.Linq;
using AfterSki.Models.RideModels;

namespace AfterSki.Models
{
    //Call HeightPrognos when a button is pressed, create a DateTime variabel that
    //gets the current DateTime for when the button was pressed and send that 
    //variabel as an inparameter for the HeightPrognos function.
    //Present the data as numbers, current height and how much the skier can 
    //expect to reach at the end of the day.

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

            int a = 1;

            
            

            //for (int i = 0; i < rideDataList.Count; i++)
            //{
            //    
            //
            //   int resultDate = rideDataList[i].swipeTime.Date.CompareTo(((DateTime)currentDate).Date);
            //
            //    if (resultDate == 0)
            //    {
            //        int resultTime = rideDataList[i].swipeTime.CompareTo((DateTime)currentDate);
            //        
            //        currentHeightInMeters += rideDataList[i].height;
            //
            //        
            //
            //        if (resultTime == -1)
            //        {
            //            if (correctDate)
            //            {
            //                timeOfSwipe = rideDataList[i].swipeTime;
            //                hoursBetween = (timeOfSwipe - (DateTime)currentDate).TotalHours;
            //                endOfDay = rideDataList[i].swipeTime.Date + endDay18;
            //
            //            }
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
        }
    }
}
