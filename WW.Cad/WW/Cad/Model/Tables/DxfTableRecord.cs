// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfTableRecord
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Tables
{
  public abstract class DxfTableRecord : DxfHandledObject, ITableRecord
  {
    public abstract string Name { get; set; }

    public abstract bool IsExternallyDependent { get; set; }

    public abstract bool IsResolvedExternalRef { get; set; }

    public abstract bool IsReferenced { get; set; }

    public abstract void Accept(ITableRecordVisitor visitor);
  }
}
