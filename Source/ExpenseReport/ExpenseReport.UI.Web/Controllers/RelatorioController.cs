using ExpenseReport.UI.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseReport.UI.Web.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult Index()
        {
            RelatorioListViewModel viewModel = new RelatorioListViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(RelatorioListViewModel viewModel)
        {
            ServicoPrincipal.ServicoPrincipalClient servico = new ServicoPrincipal.ServicoPrincipalClient();

            viewModel.Listagem = servico
                .Relatorio_ListagemPoDescricaoViagem(viewModel.Filtro)
                .ToList() ;

            return View(viewModel);
        }

        public ActionResult Cadastro(long? id)
        {
            RelatorioCadastroViewModel viewModel = new RelatorioCadastroViewModel();

            return View(viewModel);
        }

        public ActionResult GerenciarMideas()
        {
            return View();
        }
    }
}