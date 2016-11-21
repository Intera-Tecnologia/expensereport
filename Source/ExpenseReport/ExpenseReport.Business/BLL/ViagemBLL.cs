using ExpenseReport.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ExpenseReport.Business.BLL
{
    public class ViagemBLL:BaseBLL
    {
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
            return lista;
        }
    }
}
