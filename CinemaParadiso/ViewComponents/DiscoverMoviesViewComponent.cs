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
        Spain = 2,
        Genre =  3
    }
    public class DiscoverMoviesViewComponent : ViewComponent
    {
        MovieClient client;
        public DiscoverMoviesViewComponent(MovieClient client)
        {
            this.client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(DiscoverMethod method, Sort sortOption, IncludeAdult adultOption, int? genre)
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
                case DiscoverMethod.Spain:
                    result = await client.DiscoverSpainMovies(sortOption, adultOption);
                    break;
                case DiscoverMethod.Genre:
                    result = await client.DiscoverGenreMovies(genre.Value, sortOption, adultOption);
                    break;
            }
            return View(result.Movies);
        }
    }
}
