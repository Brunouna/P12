using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P12Api
{
    public class Condominos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Responsavel { get; set; }
        public bool Sindico { get; set; }
        public string Apartamento { get; set; }
    }
}