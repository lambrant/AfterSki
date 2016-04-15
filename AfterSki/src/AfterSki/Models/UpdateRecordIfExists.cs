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
        private RideStatisticDBContext _context;

        public UpdateRecordIfExists(RideStatisticDBContext context)

        {
            _context = context;
        }
        ///<summary>
        ///Checks if new datat is different than database
        ///Functional.
        ///To do: Make it more effective
        /// </summary>
        public void UpdateData()
        {
            using (_context = new RideStatisticDBContext())
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
                    ///Can be more effective by getting the newest post in database and compare it with
                    ///the new swipeTime in jsonString from url
                    /// </summary>
                    if (!_context.RideStatistic.Where(x => x.swipeTime == newData.swipeTime).Any())
                    {
                        _context.Attach(newData);
                    }
                }
                _context.SaveChanges();
            }
        }
    }
}