// Decompiled with JetBrains decompiler
// Type: ns18.Class175
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns18
{
  internal class Class175 : Class172
  {
    public const string string_2 = "rgb_color-st-attrib";
    private Vector3D vector3D_0;

    public override string imethod_2(int version)
    {
      return "rgb_color-st-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.vector3D_0.X = reader.imethod_8();
      this.vector3D_0.Y = reader.imethod_8();
      this.vector3D_0.Z = reader.imethod_8();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_7(this.vector3D_0.X);
      writer.imethod_7(this.vector3D_0.Y);
      writer.imethod_7(this.vector3D_0.Z);
    }
  }
}
