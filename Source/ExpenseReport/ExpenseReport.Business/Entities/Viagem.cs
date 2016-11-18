using System;
using System.Collections.Generic;

namespace ExpenseReport.Business.Entities
{
    public class Viagem
    {
        public long ViagemID { get; set; }
        public string Descricao { get; set; }
        public string Justificativa { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public long ProjetoID { get; set; }

        public Projeto Projeto { get; set; }
        public List<Relatorio> Relatorios { get; set; } = new List<Relatorio>();
    }
}
