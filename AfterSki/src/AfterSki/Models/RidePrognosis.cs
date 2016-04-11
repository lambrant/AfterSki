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

    public class RidePrognosis
    {
        RideStatisticDBContext rideStats = new RideStatisticDBContext();
        List<RideStatistic> rideDataList = new List<RideStatistic>();
        int metersPerDay;
        DateTime currentDate = new DateTime();
        
        public void HeightPrognos()
        {
            rideDataList = rideStats.RideStatistic.ToList();
            //currentDate = DateTime.Now;
            currentDate = new DateTime(2016, 03, 27, 12, 30, 00);

            for (int i = 0; i < rideDataList.Count; i++)
            {
                //1011m for the whole day

                int resultDate = rideDataList[i].swipeTime.Date.CompareTo(currentDate.Date);

                if (resultDate == 0)
                {
                    int resultTime = rideDataList[i].swipeTime.CompareTo(currentDate);

                    if (resultTime == -1)
                    {
                        metersPerDay += rideDataList[i].height;
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
