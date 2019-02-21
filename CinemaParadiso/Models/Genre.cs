using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{
    public class Genre
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
    }
}
