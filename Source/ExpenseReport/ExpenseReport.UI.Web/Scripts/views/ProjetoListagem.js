/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
var btnLocalizar = $("#btnLocalizar");
var btnSim = $("#btnSim");
var form = $("#formProjeto");
var Acao = $("#Acao");
var btnExcluirList = $(".btnExcluir");
var btnEditarList = $(".btnEditar");
var ProjetoIDExcluir = $("#ProjetoIDExcluir");
var ProjetoListagemTS = (function () {
    function ProjetoListagemTS() {
    }
    ProjetoListagemTS.prototype.init = function () {
        // Ao clicar, colocar o valor "A" no campo Hidden
        // de  Acao
        btnLocalizar.on("click", function () {
            Acao.val("L");
        });
        // Ao clicar, executar o submit do form para realizar
        // a remoção do registro
        $("#btnSim").on("click", function () {
            form.submit();
        });
        // Ao clicar no excluir, localizar o ID do Projeto
        // E colocar no HIDDEN correspondente
        btnExcluirList.on("click", function (e) {
            var id = $(e.currentTarget).data("id");
            Acao.val("R"); // Remover
            ProjetoIDExcluir.val(id);
        });
        btnEditarList.on("click", function (e) {
            var id = $(e.currentTarget).data("id");
            window.location.href = "/Projeto/Cadastro?id=" + id;
        });
    };
    return ProjetoListagemTS;
}());
window.onload = function () {
    var obj = new ProjetoListagemTS();
    obj.init();
};
//# sourceMappingURL=ProjetoListagem.js.map