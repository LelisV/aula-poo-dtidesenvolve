using System;

namespace BancoColumbia.Api.Excecoes
{
    public class FundoInsuficienteException : Exception
    {

        public FundoInsuficienteException(string mensagem) : base(mensagem)
        {

        }

    }
}
