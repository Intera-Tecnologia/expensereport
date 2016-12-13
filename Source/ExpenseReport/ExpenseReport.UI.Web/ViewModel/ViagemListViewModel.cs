using ExpenseReport.UI.Web.ServicoPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseReport.UI.Web.ViewModel
{
    public class ViagemListViewModel
    {
        public Utils.RetornoListagem Retorno { get; set; } = new Utils.RetornoListagem();

        public string Filtro { get; set; }
        public string Acao { get; set; }

        public long ViagemIDExcluir { get; set; }

        public List<Viagem> Listagem { get; set; }
    }
}