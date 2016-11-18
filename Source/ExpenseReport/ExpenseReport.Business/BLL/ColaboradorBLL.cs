using ExpenseReport.Business.Entities;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace ExpenseReport.Business.BLL
{
    public class ColaboradorBLL : BaseBLL
    {
        public List<Colaborador> Listagem()
        {
            this.InicializarConexao();

            string strConsulta = 
                "SELECT * FROM Colaborador ORDER BY ColaboradorID";

            List<Colaborador> lista = Conexao
                .Query<Colaborador>(strConsulta)
                .ToList();
            return lista;
        }

        public Colaborador PeloCodigo(long colaboradorID)
        {
            this.InicializarConexao();

            string strConsulta =
                @"SELECT * 
                  FROM Colaborador 
                  WHERE ColaboradorID = @ColaboradorID";

            Colaborador colaborador = Conexao
                .Query<Colaborador>(strConsulta, new { ColaboradorID = colaboradorID })
                .FirstOrDefault();

            return colaborador;
        }
    }
}
