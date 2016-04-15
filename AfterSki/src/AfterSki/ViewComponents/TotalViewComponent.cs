using AfterSki.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.ViewComponents
{
    //[ViewComponent(Name = "TotalsViewComponent")]
    public class TotalCount : ViewComponent //ViewComponent
    {
        private RideStatisticDBContext _context;

        public TotalCount(RideStatisticDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            GetCount gc = new GetCount(_context);
            gc.InvokeGetCount();
            return View(gc);
        }
    }

}