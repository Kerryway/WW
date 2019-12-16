// Decompiled with JetBrains decompiler
// Type: ns3.Class567
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class567 : Class566
  {
    private static Class567.Delegate13[] delegate13_0 = new Class567.Delegate13[6]{ (Class567.Delegate13) ((cellStyle, margin) => cellStyle.method_15(margin)), (Class567.Delegate13) ((cellStyle, margin) => cellStyle.method_14(margin)), (Class567.Delegate13) ((cellStyle, margin) => cellStyle.method_16(margin)), (Class567.Delegate13) ((cellStyle, margin) => cellStyle.method_17(margin)), (Class567.Delegate13) ((cellStyle, margin) => cellStyle.method_18(margin)), (Class567.Delegate13) ((cellStyle, margin) => cellStyle.method_19(margin)) };
    private LinkedList<Interface10> linkedList_0 = new LinkedList<Interface10>();
    private int int_0;
    private short short_0;

    public int CurrentBorderId
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public DxfTableBorder method_0()
    {
      switch (this.int_0)
      {
        case 1:
          return this.CellStyle.BorderTop;
        case 2:
          return this.CellStyle.BorderInsideHorizontal;
        case 4:
          return this.CellStyle.BorderBottom;
        case 8:
          return this.CellStyle.BorderLeft;
        case 16:
          return this.CellStyle.BorderInsideVertical;
        case 32:
          return this.CellStyle.BorderRight;
        default:
          return (DxfTableBorder) null;
      }
    }

    public void method_1(double margin)
    {
      if (this.short_0 < (short) 6)
        Class567.delegate13_0[(int) this.short_0](this.CellStyle, margin);
      ++this.short_0;
    }

    public ICollection<Interface10> ChildBuilders
    {
      get
      {
        return (ICollection<Interface10>) this.linkedList_0;
      }
    }

    public Class567(DxfTableCellStyle cellStyle)
      : base((DxfContentFormat) cellStyle)
    {
    }

    public DxfTableCellStyle CellStyle
    {
      get
      {
        return (DxfTableCellStyle) this.ContentFormat;
      }
    }

    public new void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      if (this.CellStyle.Id != 0)
      {
        if (this.CellStyle.Id == 1)
        {
          if (string.IsNullOrEmpty(this.CellStyle.Name))
            this.CellStyle.Name = "_TITLE";
        }
        else if (this.CellStyle.Id == 2)
        {
          if (string.IsNullOrEmpty(this.CellStyle.Name))
            this.CellStyle.Name = "_HEADER";
        }
        else if (this.CellStyle.Id == 3 && string.IsNullOrEmpty(this.CellStyle.Name))
          this.CellStyle.Name = "_DATA";
      }
      modelBuilder.ResolveReferences((ICollection<Interface10>) this.linkedList_0);
    }

    private delegate void Delegate13(DxfTableCellStyle cellStyle, double margin);
  }
}
