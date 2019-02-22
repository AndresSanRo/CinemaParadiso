using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{
    public class DiscoverMovie
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("title")]
        public String Title { get; set; }
        [JsonProperty("poster_path")]
        public String PosterPath { get; set; }

    }
}
