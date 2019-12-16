// Decompiled with JetBrains decompiler
// Type: ns3.Class1049
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns2;
using System.Collections.Generic;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class1049 : Interface10
  {
    private int int_6 = -1;
    private List<Interface10> list_0 = new List<Interface10>();
    private List<Interface10> list_1 = new List<Interface10>();
    private Class551 class551_0;
    private ulong ulong_0;
    private ulong ulong_1;
    private int int_0;
    private int int_1;
    private int int_2;
    private int int_3;
    private int int_4;
    private int int_5;
    private Class1026 class1026_0;
    private Class330 class330_0;
    private bool bool_0;
    private Class1000 class1000_0;
    private Class1000 class1000_1;
    private Class1000 class1000_2;

    public Class1049(Class551 table)
    {
      this.class551_0 = table;
      this.class1000_0 = new Class1000(table.TitleRowCellStyle);
      this.class1000_1 = new Class1000(table.HeaderRowCellStyle);
      this.class1000_2 = new Class1000(table.DataRowCellStyle);
    }

    public Class551 Table
    {
      get
      {
        return this.class551_0;
      }
    }

    public ulong TableStyleHandle
    {
      get
      {
        return this.ulong_0;
      }
      set
      {
        this.ulong_0 = value;
      }
    }

    public ulong OwningBlockRecordHandle
    {
      get
      {
        return this.ulong_1;
      }
      set
      {
        this.ulong_1 = value;
      }
    }

    public int OverrideFlags
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

    public int BorderColorOverrideFlags
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public int BorderLineWeightOverrideFlags
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
      }
    }

    public int BorderVisibilityOverrideFlags
    {
      get
      {
        return this.int_3;
      }
      set
      {
        this.int_3 = value;
      }
    }

    public void method_0(double rowHeight)
    {
      this.class551_0.Rows[this.int_4].Height = rowHeight;
      ++this.int_4;
    }

    public void method_1(double columnWidth)
    {
      this.class551_0.Columns[this.int_5].Width = columnWidth;
      ++this.int_5;
    }

    public Class1026 CurrentCell
    {
      get
      {
        return this.class1026_0;
      }
    }

    public Class330 CurrentCellBuilder
    {
      get
      {
        return this.class330_0;
      }
    }

    public bool StartedReadingCells
    {
      get
      {
        return this.bool_0;
      }
    }

    public Class1000 TitleRowBuilder
    {
      get
      {
        return this.class1000_0;
      }
      set
      {
        this.class1000_0 = value;
      }
    }

    public Class1000 HeaderRowBuilder
    {
      get
      {
        return this.class1000_1;
      }
      set
      {
        this.class1000_1 = value;
      }
    }

    public Class1000 DataRowBuilder
    {
      get
      {
        return this.class1000_2;
      }
      set
      {
        this.class1000_2 = value;
      }
    }

    public List<Interface10> PrerequisiteBuilders
    {
      get
      {
        return this.list_1;
      }
    }

    public void method_2(Enum47 cellType)
    {
      this.bool_0 = true;
      ++this.int_6;
      this.int_4 = this.int_6 / this.class551_0.ColumnCount;
      this.int_5 = this.int_6 % this.class551_0.ColumnCount;
      this.class1026_0 = this.class551_0.Rows[this.int_4].Cells[this.int_5];
      this.class1026_0.CellType = cellType;
      this.class330_0 = new Class330(this.class1026_0);
      this.list_0.Add((Interface10) this.class330_0);
    }

    public void method_3(Interface10 childBuilder)
    {
      this.list_0.Add(childBuilder);
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      foreach (Interface10 nterface10 in this.list_1)
        nterface10.ResolveReferences(modelBuilder);
      if (this.ulong_0 != 0UL)
        this.class551_0.TableStyle = modelBuilder.method_4<DxfTableStyle>(this.ulong_0);
      modelBuilder.ResolveReferences((ICollection<Interface10>) this.list_0);
      this.class1000_0.ResolveReferences(modelBuilder);
      this.class1000_1.ResolveReferences(modelBuilder);
      this.class1000_2.ResolveReferences(modelBuilder);
    }
  }
}
