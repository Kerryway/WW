// Decompiled with JetBrains decompiler
// Type: ns17.Class171
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using ns9;

namespace ns17
{
  internal class Class171 : Class162
  {
    public const string string_2 = "vertedge-sys-attrib";
    private Class171.Struct8[] struct8_0;
    private int[] int_2;

    public override string imethod_2(int version)
    {
      return "vertedge-sys-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int length = reader.imethod_5();
      this.struct8_0 = new Class171.Struct8[length];
      this.int_2 = new int[length];
      for (int index1 = 0; index1 < length; ++index1)
      {
        this.int_2[index1] = reader.imethod_7();
        this.struct8_0[index1].enum48_0 = reader.FileFormatVersion < Class250.int_67 ? Class102.Enum48.const_2 : (Class102.Enum48) reader.imethod_5();
        if (this.int_2[index1] != -1)
          reader.imethod_0(this.int_2[index1], (Delegate10) (entity =>
          {
            for (int index = 0; index < this.struct8_0.Length; ++index)
            {
              if (this.int_2[index] == entity.Index)
                this.struct8_0[index].class96_0 = (Class96) entity;
            }
          }));
      }
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_4(this.struct8_0.Length);
      for (int index = 0; index < this.struct8_0.Length; ++index)
      {
        writer.imethod_6((Class80) this.struct8_0[index].class96_0);
        if (writer.FileFormatVersion >= Class250.int_67)
          writer.imethod_4((int) this.struct8_0[index].enum48_0);
      }
    }

    private struct Struct8
    {
      public Class96 class96_0;
      public Class102.Enum48 enum48_0;
    }
  }
}
