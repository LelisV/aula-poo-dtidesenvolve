using System.Collections;

namespace BancoColumbia.Api
{
    public class Usuario
    {
        public string Cpf { get; set; }
        public string NomeCompleto { get; set; }
        public int Idade { get; set; }
        public string Senha { get; set; }

        public Usuario(string cpf, string nomeCompleto, int idade, string senha)
        {
            Cpf = cpf;
            NomeCompleto = nomeCompleto;
            Idade = idade;
            Senha = senha;
        }
    }
}
