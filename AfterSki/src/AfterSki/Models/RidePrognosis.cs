using System;
using System.Collections.Generic;
using System.Linq;
using AfterSki.Models.RideModels;

namespace AfterSki.Models
{
    //Add two buttons that shows the current height and the prognosis height
    //based on which closing time. If user presses closing 16.30, calculate 
    //based on that. If user presses closing at 18.00 calculate based on that.

    //What happends if the skier checks his prognosis before the day starts?

    public class RidePrognosis
    {
        public float heightProg18 { get; set; }
        public float heightProg1630 { get; set; }
        public float heightForSpecificDateAndTime { get; set; }
    }
}
