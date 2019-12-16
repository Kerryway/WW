// Decompiled with JetBrains decompiler
// Type: ns28.Class449
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;
using WW.Cad.IO;

namespace ns28
{
  internal class Class449 : Class448
  {
    public Class449(DwgReader dwgReader, Stream stream)
      : base(dwgReader, stream)
    {
    }

    public override short imethod_55()
    {
      byte num1 = this.imethod_13();
      short num2 = 0;
      switch (num1)
      {
        case 0:
          num2 = (short) this.imethod_18();
          break;
        case 1:
          num2 = (short) (496 + (int) this.imethod_18());
          break;
        case 2:
          num2 = this.imethod_45();
          break;
        case 3:
          num2 = this.imethod_45();
          break;
      }
      return num2;
    }

    public override long imethod_12()
    {
      ulong num1 = 0;
      byte num2 = this.method_10();
      for (int index = 0; index < (int) num2; ++index)
      {
        ulong num3 = (ulong) this.imethod_18();
        num1 += num3 << (index << 3);
      }
      return (long) num1;
    }

    private byte method_10()
    {
      byte num1 = 0;
      if (this.imethod_6())
        num1 = (byte) 1;
      byte num2 = (byte) ((uint) num1 << 1);
      if (this.imethod_6())
        num2 |= (byte) 1;
      byte num3 = (byte) ((uint) num2 << 1);
      if (this.imethod_6())
        num3 |= (byte) 1;
      return num3;
    }

    protected override void vmethod_0(
      long stringStreamEndBitPosition,
      out long stringStreamSizePositionInBits,
      out long stringDataSizeInBits)
    {
      stringStreamSizePositionInBits = stringStreamEndBitPosition - 16L;
      this.imethod_4(stringStreamSizePositionInBits);
      stringDataSizeInBits = (long) this.method_4();
      if ((stringDataSizeInBits & 32768L) == 0L)
        return;
      stringStreamSizePositionInBits -= 16L;
      this.imethod_4(stringStreamSizePositionInBits);
      stringDataSizeInBits &= (long) short.MaxValue;
      int num1 = (int) this.method_4();
      stringDataSizeInBits += (long) ((num1 & (int) short.MaxValue) << 15);
      if ((num1 & 32768) == 0)
        return;
      stringStreamSizePositionInBits -= 16L;
      this.imethod_4(stringStreamSizePositionInBits);
      int num2 = (int) this.method_4();
      stringDataSizeInBits += ((long) num2 & (long) short.MaxValue) << 30;
      if ((num2 & 32768) == 0)
        return;
      stringStreamSizePositionInBits -= 16L;
      this.imethod_4(stringStreamSizePositionInBits);
      int num3 = (int) this.method_4();
      stringDataSizeInBits += ((long) num3 & (long) short.MaxValue) << 45;
      if ((num3 & 32768) != 0)
        throw new Exception("Illegal string stream size.");
    }
  }
}
