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
                .Query<Projeto>(strConsulta, Descricao)
                .ToList();

            return lista;
        }
    }
}
