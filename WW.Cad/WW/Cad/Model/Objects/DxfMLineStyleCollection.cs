// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfMLineStyleCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfMLineStyleCollection : ActiveDxfHandledObjectCollection<DxfMLineStyle>
  {
    public DxfMLineStyle Find(string name)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      return this.Find(new Predicate<DxfMLineStyle>(new DxfMLineStyleCollection.Class423() { string_0 = name }.method_0));
    }

    public List<DxfMLineStyle> FindAll(string name)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      return this.FindAll(new Predicate<DxfMLineStyle>(new DxfMLineStyleCollection.Class424() { string_0 = name }.method_0));
    }
  }
}
