using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AfterSki.Controllers
{
    public class RidePrognosisController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            int a = 1;
            return View();
        }
    }
}
