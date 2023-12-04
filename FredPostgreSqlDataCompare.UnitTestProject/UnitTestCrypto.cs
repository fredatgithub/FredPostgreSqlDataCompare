using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools;

namespace FredPostgreSqlDataCompare.UnitTestProject
{
  [TestClass]
  public class UnitTestCrypto
  {
    [TestMethod]
    public void TestMethod_Length_keys()
    {
      var source = Helper.CreateAesCryptoService();
      var source1 = source[0];
      var source2 = source[1];
      Assert.IsTrue(source1.Length == 32);
      Assert.IsTrue(source2.Length == 16);
    }

    [TestMethod]
    public void TestMethod_Convert_bytes_keys_To_String()
    {
      var source = Helper.CreateAesCryptoService();
      var source1 = source[0];
      var source2 = source[1];
      string source3 = Encoding.UTF8.GetString(source1);
      Assert.IsTrue(source3.Length == 32);
    }

    [TestMethod]
    public void TestMethod_Convert_string_to_byte()
    {
      var source = Helper.CreateAesCryptoService();
      var source1 = source[0];
      var source2 = source[1];
      Assert.AreNotEqual(source1, source2);
      string source3 = Convert.ToBase64String(source1);
      byte[] source4 = Convert.FromBase64String(source3);
      string source5 = Convert.ToBase64String(source4);
      Assert.AreEqual(source5, source3);
    }

    [TestMethod]
    public void TestMethod_Convert_back_and_forth()
    {
      string originalString = "Hello, World!";
      byte[] utf8Bytes = Encoding.UTF8.GetBytes(originalString);
      string decodedString = Encoding.UTF8.GetString(utf8Bytes);
      Assert.AreEqual(originalString, decodedString);
    }

    [TestMethod]
    public void TestMethod_back_and_forth_2()
    {
      var source1 = Helper.CreateAesCryptoService()[0];
      string source2 = Convert.ToBase64String(source1);
      byte[] source3 = Convert.FromBase64String(source2);
      CollectionAssert.AreEqual(source1, source3);
    }
  }
}
