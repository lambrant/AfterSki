﻿using Microsoft.AspNet.Mvc;
using AfterSki.Models;
using Microsoft.SqlServer.Server;
using AfterSki.Models.RideModels;
using System.Linq;
using System;
using AfterSki.ViewModels;

namespace AfterSki.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            JsonData jm = new JsonData();
            jm.getSkiData();
            return View();
        }

        public IActionResult Skidata()
        {
            RidePrognosis rpv = new RidePrognosis();

            return View(rpv);
        }

        [HttpPost]
        public IActionResult Skidata(string radioBtnValue)
        {
            RidePrognosis rpv = new RidePrognosis();            
            rpv.HeightPrognos(radioBtnValue, new DateTime(2016, 03, 26, 13, 20, 00));

            return View(rpv);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}