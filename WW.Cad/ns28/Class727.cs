// Decompiled with JetBrains decompiler
// Type: ns28.Class727
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using System.Text;
using WW.Cad.Model;
using WW.Cad.Model.Entities;

namespace ns28
{
  internal class Class727 : Class726
  {
    public Class727(Stream stream, Encoding encoding, DxfVersion version)
      : base(stream, encoding, version)
    {
    }

    public override void imethod_4(string value)
    {
      if (string.IsNullOrEmpty(value))
      {
        this.imethod_32((short) 0);
      }
      else
      {
        byte[] bytes = this.Encoding.GetBytes(value);
        this.imethod_32((short) bytes.Length);
        this.imethod_12(bytes);
      }
    }

    public override void imethod_6(Color color)
    {
      this.imethod_7((Interface29) this, color);
    }

    public override void imethod_7(Interface29 stringWriter, Color color)
    {
      this.imethod_9(stringWriter, color);
    }

    public override void imethod_10(
      EntityColor color,
      Transparency transparency,
      bool isColorBookColor)
    {
      if (color == EntityColor.ByBlock && !isColorBookColor)
      {
        this.imethod_32((short) 0);
      }
      else
      {
        ushort num = 0;
        bool flag;
        if (flag = transparency.TransparencyType != TransparencyType.ByLayer)
          num |= (ushort) 8192;
        if (isColorBookColor)
          this.imethod_32((short) (ushort) ((uint) num | 49152U));
        else if (color == EntityColor.ByLayer)
          this.imethod_32((short) (ushort) ((uint) num | 256U));
        else if (color.ColorType == ColorType.ByColorIndex)
        {
          this.imethod_32((short) (ushort) ((uint) num | (uint) (ushort) color.ColorIndex));
        }
        else
        {
          int colorDifference;
          int colorIndex = (int) DxfIndexedColorSet.GetColorIndex(color.ToArgbColor(), out colorDifference);
          this.imethod_32((short) (ushort) ((uint) num | (uint) (ushort) (32768 | colorIndex)));
          this.imethod_33((int) color.Data);
        }
        if (!flag)
          return;
        this.imethod_33((int) transparency.Data);
      }
    }
  }
}
