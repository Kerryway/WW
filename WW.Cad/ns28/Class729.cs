// Decompiled with JetBrains decompiler
// Type: ns28.Class729
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;
using System.Text;
using WW.Cad.Model;

namespace ns28
{
  internal class Class729 : Class728
  {
    public Class729(Stream stream, Encoding encoding, DxfVersion version)
      : base(stream, encoding, version)
    {
    }

    public override void imethod_46(short objectType)
    {
      if (objectType <= (short) byte.MaxValue)
      {
        this.imethod_15((byte) 0);
        this.imethod_11((byte) objectType);
      }
      else if (objectType >= (short) 496 && objectType <= (short) 751)
      {
        this.imethod_15((byte) 1);
        this.imethod_11((byte) ((uint) objectType - 496U));
      }
      else
      {
        this.imethod_15((byte) 2);
        this.imethod_18(objectType);
      }
    }

    public override void imethod_34(long value)
    {
      byte num1 = 0;
      ulong num2 = (ulong) value;
      while (num2 != 0UL)
      {
        num2 >>= 8;
        ++num1;
      }
      this.method_4(num1);
      ulong num3 = (ulong) value;
      for (int index = 0; index < (int) num1; ++index)
      {
        this.imethod_11((byte) (num3 & (ulong) byte.MaxValue));
        num3 >>= 8;
      }
    }

    protected void method_4(byte value)
    {
      this.imethod_14(((int) value & 4) != 0);
      this.imethod_14(((int) value & 2) != 0);
      this.imethod_14(((int) value & 1) != 0);
    }

    public override void imethod_50(long lengthInBits)
    {
      if (lengthInBits >= 32768L)
      {
        if (lengthInBits >= 1073741824L)
        {
          if (lengthInBits >= 35184372088832L)
            throw new Exception("String stream length too long. Value: " + (object) lengthInBits + ".");
          this.method_0((ushort) (lengthInBits >> 30 & (long) ushort.MaxValue));
          this.method_0((ushort) (lengthInBits >> 15 & (long) short.MaxValue | 32768L));
        }
        else
          this.method_0((ushort) (lengthInBits >> 15 & (long) ushort.MaxValue));
        this.method_0((ushort) (lengthInBits & (long) short.MaxValue | 32768L));
      }
      else
        this.method_0((ushort) lengthInBits);
    }
  }
}
