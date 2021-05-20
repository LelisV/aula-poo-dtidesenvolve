using BancoColumbia.Api.Repositorios;
using System.Collections.Generic;

namespace BancoColumbia.Api
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        // Base fictícia
        private List<Usuario> _usuarios;

        public UsuarioRepositorio()
        {
            _usuarios = new List<Usuario>();
        }

        public bool UsuarioExiste(Usuario usuarioAVerificar)
        {
            bool existe = _usuarios.Exists(us => us.Cpf == usuarioAVerificar.Cpf);

            return existe;
        }

        public bool UsuarioExiste(string cpf)
        {
            bool existe = _usuarios.Exists(us => us.Cpf == cpf);

            return existe;
        }

        public void SalvarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }
    }
}
