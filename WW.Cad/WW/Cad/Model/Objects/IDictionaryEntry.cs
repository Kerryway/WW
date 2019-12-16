// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.IDictionaryEntry
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects
{
  public interface IDictionaryEntry
  {
    DxfDictionary Dictionary { get; set; }

    string Name { get; set; }

    DxfObject Value { get; set; }

    bool ValueReferenceIsHard { get; set; }

    IDictionaryEntry Clone(CloneContext cloneContext);
  }
}
