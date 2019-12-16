// Decompiled with JetBrains decompiler
// Type: ns3.Class566
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class566 : Interface10
  {
    private DxfContentFormat dxfContentFormat_0;
    private ValueDataType valueDataType_0;
    private ValueUnitType valueUnitType_0;
    private string string_0;
    private ulong ulong_0;

    public Class566(DxfContentFormat contentFormat)
    {
      this.dxfContentFormat_0 = contentFormat;
    }

    public DxfContentFormat ContentFormat
    {
      get
      {
        return this.dxfContentFormat_0;
      }
    }

    public ValueDataType DataType
    {
      get
      {
        return this.valueDataType_0;
      }
      set
      {
        this.valueDataType_0 = value;
      }
    }

    public ValueUnitType DataUnitType
    {
      get
      {
        return this.valueUnitType_0;
      }
      set
      {
        this.valueUnitType_0 = value;
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

    public void ResolveReferences(Class374 modelBuilder)
    {
      this.dxfContentFormat_0.method_4(DxfValueFormat.Create(this.valueDataType_0, this.valueUnitType_0));
      if (!string.IsNullOrEmpty(this.string_0))
        this.dxfContentFormat_0.ValueFormat._FormatString = this.string_0;
      if (this.ulong_0 == 0UL)
        return;
      this.dxfContentFormat_0.method_0(modelBuilder.method_4<DxfTextStyle>(this.ulong_0));
    }
  }
}
