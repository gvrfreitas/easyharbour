using System;
using System.Collections.Generic;
using System.Text;

namespace easyharbour.DTO
{
    public class OperacaoDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Berco { get; set; }

        public string Produto { get; set; }

        public double PesoBruto { get; set; }

        public string PortoDestino { get; set; }

        public DateTime? AtracacaoEfetiva { get; set; }

        public double Laytime { get; set; }

        public DateTime DesatracacaoPrevista { get; set; }

        public DateTime? DesatracacaoEfetiva { get; set; }
    }
}
