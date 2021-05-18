using System;

namespace BancoColumbia.Api
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(int numero, string cpfDono, decimal saldo, DateTime dataCriacao) : base(numero, cpfDono, saldo, dataCriacao)
        {

        }
    }
}
