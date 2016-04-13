using AfterSki.Models;
using AfterSki.Models.RideModels;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AfterSki.Models.JsonData;

namespace AfterSki.Models
{
    public class UpdateRecordIfExists
    {

        ///<summary>
        ///Checks if new datat is different than database
        ///Functional.
        ///To do: Make it more effective
        /// </summary>
        public void UpdateData()
        {
            using (var context = new RideStatisticDBContext())
            {
                for (int i = 0; i < rideStatList.Count; i++)
                {
                    var newData = new RideStatistic
                    {
                        name = rideStatList[i].destination.name,
                        liftName = rideStatList[i].liftName,
                        height = rideStatList[i].height,
                        swipeDate = rideStatList[i].swipeDate,
                        swipeTime = rideStatList[i].swipeTime
                    };

                    ///<summary>
                    ///Check the date in swipeTime in database 
                    ///and compare it to the jsonstring swipeTimedata
                    ///If not exists add to database
                    /// </summary>
                    if (!context.RideStatistic.Where(x => x.swipeTime == newData.swipeTime).Any())
                    {
                        context.Attach(newData);
                    }
                    else
                    {
                        return;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}