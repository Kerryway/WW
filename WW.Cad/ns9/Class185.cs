// Decompiled with JetBrains decompiler
// Type: ns9.Class185
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns9
{
  internal class Class185 : Class80
  {
    private Class744 class744_0 = new Class744();
    public const string string_0 = "transform";

    public override string imethod_2(int version)
    {
      return "transform";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.class744_0.imethod_0(reader);
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      this.class744_0.imethod_1(writer);
    }

    public Matrix4D Transformation
    {
      get
      {
        return this.class744_0.Transformation;
      }
      set
      {
        this.class744_0.Transformation = value;
      }
    }
  }
}
