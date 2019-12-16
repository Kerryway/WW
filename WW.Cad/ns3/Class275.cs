// Decompiled with JetBrains decompiler
// Type: ns3.Class275
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class275 : Class274
  {
    private ulong ulong_2;

    public Class275(DxfTableContent tableContent)
      : base((DxfLinkedTableData) tableContent)
    {
    }

    public ulong TableStyleHandle
    {
      get
      {
        return this.ulong_2;
      }
      set
      {
        this.ulong_2 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfTableContent handledObject = (DxfTableContent) this.HandledObject;
      if (this.ulong_2 == 0UL)
        return;
      handledObject.TableStyle = modelBuilder.method_4<DxfTableStyle>(this.ulong_2);
      foreach (Class1050 rowBuilder in this.RowBuilders)
        rowBuilder.ResolveReferences(handledObject);
      foreach (Class505 columnBuilder in this.ColumnBuilders)
        columnBuilder.ResolveReferences(handledObject);
      foreach (Class506 cellBuilder in this.CellBuilders)
        cellBuilder.ResolveReferences(modelBuilder, handledObject);
    }
  }
}
