using BancoColumbia.Api.Excecoes;
using BancoColumbia.Api.Repositorios;

namespace BancoColumbia.Api
{
    public class CadastrarUsuarioExecutor
    {
        public IUsuarioRepositorio _usuarioRepositorio;

        public CadastrarUsuarioExecutor(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void Cadastrar(Usuario usuario)
        {
            if (_usuarioRepositorio.UsuarioExiste(usuario))
            {
                throw new UsuarioJaExisteException("Já existe um usuário cadastrado com o mesmo CPF.");
            }

            _usuarioRepositorio.SalvarUsuario(usuario);
        }
    }
}
