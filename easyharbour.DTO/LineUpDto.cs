using System;
using System.Collections.Generic;
using System.Text;

namespace easyharbour.DTO
{
    public class LineUpDto
    {
        public int Posicao { get; set; }
        public string Navio { get; set; }
        public double Calado { get; set; }
        public double Largura { get; set; }
        public DateTime Datachegada { get; set; }
        public string TempoEspera { get; set; }
        public string Produto { get; set; }
        public Double Capacidade { get; set; }
        public string Prioridade { get; set; }
        public DateTime? AtracacaoSugerida { get; set; }
        public DateTime? AtracacaoPrevista { get; set; }

        public string Berco { get; set; }
    }
}
