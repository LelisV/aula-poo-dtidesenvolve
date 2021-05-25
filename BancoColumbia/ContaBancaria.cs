using System;

namespace BancoColumbia.Api
{
    public abstract class ContaBancaria
    {
        public int Numero { get; set; }
        public string CpfDono { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataCriacao { get; set; }

        public ContaBancaria(int numero, string cpfDono, decimal saldo, DateTime dataCriacao)
        {
            Numero = numero;
            CpfDono = cpfDono;
            Saldo = saldo;
            DataCriacao = dataCriacao;
        }

        public abstract void Saque(decimal quantidade);
        public abstract void Deposito(decimal quantidade);
    }
}
