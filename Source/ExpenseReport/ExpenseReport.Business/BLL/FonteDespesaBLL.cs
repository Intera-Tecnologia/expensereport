using ExpenseReport.Business.Entities;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace ExpenseReport.Business.BLL
{
    public class FonteDespesaBLL : BaseBLL
    {
        public List<FonteDespesa> Listagem()
        {
            this.InicializarConexao();

            string strConsulta = 
                "SELECT * FROM FonteDespesa ORDER BY FonteDespesaID";

            List<FonteDespesa> lista = Conexao
                .Query<FonteDespesa>(strConsulta)
                .ToList();
            return lista;
        }
    }
}
