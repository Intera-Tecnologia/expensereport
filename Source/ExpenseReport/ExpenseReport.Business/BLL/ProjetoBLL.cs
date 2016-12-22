using Dapper;
using ExpenseReport.Business.DTO;
using ExpenseReport.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseReport.Business.BLL
{
    public class ProjetoBLL : BaseBLL
    {
        public List<Projeto> Listagem()
        {
            try
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
            catch (System.Exception)
            {
                return new List<Projeto>();
            }

            
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
            long id = 0;
            try
            {
                this.InicializarConexao();

                string strConsulta =
                    @"INSERT INTO Projeto (Descricao, Programa, CentroDeCusto, Status)
                  VALUES (@Descricao, @Programa, @CentroDeCusto, @Status)
                  SELECT CAST(SCOPE_IDENTITY() AS bigint) AS ID";

                var obj = Conexao
                    .Query<RetornoIncluirDTO>(strConsulta, projeto)
                    .FirstOrDefault();

                id = obj.ID;
            }
            catch (System.Exception)
            {

                return id;
            }

            return id;
        }

        public bool Alterar(Projeto projeto)
        {
            try
            {
                this.InicializarConexao();

                string strConsulta =
                    @"UPDATE Projeto 
                  SET Descricao = @Descricao,
                      Programa = @Programa,
                      CentroDeCusto = @CentroDeCusto ,
                      Status = @Status
                  WHERE ProjetoID = @ProjetoID";

                var obj = Conexao
                    .Query<RetornoIncluirDTO>(strConsulta, projeto)
                    .FirstOrDefault();
            }
            catch (System.Exception ex)
            {

                return false;
            }

            return true;
        }

        public Projeto ProjetoPorID(long ProjetoID)
        {
            try
            {
                this.InicializarConexao();

                string strConsulta =
                    @"select * from Projeto where ProjetoID = @ProjetoID";

                Projeto obj = Conexao
                    .Query<Projeto>(strConsulta, new { ProjetoID = ProjetoID })
                    .FirstOrDefault();

                return obj;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
