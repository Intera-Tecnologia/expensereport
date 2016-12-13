using ExpenseReport.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ExpenseReport.Business.DTO;

namespace ExpenseReport.Business.BLL
{

    public class ViagemBLL:BaseBLL
    {
        ProjetoBLL projetoBLL = new ProjetoBLL();
        List<Projeto> listaProjeto = new List<Projeto>();
        public ViagemBLL()
        {
            listaProjeto = projetoBLL.Listagem();
        }
        public List<Viagem> Listagem()
        {
            this.InicializarConexao();

            string strConsulta =
                @"SELECT * 
                  FROM Viagem
                  ORDER BY DataInicio";

            List<Viagem> lista = Conexao
                .Query<Viagem>(strConsulta)
                .ToList();

            lista.ForEach(o =>
            {
                o.Projeto = listaProjeto.FirstOrDefault(pr => pr.ProjetoID == o.ProjetoID);
            });

            return lista;
        }

        public List<Viagem> Listagem(string Descricao)
        {
            this.InicializarConexao();

            Descricao = "%" + Descricao + "%";

            string strConsulta =
                @"SELECT * 
                  FROM Viagem
                  WHERE Descricao LIKE @Descricao
                  ORDER BY DataInicio";

            List<Viagem> lista = Conexao
                .Query<Viagem>(strConsulta, new { Descricao = Descricao })
                .ToList();

            lista.ForEach(o =>
            {
                o.Projeto = listaProjeto.FirstOrDefault(pr => pr.ProjetoID == o.ProjetoID);
            });

            return lista;
        }

        public List<Viagem> Listagem(long ProjetoID)
        {
            this.InicializarConexao();
            
            string strConsulta =
                @"SELECT * 
                  FROM Viagem
                  WHERE ProjetoID LIKE @ProjetoID
                  ORDER BY DataInicio";

            List<Viagem> lista = Conexao
                .Query<Viagem>(strConsulta, new { ProjetoID = ProjetoID })
                .ToList();

            lista.ForEach(o =>
            {
                o.Projeto = listaProjeto.FirstOrDefault(pr => pr.ProjetoID == o.ProjetoID);
            });

            return lista;
        }

        public bool Excluir(long ViagemID)
        {
            this.InicializarConexao();

            string strConsulta =
                @"DELETE FROM Viagem
                  WHERE ViagemID = @ViagemID";

            return Conexao.Execute(strConsulta, new { ViagemID = ViagemID }) > 0;
        }

        public long Incluir(Viagem viagem)
        {
            long id = 0;
            try
            {
                this.InicializarConexao();

                string strConsulta =
                    @"INSERT INTO Viagem (Descricao, Justificativa, DataInicio, DataFim, ProjetoID)
                  VALUES (@Descricao, @Justificativa, @DataInicio, @DataFim, @ProjetoID)
                  SELECT CAST(SCOPE_IDENTITY() AS bigint) AS ID";

                var obj = Conexao
                    .Query<RetornoIncluirDTO>(strConsulta, viagem)
                    .FirstOrDefault();

                id = obj.ID;
            }
            catch (System.Exception)
            {

                return id;
            }

            return id;
        }

        public bool Alterar(Viagem viagem)
        {
            try
            {
                this.InicializarConexao();

                string strConsulta =
                    @"UPDATE Viagem 
                  SET Descricao = @Descricao,
                      Justificativa = @Justificativa,
                      DataInicio = @DataInicio ,
                      DataFim = @DataFim,
                      ProjetoID = @ProjetoID
                  WHERE ViagemID = @ViagemID";

                var obj = Conexao
                    .Query<RetornoIncluirDTO>(strConsulta, viagem)
                    .FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                return false;
            }

            return true;
        }

        public Viagem ViagemPorID(long ViagemID)
        {
            try
            {
                this.InicializarConexao();

                string strConsulta =
                    @"select * from Viagem where ViagemID = @ViagemID";

                Viagem obj = Conexao
                    .Query<Viagem>(strConsulta, new { ViagemID = ViagemID })
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
