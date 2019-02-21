using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{
    public class Crew
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("job")]
        public String Job { get; set; }
        [JsonProperty("department")]
        public String Department { get; set; }
        [JsonProperty("profile_path")]
        public String ProfilePath { get; set; }        
    }
}
