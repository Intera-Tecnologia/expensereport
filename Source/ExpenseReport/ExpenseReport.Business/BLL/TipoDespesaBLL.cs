using ExpenseReport.Business.Entities;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace ExpenseReport.Business.BLL
{
    public class TipoDespesaBLL : BaseBLL
    {
        public List<TipoDespesa> Listagem()
        {
            this.InicializarConexao();

            string strConsulta = "SELECT * FROM TipoDespesa ORDER BY TipoDespesaID";

            List<TipoDespesa> lista = Conexao
                .Query<TipoDespesa>(strConsulta)
                .ToList();
            return lista;
        }
    }
}
