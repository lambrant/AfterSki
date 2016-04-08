using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models.RideModels
{
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
}
