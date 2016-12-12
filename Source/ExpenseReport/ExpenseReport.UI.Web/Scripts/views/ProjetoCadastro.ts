/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />


declare var $: JQueryStatic;



class ProjetoCadastroClass {

    txtDescricao = $("#Descricao");
    txtPrograma = $("#Programa");
    txtCentroDeCusto = $("#CentroDeCusto");

    init(): void {
        // Define a validação do formulário
        $("#btnSalvar").on("click", () => {
            if (this.validaForm() == true)
                $("#form").submit();
        });

        // Botão Cancelar retorna para listagem
        $("#btnCancelar").on("click", () => {
            window.location.href = '/Projeto';
        });
    }

    validaForm(): boolean {
        var validado: boolean = true;

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
    }
}

window.onload = () => {
    var obj = new ProjetoCadastroClass();
    obj.init();
}