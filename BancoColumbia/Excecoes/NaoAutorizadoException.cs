using System;

namespace BancoColumbia.Api.Excecoes
{
    public class NaoAutorizadoException : Exception
    {
        public NaoAutorizadoException(string mensagem) : base(mensagem)
        {

        }

    }
}
