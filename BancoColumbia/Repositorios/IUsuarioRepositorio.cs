namespace BancoColumbia.Api.Repositorios
{
    public interface IUsuarioRepositorio
    {
        bool UsuarioExiste(Usuario usuarioAVerificar);

        bool UsuarioExiste(string cpf);

        void SalvarUsuario(Usuario usuario);
    }
}
