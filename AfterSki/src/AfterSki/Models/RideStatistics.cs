using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AfterSki.Models
{
    public class RideStatistic
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime swipeTime { get; set; }
        public string liftName { get; set; }
        public int height { get; set; }
        public string swipeDate { get; set; }

        public class Destination2
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Destination3
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class UsedLift
        {
            public string liftName { get; set; }
            public int liftHeight { get; set; }
            public int skierRideCount { get; set; }
            public int skierTotalDropHeight { get; set; }
            public Destination3 destination { get; set; }
        }

        public class Destination4
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class NotUsedLift
        {
            public string liftName { get; set; }
            public int liftHeight { get; set; }
            public int skierRideCount { get; set; }
            public int skierTotalDropHeight { get; set; }
            public Destination4 destination { get; set; }
        }

        public class VisitedDestination
        {
            public object season { get; set; }
            public Destination2 destination { get; set; }
            public int liftCount { get; set; }
            public int skierTotalDropHeight { get; set; }
            public int skierTotalRideCount { get; set; }
            public int skierTotalLiftCount { get; set; }
            public bool showNotUsed { get; set; }
            public string lastVisited { get; set; }
            public List<UsedLift> usedLifts { get; set; }
            public List<NotUsedLift> notUsedLifts { get; set; }
        }

        public class Destination5
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Destination6
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class NotUsedLift2
        {
            public string liftName { get; set; }
            public int liftHeight { get; set; }
            public int skierRideCount { get; set; }
            public int skierTotalDropHeight { get; set; }
            public Destination6 destination { get; set; }
        }

        public class NotVisitedDestination
        {
            public object season { get; set; }
            public Destination5 destination { get; set; }
            public int liftCount { get; set; }
            public int skierTotalDropHeight { get; set; }
            public int skierTotalRideCount { get; set; }
            public int skierTotalLiftCount { get; set; }
            public bool showNotUsed { get; set; }
            public string lastVisited { get; set; }
            public List<object> usedLifts { get; set; }
            public List<NotUsedLift2> notUsedLifts { get; set; }
        }

        public class ActiveSeason
        {
            public int seasonId { get; set; }
            public string name { get; set; }
            public int seasonType { get; set; }
            public string seasonTypeName { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public bool isCurrentSeason { get; set; }
            public string leaderboardString { get; set; }
            public object months { get; set; }
            public object weeks { get; set; }
        }

        public class DefaultSeason
        {
            public int seasonId { get; set; }
            public string name { get; set; }
            public int seasonType { get; set; }
            public string seasonTypeName { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public bool isCurrentSeason { get; set; }
            public string leaderboardString { get; set; }
            public object months { get; set; }
            public object weeks { get; set; }
        }

        /// <summary>
        /// list data from jsonurl on rideStatus
        /// </summary>
        public List<RideStatistic> rideStatistics { get; set; }
        /// <summary>
        /// list datat from jsonurl on visitedDestinations
        /// </summary>
        public List<VisitedDestination> visitedDestinations { get; set; }
        /// <summary>
        /// list datat from jsonurl on notVisitedDestinations
        /// </summary>
        public List<NotVisitedDestination> notVisitedDestinations { get; set; }
        /// <summary>
        /// list datat from jsonurl on activeSeasons
        /// </summary>
        public List<ActiveSeason> activeSeasons { get; set; }
        /// <summary>
        /// list datat from jsonurl on defaultSeason
        /// </summary>
        public DefaultSeason defaultSeason { get; set; }

        /// <summary>
        /// deserializees the jsondatat from url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        private static T jsonSerializer<T>(string url) where T : new()
        {

            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        public void getSkiData()
        {
            ///<summary>
            ///get json data from url string
            ///and put out datat to list via jsonSerializer
            ///</summary>
            string url = "https://www.skistar.com/myskistar/api/v2/views/statisticspage.json?entityId=3206&seasonId=9";
            var jsData = jsonSerializer<RideStatistic>(url);
        }
    }
}