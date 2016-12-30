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

//          abEncryptedText = new byte[] 
//                            {
//                               0x20, 0x9d, 0x73, 0x98, 0x72, 0x97, 0x1d, 0x4f, 
//                               0x92, 0xa9, 0x5b, 0xf0, 0xb6, 0x72, 0x14, 0x59,
//                               0xbd, 0x53, 0x6b, 0x54, 0xe5, 0x06, 0x88, 0xd5,
//                               0x66, 0xff, 0x2f, 0x91, 0x45, 0x58, 0x91, 0x97
//                            };
//          abSalt = new byte[]
//                            {
//                               0xe6, 0x50, 0x58, 0x60, 0x06, 0xb8, 0xb1, 0x7a,
//                               0xa6, 0x8f, 0x19, 0xe0, 0xd5, 0x5f, 0x9d, 0x61
//                            };

         string strKey = CryptoEngine.Hash(PassWd, string.Empty);

         abEncryptedText = CryptoEngine.EncryptAES(Text, strKey, abSalt);

         Assert.IsNotNull(abEncryptedText);
         Assert.IsTrue(abEncryptedText.Length > 0);
         
         string strText = CryptoEngine.DecryptAES(abEncryptedText, strKey, abSalt);
         Assert.AreEqual(strText, Text);
      }
   }
}
