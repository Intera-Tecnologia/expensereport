/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
var ColaboradorCadastroClass = (function () {
    function ColaboradorCadastroClass() {
    }
    ColaboradorCadastroClass.prototype.init = function () {
        $("#btnSalvar").on("click", function () {
            $("#form_validation").validate();
        });
        $("#btnCancelar").on("click", function () {
            alert("Entrou 2");
        });
    };
    return ColaboradorCadastroClass;
}());
window.onload = function () {
    var obj = new ColaboradorCadastroClass();
    obj.init();
};
//# sourceMappingURL=ColaboradorCadastro.js.map