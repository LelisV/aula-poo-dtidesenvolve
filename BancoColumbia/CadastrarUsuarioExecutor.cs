using BancoColumbia.Api.Excecoes;

namespace BancoColumbia.Api
{
    public class CadastrarUsuarioExecutor
    {

        public UsuarioRepositorio usuarioRepositorio;

        public CadastrarUsuarioExecutor(UsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public void Cadastrar(Usuario usuario)
        {
            if (usuarioRepositorio.UsuarioExiste(usuario))
            {
                throw new UsuarioJaExisteException("Já existe um usuário cadastrado com o mesmo CPF.");
            }

            usuarioRepositorio.SalvarUsuario(usuario);
        }

    }
}
