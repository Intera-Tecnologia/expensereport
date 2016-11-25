using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpenseReport.Business.BLL;

namespace ExpenseReport.Business.Test
{
    [TestClass]
    public class TipoDespesa
    {
        [TestMethod]
        public void ListagemTest()
        {
            TipoDespesaBLL tipoDespesaBLL = new TipoDespesaBLL();
            bool funcionou = true;
            int qtd = 0;
            try
            {
                qtd = tipoDespesaBLL.Listagem().Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                funcionou = false;
            }

            Assert.IsTrue(funcionou, "Gerou uma exceção na execução.");
            Assert.IsTrue(qtd > 0, "Lista Vazia.");
        }
    }
}
