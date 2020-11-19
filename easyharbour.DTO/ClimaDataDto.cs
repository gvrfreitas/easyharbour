using System;
using System.Collections.Generic;
using System.Text;

namespace easyharbour.DTO
{
    public class Temperature
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class ClimaDataDto
    {
        public DateTime DateTime { get; set; }
        public int EpochDateTime { get; set; }
        public int WeatherIcon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public bool IsDaylight { get; set; }
        public Temperature Temperature { get; set; }
        public int PrecipitationProbability { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }


    public class ClimaDozeHorasDTo
    {
        public DateTime Data { get; set; }
        public int ChanceChuva { get; set; }
        public string Descricao { get; set; }
        public bool Chovendo { get; set; }
        public double Temperatura { get; set; }
    }

}
