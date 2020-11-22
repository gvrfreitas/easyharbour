using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace easyharbour.Common
{
    public class Enumeradores
    {


        public enum TipoProduto
        {
            [Description("Milho a granel")]
            Milho = 1,

            [Description("Soja a granel")]
            Soja = 2,

            [Description("Farelo de Soja")]
            FareloDeSoja = 3,

            [Description("Açúiar")]
            Acucar =4
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


    public static class Enumerador
    {

        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is System.Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);
                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        if (memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() is DescriptionAttribute descriptionAttribute)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return null; 
        }
    }
}
