using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Tools
{
  public static class Helper
  {
    public const int FirstElement = 0;
    public const int SecondElement = 1;
    public const int ThirdElement = 2;

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
      //byte[] inputArray = Encoding.UTF8.GetBytes(password);
      //var aesDES = new AesCryptoServiceProvider();
      //aesDES.Key = Encoding.UTF8.GetBytes(cle);
      //aesDES.Mode = CipherMode.ECB;
      //aesDES.Padding = PaddingMode.PKCS7;
      //ICryptoTransform cTransform = aesDES.CreateEncryptor();
      //byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
      //aesDES.Clear();
      //return Convert.ToBase64String(resultArray, 0, resultArray.Length);
      return string.Empty; // until implemented
    }

    public static string AESDecrypt(string password, string cle)
    {
      //byte[] inputArray = Convert.FromBase64String(password);
      //var tripleDES = new AesCryptoServiceProvider();
      //tripleDES.Key = Encoding.UTF8.GetBytes(cle);
      //tripleDES.Mode = CipherMode.ECB;
      //tripleDES.Padding = PaddingMode.PKCS7;
      //ICryptoTransform cTransform = tripleDES.CreateDecryptor();
      //byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
      //tripleDES.Clear();
      //return Encoding.UTF8.GetString(resultArray);
      return string.Empty; // until implemented
    }

    static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] salt)
    {
      // Check arguments.
      if (plainText == null || plainText.Length <= 0)
      {
        throw new ArgumentNullException("plainText");
      }

      if (key == null || key.Length <= 0)
      {
        throw new ArgumentNullException("Key");
      }

      if (salt == null || salt.Length <= 0)
      {
        throw new ArgumentNullException("IV = vecteur d'initialisation");
      }

      byte[] encrypted;

      // Create an AesCryptoServiceProvider object
      // with the specified key and IV.
      using (AesCryptoServiceProvider aesAlgo = new AesCryptoServiceProvider())
      {
        aesAlgo.Key = key;
        aesAlgo.IV = salt;

        // Create an encryptor to perform the stream transform.
        ICryptoTransform encryptor = aesAlgo.CreateEncryptor(aesAlgo.Key, aesAlgo.IV);

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

    static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] salt)
    {
      // Check arguments.
      if (cipherText == null || cipherText.Length <= 0)
      {
        throw new ArgumentNullException("cipherText");
      }

      if (key == null || key.Length <= 0)
      {
        throw new ArgumentNullException("Key");
      }

      if (salt == null || salt.Length <= 0)
      {
        throw new ArgumentNullException("IV = vecteur d'initialisation");
      }

      // Declare the string used to hold
      // the decrypted text.
      string plaintext = null;

      // Create an AesCryptoServiceProvider object
      // with the specified key and IV.
      using (AesCryptoServiceProvider aesAlgo = new AesCryptoServiceProvider())
      {
        aesAlgo.Key = key;
        aesAlgo.IV = salt;

        // Create a decryptor to perform the stream transform.
        ICryptoTransform decryptor = aesAlgo.CreateDecryptor(aesAlgo.Key, aesAlgo.IV);

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

    public static string[] CreateAesKey()
    {
      string[] result = new [] { "", ""};
      using (Aes aesAlgorithm = Aes.Create())
      {
        //Console.WriteLine($"Aes Cipher Mode : {aesAlgorithm.Mode}");
        //Console.WriteLine($"Aes Padding Mode: {aesAlgorithm.Padding}");
        //Console.WriteLine($"Aes Key Size : {aesAlgorithm.KeySize}");
        //Console.WriteLine($"Aes Block Size : {aesAlgorithm.BlockSize}");

        //set the parameters with out keyword
        var keyBase64 = Convert.ToBase64String(aesAlgorithm.Key);
        var vectorBase64 = Convert.ToBase64String(aesAlgorithm.IV);
        result[0] = keyBase64;
        result[1] = vectorBase64;
      }

      return result;
    }

    public static string[] WriteFile(string[] keys, string filename, bool append = true)
    {
      var result = new[] { "ok", ""};
      try
      {
        using (StreamWriter sw = new StreamWriter(filename, append))
        {
          for (int i = 0; i < keys.Length; i++)
          {
            sw.WriteLine(keys[i]);
          }
        }
      }
      catch (Exception exception)
      {
        result[0] = "ko";
        result[1] = exception.Message;
      }

      return result;
    }
  }
}
