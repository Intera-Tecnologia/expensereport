/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
var RelatorioListagemTS = (function () {
    function RelatorioListagemTS() {
        this.btnLocalizar = $("#btnLocalizar");
        this.btnSim = $("#btnSim");
        this.form = $("#formProjeto");
        this.Acao = $("#Acao");
        this.btnExcluirList = $(".btnExcluir");
        this.btnEditarList = $(".btnEditar");
        this.RelatorioIDExcluir = $("#RelatorioIDExcluir");
    }
    RelatorioListagemTS.prototype.init = function () {
        var _this = this;
        // Ao clicar, colocar o valor "A" no campo Hidden
        // de  Acao
        this.btnLocalizar.on("click", function () {
            _this.Acao.val("L");
        });
        // Ao clicar, executar o submit do form para realizar
        // a remoção do registro
        this.btnSim.on("click", function () {
            _this.form.submit();
        });
        // Ao clicar no excluir, localizar o ID do Projeto
        // E colocar no HIDDEN correspondente
        this.btnExcluirList.on("click", function (e) {
            var id = $(e.currentTarget).data("id");
            _this.Acao.val("R"); // Remover
            _this.RelatorioIDExcluir.val(id);
        });
        this.btnEditarList.on("click", function (e) {
            var id = $(e.currentTarget).data("id");
            window.location.href = "/Relatorio/Cadastro?id=" + id;
        });
    };
    return RelatorioListagemTS;
}());
window.onload = function () {
    var obj = new RelatorioListagemTS();
    obj.init();
};
//# sourceMappingURL=RelatorioListagem.js.map