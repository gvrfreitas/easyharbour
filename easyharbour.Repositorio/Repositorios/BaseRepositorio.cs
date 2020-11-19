using VLI.SIOP.Operacao.Dados;

namespace easyharbour.Repositorio
{
    public class BaseRepositorio
    {
        public AplicacaoContexto Contexto { get; private set; }

        public BaseRepositorio(AplicacaoContexto contexto)
        {
            this.Contexto = contexto;
        }
    }
}
