using Dapper;
using ExpenseReport.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseReport.Business.BLL
{
    public class ProjetoBLL : BaseBLL
    {
        public List<Projeto> Listagem()
        {
            this.InicializarConexao();

            string strConsulta =
                @"SELECT * FROM Projeto                
                ORDER BY Descricao";

            List<Projeto> lista = Conexao
                .Query<Projeto>(strConsulta)
                .ToList();

            return lista;
        }

        public List<Projeto> Listagem(string Descricao)
        {
            this.InicializarConexao();

            Descricao = "%" + Descricao + "%";

            string strConsulta =
                @"SELECT * FROM Projeto 
                WHERE Descricao LIKE @Descricao               
                ORDER BY Descricao";

            List<Projeto> lista = Conexao
                .Query<Projeto>(strConsulta, new { Descricao = Descricao })
                .ToList();

            return lista;
        }

        public bool Excluir(long ProjetoID)
        {
            this.InicializarConexao();

            string strConsulta =
                @"DELETE FROM Projeto
                  WHERE ProjetoID = @ProjetoID";

            return Conexao.Execute(strConsulta, new { ProjetoID = ProjetoID }) > 0;
        }

        public long Incluir(Projeto projeto)
        {
            this.InicializarConexao();

            string strConsulta =
                @"INSERT INTO Projeto (Descricao, Programa, CentroDeCusto, Status)
                  VALUES (@Descricao, @Programa, @CentroDeCusto, @Status)
                  SELECT CAST(SCOPE_IDENTITY() AS bigint)";

            long ProjetoID = Conexao
                .Query(strConsulta, projeto)
                .Single();

            return ProjetoID;
        }
    }
}
