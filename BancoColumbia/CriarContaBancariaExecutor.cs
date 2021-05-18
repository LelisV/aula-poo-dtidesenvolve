using BancoColumbia.Api.Excecoes;
using System;

namespace BancoColumbia.Api
{
    public class CriarContaBancariaExecutor
    {

        private UsuarioRepositorio _usuarioRepositorio;
        private ContaBancariaRepositorio _contaBancariaRepositorio;

        public CriarContaBancariaExecutor(UsuarioRepositorio usuarioRepositorio, ContaBancariaRepositorio contaBancariaRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contaBancariaRepositorio = contaBancariaRepositorio;
        }

        public ContaCorrente CriarContaCorrente(string cpf)
        {
            if (!_usuarioRepositorio.UsuarioExiste(cpf))
            {
                throw new UsuarioNaoExisteException($"O usuário de CPF {cpf} não existe na base.");
            }

            var random = new Random();
            var numeroConta = random.Next(100000, 999999);
            var contaCorrente = new ContaCorrente(numeroConta, cpf, 0, DateTime.Now);

            _contaBancariaRepositorio.SalvarContaBancaria(contaCorrente);

            return contaCorrente;
        }

        public ContaPoupanca CriarContaPoupanca(string cpf)
        {
            if (!_usuarioRepositorio.UsuarioExiste(cpf))
            {
                throw new UsuarioNaoExisteException($"O usuário de CPF {cpf} não existe na base.");
            }

            var random = new Random();
            var numeroConta = random.Next(100000, 999999);
            var contaPoupanca = new ContaPoupanca(numeroConta, cpf, 10, DateTime.Now);

            _contaBancariaRepositorio.SalvarContaBancaria(contaPoupanca);

            return contaPoupanca;
        }

    }
}
