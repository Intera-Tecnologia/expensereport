/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

declare var $: JQueryStatic;


class RelatorioCadastroClass {
    init(): void {
       

        (<any>$(".formata-decimal-dolar"))
            .inputmask('numeric', {
                radixPoint: ",",
                groupSeparator: ".",
                digits: 2,
                autoGroup: true,
                //  prefix: '$', //No Space, this will truncate the first character
                rightAlign: true,
                oncleared: () => { (<any>self).Value(''); } });
    }
}

window.onload = () => {
    var obj = new RelatorioCadastroClass();
    obj.init();

}