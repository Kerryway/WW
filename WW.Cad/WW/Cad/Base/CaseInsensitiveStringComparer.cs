// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.CaseInsensitiveStringComparer
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;

namespace WW.Cad.Base
{
  public class CaseInsensitiveStringComparer : IComparer<string>, IEqualityComparer<string>
  {
    public static readonly CaseInsensitiveStringComparer Instance = new CaseInsensitiveStringComparer();

    public int Compare(string x, string y)
    {
      return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase);
    }

    public bool Equals(string x, string y)
    {
      return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase) == 0;
    }

    public int GetHashCode(string obj)
    {
      return obj.ToLowerInvariant().GetHashCode();
    }
  }
}
