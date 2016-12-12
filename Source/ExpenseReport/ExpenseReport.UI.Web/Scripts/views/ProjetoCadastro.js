/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />
var ProjetoCadastroClass = (function () {
    function ProjetoCadastroClass() {
        this.txtDescricao = $("#Descricao");
        this.txtPrograma = $("#Programa");
        this.txtCentroDeCusto = $("#CentroDeCusto");
    }
    ProjetoCadastroClass.prototype.init = function () {
        var _this = this;
        // Define a validação do formulário
        $("#btnSalvar").on("click", function () {
            if (_this.validaForm() == true)
                $("#form").submit();
        });
        // Botão Cancelar retorna para listagem
        $("#btnCancelar").on("click", function () {
            window.location.href = '/Projeto';
        });
    };
    ProjetoCadastroClass.prototype.validaForm = function () {
        var validado = true;
        // descrição
        if (this.txtDescricao.val().trim().length == 0) {
            validado = false;
            $("#validaDescricao").html(MSG_CAMPO_OBRIGATORIO);
        }
        else {
            $("#validaDescricao").html(MSG_ESPACO_EM_BRANCO);
        }
        // programa
        if (this.txtPrograma.val().trim().length == 0) {
            validado = false;
            $("#validaPrograma").html(MSG_CAMPO_OBRIGATORIO);
        }
        else {
            $("#validaPrograma").html(MSG_ESPACO_EM_BRANCO);
        }
        // centro de custo
        if (this.txtCentroDeCusto.val().trim().length == 0) {
            validado = false;
            $("#validaCentroDeCusto").html(MSG_CAMPO_OBRIGATORIO);
        }
        else {
            $("#validaCentroDeCusto").html(MSG_ESPACO_EM_BRANCO);
        }
        return validado;
    };
    return ProjetoCadastroClass;
}());
window.onload = function () {
    var obj = new ProjetoCadastroClass();
    obj.init();
};
//# sourceMappingURL=ProjetoCadastro.js.map