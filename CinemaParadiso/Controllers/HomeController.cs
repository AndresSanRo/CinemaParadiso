using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CinemaParadiso.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using CinemaParadiso.Providers;
using CinemaParadiso.Data;

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
        public async Task<IActionResult> Search(String searchString)
        {
            if (searchString is null)
            {
                return RedirectToAction("Index");
            }
            DiscoverMovieRequest searchMovies = await client.SearchMovie(searchString);
            return View(searchMovies.Movies);
        }
    }
}
