using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{    
    public class MovieClient
    {
        public String URI { get; }
        public String Language { get; set; }
        IConfiguration configuration;        
        public MovieClient(IConfiguration configuration)
        {
            URI = "https://api.themoviedb.org/3/";
            Language = "language=es";
            this.configuration = configuration;
        }
        public async Task<Movie> GetMovie(int idMovie)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string requestPath = "movie/" + idMovie + "?" + this.Language + "&append_to_response=casts&api_key=" + configuration["apiKey"];
                httpClient.BaseAddress = new Uri(this.URI);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                HttpResponseMessage response = await httpClient.GetAsync(requestPath);
                String responseString = await response.Content.ReadAsStringAsync();
                responseString =  "[" + responseString + "]";
                List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(responseString);
                return movies.First();
            }
        }        
    }
}
