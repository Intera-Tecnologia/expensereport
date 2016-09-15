using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpenseReport.ServiceLibrary.Test.ServiceClient;
using System.Linq;

namespace ExpenseReport.ServiceLibrary.Test
{
   [TestClass]
   public class GetDataTest
   {
      [TestMethod]
      public void TestGetData()
      {
         ExpenseReportServiceClient wcfService = new ExpenseReportServiceClient();
         String retorno = wcfService.GetData( 5 );
         Assert.IsTrue( retorno.Contains( "5" ) );
      }
   }
}
