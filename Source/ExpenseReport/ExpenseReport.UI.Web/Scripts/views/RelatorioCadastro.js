/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
var RelatorioCadastroClass = (function () {
    function RelatorioCadastroClass() {
    }
    RelatorioCadastroClass.prototype.init = function () {
        $(".formata-decimal-dolar")
            .inputmask('numeric', {
            radixPoint: ",",
            groupSeparator: ".",
            digits: 2,
            autoGroup: true,
            //  prefix: '$', //No Space, this will truncate the first character
            rightAlign: true,
            oncleared: function () { self.Value(''); } });
    };
    return RelatorioCadastroClass;
}());
window.onload = function () {
    var obj = new RelatorioCadastroClass();
    obj.init();
};
//# sourceMappingURL=RelatorioCadastro.js.map