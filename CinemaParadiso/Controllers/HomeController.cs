﻿using System;
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
using CinemaParadiso.Repositories;
using CinemaParadiso.Filters;
using System.Security.Claims;

namespace CinemaParadiso.Controllers
{
    public class HomeController : Controller
    {
        MovieClient client;
        IRepositoryCinephile repo;
        public HomeController(MovieClient client, IRepositoryCinephile repo)
        {
            this.client = client;            
            this.repo = repo;
        }
        public IActionResult Index()
        {                                    
            return View();            
        }

        public async Task<IActionResult> Movie(int id)
        {
            Movie movie = client.GetMovie(id).Result;
            ViewData["INLIST"] = "No";            
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                this.repo.token = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (await repo.CheckInList(movie.ID, HttpContext.User.Identity.Name))
                {
                    ViewData["INLIST"] = "Yes";
                }                
            }                        
            return View(movie);
        }
        [UserAuthorize]
        public async Task<IActionResult> UserList()
        {
            this.repo.token = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Lists> listMovies = await repo.GetUserList(HttpContext.User.Identity.Name);
            List<Movie> movies = new List<Movie>();
            if (listMovies != null)
            {                
                foreach (Lists lItem in listMovies)
                {
                    movies.Add(await client.GetMovie(lItem.IdMovie));
                }                
            }
            return View(movies);
        }
        public async Task<IActionResult> Search(String searchString)
        {            
            if (searchString is null)
            {
                return RedirectToAction("Index");
            }
            ViewData["SEARCH"] = searchString;
            DiscoverMovieRequest searchMovies = await client.SearchMovie(searchString);
            return View(searchMovies.Movies);
        }
        [HttpPost]
        [UserAuthorize]
        public IActionResult AddToList(int idMovie)
        {
            this.repo.token = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Movie movie = client.GetMovie(idMovie).Result;
            String user = HttpContext.User.Identity.Name;
            repo.AddMovieToList(idMovie, user);
            return RedirectToAction("Movie", movie);
        }
        [HttpPost]
        [UserAuthorize]
        public IActionResult RemoveFromList(int idMovie)
        {
            this.repo.token = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Movie movie = client.GetMovie(idMovie).Result;
            String user = HttpContext.User.Identity.Name;            
            repo.RemoveMovieFromList(idMovie, user);
            return RedirectToAction("Movie", movie);            
        }
    }
}
