/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

declare var $: JQueryStatic;
var btnLocalizar = $("#btnLocalizar");
var btnSim = $("#btnSim");
var form = $("#formProjeto");
var Acao = $("#Acao");
var btnExcluirList = $(".btnExcluir");
var btnEditarList = $(".btnEditar");
var ProjetoIDExcluir = $("#ProjetoIDExcluir");

class ProjetoListagemTS {    
    init(): void {

        // Ao clicar, colocar o valor "A" no campo Hidden
        // de  Acao
        btnLocalizar.on("click", () => {
            Acao.val("L");
        });

        // Ao clicar, executar o submit do form para realizar
        // a remoção do registro
        $("#btnSim").on("click", () => {
            form.submit();
        });

        // Ao clicar no excluir, localizar o ID do Projeto
        // E colocar no HIDDEN correspondente
        btnExcluirList.on("click", (e: JQueryEventObject) => {
            var id = $(e.currentTarget).data("id");
            Acao.val("R"); // Remover
            ProjetoIDExcluir.val(id);
        });

        btnEditarList.on("click", (e: JQueryEventObject) => {
            var id: string = $(e.currentTarget).data("id");
            window.location.href = "/Projeto/Cadastro?id=" + id;
        });

        
    }
}

window.onload = () => {
    var obj = new ProjetoListagemTS();
    obj.init();
}
