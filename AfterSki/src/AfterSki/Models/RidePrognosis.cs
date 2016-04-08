using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        int meters;
        
        public void HeightPrognos(DateTime currentDateTime)
        {
            rideDataList = rideStats.RideStatistic.ToList();

            for (int i = 0; i < rideDataList.Count; i++)
            {
                if (rideDataList[i].swipeTime <= currentDateTime)
                {
                    meters += rideDataList[i].height;
                }
            }

        }

    }
}
