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
            //foreach (var item in rsData.ToDictionary(x => x.name + x.liftName + x.height + x.swipeDate + x.swipeTime))

            for (int i = 0; i < JsonData.rideStatList.Count; i++)
            {
                rsData.Add(new RideStatistic
                {
                    //id = JsonData.rideStatList[i].destination.id,
                    name = destination.name,
                    liftName = liftName,
                    height = height,
                    swipeDate = swipeDate,
                    swipeTime = swipeTime
                });

                var newData = new RideStatistic();
                using (var context = new RideStatisticDBContext())
                {
                    context.Entry(newData).State = newData.id == 0 ?
                                       EntityState.Added :
                                       EntityState.Modified;

                    context.SaveChanges();
                }

                //List<RideStatistic> rsData = new List<RideStatistic>();
                ////var newData = JsonData.rideStatList.ToList();
                //for (int i = 0; i < JsonData.rideStatList.Count; i++)
                //{
                //    rsData.Add(new RideStatistic
                //    {
                //        //id = JsonData.rideStatList[i].destination.id,
                //        name = JsonData.rideStatList[i].destination.name,
                //        liftName = JsonData.rideStatList[i].liftName,
                //        height = JsonData.rideStatList[i].height,
                //        swipeDate = JsonData.rideStatList[i].swipeDate,
                //        swipeTime = JsonData.rideStatList[i].swipeTime
                //    });
                //}

                ////var rsNew = new RideStatistic.(foreach (var item in rsData.ToDictionary(x => x.name + x.liftName + x.height + x.swipeDate + x.swipeTime)) ;
                //foreach (var item in rsData.ToDictionary(x => x.name + x.liftName + x.height + x.swipeDate + x.swipeTime)) ;
                //var rsNew = new RideStatistic
                //{

                //    name = destination.name,
                //    liftName = liftName,
                //    height = height,
                //    swipeDate = swipeDate,
                //    swipeTime = swipeTime
                //};
                //using (var ctx = new RideStatisticDBContext())
                //{
                //    ctx.Entry(rsNew).State = EntityState.Modified;
                //    ctx.SaveChanges();

                //    //using (var db = new RideStatisticDBContext())
                //    //{
                //    //    foreach (var item in rsData.ToDictionary(x => x.name + x.liftName + x.height + x.swipeDate + x.swipeTime)) ;
                //    //    using (var context = new RideStatisticDBContext())
                //    //    {
                //    //        //context.Entry(newData).State = EntityState.Modified;

                //    //        context.RideStatistic.AddRange(rsData); // This works but adds all data, not update
                //    //        context.SaveChanges();
                //    //    }
                //    //}
                //}
            }
        }
    }
}