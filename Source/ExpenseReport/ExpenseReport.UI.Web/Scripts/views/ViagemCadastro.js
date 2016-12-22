/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
var ViagemCadastroClass = (function () {
    function ViagemCadastroClass() {
        this.btnCancelar = $("#btnCancelar");
        this.btnSalvar = $("#btnSalvar");
        this.txtDescricao = $("#txtDescricao");
        this.txtDataInicio = $("#txtDataInicio");
        this.txtDataFim = $("#txtDataFim");
        this.txtJustificativa = $("#txtJustificativa");
        this.lblValidaDescricao = $("#validaDescricao");
        this.lblValidaDataInicio = $("#validaDataInicio");
        this.lblValidaDataFim = $("#validaDataFim");
        this.lblValidaJustificativa = $("#validaJustificativa");
        this.form = $("#form");
    }
    ViagemCadastroClass.prototype.init = function () {
        var _this = this;
        // Aplica a formatação de data nos campos de data
        $(".formata-data")
            .inputmask({ 'alias': 'date' });
        // Define a validação do formulário
        this.btnSalvar.on("click", function () {
            if (_this.validaForm() == true)
                _this.form.submit();
        });
        // Botão Cancelar retorna para listagem
        this.btnCancelar.on("click", function () {
            window.location.href = '/Viagem';
        });
    };
    ViagemCadastroClass.prototype.validaForm = function () {
        var validado = true;
        // descrição
        if (this.txtDescricao.val().trim().length == 0) {
            validado = false;
            this.lblValidaDescricao.html(MSG_CAMPO_OBRIGATORIO);
        }
        else {
            this.lblValidaDescricao.html(MSG_ESPACO_EM_BRANCO);
        }
        // Data Inicio
        if (this.txtDataInicio.val().trim().length == 0) {
            validado = false;
            this.lblValidaDataInicio.html(MSG_CAMPO_OBRIGATORIO);
        }
        else {
            this.lblValidaDataInicio.html(MSG_ESPACO_EM_BRANCO);
        }
        // Data Fim
        if (this.txtDataFim.val().trim().length == 0) {
            validado = false;
            this.lblValidaDataFim.html(MSG_CAMPO_OBRIGATORIO);
        }
        else {
            this.lblValidaDataFim.html(MSG_ESPACO_EM_BRANCO);
        }
        // Justificativa
        if (this.txtJustificativa.val().trim().length == 0) {
            validado = false;
            this.lblValidaJustificativa.html(MSG_CAMPO_OBRIGATORIO);
        }
        else {
            this.lblValidaJustificativa.html(MSG_ESPACO_EM_BRANCO);
        }
        return validado;
    };
    return ViagemCadastroClass;
}());
window.onload = function () {
    var obj = new ViagemCadastroClass();
    obj.init();
};
//# sourceMappingURL=ViagemCadastro.js.map