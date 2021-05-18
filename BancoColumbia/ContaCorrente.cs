using System;

namespace BancoColumbia.Api
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(int numero, string cpfDono, decimal saldo, DateTime dataCriacao) : base(numero, cpfDono, saldo, dataCriacao)
        {

        }
    }
}
