/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

declare var $: JQueryStatic;


class ViagemCadastroClass {
    init(): void {
        $(".formata-data")
            .inputmask({ 'alias': 'date' });
    }
}

window.onload = () => {
    var obj = new ViagemCadastroClass();
    obj.init();
    
}