// Decompiled with JetBrains decompiler
// Type: ns2.Class634
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using WW.Cad.IO;

namespace ns2
{
  internal class Class634 : Interface33
  {
    private TextReader textReader_0;
    private long long_0;

    internal Class634(TextReader r)
    {
      this.textReader_0 = r;
      this.long_0 = 1L;
    }

    public Struct18 imethod_0(DxfReader dxfReader)
    {
      string s = this.textReader_0.ReadLine();
      if (s == null)
        return Struct18.struct18_0;
      int code = int.Parse(s);
      ++this.long_0;
      string valueString = this.textReader_0.ReadLine();
      object obj = Class820.GetValue(dxfReader, code, valueString);
      ++this.long_0;
      return new Struct18(code, obj, valueString);
    }

    public Struct18 imethod_1(DxfReader dxfReader, int baseGroupCode)
    {
      string s = this.textReader_0.ReadLine();
      if (s == null)
        return Struct18.struct18_0;
      int code = int.Parse(s);
      ++this.long_0;
      string valueString = this.textReader_0.ReadLine();
      object obj = Class820.GetValue(dxfReader, baseGroupCode, valueString);
      ++this.long_0;
      return new Struct18(code, obj, valueString);
    }

    public Struct18 imethod_2(DxfReader dxfReader)
    {
      string s = this.textReader_0.ReadLine();
      if (s == null)
        return Struct18.struct18_0;
      int code = int.Parse(s);
      ++this.long_0;
      string valueString = this.textReader_0.ReadLine();
      object obj = Class820.TryGetValue(dxfReader, code, valueString);
      ++this.long_0;
      return new Struct18(code, obj, valueString);
    }

    public void imethod_3(bool close)
    {
      if (close && this.textReader_0 != null)
        this.textReader_0.Close();
      this.textReader_0 = (TextReader) null;
    }

    public string Position
    {
      get
      {
        return "line " + (object) this.long_0;
      }
    }
  }
}
