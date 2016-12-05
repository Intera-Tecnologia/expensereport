/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.inputmask.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
var ViagemCadastroClass = (function () {
    function ViagemCadastroClass() {
    }
    ViagemCadastroClass.prototype.init = function () {
        $(".formata-data")
            .inputmask({ 'alias': 'date' });
    };
    return ViagemCadastroClass;
}());
window.onload = function () {
    var obj = new ViagemCadastroClass();
    obj.init();
};
//# sourceMappingURL=ViagemCadastro.js.map