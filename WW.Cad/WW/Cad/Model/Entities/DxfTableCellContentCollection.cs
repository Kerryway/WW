// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableCellContentCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;

namespace WW.Cad.Model.Entities
{
  public class DxfTableCellContentCollection : List<DxfTableCellContent>
  {
    public DxfTableCellContentCollection()
    {
    }

    public DxfTableCellContentCollection(int capacity)
      : base(capacity)
    {
    }

    public DxfTableCellContentCollection(IEnumerable<DxfTableCellContent> collection)
      : base(collection)
    {
    }

    public void Add(DxfValueFormat format, int value)
    {
      this.Add(new DxfTableCellContent(format, value));
    }

    public void Add(DxfValueFormat format, double value)
    {
      this.Add(new DxfTableCellContent(format, value));
    }

    public void Add(DxfValueFormat format, WW.Math.Point2D value)
    {
      this.Add(new DxfTableCellContent(format, value));
    }

    public void Add(DxfValueFormat format, WW.Math.Point3D value)
    {
      this.Add(new DxfTableCellContent(format, value));
    }

    public void Add(DxfValueFormat format, string value)
    {
      this.Add(new DxfTableCellContent(format, value));
    }

    public void Add(DxfValueFormat format, DateTime value)
    {
      this.Add(new DxfTableCellContent(format, value));
    }

    public void Add(DxfValueFormat format, DxfHandledObject value)
    {
      this.Add(new DxfTableCellContent(format, value));
    }
  }
}
