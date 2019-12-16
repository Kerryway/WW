// Decompiled with JetBrains decompiler
// Type: ns2.Class633
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Globalization;
using System.IO;

namespace ns2
{
  internal class Class633 : Interface13
  {
    private TextWriter textWriter_0;

    public Class633(TextWriter writer)
    {
      this.textWriter_0 = writer;
    }

    public void imethod_0(Struct18 group)
    {
      this.method_0(group.Code);
      this.textWriter_0.WriteLine(group.ValueString);
    }

    public void imethod_1(int baseCode, Struct18 group)
    {
      this.method_0(group.Code);
      this.textWriter_0.WriteLine(group.GetValueString(baseCode));
    }

    public void imethod_2(Struct18 group)
    {
      this.method_0(group.Code);
      this.textWriter_0.WriteLine(Class820.smethod_20(group.Value));
    }

    public void imethod_3(Struct18 group)
    {
      this.method_0(group.Code);
      this.textWriter_0.WriteLine(Class820.smethod_21(group.Value));
    }

    public void imethod_4(Struct18 group)
    {
      this.method_0(group.Code);
      this.textWriter_0.WriteLine((string) group.Value);
    }

    public void Flush()
    {
      this.textWriter_0.Flush();
    }

    public void imethod_5()
    {
      this.textWriter_0.Close();
      this.textWriter_0 = (TextWriter) null;
    }

    private void method_0(int groupCode)
    {
      if (groupCode < 10)
        this.textWriter_0.WriteLine("  {0}", (object) groupCode.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      else if (groupCode < 100)
        this.textWriter_0.WriteLine(" {0}", (object) groupCode.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      else
        this.textWriter_0.WriteLine(groupCode.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }
  }
}
