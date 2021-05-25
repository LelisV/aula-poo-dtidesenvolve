namespace BancoColumbia.Api.Models
{
    public class OperacaoContaBancariaModel
    {
        public int NumeroConta { get; set; }
        public int TipoOperacao { get; set; }
        public decimal QuantidadeDinheiro { get; set; }
    }
}
