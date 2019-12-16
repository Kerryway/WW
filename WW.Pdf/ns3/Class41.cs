// Decompiled with JetBrains decompiler
// Type: ns3.Class41
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns1;
using ns2;
using System;
using WW.Text;

namespace ns3
{
  internal class Class41
  {
    private readonly uint uint_0;
    private readonly string string_0;
    private uint uint_1;
    private uint uint_2;
    private uint uint_3;

    public Class41(string tagName)
    {
      this.uint_0 = (uint) ((int) (byte) tagName[0] << 24 | (int) (byte) tagName[1] << 16 | (int) (byte) tagName[2] << 8) | (uint) (byte) tagName[3];
      this.string_0 = tagName;
    }

    public Class41(byte[] tag, uint checkSum, uint offset, uint length)
    {
      if (tag == null)
        throw new ArgumentNullException(nameof (tag), "tag cannot be null");
      if (tag.Length != 4)
        throw new ArgumentException("tag array must be 4 bytes in size", nameof (tag));
      this.uint_0 = (uint) ((int) tag[0] << 24 | (int) tag[1] << 16 | (int) tag[2] << 8) | (uint) tag[3];
      this.string_0 = Encodings.Ascii.GetString(tag, 0, tag.Length);
      this.uint_1 = checkSum;
      this.uint_2 = offset;
      this.uint_3 = length;
    }

    public string TableName
    {
      get
      {
        return this.string_0;
      }
    }

    public uint Tag
    {
      get
      {
        return this.uint_0;
      }
    }

    public uint Offset
    {
      get
      {
        return this.uint_2;
      }
      set
      {
        this.uint_2 = value;
      }
    }

    public uint Length
    {
      get
      {
        return this.uint_3;
      }
      set
      {
        this.uint_3 = value;
      }
    }

    public uint CheckSum
    {
      get
      {
        return this.uint_1;
      }
      set
      {
        this.uint_1 = value;
      }
    }

    internal Class0 method_0(Class80 reader)
    {
      return Class75.smethod_0(this.TableName, reader);
    }
  }
}
