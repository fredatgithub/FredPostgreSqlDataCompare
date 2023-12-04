using System;
using System.CodeDom;
using System.Collections.Generic;
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
    public const int FourthElement = 3;
    public const int FithElement = 4;

    public const string OK = "ok";
    public const int One = 1;

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

    public static byte[] EncryptStringToBytesWithAes(string plainText, byte[] key, byte[] salt)
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

    public static string EncryptToStringWithAes(string plainText, byte[] key, byte[] salt)
    {
      var encryptedString = Encoding.UTF8.GetString(EncryptStringToBytesWithAes(plainText, key, salt));
      return encryptedString;
    }

    /// <summary>
    /// Decode an encrypted text to a plain text.
    /// </summary>
    /// <param name="codedText">The encrypted text.</param>
    /// <param name="key">The encryption key.</param>
    /// <param name="salt">The salt.</param>
    /// <returns>A human-readable text.</returns>
    public static string DecodeToStringWithAes(string codedText, string key, string salt)
    {
      var keyToByte = Encoding.UTF8.GetBytes(key);
      var saltToByte = Encoding.UTF8.GetBytes(salt);
      var encryptedText = Encoding.UTF8.GetBytes(codedText);
      var plainText = DecodeFromBytes_Aes(encryptedText, keyToByte, saltToByte);
      return plainText;
    }

    static string DecodeFromBytes_Aes(byte[] cipherText, byte[] key, byte[] salt)
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

      // Declare the string used to hold the decrypted text.
      string plaintext = null;

      // Create an AesCryptoServiceProvider object with the specified key and IV.
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

              // Read the decrypted bytes from the decrypting stream and place them in a string.
              plaintext = srDecrypt.ReadToEnd();
            }
          }
        }
      }

      return plaintext;
    }

    public static byte[][] CreateAesCryptoService()
    {
      byte[][] result = new byte[2][];
      using (var aesAlgorithm = new AesCryptoServiceProvider())
      {
        var keyBase64 = aesAlgorithm.Key;
        var vectorBase64 = aesAlgorithm.IV;
        result[0] = keyBase64;
        result[1] = vectorBase64;
      }

      return result;
    }

    public static byte[][] CreateAesKey()
    {
      byte[][] result = new byte[2][];
      using (Aes aesAlgorithm = Aes.Create())
      {
        //Console.WriteLine($"Aes Cipher Mode : {aesAlgorithm.Mode}");
        //Console.WriteLine($"Aes Padding Mode: {aesAlgorithm.Padding}");
        //Console.WriteLine($"Aes Key Size : {aesAlgorithm.KeySize}");
        //Console.WriteLine($"Aes Block Size : {aesAlgorithm.BlockSize}");
        //var keyBase64 = Convert.ToBase64String(aesAlgorithm.Key);
        //var vectorBase64 = Convert.ToBase64String(aesAlgorithm.IV);
        var keyBase64 = aesAlgorithm.Key;
        var vectorBase64 = aesAlgorithm.IV;
        result[0] = keyBase64;
        result[1] = vectorBase64;
      }

      return result;
    }

    public static string[] WriteToFile(string[] lines, string filename, bool append = true)
    {
      var result = new[] { "ok", string.Empty };
      try
      {
        using (StreamWriter sw = new StreamWriter(filename, append))
        {
          for (int i = 0; i < lines.Length; i++)
          {
            sw.WriteLine(lines[i]);
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

    public static string[] ReadFile(string filename)
    {
      var result = new List<string> { "ok" };
      try
      {
        using (StreamReader sr = new StreamReader(filename))
        {
          var line = string.Empty;
          while ((line = sr.ReadLine()) != null)
          {
            result.Add(line);
          }
        }
      }
      catch (Exception exception)
      {
        result[0] = $"ko - {exception.Message}";
      }

      return result.ToArray();
    }
  }
}
