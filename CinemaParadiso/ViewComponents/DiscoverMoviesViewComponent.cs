using CinemaParadiso.Models;
using CinemaParadiso.Data;
using CinemaParadiso.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.ViewComponents
{
    public enum DiscoverMethod
    {
        InTheatre = 0,
        Kids = 1,
        something
    }
    public class DiscoverMoviesViewComponent : ViewComponent
    {
        MovieClient client;
        public DiscoverMoviesViewComponent(MovieClient client)
        {
            this.client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(DiscoverMethod method, Sort sortOption, IncludeAdult adultOption)
        {
            DiscoverMovieRequest result = new DiscoverMovieRequest();
            switch (method)
            {
                case DiscoverMethod.InTheatre:
                    result = await client.DiscoverInTheatreMovies(sortOption, adultOption);
                    break;
                case DiscoverMethod.Kids:
                    result = await client.DiscoverKidsMovies(sortOption, adultOption);
                    break;
            }
            return View(result.Movies);
        }
    }
}
