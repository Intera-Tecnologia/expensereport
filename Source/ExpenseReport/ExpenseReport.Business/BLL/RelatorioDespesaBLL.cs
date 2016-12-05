using Dapper;
using ExpenseReport.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseReport.Business.BLL
{
    public class RelatorioDespesaBLL:BaseBLL
    {
        public List<RelatorioDespesa> Listagem(long relatorioID)
        {
            this.InicializarConexao();

            string strConsulta =
                @"SELECT * FROM RelatorioDespesa
                WHERE RelatorioID = @RelatorioID
                ORDER BY Data";

            List<RelatorioDespesa> lista = Conexao
                .Query<RelatorioDespesa>(strConsulta, new { RelatorioID = relatorioID })
                .ToList();

            return lista;
        }

        public long Incluir(RelatorioDespesa relatorioDespesa)
        {
            this.InicializarConexao();

            string strConsulta =
                @"INSERT INTO RelatorioDespesa (RelatorioID, FonteDespesaID, TipoDespesaID, Descricao, Data, Valor, Faturado)
                  VALUES (@RelatorioID, @FonteDespesaID, @TipoDespesaID, @Descricao, @Data, @Valor, @Faturado)
                  SELECT CAST(SCOPE_IDENTITY() AS bigint)";

            long RelatorioDespesaID = Conexao
                .Query(strConsulta, relatorioDespesa)
                .Single();

            return RelatorioDespesaID;
        }

        public bool Excluir(long RelatorioDespesaID)
        {
            this.InicializarConexao();
            string strConsulta =
                @"DELETE FROM RelatorioDespesa
                  WHERE RelatorioDespesaID = @RelatorioDespesaID";

            return Conexao.Execute(strConsulta, new { RelatorioDespesaID = RelatorioDespesaID }) > 0;
        }
    }
}
