// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.IDataCellValueVisitor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects
{
  public interface IDataCellValueVisitor
  {
    void Visit(DxfDataCellValue.Unknown visitee);

    void Visit(DxfDataCellValue.Int32 visitee);

    void Visit(DxfDataCellValue.Double visitee);

    void Visit(DxfDataCellValue.String visitee);

    void Visit(DxfDataCellValue.Point3D visitee);

    void Visit(DxfDataCellValue.ObjectId visitee);

    void Visit(DxfDataCellValue.HardOwnerId visitee);

    void Visit(DxfDataCellValue.SoftOwnerId visitee);

    void Visit(DxfDataCellValue.HardPointerId visitee);

    void Visit(DxfDataCellValue.SoftPointerId visitee);

    void Visit(DxfDataCellValue.Bool visitee);

    void Visit(DxfDataCellValue.Vector3D visitee);
  }
}
