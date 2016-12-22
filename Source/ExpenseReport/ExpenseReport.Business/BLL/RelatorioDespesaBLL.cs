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

            List<TipoDespesa> listaTipo = (new TipoDespesaBLL()).Listagem();
            List<FonteDespesa> listaFonte = (new FonteDespesaBLL()).Listagem();

            foreach (RelatorioDespesa item in lista)
            {
                item.FonteDespesa = listaFonte.FirstOrDefault(o => o.FonteDespesaID == item.FonteDespesaID);
                item.TipoDespesa = listaTipo.FirstOrDefault(o => o.TipoDespesaID == item.TipoDespesaID);
            }


            return lista;
        }

        public long Incluir(RelatorioDespesa relatorioDespesa)
        {
            this.InicializarConexao();

            string strConsulta =
                @"INSERT INTO RelatorioDespesa (RelatorioID, FonteDespesaID, TipoDespesaID, Descricao, Data, Valor, Faturado)
                  VALUES (@RelatorioID, @FonteDespesaID, @TipoDespesaID, @Descricao, @Data, @Valor, @Faturado)";

            Conexao
                .Query(strConsulta, relatorioDespesa);                

            return 1;
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
