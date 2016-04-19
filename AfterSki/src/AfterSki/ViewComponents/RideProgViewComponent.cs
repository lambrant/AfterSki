using AfterSki.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Threading.Tasks;

namespace AfterSki.ViewComponents
{
    public class RideProg : ViewComponent
    {
        private RideStatisticDBContext _context;

        public RideProg(RideStatisticDBContext context)

        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string radioBtnValue)
        {
            RidePrognosis rpv = new RidePrognosis(_context);

            await rpv.HeightPrognos(radioBtnValue, new DateTime(2016, 03, 26, 13, 20, 00));
            
            return View(rpv);
        }
    }
}
