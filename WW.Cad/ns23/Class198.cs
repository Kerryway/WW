// Decompiled with JetBrains decompiler
// Type: ns23.Class198
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns44;
using ns7;

namespace ns23
{
  internal class Class198 : Class197
  {
    private Class1046 class1046_0 = new Class1046();
    public const string string_3 = "lawsur";
    public const string string_4 = "law_spl_sur";
    private Class1046[] class1046_1;

    public override string imethod_2(int version)
    {
      return "law_spl_sur";
    }

    public override void imethod_0(Interface8 reader)
    {
      if (reader.FileFormatVersion < Class250.int_48)
      {
        this.class439_0 = new Class439(reader.imethod_8(), reader.imethod_8());
        this.class439_1 = new Class439(reader.imethod_8(), reader.imethod_8());
      }
      this.class1046_0.imethod_0(reader);
      int length = reader.imethod_5();
      this.class1046_1 = new Class1046[length];
      for (int index = 0; index < length; ++index)
      {
        this.class1046_1[index] = new Class1046();
        this.class1046_1[index].imethod_0(reader);
      }
      this.method_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      if (writer.FileFormatVersion < Class250.int_48)
      {
        writer.imethod_7(this.class439_0.Start);
        writer.imethod_7(this.class439_0.End);
        writer.imethod_7(this.class439_1.Start);
        writer.imethod_7(this.class439_1.End);
        writer.imethod_15();
      }
      this.class1046_0.imethod_1(writer);
      int length = this.class1046_1.Length;
      writer.imethod_4(length);
      for (int index = 0; index < length; ++index)
        this.class1046_1[index].imethod_1(writer);
      this.method_1(writer);
    }

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }
  }
}
