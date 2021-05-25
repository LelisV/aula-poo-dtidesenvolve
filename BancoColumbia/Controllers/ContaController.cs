using BancoColumbia.Api.Excecoes;
using BancoColumbia.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BancoColumbia.Api.Controllers
{
    [ApiController]
    [Route("contas")]
    public class ContaController : ControllerBase
    {

        private AtualizarSaldoExecutor _atualizarSaldoExecutor;

        public ContaController(AtualizarSaldoExecutor atualizarSaldoExecutor)
        {
            _atualizarSaldoExecutor = atualizarSaldoExecutor;
        }

        [HttpPost]
        [Route("{cpf}/corrente")]
        public IActionResult CriarContaCorrente([FromServices] CriarContaBancariaExecutor criarContaBancariaExecutor, [FromRoute] string cpf)
        {
            try
            {
                var contaCriada = criarContaBancariaExecutor.CriarContaCorrente(cpf);

                // 201 -- recurso criado
                return Created(string.Empty, contaCriada);
            }
            catch (UsuarioNaoExisteException exception)
            {
                // 400 -- Bad request
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        [Route("{cpf}/poupanca")]
        public IActionResult CriarContaPoupanca([FromServices] CriarContaBancariaExecutor criarContaBancariaExecutor, [FromRoute] string cpf)
        {
            try
            {
                var contaCriada = criarContaBancariaExecutor.CriarContaPoupanca(cpf);

                // 201 -- recurso criado
                return Created(string.Empty, contaCriada);
            }
            catch (UsuarioNaoExisteException exception)
            {
                // 400 -- Bad request
                return BadRequest(exception.Message);
            }
        }

        [HttpPatch]
        [Route("{cpf}/saldo")]
        public IActionResult AtualizarSaldoConta([FromRoute] string cpf, [FromBody] OperacaoContaBancariaModel model)
        {
            try
            {
                var operacaoContaBancaria = new OperacaoContaBancaria(model.NumeroConta, model.TipoOperacao, model.QuantidadeDinheiro, cpf);
                var saldoAtualizado = _atualizarSaldoExecutor.AtualizarSaldo(operacaoContaBancaria);
                return Accepted(saldoAtualizado);
            }
            catch (Exception exception)
            {
                // 400 -- Bad request
                return BadRequest(exception.Message);
            }
        }
    }
}
