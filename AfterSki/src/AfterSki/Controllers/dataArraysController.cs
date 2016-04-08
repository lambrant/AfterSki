using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AfterSki;
using AfterSki.Models;

namespace AfterSki.Controllers
{
    public class dataArraysController : Controller
    {
        private ApplicationDbContext _context;

        public dataArraysController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: dataArrays
        public IActionResult Index()
        {
            return View(_context.dataArray.ToList());
            //_context.Database.
        }

        // GET: dataArrays/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var dataArray = _context.dataArray.Single(m => m.ID == id);
            if (dataArray == null)
            {
                return HttpNotFound();
            }

            return View(dataArray);
        }

        // GET: dataArrays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: dataArrays/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RideData dataArray)
        {
            if (ModelState.IsValid)
            {
                _context.dataArray.Add(dataArray);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dataArray);
        }

        // GET: dataArrays/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var dataArray = _context.dataArray.Single(m => m.ID == id);
            if (dataArray == null)
            {
                return HttpNotFound();
            }
            return View(dataArray);
        }

        // POST: dataArrays/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RideData dataArray)
        {
            if (ModelState.IsValid)
            {
                _context.Update(dataArray);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dataArray);
        }

        // GET: dataArrays/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var dataArray = _context.dataArray.Single(m => m.ID == id);
            if (dataArray == null)
            {
                return HttpNotFound();
            }

            return View(dataArray);
        }

        // POST: dataArrays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var dataArray = _context.dataArray.Single(m => m.ID == id);
            _context.dataArray.Remove(dataArray);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
