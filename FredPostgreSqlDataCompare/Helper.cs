using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FredPostgreSqlDataCompare
{
  public static class Helper
  {
    public static string TripleDESEncrypt(string password, string cle)
    {
      byte[] inputArray = Encoding.UTF8.GetBytes(password);
      var tripleDES = new TripleDESCryptoServiceProvider();
      tripleDES.Key = Encoding.UTF8.GetBytes(cle);
      tripleDES.Mode = CipherMode.ECB;
      tripleDES.Padding = PaddingMode.PKCS7;
      ICryptoTransform cTransform = tripleDES.CreateEncryptor();
      byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
      tripleDES.Clear();
      return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    public static string TripleDESDecrypt(string password, string cle)
    {
      byte[] inputArray = Convert.FromBase64String(password);
      var tripleDES = new TripleDESCryptoServiceProvider();
      tripleDES.Key = Encoding.UTF8.GetBytes(cle);
      tripleDES.Mode = CipherMode.ECB;
      tripleDES.Padding = PaddingMode.PKCS7;
      ICryptoTransform cTransform = tripleDES.CreateDecryptor();
      byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
      tripleDES.Clear();
      return Encoding.UTF8.GetString(resultArray);
    }

    public static string AESEncrypt(string password, string cle)
    {
      byte[] inputArray = Encoding.UTF8.GetBytes(password);
      var tripleDES = new AesCryptoServiceProvider();
      tripleDES.Key = Encoding.UTF8.GetBytes(cle);
      tripleDES.Mode = CipherMode.ECB;
      tripleDES.Padding = PaddingMode.PKCS7;
      ICryptoTransform cTransform = tripleDES.CreateEncryptor();
      byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
      tripleDES.Clear();
      return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    public static string AESDecrypt(string password, string cle)
    {
      byte[] inputArray = Convert.FromBase64String(password);
      var tripleDES = new AesCryptoServiceProvider();
      tripleDES.Key = Encoding.UTF8.GetBytes(cle);
      tripleDES.Mode = CipherMode.ECB;
      tripleDES.Padding = PaddingMode.PKCS7;
      ICryptoTransform cTransform = tripleDES.CreateDecryptor();
      byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
      tripleDES.Clear();
      return Encoding.UTF8.GetString(resultArray);
    }

    public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
    {
      // Check arguments.
      if (plainText == null || plainText.Length <= 0)
        throw new ArgumentNullException("plainText");
      if (Key == null || Key.Length <= 0)
        throw new ArgumentNullException("Key");
      if (IV == null || IV.Length <= 0)
        throw new ArgumentNullException("IV");
      byte[] encrypted;

      // Create an AesCryptoServiceProvider object
      // with the specified key and IV.
      using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
      {
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        // Create an encryptor to perform the stream transform.
        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for encryption.
        using (MemoryStream msEncrypt = new MemoryStream())
        {
          using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
          {
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
              //Write all data to the stream.
              swEncrypt.Write(plainText);
            }
            encrypted = msEncrypt.ToArray();
          }
        }
      }

      // Return the encrypted bytes from the memory stream.
      return encrypted;
    }

    public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
    {
      // Check arguments.
      if (cipherText == null || cipherText.Length <= 0)
        throw new ArgumentNullException("cipherText");
      if (Key == null || Key.Length <= 0)
        throw new ArgumentNullException("Key");
      if (IV == null || IV.Length <= 0)
        throw new ArgumentNullException("IV");

      // Declare the string used to hold
      // the decrypted text.
      string plaintext = null;

      // Create an AesCryptoServiceProvider object
      // with the specified key and IV.
      using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
      {
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        // Create a decryptor to perform the stream transform.
        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for decryption.
        using (MemoryStream msDecrypt = new MemoryStream(cipherText))
        {
          using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
          {
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {

              // Read the decrypted bytes from the decrypting stream
              // and place them in a string.
              plaintext = srDecrypt.ReadToEnd();
            }
          }
        }
      }

      return plaintext;
    }
  }
}
