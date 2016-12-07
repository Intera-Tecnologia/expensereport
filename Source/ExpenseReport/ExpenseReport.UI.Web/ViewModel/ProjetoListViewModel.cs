using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseReport.UI.Web.ServicoPrincipal;

namespace ExpenseReport.UI.Web.ViewModel
{
    public class ProjetoListViewModel
    {
        public Utils.RetornoListagem Retorno { get; set; } = new Utils.RetornoListagem();

        public string Filtro { get; set; }

        public string Acao { get; set; }

        public long ProjetoIDExcluir { get; set; }

        public List<Projeto> Listagem { get; set; } = new List<Projeto>();        

    }
}