using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ExpenseReport.Business.Entities;
using ExpenseReport.Business.BLL;

namespace ExpenseReport.ServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicoPrincipal" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicoPrincipal.svc or ServicoPrincipal.svc.cs at the Solution Explorer and start debugging.
    public class ServicoPrincipal : IServicoPrincipal
    {
        #region Imagem
        public List<Imagem> Imagem_ListagemPorRelatorioDespesa(long RelatorioDespesaID)
        {
            ImagemBLL imagemBLL = new ImagemBLL();
            return imagemBLL.Listagem(RelatorioDespesaID);
        }

        public long Imagem_Incluir(Imagem imagem)
        {
            ImagemBLL imagemBLL = new ImagemBLL();
            return imagemBLL.Incluir(imagem);
        }

        public bool Imagem_Excluir(long imagemID)
        {
            ImagemBLL imagemBLL = new ImagemBLL();
            return imagemBLL.Excluir(imagemID);
        }
        #endregion

        #region Colaborador
        public List<Colaborador> Colaborador_Listagem()
        {
            ColaboradorBLL colaboradorBLL = new ColaboradorBLL();
            return colaboradorBLL.Listagem();
        }

        public List<Colaborador> Colaborador_ListagemPorNome(string nome)
        {
            ColaboradorBLL colaboradorBLL = new ColaboradorBLL();
            return colaboradorBLL.Listagem(nome);
        }

        public Colaborador Colaborador_PeloCodigo(long colaboradorID)
        {
            ColaboradorBLL colaboradorBLL = new ColaboradorBLL();
            return colaboradorBLL.PeloCodigo(colaboradorID);
        }
        #endregion

        #region Projeto
        public List<Projeto> Projeto_Listagem()
        {
            ProjetoBLL projetoBLL = new ProjetoBLL();
            return projetoBLL.Listagem();
        }

        public List<Projeto> Projeto_ListagemPorDescricao(string Descricao)
        {
            ProjetoBLL projetoBLL = new ProjetoBLL();
            return projetoBLL.Listagem(Descricao);
        }

        public bool Projeto_Excluir(long ProjetoID)
        {
            ProjetoBLL projetoBLL = new ProjetoBLL();
            return projetoBLL.Excluir(ProjetoID);
        }

        public long Projeto_Incluir(Projeto projeto)
        {
            ProjetoBLL projetoBLL = new ProjetoBLL();
            return projetoBLL.Incluir(projeto);
        }
        #endregion

        #region Relatorio
        public List<Relatorio> Relatorio_ListagemPorData(DateTime data)
        {
            RelatorioBLL relatorioBLL = new RelatorioBLL();
            return relatorioBLL.Listagem(data);
        }

        public List<Relatorio> Relatorio_ListagemPorColaborador(long colaboradorID)
        {
            RelatorioBLL relatorioBLL = new RelatorioBLL();
            return relatorioBLL.Listagem(colaboradorID);
        }

        public List<Relatorio> Relatorio_ListagemPorDataColaborador(DateTime data, long colaboradorID)
        {
            RelatorioBLL relatorioBLL = new RelatorioBLL();
            return relatorioBLL.Listagem(data, colaboradorID);
        }
        #endregion

        #region RelatorioDespesa
        public bool RelatorioDespesa_Excluir(long RelatorioDespesaID)
        {
            RelatorioDespesaBLL relatorioDespesaBLL = new RelatorioDespesaBLL();
            return relatorioDespesaBLL.Excluir(RelatorioDespesaID);
        }

        public long RelatorioDespesa_Incluir(Business.Entities.RelatorioDespesa relatorioDespesa)
        {
            RelatorioDespesaBLL relatorioDespesaBLL = new RelatorioDespesaBLL();
            return relatorioDespesaBLL.Incluir(relatorioDespesa);
        }

        public List<Business.Entities.RelatorioDespesa> RelatorioDespesa_ListagemPorRelatorio(long relatorioID)
        {
            RelatorioDespesaBLL relatorioDespesaBLL = new RelatorioDespesaBLL();
            return relatorioDespesaBLL.Listagem(relatorioID);
        }
        #endregion

        #region FonteDespesa
        public List<FonteDespesa> FonteDespesa_Listagem()
        {
            FonteDespesaBLL fonteDespesa = new FonteDespesaBLL();
            return fonteDespesa.Listagem();
        }


        #endregion

        #region TipoDespesa
        public List<TipoDespesa> TipoDespesa_Listagem()
        {
            TipoDespesaBLL tipoDespesaBLL = new TipoDespesaBLL();
            return tipoDespesaBLL.Listagem();
        }
        #endregion

        #region Viagem
        public List<Viagem> Viagem_Listagem()
        {
            ViagemBLL viagemBLL = new ViagemBLL();
            return viagemBLL.Listagem();
        }

        public List<Viagem> Viagem_ListagemPorProjeto(long ProjetoID)
        {
            ViagemBLL viagemBLL = new ViagemBLL();
            return viagemBLL.Listagem(ProjetoID);
        }

        public List<Viagem> Viagem_ListagemPorDescricao(string Descricao)
        {
            ViagemBLL viagemBLL = new ViagemBLL();
            return viagemBLL.Listagem(Descricao);
        }
        
        #endregion

    }
}
