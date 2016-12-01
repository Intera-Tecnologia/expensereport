/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
var ColaboradorCadastroClass = (function () {
    function ColaboradorCadastroClass() {
    }
    ColaboradorCadastroClass.prototype.init = function () {
        $("#btnSavlar").on("click", function () {
            alert("Entrou");
            $("#form_validation").validate();
        });
    };
    return ColaboradorCadastroClass;
}());
window.onload = function () {
    var obj = new ColaboradorCadastroClass();
    obj.init();
};
//# sourceMappingURL=ColaboradorCadastro.js.map