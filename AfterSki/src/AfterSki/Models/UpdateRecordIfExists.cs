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
            List<RideStatistic> rsData = new List<RideStatistic>();
            //var newData = JsonData.rideStatList.ToList();
            for (int i = 0; i < JsonData.rideStatList.Count; i++)
            {
                rsData.Add(new RideStatistic
                {
                    name = JsonData.rideStatList[i].destination.name,
                    liftName = JsonData.rideStatList[i].liftName,
                    height = JsonData.rideStatList[i].height,
                    swipeDate = JsonData.rideStatList[i].swipeDate,
                    swipeTime = JsonData.rideStatList[i].swipeTime
                });
            }
            
            using (var dbFlush = new RideStatisticDBContext())
            {
                using (var db = new RideStatisticDBContext())
                {
                    foreach (var item in rsData.ToDictionary(x => x.name + x.liftName + x.height + x.swipeDate + x.swipeTime)) ;
                    using (var context = new RideStatisticDBContext())
                    {
                        //context.Entry(newData).State = EntityState.Modified;

                        context.RideStatistic.AddRange(rsData);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}