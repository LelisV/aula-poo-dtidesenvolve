using System;

namespace BancoColumbia.Api
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(int numero, string cpfDono, decimal saldo, DateTime dataCriacao) : base(numero, cpfDono, saldo, dataCriacao)
        {

        }

        public override void Deposito(decimal quantidade)
        {
            Saldo += quantidade;
        }

        public override void Saque(decimal quantidade)
        {
            Saldo -= quantidade + Constantes.TAXA_SAQUE;
        }
    }
}
