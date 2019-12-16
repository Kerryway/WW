// Decompiled with JetBrains decompiler
// Type: ns44.Class1046
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns44
{
  internal class Class1046 : Interface3
  {
    private string string_0;
    private Class648[] class648_0;

    public virtual void imethod_0(Interface8 reader)
    {
      this.string_0 = reader.ReadString();
      if (this.string_0 == "null_law")
        return;
      int length = reader.imethod_5();
      this.class648_0 = new Class648[length];
      for (int index = 0; index < length; ++index)
        this.class648_0[index] = Class648.smethod_0(reader);
    }

    public virtual void imethod_1(Interface9 writer)
    {
      writer.WriteString(this.string_0);
      if (this.string_0 == "null_law")
        return;
      writer.imethod_15();
      int length = this.class648_0.Length;
      writer.imethod_4(length);
      writer.imethod_15();
      for (int index = 0; index < length; ++index)
        Class648.smethod_1(writer, this.class648_0[index]);
    }
  }
}
