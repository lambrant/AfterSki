using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models.RideModels
{
    public class UsedLift
    {
        public string liftName { get; set; }
        public int liftHeight { get; set; }
        public int skierRideCount { get; set; }
        public int skierTotalDropHeight { get; set; }
        public Destination3 destination { get; set; }
    }
}
