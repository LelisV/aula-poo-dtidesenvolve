namespace BancoColumbia.Api.Repositorios
{
    public interface IContaBancariaRepositorio
    {
        void SalvarContaBancaria(ContaBancaria contaBancaria);
        ContaBancaria ObterConta(int numeroConta);
    }
}
