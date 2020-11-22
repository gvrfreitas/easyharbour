using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace easyharbour.Models
{
    [Table("BercosGraos")]
    public class BercoGrao
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Nome { get; set; }

        public double Comprimento { get; set; }

        public double CalaodBaixa { get; set; }

        public double CalaodAlta { get; set; }

        public string CaladoMaximoTrecho { get; set; }

        public double Prancha { get; set; }

    }
}
