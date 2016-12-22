using System;
using System.Collections.Generic;

namespace ExpenseReport.Business.Entities
{
    public class Relatorio
    {
        public long RelatorioID { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal DiariasRecebidas { get; set; }
        public decimal AdiantamentoRecebido { get; set; }
        public decimal CambioDia { get; set; }
        public string Moeda { get; set; }
        public decimal PassagemFaturada { get; set; }
        public long ColaboradorID { get; set; }
        public long ViagemID { get; set; }

        public Colaborador Colaborador { get; set; }
        public Viagem Viagem { get; set; }
        public List<RelatorioDespesa> Despesas { get; set; } = new List<RelatorioDespesa>();

        public DateTime DataViagemInicio { get; set; }
        public DateTime DataViagemFim { get; set; }
    }
}
