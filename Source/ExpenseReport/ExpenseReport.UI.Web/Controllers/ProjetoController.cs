using ExpenseReport.UI.Web.ViewModel;
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

        

        [HttpPost]
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        public ActionResult Cadastro(ViewModel.ProjetoCadastroViewModel viewModel)
        {
            try
            {
                ServicoPrincipal.ServicoPrincipalClient servico = new ServicoPrincipal.ServicoPrincipalClient();

                if (viewModel.ProjetoID == 0) // incluir
                {
                    long projetoID = servico.Projeto_Incluir(new ServicoPrincipal.Projeto
                    {
                        CentroDeCusto = viewModel.CentroDeCusto,
                        Descricao = viewModel.Descricao,
                        ExtensionData = viewModel.ExtensionData,
                        Programa = viewModel.Programa,
                        ProjetoID = viewModel.ProjetoID,
                        Status = viewModel.Status
                    });

                    if (projetoID == 0)
                    {
                        viewModel.Retorno.RetornouErro = true;
                        viewModel.Retorno.MensagemErro = Utils.Constantes.MENSAGEM_ERRO_INCLUIR;
                    }
                    else
                    {
                        viewModel.ProjetoID = projetoID;
                        viewModel.Retorno.RetornouSucesso = true;
                        viewModel.Retorno.MensagemSucesso = Utils.Constantes.MENSAGEM_SUCESSO_INCLUIR;
                    }
                
                }
                else // alterar
                {
                    if (servico.Projeto_Alterar(new ServicoPrincipal.Projeto
                    {
                        CentroDeCusto = viewModel.CentroDeCusto,
                        Descricao = viewModel.Descricao,
                        ExtensionData = viewModel.ExtensionData,
                        Programa = viewModel.Programa,
                        ProjetoID = viewModel.ProjetoID,
                        Status = viewModel.Status
                    }) == true)
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
            }
            catch (Exception)
            {
                viewModel.Retorno.RetornouErro = true;
                viewModel.Retorno.MensagemErro = Utils.Constantes.MENSAGEM_ERRO_INCLUIR;
            }

            return View(viewModel);
        }

        
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        public ActionResult Cadastro(long? id)
        {
            try
            {
                if (id == null) return View(new ProjetoCadastroViewModel());

                ServicoPrincipal.ServicoPrincipalClient servico = new ServicoPrincipal.ServicoPrincipalClient();
                ServicoPrincipal.Projeto projeto = servico.Projeto_PorID(id.Value);
                ProjetoCadastroViewModel viewModel = new ProjetoCadastroViewModel()
                {
                    CentroDeCusto = projeto.CentroDeCusto,
                    Descricao = projeto.Descricao,
                    Programa = projeto.Programa,
                    ProjetoID = projeto.ProjetoID,
                    Status = projeto.Status
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return View(new ProjetoCadastroViewModel());
            }
            
        }

    }
}