using AfterSki.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.ViewComponents
{
    public class RideProgViewComp : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(string radioBtnValue)
        {
            RidePrognosis rpv = new RidePrognosis();
            await rpv.HeightPrognos(radioBtnValue, new DateTime(2016, 03, 26, 13, 20, 00));
            
            return View(rpv);
        }


        //[HttpPost]
        //public IActionResult Skidata(string radioBtnValue)
        //{
        //    RidePrognosis rpv = new RidePrognosis();
        //    rpv.HeightPrognos(radioBtnValue, new DateTime(2016, 03, 26, 13, 20, 00));
        //
        //    return View(rpv);
        //}
    }
}
