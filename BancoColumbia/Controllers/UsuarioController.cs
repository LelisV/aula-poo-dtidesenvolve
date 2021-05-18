using BancoColumbia.Api.Excecoes;
using BancoColumbia.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BancoColumbia.Api.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        // o controller tem que herdar da super classe de controllers do framework (ControllerBase)
        // por padrão o controller tem a rota no plural

        private CadastrarUsuarioExecutor _cadastrarUsuarioExecutor;

        public UsuarioController(CadastrarUsuarioExecutor cadastrarUsuarioExecutor)
        {
            _cadastrarUsuarioExecutor = cadastrarUsuarioExecutor;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(UsuarioModel usuarioModel)
        {
            //instancio objeto
            var novoUsuario = new Usuario(usuarioModel.Cpf, usuarioModel.NomeCompleto, usuarioModel.Idade, usuarioModel.Senha);

            try
            {
                _cadastrarUsuarioExecutor.Cadastrar(novoUsuario);

                // 201 -- Created
                return Created(string.Empty, novoUsuario);
            }
            catch (UsuarioJaExisteException exception)
            {
                // 400 -- Bad request
                return BadRequest(exception.Message);
            }
        }
    }
}
