/// <reference path="../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

declare var $: JQueryStatic;

class RelatorioListagemTS {
    btnLocalizar = $("#btnLocalizar");
    btnSim = $("#btnSim");
    form = $("#formProjeto");
    Acao = $("#Acao");
    btnExcluirList = $(".btnExcluir");
    btnEditarList = $(".btnEditar");
    RelatorioIDExcluir = $("#RelatorioIDExcluir");

    init(): void {
        // Ao clicar, colocar o valor "A" no campo Hidden
        // de  Acao
        this.btnLocalizar.on("click", () => {
            this.Acao.val("L");
        });

        // Ao clicar, executar o submit do form para realizar
        // a remoção do registro
        this.btnSim.on("click", () => {
            this.form.submit();
        });

        // Ao clicar no excluir, localizar o ID do Projeto
        // E colocar no HIDDEN correspondente
        this.btnExcluirList.on("click", (e: JQueryEventObject) => {
            var id = $(e.currentTarget).data("id");
            this.Acao.val("R"); // Remover
            this.RelatorioIDExcluir.val(id);
        });

        this.btnEditarList.on("click", (e: JQueryEventObject) => {            
            var id: string = $(e.currentTarget).data("id");
            window.location.href = "/Relatorio/Cadastro?id=" + id;
        });
    }
}

window.onload = () => {
    var obj = new RelatorioListagemTS();
    obj.init();
}
