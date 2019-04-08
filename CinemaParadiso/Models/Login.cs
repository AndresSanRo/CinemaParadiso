using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Models
{
    public class Login
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public Login() { }
        public Login(String user, String pass)
        {
            UserName = user;
            Password = pass;
        }
    }
}
