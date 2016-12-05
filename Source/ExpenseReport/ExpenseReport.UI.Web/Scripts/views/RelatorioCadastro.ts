/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

declare var $: JQueryStatic;


class RelatorioCadastroClass {
    init(): void {
        $(".formata-decimal-dolar")
            .inputmask('US$ 99.999,99', { rightAlign: true, numericInput:true });
    }
}

window.onload = () => {
    var obj = new RelatorioCadastroClass();
    obj.init();

}