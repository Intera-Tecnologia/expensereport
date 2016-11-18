using System.Collections.Generic;

namespace ExpenseReport.Business.Entities
{
    public class Projeto
    {
        public long ProjetoID { get; set; }
        public string Descricao { get; set; }
        public string Programa { get; set; }
        public string CentroDeCusto { get; set; }
        public string Status { get; set; }

        List<Viagem> Viagens { get; set; } = new List<Viagem>();
    }
}
