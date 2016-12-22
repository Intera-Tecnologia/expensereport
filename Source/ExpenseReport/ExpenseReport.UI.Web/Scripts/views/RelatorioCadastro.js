/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
var RelatorioCadastroClass = (function () {
    function RelatorioCadastroClass() {
        this.btnCancelar = $("#btnCancelar");
        this.btnSalvar = $("#btnSalvar");
        this.btnSalvarDespesa = $("#btnSalvarDespesa");
        this.lblViagem = $("#validaViagem");
        this.lblDiarias = $("#validaDiarias");
        this.lblAdiantamento = $("#validaAdiantamento");
        this.lblMoeda = $("#validaMoeda");
        this.lblPasagem = $("#validaPassagem");
        this.lblCambio = $("#validaCambio");
        this.cmbViagem = $("#cmbViagem");
        this.txtDiariasRecebidas = $("#txtDiariasRecebidas");
        this.txtMoeda = $("#txtMoeda");
        this.txtPassagemFaturada = $("#txtPassagemFaturada");
        this.cmbColaborador = $("#cmbColaborador");
        this.txtCambioDia = $("#txtCambioDia");
        this.hidAcao = $("#Acao");
        this.form = $("#form");
    }
    RelatorioCadastroClass.prototype.init = function () {
        var _this = this;
        $(".formata-data")
            .inputmask({ 'alias': 'date' });
        $(".formata-decimal-dolar")
            .inputmask('numeric', {
            radixPoint: ",",
            groupSeparator: "",
            digits: 2,
            autoGroup: true,
            rightAlign: true,
            oncleared: function () { self.Value(''); }
        });
        // Define a validação do formulário
        this.btnSalvar.on("click", function () {
            _this.hidAcao.val("N");
            if (_this.validaForm() == true)
                _this.form.submit();
        });
        // Botão Cancelar retorna para listagem
        this.btnCancelar.on("click", function () {
            window.location.href = '/Relatorio';
        });
        this.btnSalvarDespesa.on("click", function () {
            _this.hidAcao.val("AdDesp");
            _this.form.submit();
        });
    };
    RelatorioCadastroClass.prototype.validaForm = function () {
        var validado = true;
        // Passagem Faturada
        if (this.txtPassagemFaturada.val().trim().length == 0 || this.txtPassagemFaturada.val().trim() == "0") {
            validado = false;
            this.lblPasagem.html(MSG_CAMPO_OBRIGATORIO);
        }
        else {
            this.lblPasagem.html(MSG_ESPACO_EM_BRANCO);
        }
        // Passagem Faturada
        if (this.txtCambioDia.val().trim().length == 0 || this.txtCambioDia.val() == 0) {
            validado = false;
            this.lblCambio.html(MSG_CAMPO_OBRIGATORIO);
        }
        else {
            this.lblCambio.html(MSG_ESPACO_EM_BRANCO);
        }
        return validado;
    };
    return RelatorioCadastroClass;
}());
window.onload = function () {
    var obj = new RelatorioCadastroClass();
    obj.init();
};
//# sourceMappingURL=RelatorioCadastro.js.map