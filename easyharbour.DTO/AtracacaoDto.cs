﻿using System;

namespace easyharbour.DTO
{
    public class AtracacaoDto
    {
        public Guid Id { get; set; }

        public string Navio { get; set; }

        public string Operador { get; set; }

        public int Viagem { get; set; }

        public DateTime AvisoChegada { get; set; }

        public DateTime? Autorizacao { get; set; }

        public DateTime? PrevisaoAtracacao { get; set; }

        public DateTime? AtracacaoEfetiva { get; set; }

        public DateTime? Desatracacao { get; set; }

        public bool Fundiado { get; set; }

        public bool EmOperacao { get; set; }
    }
}