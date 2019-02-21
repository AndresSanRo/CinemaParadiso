using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{
    public class Cast
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("cast_id")]
        public int CastID { get; set; }
        [JsonProperty("character")]
        public String Character { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        [JsonProperty("profile_path")]
        public String ProfilePath { get; set; }
    }
}
