using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P12Api
{
    public class Apartamentos
    {
        public int Id { get; set; }
        public int Idcondomino { get; set; }
        public int Numero { get; set; }
        public bool Responsavel { get; set; }
        public bool Ocupacao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }        
        public bool Janeiro { get; set; }
        public bool Fevereiro { get; set; }
        public bool Marco { get; set; }
        public bool Abril { get; set; }
        public bool Maio { get; set; }
        public bool Junho { get; set; }
        public bool Julho { get; set; }
        public bool Agosto { get; set; }
        public bool Setembro { get; set; }
        public bool Outubro { get; set; }
        public bool Novembro { get; set; }
        public bool Dezembro { get; set; }
    }
}