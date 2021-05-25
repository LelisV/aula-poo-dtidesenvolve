using System;

namespace BancoColumbia.Api.Excecoes
{
    public class OperacaoInvalidaException : Exception
    {
        public OperacaoInvalidaException(string mensagem) : base(mensagem)
        {

        }

    }
}
