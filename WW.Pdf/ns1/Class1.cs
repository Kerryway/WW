// Decompiled with JetBrains decompiler
// Type: ns1.Class1
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using ns3;
using System;
using System.Text;

namespace ns1
{
  internal class Class1 : Class0
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private const int int_0 = 3;
    private const int int_1 = 0;
    private const int int_2 = 1;
    private const int int_3 = 1033;
    private const int int_4 = 1;
    private const int int_5 = 2;
    private const int int_6 = 3;
    private const int int_7 = 4;
    private const int int_8 = 5;
    private const int int_9 = 6;
    private ushort ushort_0;

    public Class1(Class41 entry)
      : base(entry)
    {
    }

    public string FamilyName
    {
      get
      {
        return this.string_0;
      }
    }

    public string FullName
    {
      get
      {
        return this.string_1;
      }
    }

    protected internal override void vmethod_0(Class80 reader)
    {
      Class74 stream = reader.Stream;
      int num1 = (int) stream.method_8();
      int num2 = (int) stream.method_8();
      this.ushort_0 = stream.method_8();
      for (int index = 0; index < num2; ++index)
      {
        int num3 = (int) stream.method_8();
        int num4 = (int) stream.method_8();
        int num5 = (int) stream.method_8();
        int num6 = (int) stream.method_8();
        int length = (int) stream.method_8();
        int stringOffset = (int) stream.method_8();
        if (num3 == 3 && (num4 == 0 || num4 == 1) && num5 == 1033)
        {
          switch (num6)
          {
            case 1:
              this.string_0 = this.method_0(stream, stringOffset, length);
              break;
            case 4:
              this.string_1 = this.method_0(stream, stringOffset, length);
              break;
          }
          if (this.string_0 != string.Empty && this.string_1 != string.Empty)
            break;
        }
      }
    }

    private string method_0(Class74 stream, int stringOffset, int length)
    {
      stream.method_26();
      stream.Position = (long) (this.Entry.Offset + (uint) this.ushort_0) + (long) stringOffset;
      byte[] numArray = new byte[length];
      stream.method_24(numArray, 0, length);
      stream.method_27();
      return Encoding.BigEndianUnicode.GetString(numArray, 0, numArray.Length);
    }

    protected internal override void vmethod_1(Class79 writer)
    {
      throw new NotImplementedException("Write is not implemented.");
    }
  }
}
