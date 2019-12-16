// Decompiled with JetBrains decompiler
// Type: ns28.Class445
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Math;

namespace ns28
{
  internal class Class445 : Class444
  {
    public Class445(DwgReader dwgReader, Stream stream)
      : base(dwgReader, stream)
    {
    }

    public override Vector3D imethod_9()
    {
      return this.imethod_51();
    }

    public override Vector3D imethod_10()
    {
      return this.imethod_51();
    }

    public override double imethod_17()
    {
      return this.imethod_8();
    }

    public override Color imethod_23(Interface30 stringReader)
    {
      short colorIndex = this.imethod_14();
      if (colorIndex < (short) 0)
        colorIndex = -colorIndex;
      return Color.CreateFromColorIndex(colorIndex);
    }

    public override Color imethod_25(Interface30 stringReader)
    {
      int num1 = (int) this.imethod_14();
      int num2 = this.imethod_11();
      byte num3 = this.imethod_18();
      string name = string.Empty;
      if (((int) num3 & 1) == 1)
        name = stringReader.ReadString();
      string colorBookName = string.Empty;
      if (((int) num3 & 2) == 2)
        colorBookName = stringReader.ReadString();
      Color color;
      switch ((byte) (num2 >> 24))
      {
        case 192:
          color = Color.ByLayer;
          break;
        case 193:
          color = Color.ByBlock;
          break;
        case 194:
          color = Color.smethod_1((uint) num2, colorBookName, name);
          break;
        case 195:
          color = Color.CreateFromColorIndex((short) (num2 & (int) ushort.MaxValue));
          break;
        default:
          color = Color.smethod_1((uint) num2, colorBookName, name);
          break;
      }
      return color;
    }

    public override void imethod_26(
      out EntityColor color,
      out Transparency transparency,
      out bool isColorBookColor)
    {
      isColorBookColor = false;
      short colorNumber = this.imethod_14();
      transparency = Transparency.ByLayer;
      color = DxfIndexedColorSet.GetEntityColor(colorNumber);
    }

    public override string ReadString()
    {
      short num = this.imethod_14();
      string str;
      if (num > (short) 0)
      {
        byte[] bytes = this.imethod_19((int) num);
        str = bytes[(int) num - 1] != (byte) 0 ? this.encoding_0.GetString(bytes, 0, (int) num) : this.encoding_0.GetString(bytes, 0, (int) num - 1);
      }
      else
        str = string.Empty;
      return str;
    }

    public override string imethod_30()
    {
      int length = (int) this.imethod_45();
      int dwgCodePage = (int) this.imethod_18();
      string empty;
      if (length == 0)
      {
        empty = string.Empty;
      }
      else
      {
        byte[] bytes = this.imethod_19(length);
        empty = Class952.smethod_0(dwgCodePage).GetString(bytes, 0, bytes.Length);
      }
      return empty;
    }
  }
}
