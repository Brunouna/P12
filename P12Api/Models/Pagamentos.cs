using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P12Api
{
    public class Pagamentos
    {
        public int Id { get; set; }
        public int IdApartamento { get; set; }
        public string Apartamento { get; set; }
        public DateTime DataPagamento { get; set; }
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