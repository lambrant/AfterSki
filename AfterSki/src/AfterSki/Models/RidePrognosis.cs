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
        int currentHeightInMeters;
        double hoursBetween;
        int accumulatedHeightInMeters;
        bool correctDate = true;
        DateTime currentDate = new DateTime(2016, 03, 27, 10, 30, 00);
        DateTime timeOfSwipe = new DateTime();
        DateTime endOfDay = new DateTime();
        
        public void HeightPrognos()
        {
            rideDataList = rideStats.RideStatistic.ToList();
            currentDate = new DateTime();

            for (int i = 0; i < rideDataList.Count; i++)
            {
                int resultDate = rideDataList[i].swipeTime.Date.CompareTo(currentDate.Date);

                if (correctDate)
                {
                    timeOfSwipe = rideDataList[i].swipeTime;
                    hoursBetween = (timeOfSwipe - currentDate).TotalHours;
                    endOfDay = rideDataList[i].swipeTime;
                    correctDate = false;
                }

                if (resultDate == 0)
                {
                    int resultTime = rideDataList[i].swipeTime.CompareTo(currentDate);

                    if (resultTime == -1)
                    {
                        currentHeightInMeters += rideDataList[i].height;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
