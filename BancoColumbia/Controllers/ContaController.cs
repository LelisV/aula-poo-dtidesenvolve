using BancoColumbia.Api.Excecoes;
using Microsoft.AspNetCore.Mvc;

namespace BancoColumbia.Api.Controllers
{
    [ApiController]
    [Route("contas")]
    public class ContaController : ControllerBase
    {

        private CriarContaBancariaExecutor _criarContaBancariaExecutor;

        public ContaController(CriarContaBancariaExecutor criarContaBancariaExecutor)
        {
            _criarContaBancariaExecutor = criarContaBancariaExecutor;
        }

        [HttpPost]
        [Route("{cpf}/corrente")]
        public IActionResult CriarContaCorrente([FromRoute] string cpf)
        {
            try
            {
                var contaCriada = _criarContaBancariaExecutor.CriarContaCorrente(cpf);

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
        public IActionResult CriarContaPoupanca([FromRoute] string cpf)
        {
            try
            {
                var contaCriada = _criarContaBancariaExecutor.CriarContaPoupanca(cpf);

                // 201 -- recurso criado
                return Created(string.Empty, contaCriada);
            }
            catch (UsuarioNaoExisteException exception)
            {
                // 400 -- Bad request
                return BadRequest(exception.Message);
            }
        }

    }
}
