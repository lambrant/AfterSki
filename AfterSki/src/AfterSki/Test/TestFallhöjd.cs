using AfterSki.Controllers;
using AfterSki.Models;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AfterSki.Test
{

    public class TestFallhöjd
    {
        private RideStatisticDBContext _context;
        private HomeController _controller;

        public TestFallhöjd()
        {
            //Initialize DbContext in memory
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase();
            _context = new RideStatisticDBContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            //Här populeras databasen finns på minnet med data från den riktiga databasen
            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Gustav III",
                height = 236,
                swipeTime = new DateTime(2016, 03, 20, 17, 54, 17),
                swipeDate = "Sön, 20 Mar"

            });
            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Gustav III",
                height = 236,
                swipeTime = new DateTime(2016, 03, 20, 17, 40, 08),
                swipeDate = "Sön, 20 Mar"
            });

            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Tranan",
                height = 20,
                swipeTime = new DateTime(2016, 03, 27, 12, 43, 26),
                swipeDate = "Sön, 27 Mar"
            });

            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Märta Express",
                height = 260,
                swipeTime = new DateTime(2016, 03, 27, 12, 27, 34),
                swipeDate = "Sön, 27 Mar"
            });

            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Ugglan",
                height = 24,
                swipeTime = new DateTime(2016, 03, 27, 11, 47, 24),
                swipeDate = "Sön, 27 Mar"
            });

            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Krakan",
                height = 22,
                swipeTime = new DateTime(2016, 03, 27, 11, 42, 41),
                swipeDate = "Sön, 27 Mar"
            });

            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Tranan",
                height = 20,
                swipeTime = new DateTime(2016, 03, 27, 11, 38, 08),
                swipeDate = "Sön, 27 Mar"
            });

            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Sydpolen",
                height = 36,
                swipeTime = new DateTime(2016, 03, 27, 11, 27, 36),
                swipeDate = "Sön, 27 Mar"
            });

            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Express 303",
                height = 303,
                swipeTime = new DateTime(2016, 03, 27, 11, 09, 39),
                swipeDate = "Sön, 27 Mar"
            });

            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Märta Express",
                height = 260,
                swipeTime = new DateTime(2016, 03, 27, 10, 55, 44),
                swipeDate = "Sön, 27 Mar"
            });

            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Måsen",
                height = 30,
                swipeTime = new DateTime(2016, 03, 27, 10, 50, 26),
                swipeDate = "Sön, 27 Mar"
            });

            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Sparven",
                height = 12,
                swipeTime = new DateTime(2016, 03, 27, 10, 46, 59),
                swipeDate = "Sön, 27 Mar"
            });

            _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
            {
                name = "Sälen",
                liftName = "Ugglan",
                height = 24,
                swipeTime = new DateTime(2016, 03, 27, 10, 43, 41),
                swipeDate = "Sön, 27 Mar"
            });


            _context.SaveChanges(); // Här sparas datan
            

            //Create test subject
            _controller = new HomeController(_context);
        }

        [Fact]
        public void TestFallhöjden()
        {
            FallingData fallingdata = new FallingData(_context);

            IEnumerable<FallingData.FallData> fallHeightArray = fallingdata.FallHeightSumPerHour("Sön, 20 Mar");


            Assert.Equal(1, fallHeightArray.Count());
            Assert.Equal(472, fallHeightArray.First().y);
        }

        [Fact]
        public void TestSummeradfallhöjd()
        {
            FallingData fallDataInstance = new FallingData(_context);

            IEnumerable<FallingData.FallingDataObject> fallHeightPerDayArray = fallDataInstance.FallHeightSumPerDay("Sön, 27 Mar");

            Assert.Equal(3, fallHeightPerDayArray.Count());
            Assert.Equal(280, fallHeightPerDayArray.ElementAt(0).y);
        }
    }
}


