using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AfterSki.Models
{
    public class JsonData
    {

        public List<RideStatistic> rideStatList = new List<RideStatistic>();

        public class RideStatistic
        {
            public int id { get; set; }
            public string name { get; set; }
            public DateTime swipeTime { get; set; }
            public string liftName { get; set; }
            public int height { get; set; }
            public string swipeDate { get; set; }
        }

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

        private async Task<T> jsonSerializer<T>(string jsonPath) where T : new()
        {

            using (var http = new HttpClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = await http.GetStringAsync(jsonPath);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        public async void getSkiData()
        {
            ///<summary>
            ///get json data from url string
            ///and put out datat to list via jsonSerializer
            ///</summary>
            string jsonPath = "https://www.skistar.com/myskistar/api/v2/views/statisticspage.json?entityId=3206&seasonId=9";
            var jsData = await jsonSerializer<JsonData>(jsonPath);
            rideStatList = jsData.rideStatistics;
            var path = @"C:\xml\json.txt";
            var tw = new StreamWriter(path);
            foreach (var item in rideStatList.Select(x => x.id + ";" + x.name + ";" + x.liftName + ";" + x.swipeDate + ";" + x.swipeTime + ";" + x.height.ToString()).ToArray())
            {
                tw.WriteLine(item.ToString());
            }
            tw.Close();
        }

        //public void ListToCsv()
        //{
        //    string path = @"C:\xml\csvText.csv";
        //    var csvToFile = new StringBuilder();
        //    string csv = String.Join(",", rideStatList.Select(x => x.ToString().ToArray()));
        //    var wr = new StreamWriter(path);
        //    //foreach (var item in rideStatList.Select(x => x.id + x.name + x.liftName + x.height + x.swipeDate + x.swipeTime.ToString()).ToArray())
        //    //{
        //    //    wr.WriteLine(item.ToString());
        //    //}
        //    ////for (int i = 0; i < rideStatList.Count; i++)
        //    ////{
        //    ////    wr.WriteLine(i.ToString());
        //    ////}

        //    wr.WriteLine(path, csvToFile.ToString());
        //    wr.Close();

        //}
    }
}