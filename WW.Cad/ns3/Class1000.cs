// Decompiled with JetBrains decompiler
// Type: ns3.Class1000
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class1000
  {
    private Class984 class984_0;
    private ulong ulong_0;
    private ValueDataType? nullable_0;
    private ValueUnitType? nullable_1;
    private string string_0;

    public Class1000(Class984 rowCellStyleOverrides)
    {
      this.class984_0 = rowCellStyleOverrides;
    }

    public ulong TextStyleHandle
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

    public ValueDataType? DataType
    {
      get
      {
        return this.nullable_0;
      }
      set
      {
        this.nullable_0 = value;
      }
    }

    public ValueUnitType? DataUnitType
    {
      get
      {
        return this.nullable_1;
      }
      set
      {
        this.nullable_1 = value;
      }
    }

    public string FormatString
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      if (this.ulong_0 != 0UL)
        this.class984_0.TextStyle = modelBuilder.method_4<DxfTextStyle>(this.ulong_0);
      if (!this.nullable_0.HasValue)
        return;
      this.class984_0.CellFormat = DxfValueFormat.Create(this.nullable_0, this.nullable_1, this.string_0);
    }
  }
}
