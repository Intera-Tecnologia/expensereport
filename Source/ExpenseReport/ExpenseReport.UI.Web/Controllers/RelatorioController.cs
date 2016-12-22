using ExpenseReport.UI.Web.ServicoPrincipal;
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

            if (id != null)
            {
                ServicoPrincipal.ServicoPrincipalClient servico = new ServicoPrincipal.ServicoPrincipalClient();
                viewModel.Relatorio = servico.Relatorio_PorId(id.Value);
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Cadastro(RelatorioCadastroViewModel viewModel)
        {
            ServicoPrincipal.ServicoPrincipalClient servico = new ServicoPrincipal.ServicoPrincipalClient();

            if (viewModel.Acao == "N")
            {
                if (viewModel.Relatorio.RelatorioID == 0) // Novo
                {
                    try
                    {
                        long id = servico.Relatorio_Incluir(viewModel.Relatorio);
                        viewModel.Relatorio.RelatorioID = id;

                        viewModel.Retorno.RetornouSucesso = true;
                        viewModel.Retorno.MensagemSucesso = Utils.Constantes.MENSAGEM_SUCESSO_INCLUIR;
                    }
                    catch (Exception)
                    {
                        viewModel.Retorno.RetornouErro = true;
                        viewModel.Retorno.MensagemErro = Utils.Constantes.MENSAGEM_ERRO_INCLUIR;
                    }
                }
                else // Alterar
                {
                    try
                    {
                        if (servico.Relatorio_Alterar(viewModel.Relatorio))
                        {
                            viewModel.Retorno.RetornouSucesso = true;
                            viewModel.Retorno.MensagemSucesso = Utils.Constantes.MENSAGEM_SUCESSO_ALTERAR;
                        }
                        else
                        {
                            viewModel.Retorno.RetornouErro = true;
                            viewModel.Retorno.MensagemErro = Utils.Constantes.MENSAGEM_ERRO_ALTERAR;
                        }
                    }
                    catch (Exception)
                    {
                        viewModel.Retorno.RetornouErro = true;
                        viewModel.Retorno.MensagemErro = Utils.Constantes.MENSAGEM_ERRO_ALTERAR;
                    }
                }
            }
            else
            {
                // Adicionar despesa
                RelatorioDespesa relDesp = new RelatorioDespesa
                {
                    Data = viewModel.Despesa_Data,
                    Descricao = viewModel.Despesa_Descricao,
                    Faturado = viewModel.Despesa_Faturado == 1,
                    FonteDespesaID = viewModel.Despesa_Fonte,
                    TipoDespesaID = viewModel.Despesa_Tipo,
                    RelatorioID = viewModel.Relatorio.RelatorioID,
                    Valor = viewModel.Despesa_Valor
                };

                long id = servico.RelatorioDespesa_Incluir(relDesp);
                viewModel.Relatorio.Despesas = servico.RelatorioDespesa_ListagemPorRelatorio(viewModel.Relatorio.RelatorioID);
                viewModel.Retorno.RetornouSucesso = true;
                viewModel.Retorno.MensagemSucesso = Utils.Constantes.MENSAGEM_SUCESSO_INCLUIR;
            }

            return View(viewModel);
        }

        public ActionResult GerenciarMideas()
        {
            return View();
        }
    }
}