using System;
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
  }
}
