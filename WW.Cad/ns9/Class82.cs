// Decompiled with JetBrains decompiler
// Type: ns9.Class82
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns7;

namespace ns9
{
  internal abstract class Class82 : Class81
  {
    public const string string_0 = "surface";
    private Class188 class188_0;

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      if (this.UsedAsBase)
        return;
      this.class188_0 = this.vmethod_4();
      this.class188_0.imethod_0(reader);
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      if (this.UsedAsBase)
        return;
      this.class188_0.imethod_1(writer);
    }

    protected virtual Class188 vmethod_4()
    {
      return new Class188();
    }

    public Class188 SurfacePrimitive
    {
      get
      {
        return this.class188_0;
      }
    }
  }
}
