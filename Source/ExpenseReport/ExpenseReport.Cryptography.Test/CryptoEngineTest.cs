using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpenseReport.Cryptography.Engine;

namespace ExpenseReport.Cryptography.Test
{
   [TestClass]
   public class CryptoEngineTest
   {
      const string Text = "MessageToEncrypt";
      const string PassWd = "PassWd";
      const string HashPassWd = "Password";
      byte[] abEncryptedText;
      byte[] abSalt;     
      
      [TestMethod]
      public void TestEncryptDecrypt()
      {
         abEncryptedText = null;
         abSalt = CryptoEngine.CreateSalt();
         string strKey = CryptoEngine.Hash(PassWd, string.Empty);

         abEncryptedText = CryptoEngine.EncryptAES(Text, strKey, abSalt);

         Assert.IsNotNull(abEncryptedText);
         Assert.IsTrue(abEncryptedText.Length > 0);
         
         string strText = CryptoEngine.DecryptAES(abEncryptedText, strKey, abSalt);
         Assert.AreEqual(strText, Text);
      }
   }
}
