using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ExpenseReport.ServiceLibrary.Test.ServicoPrincipal;
using System.Collections.Generic;

namespace ExpenseReport.ServiceLibrary.Test
{
   [TestClass]
   public class FonteDespesaTest
   {
      [TestMethod]
      public void ListagemWCFTest()
      {
            ServicoPrincipalClient servico = new ServicoPrincipalClient();
            int qtd = 0;
            bool funcionou = true;
            try
            {
                List<FonteDespesa> lista = servico
                        .FonteDespesa_Listagem()
                        .ToList();
                qtd = lista.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                funcionou = false;
                throw;
            }

            Assert.AreEqual(funcionou == true, "WCF Gerou uma exceção na execução.");
            Assert.AreEqual(qtd > 0, "Retornou uma lista vazia.");
      }
   }
}
