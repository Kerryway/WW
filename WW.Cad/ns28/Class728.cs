// Decompiled with JetBrains decompiler
// Type: ns28.Class728
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;
using System.Text;
using WW;
using WW.Cad.Model;

namespace ns28
{
  internal class Class728 : Class727
  {
    public Class728(Stream stream, Encoding encoding, DxfVersion version)
      : base(stream, encoding, version)
    {
    }

    public override Encoding EffectiveEncoding
    {
      get
      {
        return Encoding.Unicode;
      }
    }

    public override void imethod_4(string value)
    {
      if (string.IsNullOrEmpty(value))
      {
        this.imethod_32((short) 0);
      }
      else
      {
        this.imethod_32((short) value.Length);
        this.imethod_12(Encoding.Unicode.GetBytes(value));
      }
    }

    public override void imethod_5(string value)
    {
      if (string.IsNullOrEmpty(value))
      {
        this.imethod_13(LittleEndianBitConverter.GetBytes((ushort) 0), 0, 2);
      }
      else
      {
        this.imethod_13(LittleEndianBitConverter.GetBytes((ushort) value.Length), 0, 2);
        byte[] bytes = Encoding.Unicode.GetBytes(value);
        this.imethod_13(bytes, 0, bytes.Length);
      }
    }

    public override void imethod_50(long lengthInBits)
    {
      if (lengthInBits >= 32768L)
      {
        if (lengthInBits >= 1073741824L)
          throw new Exception("R21 does not support string stream lengths totaling more than 30 bits.");
        this.method_0((ushort) (lengthInBits >> 15 & (long) ushort.MaxValue));
        this.method_0((ushort) (lengthInBits & (long) short.MaxValue | 32768L));
      }
      else
        this.method_0((ushort) lengthInBits);
    }
  }
}
