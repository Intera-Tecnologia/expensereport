using ExpenseReport.UI.Web.ServicoPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseReport.UI.Web.ViewModel
{
    public class RelatorioListViewModel
    {
        public Utils.RetornoListagem Retorno { get; set; } = new Utils.RetornoListagem();
        public string Filtro { get; set; }
        public string Acao { get; set; }
        public long RelatorioIDExcluir { get; set; }
        public List<Relatorio> Listagem { get; set; }

        
    }
}