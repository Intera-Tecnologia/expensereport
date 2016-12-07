using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseReport.UI.Web.Controllers
{
    public class ProjetoController : Controller
    {
        // GET: Projeto
        public ActionResult Index()
        {
            ViewModel.ProjetoListViewModel viewModel = new ViewModel.ProjetoListViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(ViewModel.ProjetoListViewModel viewModel)
        {
            try
            {
                ServicoPrincipal.ServicoPrincipalClient servico =
                    new ServicoPrincipal.ServicoPrincipalClient();

                if (viewModel.Acao == "L") // Localizar
                {
                    viewModel.Listagem = servico
                            .Projeto_ListagemPorDescricao(viewModel.Filtro)
                            .ToList();
                }
                else if (viewModel.Acao == "R") // Remover
                {
                    if (servico.Projeto_Excluir(viewModel.ProjetoIDExcluir))
                    {
                        viewModel.Retorno.RetornouSucesso = true;
                        viewModel.Retorno.MensagemSucesso = Utils.Constantes.MENSAGEM_SUCESSO_EXCLUSAO;
                    }
                    else
                    {
                        viewModel.Retorno.RetornouErro = true;
                        viewModel.Retorno.MensagemErro = Utils.Constantes.MENSAGEM_SUCESSO_EXCLUSAO;
                    }

                    viewModel.Listagem = servico
                            .Projeto_ListagemPorDescricao(viewModel.Filtro)
                            .ToList();
                }
            }
            catch (Exception)
            {
                viewModel.Retorno.RetornouErro = true;
                viewModel.Retorno.MensagemErro = Utils
                    .Constantes
                    .MENSAGEM_ERRO_CONSULTA_PADRAO;
            }
            return View(viewModel);
        }

        public ActionResult Cadastro()
        {
            return View(new ViewModel.ProjetoCadastroViewModel());
        }

        [HttpPost]
        public ActionResult Cadastro(ViewModel.ProjetoCadastroViewModel viewModel)
        {
            try
            {
                ServicoPrincipal.ServicoPrincipalClient servico = new ServicoPrincipal.ServicoPrincipalClient();
                long projetoID = servico.Projeto_Incluir(viewModel.Projeto);
                if (projetoID == 0)
                {
                    viewModel.Retorno.RetornouErro = true;
                    viewModel.Retorno.MensagemErro = Utils.Constantes.MENSAGEM_ERRO_INCLUIR;
                }
                else
                {
                    viewModel.Retorno.RetornouSucesso = true;
                    viewModel.Retorno.MensagemSucesso = Utils.Constantes.MENSAGEM_SUCESSO_INCLUIR;
                }
            }
            catch (Exception)
            {
                viewModel.Retorno.RetornouErro = true;
                viewModel.Retorno.MensagemErro = Utils.Constantes.MENSAGEM_ERRO_INCLUIR;
            }

            return View(viewModel);
        }

    }
}