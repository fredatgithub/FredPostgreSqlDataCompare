using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools;

namespace FredPostgreSqlDataCompare.UnitTestProject
{
  [TestClass]
  public class UnitTestCrypro
  {
    [TestMethod]
    public void TestMethod_1()
    {
      Aes aesAlgo = Aes.Create();
      aesAlgo.KeySize = 256; // 128 ou 192 ou 256 bits 
      byte[] key = aesAlgo.Key;
      var source = "the super duper long password";
      var source2 = key.ToString();
      var expected = "whatever";
      //var result = Helper.AESEncrypt(source, source2);
      //Assert.AreEqual(expected, result);
    }
  }
}
