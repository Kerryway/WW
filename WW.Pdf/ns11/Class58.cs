// Decompiled with JetBrains decompiler
// Type: ns11.Class58
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns1;
using System.Collections;

namespace ns11
{
  internal class Class58 : IComparer
  {
    public int Compare(object x, object y)
    {
      Class76 class76 = (Class76) x;
      char ch = (char) y;
      if ((int) class76.End < (int) ch)
        return -1;
      return (int) class76.Start > (int) ch ? 1 : 0;
    }
  }
}
