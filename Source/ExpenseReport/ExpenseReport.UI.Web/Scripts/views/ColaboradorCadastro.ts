/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

declare var $: JQueryStatic;

class ColaboradorCadastroClass {
    init(): void {
        $("#btnSalvar").on("click", () => {                   
            (<any>$("#form_validation")).validate();
        });

        $("#btnCancelar").on("click", () => {
            alert("Entrou 2");
        });
    }


}

window.onload = () => {
    
    var obj = new ColaboradorCadastroClass();
    obj.init();
}