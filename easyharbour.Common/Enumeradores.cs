using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace easyharbour.Common
{
    public class Enumeradores
    {


        public enum TipoProduto
        {
            Milho = 1,
            Soja = 2,
            FareloDeSoja = 3,
            Cafe =4
        }

        public enum Status
        {
            [Description("Programado")]
            Programado = 1,

            [Description("Fundeado")]
            Fundeado = 2,

            [Description("Em Atracação")]
            EmAtracacao = 3,

            [Description("Atracado")]
            Atracado = 4,

            [Description("Em Carregamento")]
            EmCarregamento = 5,

            [Description("Finalizado")]
            Finalizado = 6
        }

    }
}
