/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
var RelatorioCadastroClass = (function () {
    function RelatorioCadastroClass() {
    }
    RelatorioCadastroClass.prototype.init = function () {
        $(".formata-decimal-dolar")
            .inputmask('US$ 99.999,99', { rightAlign: true, numericInput: true });
    };
    return RelatorioCadastroClass;
}());
window.onload = function () {
    var obj = new RelatorioCadastroClass();
    obj.init();
};
//# sourceMappingURL=RelatorioCadastro.js.map