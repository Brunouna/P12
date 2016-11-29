using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P12Api
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public bool Sindico { get; set; } 
    }
}