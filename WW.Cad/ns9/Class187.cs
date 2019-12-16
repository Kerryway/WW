// Decompiled with JetBrains decompiler
// Type: ns9.Class187
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns9
{
  internal class Class187 : Class80
  {
    public const string string_0 = "asmheader";
    private string string_1;

    public string ExtentedVersion
    {
      get
      {
        return this.string_1;
      }
    }

    public override string imethod_2(int version)
    {
      return "asmheader";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.string_1 = reader.ReadString();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.WriteString(this.string_1);
    }

    public override void vmethod_2(Class795 satFile)
    {
      satFile.Asmheader = this;
    }
  }
}
