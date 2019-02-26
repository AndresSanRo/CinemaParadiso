using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{
    [Table("LISTS")]
    public class Lists
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public int IdMovie { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        public String UserEmail { get; set; }
        //[Column("REVIEW")]
        //public String Review { get; set; }
        //[Column("PUNTUATION")]
        //public int Puntuation { get; set; }
    }
}
