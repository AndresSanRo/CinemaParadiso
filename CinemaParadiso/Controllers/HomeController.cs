using System;
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
            return View();            
        }

        public IActionResult Movie(int id)
        {
            Movie movie = client.GetMovie(id).Result;
            return View(movie);
        }
        
    }
}
