using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseReport.UI.Web.Controllers
{
    public class ViagemController : Controller
    {
        // GET: Viagem
        public ActionResult Index()
        {
            return View(new ViewModel.ViagemListViewModel());
        }

        [HttpPost]
        public ActionResult Index(ViewModel.ViagemListViewModel viewModel)
        {
            try
            {
                ServicoPrincipal.ServicoPrincipalClient servico =
                    new ServicoPrincipal.ServicoPrincipalClient();

                if (viewModel.Acao == "L") // Localizar
                {
                    viewModel.Listagem = servico
                            .Viagem_ListagemPorDescricao(viewModel.Filtro)
                            .ToList();
                }
                else if (viewModel.Acao == "R") // Remover
                {
                    if (servico.Viagem_Excluir(viewModel.ViagemIDExcluir))
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
                            .Viagem_ListagemPorDescricao(viewModel.Filtro)
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

        
        public ActionResult Cadastro(long? id)
        {
            ViewModel.ViagemCadastroViewModel viewModel = new ViewModel.ViagemCadastroViewModel();

            if (id != null)
            {
                ServicoPrincipal.ServicoPrincipalClient servico =
                new ServicoPrincipal.ServicoPrincipalClient();

                viewModel.Viagem = servico.Viagem_PorID(id.Value);
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Cadastro(ViewModel.ViagemCadastroViewModel viewModel)
        {
            ServicoPrincipal.ServicoPrincipalClient servico =
                new ServicoPrincipal.ServicoPrincipalClient();

            if (viewModel.Viagem.ViagemID == 0) // Inluir
            {

                try
                {
                    long id = servico.Viagem_Incluir(viewModel.Viagem);
                    viewModel.Viagem.ViagemID = id;
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
                    if (servico.Viagem_Alterar(viewModel.Viagem))
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

            return View(viewModel);
        }
    }
}