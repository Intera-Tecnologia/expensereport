/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

declare var $: JQueryStatic;


class ViagemListagemTS {
    btnLocalizar = $("#btnLocalizar");
    btnSim = $("#btnSim");
    form = $("#formViagem");
    Acao = $("#Acao");
    btnExcluirList = $(".btnExcluir");
    btnEditarList = $(".btnEditar");
    ViagemIDExcluir = $("#ViagemIDExcluir");

    init(): void {

        // Ao Clicar, colocar o valor "A" no campo Hidden
        // de Acao
        this.btnLocalizar.on("click", () => {            
            this.Acao.val("L");
        });

        // Ao clicar, executar o submit do form para realizar
        // a remoção do registro
        $("#btnSim").on("click", () => {
            this.form.submit();
        });

        // Ao clicar no excluir, localizar o ID do Projeto
        // E colocar no HIDDEN correspondente
        this.btnExcluirList.on("click", (e: JQueryEventObject) => {
            var id = $(e.currentTarget).data("id");
            this.Acao.val("R"); // Remover
            this.ViagemIDExcluir.val(id);
        });

        this.btnEditarList.on("click", (e: JQueryEventObject) => {
            var id: string = $(e.currentTarget).data("id");
            window.location.href = "/Viagem/Cadastro?id=" + id;
        });
    }
}

window.onload = () => {
    var obj = new ViagemListagemTS();
    obj.init();
}