using System;

namespace BancoColumbia.Api.Excecoes
{
    public class ContaNaoExisteException : Exception
    {

        public ContaNaoExisteException(string mensagem) : base(mensagem)
        {

        }
        
    }
}
