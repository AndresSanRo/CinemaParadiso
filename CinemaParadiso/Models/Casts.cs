using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{
    public class Casts
    {
        [JsonProperty("cast")]
        [JsonConverter(typeof(SingleOrArrayConverter<Cast>))]
        public List<Cast> Cast { get; set; }
        [JsonProperty("crew")]
        [JsonConverter(typeof(SingleOrArrayConverter<Crew>))]
        public List<Crew> Crew { get; set; }
    }
}
