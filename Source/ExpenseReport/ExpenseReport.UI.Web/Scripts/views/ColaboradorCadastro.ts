/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

declare var $: JQueryStatic;

class ColaboradorCadastroClass {
    init(): void {
        $("#btnSavlar").on("click", () => {
            alert("Entrou");
            (<any>$("#form_validation")).validate();
        });
    }


}

window.onload = () => {
    var obj = new ColaboradorCadastroClass();
    obj.init();
}