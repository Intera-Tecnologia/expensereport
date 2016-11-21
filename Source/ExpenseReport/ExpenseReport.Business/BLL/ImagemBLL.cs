using Dapper;
using ExpenseReport.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseReport.Business.BLL
{
    public class ImagemBLL : BaseBLL
    {
        public List<Imagem> Listagem(long RelatorioDespesaID)
        {
            this.InicializarConexao();

            string strConsulta =
                @"SELECT * 
                  FROM Imagem i
                  WHERE i.RelatorioDespesaID = @RelatorioDespesaID
                  ORDER BY ImagemID";

            List<Imagem> lista = Conexao
                .Query<Imagem>(strConsulta, new { RelatorioDespesaID = RelatorioDespesaID })
                .ToList();
            return lista;
        }

        public long Incluir(Imagem imagem)
        {
            this.InicializarConexao();

            string strConsulta =
                @"INSERT INTO IMAGEM (NomeArquivo, RelatorioDespesaID)
                  VALUES (@NomeArquivo, @RelatorioDespesaID)
                  SELECT CAST(SCOPE_IDENTITY() AS bigint)";

            long ImagemID = Conexao
                .Query(strConsulta, imagem)
                .Single();

            return ImagemID;
        }
        
        public bool Excluir(long imagemID)
        {
            this.InicializarConexao();
            string strConsulta =
                @"DELETE FROM Imagem
                  WHERE ImagemID = @ImagemID";

            return Conexao.Execute(strConsulta, new { ImagemID = imagemID }) > 0;
        }

    }
}
