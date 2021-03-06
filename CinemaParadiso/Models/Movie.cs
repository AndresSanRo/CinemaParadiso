﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("title")]
        public String Title { get; set; }
        [JsonProperty("overview")]
        public String Overview { get; set; }        
        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }
        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }
        [JsonProperty("poster_path")]
        public string Poster { get; set; }
        [JsonProperty("genres")]
        [JsonConverter(typeof(SingleOrArrayConverter<Genre>))]
        public List<Genre> Genres { get; set; }
        [JsonProperty("casts")]
        public Casts People { get; set; }
        public static String ImagesPath { get; set; }
        public Movie()
        {
            ImagesPath = "https://image.tmdb.org/t/p/w500/";
        }
    }
}
