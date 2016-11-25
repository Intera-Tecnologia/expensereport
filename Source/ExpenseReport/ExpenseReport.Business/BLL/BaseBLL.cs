using System.Configuration;
using System.Data.SqlClient;

namespace ExpenseReport.Business.BLL
{
    public class BaseBLL
    {
        public static string StringConexao { get; set; } = "";
        public static SqlConnection Conexao { get; set; }

        public BaseBLL()
        {
            BaseBLL.StringConexao = ConfigurationManager
                .ConnectionStrings["ExpenseReport"]
                .ConnectionString;
        }

        public void InicializarConexao()
        {
            if (BaseBLL.Conexao == null)
                this.IniciarConexao();
            if (Conexao.State == System.Data.ConnectionState.Closed)
                Conexao.Open();
        }

        public void IniciarConexao()
        {
            BaseBLL.Conexao = new SqlConnection(BaseBLL.StringConexao);
        }
        

    }
}
