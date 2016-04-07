using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using AfterSki.Models;
using AfterSki.Models.RideModels;

namespace AfterSki.Controllers
{
    [Produces("application/json")]
    [Route("api/RideStatistics")]
    public class RideStatisticsController : Controller
    {
        private ApplicationDbContext _context;

        public RideStatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RideStatistics
        [HttpGet]
        public IEnumerable<RideStatistic> GetRideStatistic()
        {
            return _context.RideStatistic;
        }

        // GET: api/RideStatistics/5
        [HttpGet("{id}", Name = "GetRideStatistic")]
        public IActionResult GetRideStatistic([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            RideStatistic rideStatistic = _context.RideStatistic.Single(m => m.id == id);

            if (rideStatistic == null)
            {
                return HttpNotFound();
            }

            return Ok(rideStatistic);
        }

        // PUT: api/RideStatistics/5
        [HttpPut("{id}")]
        public IActionResult PutRideStatistic(int id, [FromBody] RideStatistic rideStatistic)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != rideStatistic.id)
            {
                return HttpBadRequest();
            }

            _context.Entry(rideStatistic).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RideStatisticExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/RideStatistics
        [HttpPost]
        public IActionResult PostRideStatistic([FromBody] RideStatistic rideStatistic)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.RideStatistic.Add(rideStatistic);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RideStatisticExists(rideStatistic.id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetRideStatistic", new { id = rideStatistic.id }, rideStatistic);
        }

        // DELETE: api/RideStatistics/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRideStatistic(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            RideStatistic rideStatistic = _context.RideStatistic.Single(m => m.id == id);
            if (rideStatistic == null)
            {
                return HttpNotFound();
            }

            _context.RideStatistic.Remove(rideStatistic);
            _context.SaveChanges();

            return Ok(rideStatistic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RideStatisticExists(int id)
        {
            return _context.RideStatistic.Count(e => e.id == id) > 0;
        }
    }
}