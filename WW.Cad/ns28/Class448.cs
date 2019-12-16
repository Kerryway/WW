// Decompiled with JetBrains decompiler
// Type: ns28.Class448
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using System.Text;
using WW.Cad.IO;

namespace ns28
{
  internal class Class448 : Class447
  {
    public Class448(DwgReader dwgReader, Stream stream)
      : base(dwgReader, stream)
    {
    }

    public override string ReadString()
    {
      int num = (int) this.imethod_14();
      string empty;
      if (num > 0)
      {
        byte[] bytes = this.imethod_19(num << 1);
        empty = Encoding.Unicode.GetString(bytes, 0, bytes.Length);
      }
      else
        empty = string.Empty;
      return empty;
    }

    public override string imethod_30()
    {
      int num = (int) this.imethod_45();
      string empty;
      if (num == 0)
      {
        empty = string.Empty;
      }
      else
      {
        byte[] bytes = this.imethod_19(num << 1);
        empty = Encoding.Unicode.GetString(bytes, 0, bytes.Length);
      }
      return empty;
    }
  }
}
