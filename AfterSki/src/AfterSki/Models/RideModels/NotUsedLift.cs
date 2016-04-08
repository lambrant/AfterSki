using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models.RideModels
{
    public class NotUsedLift
    {
        public string liftName { get; set; }
        public int liftHeight { get; set; }
        public int skierRideCount { get; set; }
        public int skierTotalDropHeight { get; set; }
        public Destination4 destination { get; set; }
    }
}
