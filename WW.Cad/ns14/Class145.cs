// Decompiled with JetBrains decompiler
// Type: ns14.Class145
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns14
{
  internal class Class145 : Class144
  {
    public const string string_8 = "vector_attrib-name_attrib-gen-attrib";
    private Vector3D vector3D_0;

    public override string imethod_2(int version)
    {
      return "vector_attrib-name_attrib-gen-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.vector3D_0 = reader.imethod_19();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_18(this.vector3D_0);
    }
  }
}
