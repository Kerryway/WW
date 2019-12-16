// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPatternStore
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace WW.Cad.Model.Entities
{
  public static class DxfPatternStore
  {
    private static Dictionary<string, DxfPattern> dictionary_0 = new Dictionary<string, DxfPattern>();

    public static void Add(DxfPattern pattern)
    {
      if (pattern.Name == null)
        throw new ArgumentException("Pattern must have a name.");
      DxfPatternStore.dictionary_0[pattern.Name] = pattern;
    }

    public static void Add(DxfPattern[] patterns)
    {
      if (patterns == null)
        throw new ArgumentException(nameof (patterns));
      foreach (DxfPattern pattern in patterns)
        DxfPatternStore.Add(pattern);
    }

    public static DxfPattern GetPatternWithName(string name)
    {
      if (name == null)
        throw new ArgumentException("Name must have a value.");
      return DxfPatternStore.dictionary_0[name];
    }

    public static DxfPattern[] GetPatterns()
    {
      ICollection values = (ICollection) DxfPatternStore.dictionary_0.Values;
      DxfPattern[] dxfPatternArray = new DxfPattern[values.Count];
      values.CopyTo((Array) dxfPatternArray, 0);
      return dxfPatternArray;
    }

    public static void Clear()
    {
      DxfPatternStore.dictionary_0.Clear();
    }
  }
}
