using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{
    public class DiscoverMovieRequest
    {
        [JsonProperty("page")]
        public int CurrentPage { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set;}
        [JsonProperty("results")]
        [JsonConverter(typeof(SingleOrArrayConverter<DiscoverMovie>))]
        public List<DiscoverMovie> Movies { get; set; }
    }
}
