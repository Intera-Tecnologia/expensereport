/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
var ViagemListagemTS = (function () {
    function ViagemListagemTS() {
        this.btnLocalizar = $("#btnLocalizar");
        this.btnSim = $("#btnSim");
        this.form = $("#formViagem");
        this.Acao = $("#Acao");
        this.btnExcluirList = $(".btnExcluir");
        this.btnEditarList = $(".btnEditar");
        this.ViagemIDExcluir = $("#ViagemIDExcluir");
    }
    ViagemListagemTS.prototype.init = function () {
        var _this = this;
        // Ao Clicar, colocar o valor "A" no campo Hidden
        // de Acao
        this.btnLocalizar.on("click", function () {
            _this.Acao.val("L");
        });
        // Ao clicar, executar o submit do form para realizar
        // a remoção do registro
        $("#btnSim").on("click", function () {
            _this.form.submit();
        });
        // Ao clicar no excluir, localizar o ID do Projeto
        // E colocar no HIDDEN correspondente
        this.btnExcluirList.on("click", function (e) {
            var id = $(e.currentTarget).data("id");
            _this.Acao.val("R"); // Remover
            _this.ViagemIDExcluir.val(id);
        });
        this.btnEditarList.on("click", function (e) {
            var id = $(e.currentTarget).data("id");
            window.location.href = "/Viagem/Cadastro?id=" + id;
        });
    };
    return ViagemListagemTS;
}());
window.onload = function () {
    var obj = new ViagemListagemTS();
    obj.init();
};
//# sourceMappingURL=ViagemListagem.js.map