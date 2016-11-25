using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpenseReport.Business.BLL;

namespace ExpenseReport.Business.Test
{
    [TestClass]
    public class FonteDespesaTest
    {
        [TestMethod]
        public void ListagemTest()
        {
            FonteDespesaBLL fonteDespesaBLL = new FonteDespesaBLL();
            bool funcionou = true;
            int qtd = 0;
            try
            {
                qtd = fonteDespesaBLL.Listagem().Count;
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
