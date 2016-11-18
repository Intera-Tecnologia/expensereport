namespace ExpenseReport.Business.Entities
{
    public class Imagem
    {
        public long ImagemID { get; set; }
        public string NomeArquivo { get; set; }
        public long RelatorioDespesaID { get; set; }
        public RelatorioDespesa RelatorioDespesa { get; set; }
    }
}
