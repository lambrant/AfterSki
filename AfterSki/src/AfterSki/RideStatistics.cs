using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models
{
    public class RideStatistics
    {
        public int ID { get; set; }
        public DateTime swipeTime { get; set; }
        public string liftName { get; set; }
        public string destination { get; set; }
        public int height { get; set; }
        public string swipeDate { get; set; }
    }
}
