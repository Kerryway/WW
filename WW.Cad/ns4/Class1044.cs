// Decompiled with JetBrains decompiler
// Type: ns4.Class1044
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW;

namespace ns4
{
  internal class Class1044 : Interface25
  {
    private readonly string string_0;
    private readonly int int_0;
    private readonly int int_1;

    public Class1044(string breakRemoveChars, string breakAfterChars, string breakBeforeChars)
    {
      this.string_0 = breakRemoveChars + breakAfterChars + breakBeforeChars;
      this.int_0 = breakRemoveChars.Length;
      this.int_1 = this.int_0 + breakAfterChars.Length;
    }

    public Class1044(string breakRemoveChars, string breakAfterChars)
      : this(breakRemoveChars, breakAfterChars, string.Empty)
    {
    }

    public Pair<string, string> imethod_0(string text, ref int position)
    {
      while (--position > 0)
      {
        int num = this.string_0.IndexOf(text[position]);
        if (num >= 0)
        {
          if (num < this.int_0)
            return new Pair<string, string>(text.Substring(0, position), text.Substring(position + 1));
          if (num < this.int_1)
            return new Pair<string, string>(text.Substring(0, position + 1), text.Substring(position + 1));
          return new Pair<string, string>(text.Substring(0, position), text.Substring(position));
        }
      }
      position = -1;
      return (Pair<string, string>) null;
    }

    public Pair<string, string> imethod_1(string text, ref int position)
    {
      int length = text.Length;
      while (++position < length)
      {
        int num = this.string_0.IndexOf(text[position]);
        if (num >= 0)
        {
          if (num < this.int_0)
            return new Pair<string, string>(text.Substring(0, position), text.Substring(position + 1));
          if (num < this.int_1)
            return new Pair<string, string>(text.Substring(0, position + 1), text.Substring(position + 1));
          return new Pair<string, string>(text.Substring(0, position), text.Substring(position));
        }
      }
      position = -1;
      return (Pair<string, string>) null;
    }
  }
}
