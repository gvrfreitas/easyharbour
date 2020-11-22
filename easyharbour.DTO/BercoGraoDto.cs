using System;


namespace easyharbour.DTO
{
    public class BercoGraoDto
    {
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
