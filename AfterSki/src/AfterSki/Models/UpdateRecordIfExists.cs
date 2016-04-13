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
    public class UpdateRecordIfExists : RideStatistic
    {

        ///<summary>
        ///Checks if new datat is different than database
        ///Not functional
        /// </summary>
        public void UpdateData()
        {

            using (var context = new RideStatisticDBContext())
            {
                for (int i = 0; i < JsonData.rideStatList.Count; i++)
                {
                    var newData = new RideStatistic
                    {
                        name = JsonData.rideStatList[i].destination.name,
                        liftName = JsonData.rideStatList[i].liftName,
                        height = JsonData.rideStatList[i].height,
                        swipeDate = JsonData.rideStatList[i].swipeDate,
                        swipeTime = JsonData.rideStatList[i].swipeTime
                    };

                    ///<summary>
                    ///Check the date in database and compare it to the jsonstring
                    ///If not exists add to database
                    /// </summary>
                    if (!context.RideStatistic.Where(x => x.swipeTime == newData.swipeTime).Any())
                    {
                        context.Attach(newData);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}