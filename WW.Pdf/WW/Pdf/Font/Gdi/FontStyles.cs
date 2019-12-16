// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.Gdi.FontStyles
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf.Font.Gdi
{
  public class FontStyles
  {
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3;

    public bool RegularAvailable
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public bool BoldAvailable
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public bool ItalicAvailable
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public bool BoldItalicAvailable
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.bool_3 = value;
      }
    }

    internal void method_0()
    {
      this.bool_0 = false;
      this.bool_1 = false;
      this.bool_2 = false;
      this.bool_3 = false;
    }
  }
}
