using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models.RideModels
{
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
}
