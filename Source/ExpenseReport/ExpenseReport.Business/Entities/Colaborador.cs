using System.Collections.Generic;

namespace ExpenseReport.Business.Entities
{
    public class Colaborador
    {
        public long ColaboradorID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public long TokenID { get; set; }

        public Token UserToken { get; set; }
        public List<Relatorio> Relatorios { get; set; } = new List<Relatorio>();
    }
}
