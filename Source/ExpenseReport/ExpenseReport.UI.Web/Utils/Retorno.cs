using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseReport.UI.Web.Utils
{
    public class Retorno
    {
        public bool RetornouErro { get; set; }
        public string MensagemErro { get; set; }
        public bool RetornouSucesso { get; set; }
        public string MensagemSucesso { get; set; }
        public bool RetornouAlerta { get; set; }
        public string MensagemAlerta { get; set; }
    }
}