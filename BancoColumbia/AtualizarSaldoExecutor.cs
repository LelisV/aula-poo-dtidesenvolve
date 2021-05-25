using BancoColumbia.Api.Excecoes;
using BancoColumbia.Api.Repositorios;

namespace BancoColumbia.Api
{
    public class AtualizarSaldoExecutor
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IContaBancariaRepositorio _contaBancariaRepositorio;

        public AtualizarSaldoExecutor(IUsuarioRepositorio usuarioRepositorio, IContaBancariaRepositorio contaBancariaRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contaBancariaRepositorio = contaBancariaRepositorio;
        }

        public decimal AtualizarSaldo(OperacaoContaBancaria operacaoContaBancaria)
        {
            // validar se usuario existe
            if (!_usuarioRepositorio.UsuarioExiste(operacaoContaBancaria.CpfDonoConta))
            {
                throw new UsuarioNaoExisteException($"O usuário de CPF {operacaoContaBancaria.CpfDonoConta} não existe");
            }

            // obter a conta pelo numero dela
            var contaBancaria = _contaBancariaRepositorio.ObterConta(operacaoContaBancaria.NumeroConta);
            if (contaBancaria == null)
            {
                throw new ContaNaoExisteException($"A conta bancária de número {operacaoContaBancaria.NumeroConta} não existe");
            }
            
            // validar se a conta é do mesmo usuario que foi passado
            if (contaBancaria.CpfDono != operacaoContaBancaria.CpfDonoConta)
            {
                throw new NaoAutorizadoException($"O usuário de CPF {operacaoContaBancaria.CpfDonoConta} não tem permissão para modificar a conta {operacaoContaBancaria.NumeroConta}");
            }

            // verificar tipo operacao
            switch(operacaoContaBancaria.TipoOperacao)
            {
                case 1: 
                    // chamar saque;
                    Sacar(contaBancaria, operacaoContaBancaria.QuantidadeDinheiro);
                    break;
                case 2:
                    Depositar(contaBancaria, operacaoContaBancaria.QuantidadeDinheiro);
                    // chamar deposito;
                    break;
                default: throw new OperacaoInvalidaException($"A operação de número {operacaoContaBancaria.TipoOperacao} não existe ou está indisponível no momento");
            }

            return contaBancaria.Saldo;
        }

        private void Sacar(ContaBancaria contaBancaria, decimal valorSaque)
        {
            if (contaBancaria.Saldo >= valorSaque + Constantes.TAXA_SAQUE)
            {
                contaBancaria.Saque(valorSaque);

                return;
            }

            throw new FundoInsuficienteException($"A conta {contaBancaria.Numero} tem fundos insuficientes para saque considerando o valor da taxa");
        }

        private void Depositar(ContaBancaria contaBancaria, decimal valorDeposito)
        {
            contaBancaria.Deposito(valorDeposito);
        }

    }
}
