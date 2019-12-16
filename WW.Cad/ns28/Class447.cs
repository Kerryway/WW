// Decompiled with JetBrains decompiler
// Type: ns28.Class447
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;

namespace ns28
{
  internal class Class447 : Class446
  {
    public Class447(DwgReader dwgReader, Stream stream)
      : base(dwgReader, stream)
    {
    }

    public override Color imethod_23(Interface30 stringReader)
    {
      return this.imethod_25(stringReader);
    }

    public override void imethod_26(
      out EntityColor color,
      out Transparency transparency,
      out bool isColorBookColor)
    {
      isColorBookColor = false;
      short num1 = this.imethod_14();
      if (num1 == (short) 0)
      {
        color = EntityColor.ByBlock;
        transparency = Transparency.Opaque;
      }
      else
      {
        ushort num2 = (ushort) ((uint) (ushort) num1 & 65280U);
        if (((int) num2 & 16384) != 0)
        {
          color = EntityColors.ByBlock;
          isColorBookColor = true;
        }
        else if (((int) num2 & 32768) != 0)
        {
          int num3 = this.imethod_11();
          color = EntityColor.CreateFromRgb(num3 & 16777215);
        }
        else
          color = DxfIndexedColorSet.GetEntityColor((short) ((int) num1 & 4095));
        if (((int) num2 & 8192) != 0)
          transparency = new Transparency((uint) this.imethod_11());
        else
          transparency = Transparency.ByLayer;
      }
    }
  }
}
