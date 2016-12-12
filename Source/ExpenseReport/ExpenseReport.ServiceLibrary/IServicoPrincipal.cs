using ExpenseReport.Business.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ExpenseReport.ServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicoPrincipal" in both code and config file together.
    [ServiceContract]
    public interface IServicoPrincipal
    {
        #region Imagem
        [OperationContract]
        List<Imagem> Imagem_ListagemPorRelatorioDespesa(long RelatorioDespesaID);

        [OperationContract]
        long Imagem_Incluir(Imagem imagem);

        [OperationContract]
        bool Imagem_Excluir(long imagemID);
        #endregion

        #region Colaborador
        [OperationContract]
        List<Colaborador> Colaborador_Listagem();

        [OperationContract]
        List<Colaborador> Colaborador_ListagemPorNome(string nome);

        [OperationContract]
        Colaborador Colaborador_PeloCodigo(long colaboradorID);
        #endregion

        #region FonteDespesa
        [OperationContract]
        List<FonteDespesa> FonteDespesa_Listagem();
        #endregion

        #region TipoDespesa
        [OperationContract]
        List<TipoDespesa> TipoDespesa_Listagem();
        #endregion

        #region Viagem
        [OperationContract]
        List<Viagem> Viagem_Listagem();

        [OperationContract]
        List<Viagem> Viagem_ListagemPorDescricao(string Descricao);

        [OperationContract]
        List<Viagem> Viagem_ListagemPorProjeto(long ProjetoID);
        #endregion

        #region RelatorioDespesa
        [OperationContract]
        List<RelatorioDespesa> RelatorioDespesa_ListagemPorRelatorio(long relatorioID);

        [OperationContract]
        long RelatorioDespesa_Incluir(RelatorioDespesa relatorioDespesa);

        [OperationContract]
        bool RelatorioDespesa_Excluir(long RelatorioDespesaID);
        #endregion

        #region Relatorio
        [OperationContract]
        List<Relatorio> Relatorio_ListagemPorData(DateTime data);

        [OperationContract]
        List<Relatorio> Relatorio_ListagemPorColaborador(long colaboradorID);

        [OperationContract]
        List<Relatorio> Relatorio_ListagemPorDataColaborador(DateTime data, long colaboradorID);
        #endregion

        #region Projeto
        [OperationContract]
        List<Projeto> Projeto_Listagem();

        [OperationContract]
        List<Projeto> Projeto_ListagemPorDescricao(string Descrica);

        [OperationContract]
        bool Projeto_Excluir(long ProjetoID);

        [OperationContract]
        long Projeto_Incluir(Projeto projeto);

        [OperationContract]
        bool Projeto_Alterar(Projeto projeto);

        [OperationContract]
        Projeto Projeto_PorID(long ProjetoID);
        #endregion
    }
}
