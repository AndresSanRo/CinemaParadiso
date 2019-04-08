using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaParadiso.Repositories;
using Microsoft.AspNetCore.Mvc;
using CinemaParadiso.Models;
using CinemaParadiso.Data;

namespace CinemaParadiso.Controllers
{
    public class ProfileController : Controller
    {
        IRepositoryCinephile repo;
        MovieClient client;
        public ProfileController(IRepositoryCinephile repo, MovieClient client)
        {
            this.repo = repo;
            this.client = client;
        }
        public async Task<IActionResult> Profile()
        {
            Cinephile user = await repo.GetUser(HttpContext.User.Identity.Name);            
            List<Lists> listMovies = await repo.GetUserList(HttpContext.User.Identity.Name);
            List<Movie> movies = new List<Movie>();
            if (listMovies != null)
            {
                foreach (Lists lItem in listMovies)
                {
                    movies.Add(await client.GetMovie(lItem.IdMovie));
                }
            }
            ViewData["LIST"] = movies;
            return View(user);
        }
    }
}