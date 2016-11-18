using System.Collections.Generic;

namespace ExpenseReport.Business.Entities
{
    public class Colaborador
    {
        public long ColaboradorID { get; set; }
        public string Nome { get; set; }

        public List<Relatorio> Relatorios { get; set; } = new List<Relatorio>();
    }
}
