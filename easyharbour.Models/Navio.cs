using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace easyharbour.Models
{
    [Table("Navios")]
    public class Navio
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Descritivo { get; set; }

        public double Draft { get; set; }

        public double Beam { get; set; }

    }
}
