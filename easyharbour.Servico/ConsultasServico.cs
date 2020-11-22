using System;
using System.Collections.Generic;
using System.Text;

namespace easyharbour.Servico
{
    public class ConsultasServico
    {
        public readonly AtracacaoServico _atracacaoServico;
        public readonly NaviooServico _naviooServico;
        public readonly BercoGraoServico _bercoGraoServico;

        public ConsultasServico(AtracacaoServico atracacaoServico,
                                NaviooServico naviooServico,
                                BercoGraoServico bercoGraoServico )
        {
            _atracacaoServico = atracacaoServico;
            _naviooServico = naviooServico;
            _bercoGraoServico = bercoGraoServico;
        }
    }
}
