using System;
using System.Collections.Generic;

namespace ExpenseReport.Business.Entities
{
    public class RelatorioDespesa
    {
        public long RelatorioDespesaID { get; set; }
        public long RelatorioID { get; set; }
        public long FonteDespesaID { get; set; }
        public long TipoDespesaID { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public bool Faturado { get; set; }

        public Relatorio Relatorio { get; set; }
        public FonteDespesa FonteDespesa { get; set; }
        public TipoDespesa TipoDespesa { get; set; }
        public List<Imagem> Imagens { get; set; } = new List<Imagem>();
    }
}
