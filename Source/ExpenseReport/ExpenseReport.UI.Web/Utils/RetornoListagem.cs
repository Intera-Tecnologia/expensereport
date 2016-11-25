using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseReport.UI.Web.Utils
{
    public class RetornoListagem : Retorno
    {
        public int PaginaAtual { get; set; }
        public int QtdPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
    }
}