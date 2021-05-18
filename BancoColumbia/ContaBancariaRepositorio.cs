using System.Collections.Generic;

namespace BancoColumbia.Api
{
    public class ContaBancariaRepositorio
    {
        // base fictícia de contas bancarias
        private List<ContaBancaria> _contasBancarias;

        public ContaBancariaRepositorio()
        {
            _contasBancarias = new List<ContaBancaria>();
        }

        public void SalvarContaBancaria(ContaBancaria contaBancaria)
        {
            _contasBancarias.Add(contaBancaria);
        }

        public TipoConta ObterTipoContaBancaria(int numeroConta)
        {
            var contaBancaria = _contasBancarias.Find(conta => conta.Numero == numeroConta);
            
            if (contaBancaria is ContaCorrente)
            {
                return TipoConta.Corrente;
            }

            return TipoConta.Poupanca;
        }

    }
}
