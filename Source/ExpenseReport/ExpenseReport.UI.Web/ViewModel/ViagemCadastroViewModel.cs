using ExpenseReport.UI.Web.ServicoPrincipal;
using ExpenseReport.UI.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseReport.UI.Web.ViewModel
{
    public class ViagemCadastroViewModel
    {
        public ViagemCadastroViewModel()
        {
            ServicoPrincipalClient servico = new ServicoPrincipalClient();


            servico.Projeto_Listagem()
                .ToList()
                .ForEach(t => this.ListaProjeto.Add(new SelectListItem { Value = t.ProjetoID.ToString(), Text = t.Descricao }));
                
        }

        public Retorno Retorno { get; set; } = new Retorno();
        public Viagem Viagem { get; set; } = new Viagem();
        public List<SelectListItem> ListaProjeto { get; set; } = new List<SelectListItem>();
    }
}