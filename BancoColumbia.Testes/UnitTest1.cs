using BancoColumbia.Api;
using BancoColumbia.Api.Excecoes;
using BancoColumbia.Api.Repositorios;
using Moq;
using Xunit;

namespace BancoColumbia.Testes
{
    public class UnitTest1
    {
        [Fact]
        public void Tentar_Cadastrar_Usuario_Ja_Existe()
        {
            // Arrange
            // Prepara o cen�rio do seu teste criando vari�vel de entrada, etc.
            var mockUsuarioRepositorio = new Mock<IUsuarioRepositorio>();
            var usuario = new Usuario("cpfusuario", "nome usuario", 18, "12345");

            mockUsuarioRepositorio.Setup(m => m.UsuarioExiste(usuario)).Returns(true).Verifiable();

            var cadastrarUsuarioExecutor = new CadastrarUsuarioExecutor(mockUsuarioRepositorio.Object);

            // Act & Assert
            // Voc� chamada o m�todo que quer testar
            // Voc� verifica se o m�todo se comportou como esperado pro cen�rio criado
            Assert.Throws<UsuarioJaExisteException>(() => cadastrarUsuarioExecutor.Cadastrar(usuario));
            mockUsuarioRepositorio.VerifyAll();
            mockUsuarioRepositorio.VerifyNoOtherCalls();
        }

        [Fact]
        public void Cadastrar_Usuario_Sucesso()
        {
            // Arrange
            var mockUsuarioRepositorio = new Mock<IUsuarioRepositorio>();
            var usuario = new Usuario("cpfusuario", "nome usuario", 18, "12345");

            mockUsuarioRepositorio.Setup(m => m.UsuarioExiste(usuario)).Returns(false).Verifiable();
            mockUsuarioRepositorio.Setup(m => m.SalvarUsuario(usuario)).Verifiable();

            var cadastrarUsuarioExecutor = new CadastrarUsuarioExecutor(mockUsuarioRepositorio.Object);

            // Act
            cadastrarUsuarioExecutor.Cadastrar(usuario);

            // Assert
            mockUsuarioRepositorio.VerifyAll();
            mockUsuarioRepositorio.VerifyNoOtherCalls();
        }
    }
}
