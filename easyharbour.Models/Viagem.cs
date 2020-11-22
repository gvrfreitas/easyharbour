using easyharbour.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static easyharbour.Common.Enumeradores;

namespace easyharbour.Model
{

    [Table("Viagens")]
    public class Viagem
    {

        [Key]
        public Guid Id { get; set; }

        public string Codigo { get; set; }

        public Guid NavioId { get; set; }

        public Guid BercoGraoId { get; set; }

        public TipoProduto TipoProduto { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public double Quantidade { get; set; }

        public Status Status { get; set; }

        [ForeignKey("NavioId")]
        public virtual Navio Navio { get; set; }


        [ForeignKey("BercoGraoId")]
        public virtual BercoGrao BercoGrao { get; set; }

    }
}
