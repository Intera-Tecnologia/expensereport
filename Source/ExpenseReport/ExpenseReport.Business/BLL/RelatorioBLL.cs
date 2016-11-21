using Dapper;
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

            return lista;
        }

        

    }
}
