// Decompiled with JetBrains decompiler
// Type: ns10.Class69
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns7;
using ns8;
using System;
using System.IO;
using WW.Pdf;
using WW.Text;
using WW.Util;

namespace ns10
{
  internal class Class69
  {
    private static readonly byte[] byte_0 = new byte[32]{ (byte) 40, (byte) 191, (byte) 78, (byte) 94, (byte) 78, (byte) 117, (byte) 138, (byte) 65, (byte) 100, (byte) 0, (byte) 78, (byte) 86, byte.MaxValue, (byte) 250, (byte) 1, (byte) 8, (byte) 46, (byte) 46, (byte) 0, (byte) 182, (byte) 208, (byte) 104, (byte) 62, (byte) 128, (byte) 47, (byte) 12, (byte) 169, (byte) 254, (byte) 100, (byte) 83, (byte) 105, (byte) 122 };
    private byte[] byte_1;
    private byte[] byte_2;
    private byte[] byte_3;
    private int int_0;

    public Class69(Class68 options, PdfFileIdentifier fileId)
    {
      this.method_1(options);
      this.method_0(options, fileId);
      this.method_2(options);
      this.int_0 = options.Permissions;
    }

    private void method_0(Class68 options, PdfFileIdentifier fileId)
    {
      this.byte_3 = Class69.smethod_0(Class69.smethod_1(options.UserPassword), this.byte_1, options.Permissions, fileId.CreatedPart);
    }

    private void method_1(Class68 options)
    {
      byte[] hash = Md5Helper.ComputeHash(Class69.smethod_1(options.OwnerPassword ?? options.UserPassword));
      byte[] dataIn = Class69.smethod_1(options.UserPassword);
      Class44 class44 = new Class44(hash, 0, 5);
      this.byte_1 = new byte[32];
      class44.method_1(dataIn, this.byte_1);
    }

    private void method_2(Class68 options)
    {
      Class44 class44 = new Class44(this.byte_3);
      this.byte_2 = new byte[32];
      class44.method_1(Class69.byte_0, this.byte_2);
    }

    internal byte[] UserEntry
    {
      get
      {
        return this.byte_2;
      }
      set
      {
        this.byte_2 = value;
      }
    }

    internal byte[] OwnerEntry
    {
      get
      {
        return this.byte_1;
      }
      set
      {
        this.byte_1 = value;
      }
    }

    private static byte[] smethod_0(
      byte[] paddedPassword,
      byte[] ownerEntry,
      int permissions,
      byte[] fileId)
    {
      MemoryStream memoryStream = new MemoryStream();
      memoryStream.Write(paddedPassword, 0, 32);
      memoryStream.Write(ownerEntry, 0, 32);
      memoryStream.Write(BitConverter.GetBytes(permissions), 0, 4);
      memoryStream.Write(fileId, 0, fileId.Length);
      byte[] hash = Md5Helper.ComputeHash(memoryStream.ToArray());
      byte[] numArray = new byte[5];
      Array.Copy((Array) hash, 0, (Array) numArray, 0, 5);
      return numArray;
    }

    private static byte[] smethod_1(string password)
    {
      byte[] bytes = new byte[32];
      if (password != null)
      {
        int charCount = password.Length < 32 ? password.Length : 32;
        Encodings.Ascii.GetBytes(password, 0, charCount, bytes, 0);
        int index1 = charCount;
        int index2 = 0;
        while (index1 < 32)
        {
          bytes[index1] = Class69.byte_0[index2];
          ++index1;
          ++index2;
        }
      }
      else
        Class69.byte_0.CopyTo((Array) bytes, 0);
      return bytes;
    }

    internal static bool smethod_2(
      string password,
      byte[] userEntry,
      byte[] ownerEntry,
      int permissions,
      byte[] fileId)
    {
      return Class69.smethod_3(Class69.smethod_1(password), userEntry, ownerEntry, permissions, fileId);
    }

    private static bool smethod_3(
      byte[] paddedPassword,
      byte[] userEntry,
      byte[] ownerEntry,
      int permissions,
      byte[] fileId)
    {
      Class44 class44 = new Class44(Class69.smethod_0(paddedPassword, ownerEntry, permissions, fileId));
      byte[] numArray = new byte[32];
      class44.method_1(userEntry, numArray);
      return Class69.smethod_5(Class69.byte_0, numArray);
    }

    internal static bool smethod_4(
      string password,
      byte[] userEntry,
      byte[] ownerEntry,
      int permissions,
      byte[] fileId)
    {
      Class44 class44 = new Class44(Md5Helper.ComputeHash(Class69.smethod_1(password)), 0, 5);
      byte[] numArray = new byte[32];
      class44.method_1(ownerEntry, numArray);
      return Class69.smethod_3(numArray, userEntry, ownerEntry, permissions, fileId);
    }

    private static bool smethod_5(byte[] a1, byte[] a2)
    {
      if (a1.Length != a2.Length)
        return false;
      for (int index = 0; index < a1.Length; ++index)
      {
        if ((int) a1[index] != (int) a2[index])
          return false;
      }
      return true;
    }
  }
}
