using System;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Models
{
    public class DoacaoModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public double Frete { get; set; }
        public int Quantidade { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataRegistro { get; set; }
        public bool Estado { get; set; }

    }
}
