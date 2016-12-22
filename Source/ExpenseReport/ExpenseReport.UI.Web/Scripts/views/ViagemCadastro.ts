/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

declare var $: JQueryStatic;


class ViagemCadastroClass {

    btnCancelar = $("#btnCancelar");
    btnSalvar = $("#btnSalvar");

    txtDescricao = $("#txtDescricao");
    txtDataInicio = $("#txtDataInicio");
    txtDataFim = $("#txtDataFim");
    txtJustificativa = $("#txtJustificativa");

    lblValidaDescricao = $("#validaDescricao");
    lblValidaDataInicio = $("#validaDataInicio");
    lblValidaDataFim = $("#validaDataFim");
    lblValidaJustificativa = $("#validaJustificativa");

    form = $("#form");

    init(): void {

        // Aplica a formatação de data nos campos de data
        $(".formata-data")
            .inputmask({ 'alias': 'date' });

        // Define a validação do formulário
        this.btnSalvar.on("click", () => {
            if (this.validaForm() == true)
                this.form.submit();
        });

        // Botão Cancelar retorna para listagem
        this.btnCancelar.on("click", () => {
            window.location.href = '/Viagem';
        });
        
    }

    validaForm(): boolean {        
        var validado: boolean = true;

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
    }

}

window.onload = () => {
    var obj = new ViagemCadastroClass();
    obj.init();
    
}