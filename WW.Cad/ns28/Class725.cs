// Decompiled with JetBrains decompiler
// Type: ns28.Class725
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;
using System.Text;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Math;

namespace ns28
{
  internal class Class725 : Class724
  {
    public Class725(Stream stream, Encoding encoding, DxfVersion version)
      : base(stream, encoding, version)
    {
    }

    public override void imethod_2(Vector3D value)
    {
      this.imethod_29(value);
    }

    public override void imethod_3(Vector3D value)
    {
      this.imethod_29(value);
    }

    public override void imethod_1(double value)
    {
      this.imethod_16(value);
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
        this.imethod_32((short) (bytes.Length + 1));
        this.imethod_12(bytes);
        this.imethod_11((byte) 0);
      }
    }

    public override void imethod_5(string value)
    {
      if (string.IsNullOrEmpty(value))
      {
        this.imethod_18((short) 0);
        this.imethod_11((byte) (this.DwgCodePage & (int) byte.MaxValue));
      }
      else
      {
        if (value.Length > (int) short.MaxValue)
          throw new ArgumentOutOfRangeException("Extended data string length may not be longer than 32767 characters for version 18 and earlier.");
        byte[] bytes = this.Encoding.GetBytes(value);
        this.imethod_18((short) bytes.Length);
        this.imethod_11((byte) (this.DwgCodePage & (int) byte.MaxValue));
        this.imethod_13(bytes, 0, bytes.Length);
      }
    }

    public override void imethod_6(Color color)
    {
      switch (color.ColorType)
      {
        case ColorType.ByLayer:
          this.imethod_32((short) 256);
          break;
        case ColorType.ByBlock:
          this.imethod_32((short) 0);
          break;
        case ColorType.ByColorIndex:
          this.imethod_32(color.ColorIndex);
          break;
        default:
          this.imethod_32(DxfIndexedColorSet.GetColorIndex((DxfIndexedColor) DxfIndexedColorSet.AcadClassicIndexedColors, color.ToArgbColor(DxfIndexedColorSet.AcadClassicIndexedColors)));
          break;
      }
    }

    public override void imethod_10(
      EntityColor color,
      Transparency transparency,
      bool isColorBookColor)
    {
      this.imethod_6(Color.CreateFrom(color));
    }
  }
}
