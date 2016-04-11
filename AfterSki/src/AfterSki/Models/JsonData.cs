﻿using AfterSki.Controllers;
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
            DataImport di = new DataImport();
            di.ListToDB();
            //jsonToTxtFile();
        }
        ///< summary >
        /// TextWriter writes a tempfile to wwwroot/tmp and deletes the created file when done.
        /// Function might not be needed. Just shows the data from the rideStatList
        /// </ summary >
        ///
        ///

        //public void jsonToTxtFile()
        //{
        //    var path = @"tmp\jsonData.txt";
        //    using (var tw = new StreamWriter(path))
        //    {
        //        foreach (var item in rideStatList.Select(x => x.destination.id + ";" + x.destination.name + ";" + x.liftName + ";" + x.swipeDate + ";" + x.swipeTime + ";" + x.height.ToString()).ToArray())
        //        {
        //            tw.WriteLine(item.ToString());
        //        }
        //    }
        //    File.Delete(path);

        //}
    }
}