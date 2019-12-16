// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.FontCharRemapper
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Text;

namespace WW.Cad.Model.Entities
{
  public class FontCharRemapper
  {
    private readonly Encoding encoding_0;
    private readonly Encoding encoding_1;

    public FontCharRemapper(Encoding encode, Encoding decode)
    {
      this.encoding_0 = encode;
      this.encoding_1 = decode;
    }

    public char Remap(char c)
    {
      return this.encoding_1.GetChars(this.encoding_0.GetBytes(new char[1]{ c }))[0];
    }
  }
}
