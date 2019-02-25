using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{
    [Table("CINEPHILES")]
    public class Cinephile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("EMAIL")]
        public String Email { get; set; }
        [Column("PASSWORDHASH")]
        public String Password { get; set; }
        [Column("CINENAME")]
        public String Name { get; set; }
        [Column("CINELASTNAME")]
        public String LastName { get; set; }
        [Column("AGE")]
        public int Age { get; set; }
        [Column("CINEIMAGE")]
        public String Image { get; set; }
    }
}
