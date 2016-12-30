using PCLCrypto;
using System;
using System.IO;
using System.Text;

namespace ExpenseReport.Cryptography.Engine
{
   public static class CryptoEngine
   {
      public static readonly int SaltBitSize = 128;
      public static readonly int SaltByteSize = SaltBitSize / 8;

      public static readonly int KeyBitSize = 256;
      public static readonly int KeyByteSize = KeyBitSize / 8;

      public static readonly int Iterations = 10000;


      public static byte[] CreateSalt()
      {
         // .NET Framework-like API
         byte[] cryptoRandomBuffer = new byte[SaltByteSize];
         NetFxCrypto.RandomNumberGenerator.GetBytes(cryptoRandomBuffer);
         return cryptoRandomBuffer;
      }

      /// <summary>    
      /// Creates a derived key from a combination     
      /// </summary>    
      /// <param name="password"></param>    
      /// <param name="salt"></param>    
      /// <param name="keyLengthInBytes"></param>    
      /// <param name="iterations"></param>    
      /// <returns></returns>    
      public static byte[] CreateDerivedKey(string password, byte[] salt)
      {
         byte[] key = NetFxCrypto.DeriveBytes.GetBytes(password, salt, Iterations, KeyByteSize);
         return key;
      }

      /// <summary>    
      /// Encrypts given data using symmetric algorithm AES    
      /// </summary>    
      /// <param name="data">Data to encrypt</param>    
      /// <param name="password">Password</param>    
      /// <param name="salt">Salt</param>    
      /// <returns>Encrypted bytes</returns>    
      public static byte[] EncryptAES(string data, string password, byte[] salt)
      {
         byte[] key = CreateDerivedKey(password, salt);

         ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
         ICryptographicKey symetricKey = aes.CreateSymmetricKey(key);
         var bytes = WinRTCrypto.CryptographicEngine.Encrypt(symetricKey, Encoding.UTF8.GetBytes(data));
         return bytes;
      }
      /// <summary>    
      /// Decrypts given bytes using symmetric algorithm AES    
      /// </summary>    
      /// <param name="data">data to decrypt</param>    
      /// <param name="password">Password used for encryption</param>    
      /// <param name="salt">Salt used for encryption</param>    
      /// <returns></returns>    
      public static string DecryptAES(byte[] data, string password, byte[] salt)
      {
         byte[] key = CreateDerivedKey(password, salt);

         ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
         ICryptographicKey symetricKey = aes.CreateSymmetricKey(key);
         var bytes = WinRTCrypto.CryptographicEngine.Decrypt(symetricKey, data);
         return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
      }
      public static string Hash(string text, string key)
      {
         byte[] data = Encoding.UTF8.GetBytes(text);
         var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha256);
         byte[] hash = hasher.HashData(data);
         return Convert.ToBase64String(hash);
         
      }

   }
}

