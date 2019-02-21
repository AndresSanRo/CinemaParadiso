﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CinemaParadiso.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Movie = CinemaParadiso.Models.Movie;

namespace CinemaParadiso.Controllers
{
    public class HomeController : Controller
    {
        MovieClient client;
        public HomeController(MovieClient client)
        {
            this.client = client;  
        }
        public IActionResult Index()
        {
            string response = client.GetMovie("550").Result;
            //System.Diagnostics.Debug.WriteLine(response);
            //string json = "[{title:'John Simith',overview:35},{title:'Pablo Perez',overview:34}]";
            List<Movie> movie = (List<Movie>)JsonConvert.DeserializeObject<List<Movie>>(response);
            //String[] cadena = (String[])JsonConvert.DeserializeObject(response);
            //var query = from datos in response
            //            select new Movie {
            //                Title = datos.
            //            };            
            return View(movie);            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
