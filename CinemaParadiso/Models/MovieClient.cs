using Microsoft.Extensions.Configuration;
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
        IConfiguration configuration;        
        public MovieClient(IConfiguration configuration)
        {
            URI = "https://api.themoviedb.org/3/";
            this.configuration = configuration;
        }
        public async Task<string> GetMovie(string idMovie)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string requestPath = "movie/" + idMovie + "?api_key=" + configuration["apiKey"];
                httpClient.BaseAddress = new Uri(this.URI);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                HttpResponseMessage response = await httpClient.GetAsync(requestPath);
                String responseString = await response.Content.ReadAsStringAsync();
                return "[" + responseString + "]";
            }
        }
    }
}
