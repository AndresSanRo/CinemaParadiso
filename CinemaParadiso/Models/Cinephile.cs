using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{    
    public class Cinephile
    {        
        public String Email { get; set; }        
        public String Password { get; set; }        
        public String Name { get; set; }        
        public String LastName { get; set; }        
        public int Age { get; set; }        
        public String Image { get; set; }
    }
}
