using CinemaParadiso.Providers;
using CinemaParadiso.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CinemaParadiso.Data
{    
    public class MovieClient
    {
        public String URI { get; }
        public String Language { get; set; }
        public String Region { get; set; }
        IConfiguration configuration;        
        public MovieClient(IConfiguration configuration)
        {
            URI = "https://api.themoviedb.org/3/";
            Language = "language=es";
            Region = "region=ES";
            this.configuration = configuration;
        }
        /// <summary>
        /// Returns a movie from the API.
        /// </summary>
        /// <param name="idMovie">int. The id of the movie</param>
        /// <returns>Movie. A movie object.</returns>
        public async Task<Movie> GetMovie(int idMovie)
        {           
            string request = "movie/" + idMovie + "?" + this.Language + "&append_to_response=casts&api_key=" + configuration["apiKey"];
            String responseString = await ApiRequest(request, configuration["apiKey"]);
            responseString =  "[" + responseString + "]";
            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(responseString);
            return movies.FirstOrDefault();            
        }
        /// <summary>
        /// Discover the movies in theatre untill last month since today.
        /// </summary>
        /// <param name="sortMethod">Enum. The sort option</param>
        /// <param name="option">Enum. Include adult movies or not</param>
        /// <returns></returns>
        public async Task<DiscoverMovieRequest> DiscoverInTheatreMovies(Sort sortMethod, IncludeAdult option)
        {
            DateTime date = DateTime.Now;           
            String request = "discover/movie?";
            request += this.Language;
            request += "&" + this.Region;
            request += "&primary_release_date.gte=" + date.AddMonths(-1).ToString("yyyy-MM-dd");
            request += "&primary_release_date.lte=" + date.ToString("yyyy-MM-dd");
            request += "&sort_by=" + DiscoverProvider.SortBy(sortMethod);                
            String responseString = await ApiRequest(request, configuration["apiKey"]);                
            responseString = "[" + responseString + "]";
            List<DiscoverMovieRequest> movies = JsonConvert.DeserializeObject<List<DiscoverMovieRequest>>(responseString);
            return movies.FirstOrDefault();            
        }
        /// <summary>
        /// Discover movies rated G for kids.
        /// </summary>
        /// <param name="sortMethod">Enum. The sort option.</param>
        /// <param name="option">Enum. Include adult movies or not.</param>
        /// <returns></returns>
        public async Task<DiscoverMovieRequest> DiscoverKidsMovies(Sort sortMethod, IncludeAdult option)
        {
            DateTime date = DateTime.Now;
            String request = "discover/movie?";
            request += this.Language;
            request += "&" + this.Region;
            request += "&certification.lte=G";            
            request += "&sort_by=" + DiscoverProvider.SortBy(sortMethod);
            String responseString = await ApiRequest(request, configuration["apiKey"]);
            responseString = "[" + responseString + "]";
            List<DiscoverMovieRequest> movies = JsonConvert.DeserializeObject<List<DiscoverMovieRequest>>(responseString);
            return movies.FirstOrDefault();
        }
        /// <summary>
        /// Discover popular movies in Spain.
        /// </summary>
        /// <param name="sortMethod">Enum. The sort option.</param>
        /// <param name="option">Enum. Include adult movies or not.</param>
        /// <returns></returns>
        public async Task<DiscoverMovieRequest> DiscoverSpainMovies(Sort sortMethod, IncludeAdult option)
        {            
            String request = "discover/movie?";
            request += this.Language;
            request += "&" + this.Region;
            request += "&certification_country=ES";
            request += "&sort_by=" + DiscoverProvider.SortBy(sortMethod);
            String responseString = await ApiRequest(request, configuration["apiKey"]);
            responseString = "[" + responseString + "]";
            List<DiscoverMovieRequest> movies = JsonConvert.DeserializeObject<List<DiscoverMovieRequest>>(responseString);
            return movies.FirstOrDefault();
        }
        /// <summary>
        /// Discover movies filtered by genre.
        /// </summary>
        /// <param name="sortMethod">Enum. The sort option.</param>
        /// <param name="option">Enum. Include adult movies or not.</param>
        /// <returns></returns>
        public async Task<DiscoverMovieRequest> DiscoverGenreMovies(int genre, Sort sortMethod, IncludeAdult option)
        {            
            String request = "discover/movie?";
            request += this.Language;
            request += "&" + this.Region;
            request += "&with_genres=" + genre;
            request += "&sort_by=" + DiscoverProvider.SortBy(sortMethod);
            String responseString = await ApiRequest(request, configuration["apiKey"]);
            responseString = "[" + responseString + "]";
            List<DiscoverMovieRequest> movies = JsonConvert.DeserializeObject<List<DiscoverMovieRequest>>(responseString);
            return movies.FirstOrDefault();
        }
        /// <summary>
        /// Search for a movie.
        /// </summary>
        /// <param name="search">String. The search info.</param>
        /// <param name="sortMethod">Enum. The sort option.</param>
        /// <param name="option">Enum. Include adult movies or not.</param>
        /// <returns></returns>
        public async Task<DiscoverMovieRequest> SearchMovie(String search)
        {
            String request = "search/movie?";
            request += this.Language;
            request += "&" + this.Region;
            request += "&query=" + search;            
            String responseString = await ApiRequest(request, configuration["apiKey"]);
            responseString = "[" + responseString + "]";
            List<DiscoverMovieRequest> movies = JsonConvert.DeserializeObject<List<DiscoverMovieRequest>>(responseString);
            return movies.FirstOrDefault();
        }
        /// <summary>
        /// Do an API request.
        /// </summary>
        /// <param name="request">http get params to the request</param>
        /// <returns></returns>
        private async Task<String> ApiRequest(String request, String apiKey)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(this.URI);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.GetAsync(request + "&api_key=" + apiKey);
                String responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }                
        }
    }
}
