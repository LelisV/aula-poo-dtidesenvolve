namespace BancoColumbia.Api
{
    public class OperacaoContaBancaria
    {
        public int NumeroConta { get; set; }
        public int TipoOperacao { get; set; }
        public decimal QuantidadeDinheiro { get; set; }
        public string CpfDonoConta { get; set; }

        public OperacaoContaBancaria(int numeroConta, int tipoOperacao, decimal quantidadeDinheiro, string cpfDonoConta)
        {
            NumeroConta = numeroConta;
            TipoOperacao = tipoOperacao;
            QuantidadeDinheiro = quantidadeDinheiro;
            CpfDonoConta = cpfDonoConta;
        }
    }
}
