using CinemaParadiso.Models;
using CinemaParadiso.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.ViewComponents
{
    public class DiscoverMoviesViewComponent : ViewComponent
    {
        MovieClient client;
        public DiscoverMoviesViewComponent(MovieClient client)
        {
            this.client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(Sort sortOption, IncludeAdult adultOption)
        {
            List<Movie> movies = await client.DiscoverMovies(sortOption, adultOption);
            return View();
        }
    }
}
