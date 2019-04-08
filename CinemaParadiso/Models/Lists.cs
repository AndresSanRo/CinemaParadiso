using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{    
    public class Lists
    {                        
        public int IdMovie { get; set; }               
        public String UserEmail { get; set; }        
        //public String Review { get; set; }        
        //public int Puntuation { get; set; }
    }
}
