using System;

namespace APIIndicadores.Models
{
    public class BolsaValores
    {
        public string Sigla { get; set; }
        public string NomeBolsa { get; set; }
        public DateTime DataReferencia { get; set; }
        public decimal Variacao { get; set; }
    }
}