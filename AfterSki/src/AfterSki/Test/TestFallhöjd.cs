//using AfterSki.Controllers;
//using AfterSki.Models;
//using Microsoft.Data.Entity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;

//namespace AfterSki.Test
//{
    
    //public class TestFallhöjd
    //{
    //        private RideStatisticDBContext _context;
    //        private HomeController _controller;

    //        public TestFallhöjd()
    //        {
    //            // Initialize DbContext in memory
    //            var optionsBuilder = new DbContextOptionsBuilder();
    //            optionsBuilder.UseInMemoryDatabase();
    //            _context = new RideStatisticDBContext(optionsBuilder.Options);

    //        // Seed data
    //        _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
    //        {
    //            name = "Sälen",
    //            liftName = "Gustav III",
    //            height = 236,
    //            swipeTime = new DateTime(2016, 03, 20, 17, 54 ,17),
    //            swipeDate = "Sön, 20 Mar"
                

    //            //2	236	Gustav III	Sälen	Sön, 20 Mar	2016-03-20 17:54:17.000
    //            //2   236 Gustav III  Sälen   Sön,  20 Mar 2016 - 03 - 20 17:40:08.000

    //        });
    //        _context.RideStatistic.Add(new Models.RideModels.RideStatistic()
    //        {
    //            name = "Sälen",
    //            liftName = "Gustav III",
    //            height = 236,
    //            swipeTime = new DateTime(2016, 03, 20, 17, 40, 08),
    //            swipeDate = "Sön, 20 Mar"
    //        });
    //        _context.SaveChanges();
     
    //        // Create test subject
    //        _controller = new HomeController(_context);
    //    }

    //    //[Fact]
    //    //public void testFallhöjden()
    //    //{
    //    //    FallingData fallingdata = new FallingData(_context);

    //    //    IEnumerable<FallingData.FallData> fallHeightArray = fallingdata.FallingHeightPerDay("Sön, 20 mar");


    //    //    Assert.True(fallHeightArray.Count() == 1);
    //    //    Assert.True(fallHeightArray.First().y == 472);


    //    //}
    

