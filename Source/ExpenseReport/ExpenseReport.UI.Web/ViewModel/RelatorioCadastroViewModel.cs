using ExpenseReport.UI.Web.ServicoPrincipal;
using ExpenseReport.UI.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseReport.UI.Web.ViewModel
{
    public class RelatorioCadastroViewModel
    {
        public RelatorioCadastroViewModel()
        {
            ServicoPrincipalClient servico = new ServicoPrincipalClient();

            servico.Viagem_Listagem()
                .ToList()
                .ForEach(t => this.ListaViagem.Add(new SelectListItem { Value = t.ViagemID.ToString(), Text = t.Descricao }));

            servico.Colaborador_Listagem()
                .ToList()
                .ForEach(c => this.ListaColaborador.Add(new SelectListItem { Value = c.ColaboradorID.ToString(), Text = c.Nome }));
        }

        public Retorno Retorno { get; set; } = new Retorno();
        public Relatorio Relatorio { get; set; } = new Relatorio();

        public List<SelectListItem> ListaViagem { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListaColaborador { get; set; } = new List<SelectListItem>();
        public string Acao { get; set; }


        public DateTime Despesa_Data { get; set; }
        public long Despesa_Fonte { get; set; }
        public long Despesa_Tipo { get; set; }
        public string Despesa_Descricao { get; set; }
        public int Despesa_Faturado { get; set; }
        public decimal Despesa_Valor { get; set; }


    }
}