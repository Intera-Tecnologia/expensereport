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
                @"SELECT * 
                  FROM Colaborador 
                  ORDER BY Nome";

            List<Colaborador> lista = Conexao
                .Query<Colaborador>(strConsulta)
                .ToList();
            return lista;
        }

        public List<Colaborador> Listagem(string nome)
        {
            this.InicializarConexao();

            nome = "%" + nome + "%";

            string strConsulta =
                @"SELECT * 
                  FROM Colaborador 
                  WHERE Nome LIKE @Nome
                  ORDER BY Nome";

            List<Colaborador> lista = Conexao
                .Query<Colaborador>(strConsulta, new { Nome = nome })
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

            Token UserToken = Conexao
                .Query<Token>(@"select * 
                                from Token 
                                where TokenID = @TokenID", new { TokenID = colaborador.TokenID })
                .FirstOrDefault();

            colaborador.UserToken = UserToken;

            return colaborador;
        }

        public Colaborador Acesso(string login, string senha)
        {
            this.InicializarConexao();

            string strConsulta =
                @"SELECT * 
                  FROM Colaborador 
                  WHERE ColaboradorID = @ColaboradorID";

            Colaborador colaborador = Conexao
                .Query<Colaborador>(strConsulta, new { Login = login, Senha = senha })
                .FirstOrDefault();

            return colaborador;
        }
    }
}
