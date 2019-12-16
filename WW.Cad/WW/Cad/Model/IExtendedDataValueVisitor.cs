// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.IExtendedDataValueVisitor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model
{
  public interface IExtendedDataValueVisitor
  {
    void Visit(DxfExtendedData.BinaryData value);

    void Visit(DxfExtendedData.DatabaseHandle value);

    void Visit(DxfExtendedData.Distance value);

    void Visit(DxfExtendedData.Double value);

    void Visit(DxfExtendedData.LayerReference value);

    void Visit(DxfExtendedData.PointOrVector value);

    void Visit(DxfExtendedData.ScaleFactor value);

    void Visit(DxfExtendedData.Int16 value);

    void Visit(DxfExtendedData.Int32 value);

    void Visit(DxfExtendedData.String value);

    void Visit(DxfExtendedData.Bracket value);

    void Visit(DxfExtendedData.WorldDirection value);

    void Visit(DxfExtendedData.WorldSpaceDisplacement value);

    void Visit(DxfExtendedData.WorldSpacePosition value);

    void Visit(DxfExtendedData.ValueCollection value);
  }
}
