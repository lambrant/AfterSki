using AfterSki.Controllers;
using AfterSki.Models.RideModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace AfterSki.Models
{
    public class JsonData
    {
        public static List<RideStatistic> rideStatList = new List<RideStatistic>();
        public static List<ActiveSeason> activeSeasonList = new List<ActiveSeason>();
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
        /// deserializes the jsondatat from url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>

        private  async Task<T> jsonSerializer <T>(string jsonPath)  where T :  new()
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
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data): new T();
            }
        }

        public async void getSkiData()
        {
            ///<summary>
            ///Testdata for checking update funktion
            /// </summary>
            //string jsonPath = "https://www.skistar.com/myskistar/api/v2/views/statisticspage.json?entityId=1&seasonId=9";

            ///<summary>
            ///martins data 3206
            ///</summary>

            string jsonPath = "https://www.skistar.com/myskistar/api/v2/views/statisticspage.json?entityId=3206&seasonId=9";
            
            ///<summary>
            ///get json data from url string
            ///and put out datat to list via jsonSerializer
            ///</summary>
            var jsData = await jsonSerializer<JsonData>(jsonPath);
            rideStatList = jsData.rideStatistics;
        }
    }
}