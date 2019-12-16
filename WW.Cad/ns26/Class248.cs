// Decompiled with JetBrains decompiler
// Type: ns26.Class248
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using ns9;
using WW.Math;

namespace ns26
{
  internal class Class248 : Class242
  {
    public const string string_0 = "degenerate_curve";
    private Point3D point3D_0;

    public override string imethod_2(int version)
    {
      return "degenerate_curve";
    }

    public override void vmethod_0(Interface8 reader)
    {
      this.point3D_0 = reader.imethod_18();
      base.vmethod_0(reader);
    }

    public override void vmethod_1(Interface9 writer)
    {
      writer.imethod_17(this.point3D_0);
      base.vmethod_1(writer);
    }

    public override void imethod_3(
      Class95 loop,
      Class88 curve,
      Class107 coedge,
      Class917 approximation,
      Class258 accuracy)
    {
      approximation.method_0(coedge.StartLocation);
      approximation.method_0(coedge.EndLocation);
    }
  }
}
