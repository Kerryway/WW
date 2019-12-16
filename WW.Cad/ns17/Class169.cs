// Decompiled with JetBrains decompiler
// Type: ns17.Class169
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns17
{
  internal class Class169 : Class163
  {
    public static readonly string[] string_4 = new string[4]{ "unset_continuity", "position_continuous", "slope_continuous", "curvature_continuous" };
    public static readonly string[] string_5 = new string[2]{ "bl_v_auto_unset", "bl_v_auto_linear" };
    public const string string_3 = "vblend-blend-sys-attrib";
    private int int_2;
    private int int_3;
    private double double_0;

    public override string imethod_2(int version)
    {
      return "vblend-blend-sys-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.double_0 = reader.imethod_8();
      this.int_2 = reader.imethod_11(Class169.string_4);
      if (reader.FileFormatVersion >= Class250.int_44)
        this.int_3 = reader.imethod_11(Class169.string_5);
      else
        this.int_3 = 0;
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_7(this.double_0);
      writer.imethod_10(Class169.string_4, this.int_2);
      if (writer.FileFormatVersion < Class250.int_44)
        return;
      writer.imethod_10(Class169.string_5, this.int_3);
    }
  }
}
