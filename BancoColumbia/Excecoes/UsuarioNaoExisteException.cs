using System;

namespace BancoColumbia.Api.Excecoes
{
    public class UsuarioNaoExisteException : Exception
    {
        public UsuarioNaoExisteException(string mensagem) : base(mensagem)
        {

        }
    }
}
