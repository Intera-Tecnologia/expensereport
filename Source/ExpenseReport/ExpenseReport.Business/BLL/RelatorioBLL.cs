using Dapper;
using ExpenseReport.Business.DTO;
using ExpenseReport.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseReport.Business.BLL
{
    public class RelatorioBLL : BaseBLL
    {
        public List<Relatorio> Listagem(DateTime data)
        {
            this.InicializarConexao();

            string strConsulta =
                @"SELECT r.* ,
                    v.DataInicio as DataViagemInicio,  
                    v.DataFim as DataViagemFim
                  FROM Relatorio r
                  INNER JOIN Viagem v ON r.ViagemID = v.ViagemID
                  WHERE (v.DataInicio >= @Data AND v.DataFim <= @Data )
                  ORDER BY v.DataInicio";

            List<Relatorio> lista = Conexao
                .Query<Relatorio>(strConsulta,new { Data = data })
                .ToList();

            CompletaDetalhes(lista);

            return lista;
        }

        public List<Relatorio> Listagem(long colaboradorID)
        {
            this.InicializarConexao();

            string strConsulta =
                @"SELECT r.* ,
                    v.DataInicio as DataViagemInicio,  
                    v.DataFim as DataViagemFim
                  FROM Relatorio r
                  INNER JOIN Viagem v ON r.ViagemID = v.ViagemID
                  WHERE ( r.ColaboradorID = @ColaboradorID )
                  ORDER BY v.DataInicio";

            List<Relatorio> lista = Conexao
                .Query<Relatorio>(strConsulta, new { ColaboradorID = colaboradorID })
                .ToList();

            CompletaDetalhes(lista);

            return lista;
        }

        public List<Relatorio> Listagem(DateTime data, long colaboradorID)
        {
            this.InicializarConexao();

            string strConsulta =
                @"SELECT r.* ,
                    v.DataInicio as DataViagemInicio,  
                    v.DataFim as DataViagemFim
                  FROM Relatorio r
                  INNER JOIN Viagem v ON r.ViagemID = v.ViagemID
                  WHERE v.DataInicio >= @Data 
                    AND v.DataFim <= @Data 
                    AND r.ColaboradorID = @ColaboradorID
                  ORDER BY v.DataInicio";

            List<Relatorio> lista = Conexao
                .Query<Relatorio>(strConsulta, new { Data = data, ColaboradorID = colaboradorID })
                .ToList();

            CompletaDetalhes(lista);

            return lista;


        }

        public List<Relatorio> Listagem(string descricaoViagem)
        {
            this.InicializarConexao();

            string strConsulta =
                @"SELECT r.* ,
                    v.DataInicio as DataViagemInicio,  
                    v.DataFim as DataViagemFim
                  FROM Relatorio r
                  INNER JOIN Viagem v ON r.ViagemID = v.ViagemID
                  WHERE (v.Descricao like @Descricao)
                  ORDER BY v.DataInicio";

            List<Relatorio> lista = Conexao
                .Query<Relatorio>(strConsulta, new { Descricao = "%"+descricaoViagem+"%" })
                .ToList();

            CompletaDetalhes(lista);

            return lista;
        }

        public long Incluir(Relatorio relatorio)
        {
            long id = 0;
            try
            {
                this.InicializarConexao();

                string strConsulta =
                    @"INSERT INTO Relatorio (DataEntrega, DiariasRecebidas, AdiantamentoRecebido, CambioDia, Moeda, PassagemFaturada, ColaboradorID, ViagemID)
                  VALUES (@DataEntrega, @DiariasRecebidas, @AdiantamentoRecebido, @CambioDia, @Moeda, @PassagemFaturada, @ColaboradorID, @ViagemID)
                  SELECT CAST(SCOPE_IDENTITY() AS bigint) AS ID";

                if (relatorio.DataEntrega.Year < 2000)
                    relatorio.DataEntrega = DateTime.Now.Date;

                var obj = Conexao
                    .Query<RetornoIncluirDTO>(strConsulta, relatorio)
                    .FirstOrDefault();

                id = obj.ID;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return id;
            }

            return id;
            
        }

        public bool Alterar(Relatorio relatorio)
        {
            try
            {
                this.InicializarConexao();

                string strConsulta =
                    @"UPDATE Relatorio 
                  SET DataEntrega = @DataEntrega, 
                      DiariasRecebidas = @DiariasRecebidas, 
                      AdiantamentoRecebido = @AdiantamentoRecebido, 
                      CambioDia = @CambioDia, 
                      Moeda= @Moeda, 
                      PassagemFaturada = @PassagemFaturada, 
                      ColaboradorID = @ColaboradorID, 
                      ViagemID = @ViagemID
                  WHERE RelatorioID = @RelatorioID";

                Conexao
                    .Query<RetornoIncluirDTO>(strConsulta, relatorio);                
                
            }
            catch (System.Exception ex)
            {

                return false;
            }

            return true;
        }

        public Relatorio RelatorioPorID(long RelatorioID)
        {
            try
            {
                this.InicializarConexao();

                string strConsulta =
                    @"select * from Relatorio where RelatorioID = @RelatorioID";

                Relatorio obj = Conexao
                    .Query<Relatorio>(strConsulta, new { RelatorioID = RelatorioID })
                    .FirstOrDefault();

                obj.Despesas = (new RelatorioDespesaBLL()).Listagem(RelatorioID);

                return obj;
            }
            catch (System.Exception)
            {
                return null;
            }

        }

        private void CompletaDetalhes(List<Relatorio> lista)
        {
            ViagemBLL viagemBLL = new ViagemBLL();
            ProjetoBLL projetoBLL = new ProjetoBLL();

            foreach (Relatorio relatorio in lista)
            {
                Viagem viagem = viagemBLL.ViagemPorID(relatorio.ViagemID);
                viagem.Projeto = projetoBLL.ProjetoPorID(viagem.ProjetoID);
                relatorio.Viagem = viagem;
            }
        }

    }
}
