// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.ITableRecord
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Tables
{
  public interface ITableRecord
  {
    string Name { get; set; }

    bool IsExternallyDependent { get; set; }

    bool IsResolvedExternalRef { get; set; }

    bool IsReferenced { get; set; }

    void Accept(ITableRecordVisitor visitor);
  }
}
