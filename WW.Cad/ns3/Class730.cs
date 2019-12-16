// Decompiled with JetBrains decompiler
// Type: ns3.Class730
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class730
  {
    private double double_0;
    private Color color_0;
    private int? nullable_0;
    private ulong? nullable_1;

    public Class730(double offset, Color color)
    {
      this.double_0 = offset;
      this.color_0 = color;
    }

    public int? LineTypeIndex
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

    public ulong? LineTypeHandle
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

    public void ResolveReferences(Class374 modelBuilder, DxfMLineStyle mlineStyle)
    {
      DxfLineType lineType1 = (DxfLineType) null;
      if (this.nullable_1.HasValue)
        lineType1 = modelBuilder.method_4<DxfLineType>(this.nullable_1.Value);
      else if (this.nullable_0.HasValue)
      {
        if (this.nullable_0.Value == (int) short.MaxValue)
          lineType1 = modelBuilder.Model.ByLayerLineType;
        else if (this.nullable_0.Value == 32766)
        {
          lineType1 = modelBuilder.Model.ByBlockLineType;
        }
        else
        {
          int num = -1;
          foreach (DxfLineType lineType2 in (KeyedDxfHandledObjectCollection<string, DxfLineType>) modelBuilder.Model.LineTypes)
          {
            if (lineType2 != modelBuilder.Model.ByLayerLineType && lineType2 != modelBuilder.Model.ByBlockLineType)
              ++num;
            if (num == this.nullable_0.Value)
            {
              lineType1 = lineType2;
              break;
            }
          }
        }
      }
      else
        lineType1 = modelBuilder.Model.ByLayerLineType;
      mlineStyle.Elements.Add(new DxfMLineStyle.Element(this.double_0, this.color_0, lineType1));
    }
  }
}
