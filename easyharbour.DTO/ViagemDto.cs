using System;
using static easyharbour.Common.Enumeradores;

namespace easyharbour.DTO
{
    public class ViagemDto
    {
        public Guid Id { get; set; }

        public string Codigo { get; set; }

        public Guid NavioId { get; set; }

        public Guid BercoGraoId { get; set; }

        public TipoProduto TipoProduto { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public double Quantidade { get; set; }

        public Status Status { get; set; }
    }
}
