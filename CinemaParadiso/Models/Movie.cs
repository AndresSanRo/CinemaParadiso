using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{
    public class Movie
    {
        [JsonProperty("title")]
        public String Title { get; set; }
        [JsonProperty("overview")]
        public String Overview { get; set; }
    }
}
