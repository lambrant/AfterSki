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
        ///Not functional
        /// </summary>
        public void UpdateDb()
        {
            List<RideStatistic> rs = new List<RideStatistic>();
            rs = JsonData.rideStatList;

            using (var context = new RideStatisticDBContext())
            {
                context.Entry(rs).State = EntityState.Modified;
                var x = context.SaveChanges();

            }
        }
    }
}