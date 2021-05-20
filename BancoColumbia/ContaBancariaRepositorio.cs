﻿using BancoColumbia.Api.Repositorios;
using System.Collections.Generic;

namespace BancoColumbia.Api
{
    public class ContaBancariaRepositorio : IContaBancariaRepositorio
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

    }
}
