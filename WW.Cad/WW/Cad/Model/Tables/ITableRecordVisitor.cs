// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.ITableRecordVisitor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Tables
{
  public interface ITableRecordVisitor
  {
    void Visit(DxfAppId value);

    void Visit(DxfBlock value);

    void Visit(DxfDimensionStyle value);

    void Visit(DxfLayer value);

    void Visit(DxfLineType value);

    void Visit(DxfTextStyle value);

    void Visit(DxfUcs value);

    void Visit(DxfView value);

    void Visit(DxfViewportEntityHeader value);

    void Visit(DxfVPort value);
  }
}
