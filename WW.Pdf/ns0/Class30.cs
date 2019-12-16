// Decompiled with JetBrains decompiler
// Type: ns0.Class30
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.Collections.Generic;
using WW.Pdf;
using WW.Pdf.Font;

namespace ns0
{
  internal abstract class Class30 : WW.Pdf.Font.Font
  {
    public const int int_0 = 1000;

    public abstract string CidBaseFont { get; }

    public abstract PdfWArray WArray { get; }

    public abstract IDictionary<ushort, char> CMapEntries { get; }

    public override PdfFontTypeEnum Type
    {
      get
      {
        return PdfFontTypeEnum.CIDFont;
      }
    }

    public virtual string Registry
    {
      get
      {
        return "Adobe";
      }
    }

    public virtual string Ordering
    {
      get
      {
        return "Identity";
      }
    }

    public virtual int Supplement
    {
      get
      {
        return 0;
      }
    }

    public virtual int DefaultWidth
    {
      get
      {
        return 1000;
      }
    }
  }
}
