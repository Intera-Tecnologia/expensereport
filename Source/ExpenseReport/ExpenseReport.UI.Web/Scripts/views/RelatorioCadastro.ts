/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

declare var $: JQueryStatic;


class RelatorioCadastroClass {

    btnCancelar = $("#btnCancelar");
    btnSalvar = $("#btnSalvar");
    btnSalvarDespesa = $("#btnSalvarDespesa");

    lblViagem = $("#validaViagem");
    lblDiarias = $("#validaDiarias");
    lblAdiantamento = $("#validaAdiantamento");
    lblMoeda = $("#validaMoeda");
    lblPasagem = $("#validaPassagem");    
    lblCambio = $("#validaCambio");

    cmbViagem = $("#cmbViagem");
    txtDiariasRecebidas = $("#txtDiariasRecebidas");
    txtMoeda = $("#txtMoeda");
    txtPassagemFaturada = $("#txtPassagemFaturada");
    cmbColaborador = $("#cmbColaborador");
    txtCambioDia = $("#txtCambioDia");
    hidAcao = $("#Acao");

    form = $("#form");


    init(): void {

        $(".formata-data")
            .inputmask({ 'alias': 'date' });

        (<any>$(".formata-decimal-dolar"))
            .inputmask('numeric', {
                radixPoint: ",",
                groupSeparator: "",
                digits: 2,
                autoGroup: true,                
                rightAlign: true,
                oncleared: () => { (<any>self).Value(''); }
            });

        // Define a validação do formulário
        this.btnSalvar.on("click", () => {   
            this.hidAcao.val("N");         
            if (this.validaForm() == true)
                this.form.submit();
        });

        // Botão Cancelar retorna para listagem
        this.btnCancelar.on("click", () => {
            window.location.href = '/Relatorio';
        });

        this.btnSalvarDespesa.on("click", () => {
            this.hidAcao.val("AdDesp");
            this.form.submit();
        });
    }

    validaForm(): boolean {
        var validado: boolean = true;       
        
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
    }
}

window.onload = () => {
    var obj = new RelatorioCadastroClass();
    obj.init();

}