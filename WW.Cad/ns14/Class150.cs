// Decompiled with JetBrains decompiler
// Type: ns14.Class150
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns14
{
  internal class Class150 : Class144
  {
    public const string string_8 = "position_attrib-name_attrib-gen-attrib";
    private Point3D point3D_0;

    public override string imethod_2(int version)
    {
      return "position_attrib-name_attrib-gen-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.point3D_0 = reader.imethod_18();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_17(this.point3D_0);
    }
  }
}
