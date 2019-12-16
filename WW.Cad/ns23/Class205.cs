// Decompiled with JetBrains decompiler
// Type: ns23.Class205
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns23
{
  internal abstract class Class205 : Class204
  {
    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      base.vmethod_1(reader);
      if (reader.FileFormatVersion < Class250.int_38)
        return;
      this.vector3D_0 = reader.imethod_19();
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      base.vmethod_3(writer);
      if (writer.FileFormatVersion < Class250.int_38)
        return;
      writer.imethod_18(this.vector3D_0);
    }

    public override void vmethod_1(Interface8 reader)
    {
    }

    public override void vmethod_3(Interface9 writer)
    {
    }
  }
}
