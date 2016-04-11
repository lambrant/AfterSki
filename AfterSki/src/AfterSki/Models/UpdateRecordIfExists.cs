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
            List<RideStatistic> newData = new List<RideStatistic>();
            newData = JsonData.rideStatList.ToList();
            using (var dbFlush = new RideStatisticDBContext())
            {
                using (var db = new RideStatisticDBContext())
                {
                    foreach (var item in newData.ToDictionary(x => x.name + x.liftName + x.height + x.swipeDate + x.swipeTime)) ;
                    using (var context = new RideStatisticDBContext())
                    {
                        //context.Entry(newData).State = EntityState.Modified;

                        context.RideStatistic.AddRange(newData);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}