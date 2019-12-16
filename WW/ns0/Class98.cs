// Decompiled with JetBrains decompiler
// Type: ns0.Class98
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ns0
{
  internal class Class98
  {
    private static byte[] byte_0 = new byte[8]{ (byte) 50, (byte) 118, (byte) 118, (byte) 109, (byte) 130, (byte) 48, (byte) 11, (byte) 61 };
    private static byte[] byte_1 = new byte[8]{ (byte) 17, (byte) 19, (byte) 47, (byte) 49, (byte) 22, (byte) 245, (byte) 146, (byte) 183 };

    internal static byte[] smethod_0(byte[] plainBytes)
    {
      DES des = (DES) new DESCryptoServiceProvider();
      des.IV = Class98.byte_0;
      des.Key = Class98.byte_1;
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);
      cryptoStream.Write(plainBytes, 0, plainBytes.Length);
      cryptoStream.Close();
      return memoryStream.ToArray();
    }

    internal static byte[] smethod_1(byte[] encryptedBytes)
    {
      DES des = (DES) new DESCryptoServiceProvider();
      des.IV = Class98.byte_0;
      des.Key = Class98.byte_1;
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write);
      cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
      cryptoStream.Close();
      return memoryStream.ToArray();
    }

    internal static string smethod_2(byte[] bytes)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < bytes.Length; ++index)
        stringBuilder.Append(bytes[index].ToString("x2"));
      return stringBuilder.ToString();
    }

    internal static byte[] smethod_3(string s)
    {
      byte[] numArray = new byte[s.Length / 2];
      for (int startIndex = 0; startIndex < s.Length; startIndex += 2)
      {
        string s1 = s.Substring(startIndex, 2);
        numArray[startIndex / 2] = byte.Parse(s1, NumberStyles.HexNumber);
      }
      return numArray;
    }
  }
}
