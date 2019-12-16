// Decompiled with JetBrains decompiler
// Type: ns33.Class805
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model.Entities;

namespace ns33
{
  internal class Class805
  {
    private ShxFile shxFile_0;
    private char char_0;

    internal Class805(ShxFile font, char character)
    {
      this.shxFile_0 = font;
      this.char_0 = character;
    }

    public override int GetHashCode()
    {
      return this.shxFile_0.GetHashCode() ^ this.char_0.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      Class805 class805 = (Class805) obj;
      if ((int) this.char_0 == (int) class805.char_0)
        return this.shxFile_0 == class805.shxFile_0;
      return false;
    }
  }
}
