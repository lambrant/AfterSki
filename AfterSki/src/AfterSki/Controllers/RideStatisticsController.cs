using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AfterSki.Models.RideModels;
using System.Collections.Generic;
using System;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http.Internal;
using System.Data;
using AfterSki.Models;

namespace AfterSki.Controllers
{
    public class RideStatisticsController : Controller
    {
        private RideStatisticDBContext _context;

        public RideStatisticsController(RideStatisticDBContext context)

        {
            _context = context; 
        }

        //GET: RideStatistics
        public IActionResult Index(string searchFacility)
        {
            var TitleQry = from w in _context.RideStatistic
                           orderby w.name
                           select w.name;

            /// populates the dropdown
            var TitleList = new List<string>();
            TitleList.AddRange(TitleQry.Distinct());
            ViewData["searchfacility"] = new SelectList(TitleList);

            var facility = from c in _context.RideStatistic
                          select c;
            
            if (!String.IsNullOrEmpty(searchFacility))
            {
                facility = facility.Where(s => s.name.Contains(searchFacility));
            }

            return View(facility);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Models.RideModels.RideStatistic rideStatistic = _context.RideStatistic.Single(m => m.id == id);
            if (rideStatistic == null)
            {
                return HttpNotFound();
            }

            return View(rideStatistic);
        }

        // GET: RideStatistics/Create
        public IActionResult Create()
        {
            var viewModel = new Models.RideModels.RideStatistic
            {
                swipeTime = System.DateTime.Now,

            };

            return View();
        }

        // POST: RideStatistics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.RideModels.RideStatistic rideStatistic)
        {
            if (ModelState.IsValid)
            {
                _context.RideStatistic.Add(rideStatistic);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rideStatistic);
        }
        
        // GET: RideStatistics/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Models.RideModels.RideStatistic rideStatistic = _context.RideStatistic.Single(m => m.id == id);
            if (rideStatistic == null)
            {
                return HttpNotFound();
            }
            return View(rideStatistic);
        }

        // POST: RideStatistics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.RideModels.RideStatistic rideStatistic)
        {
            if (ModelState.IsValid)
            {
                _context.Update(rideStatistic);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rideStatistic);
        }

        // GET: RideStatistics/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Models.RideModels.RideStatistic rideStatistic = _context.RideStatistic.Single(m => m.id == id);
            if (rideStatistic == null)
            {
                return HttpNotFound();
            }

            return View(rideStatistic);
        }

        // POST: RideStatistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Models.RideModels.RideStatistic rideStatistic = _context.RideStatistic.Single(m => m.id == id);
            _context.RideStatistic.Remove(rideStatistic);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
