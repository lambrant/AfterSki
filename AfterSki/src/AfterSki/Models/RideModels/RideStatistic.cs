using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static AfterSki.Models.JsonData;

namespace AfterSki.Models.RideModels
{
    public class RideStatistic
    {
        public int id { get; set; }

        [Display(Name = "Skidort")]
        public string name { get; set; }

        [Display(Name = "Liftnamn")]
        public string liftName { get; set; }

        [Display(Name = "Fallhöjd")]
        public int height { get; set; }

        [Display(Name = "Tidsregistrering")]
        public DateTime swipeTime { get; set; }

        [Display(Name = "Åkdag")]
        public string swipeDate { get; set; }
        public Destination destination { get; set; }

    }
}