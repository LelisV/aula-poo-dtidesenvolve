using System;

namespace BancoColumbia.Api.Excecoes
{
    public class UsuarioJaExisteException : Exception
    {

        public UsuarioJaExisteException(string mensagem) : base(mensagem) { }

    }
}
