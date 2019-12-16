// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfTableBorder
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Objects
{
  public class DxfTableBorder
  {
    private short short_0 = -2;
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private BorderType borderType_0 = BorderType.Single;
    private bool bool_0 = true;
    private Color color_0 = Color.ByBlock;
    private double double_0 = 0.045;
    private TableBorderPropertyFlags tableBorderPropertyFlags_0;
    private bool bool_1;

    public short LineWeight
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
        this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.LineWeight;
        this.HasData = true;
      }
    }

    public bool OverrideLineWeight
    {
      get
      {
        return (this.tableBorderPropertyFlags_0 & TableBorderPropertyFlags.LineWeight) != TableBorderPropertyFlags.None;
      }
      set
      {
        if (value)
          this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.LineWeight;
        else
          this.tableBorderPropertyFlags_0 &= ~TableBorderPropertyFlags.LineWeight;
      }
    }

    public DxfLineType LineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.LineType;
        this.HasData = true;
      }
    }

    public bool OverrideLineType
    {
      get
      {
        return (this.tableBorderPropertyFlags_0 & TableBorderPropertyFlags.LineType) != TableBorderPropertyFlags.None;
      }
      set
      {
        if (value)
          this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.LineType;
        else
          this.tableBorderPropertyFlags_0 &= ~TableBorderPropertyFlags.LineType;
      }
    }

    public BorderType BorderType
    {
      get
      {
        return this.borderType_0;
      }
      set
      {
        this.borderType_0 = value;
        this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.BorderType;
        this.HasData = true;
      }
    }

    public bool OverrideBorderType
    {
      get
      {
        return (this.tableBorderPropertyFlags_0 & TableBorderPropertyFlags.BorderType) != TableBorderPropertyFlags.None;
      }
      set
      {
        if (value)
          this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.BorderType;
        else
          this.tableBorderPropertyFlags_0 &= ~TableBorderPropertyFlags.BorderType;
      }
    }

    public bool Visible
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
        this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.Visibility;
        this.HasData = true;
      }
    }

    public bool OverrideVisibility
    {
      get
      {
        return (this.tableBorderPropertyFlags_0 & TableBorderPropertyFlags.Visibility) != TableBorderPropertyFlags.None;
      }
      set
      {
        if (value)
          this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.Visibility;
        else
          this.tableBorderPropertyFlags_0 &= ~TableBorderPropertyFlags.Visibility;
      }
    }

    public Color Color
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.Color;
        this.HasData = true;
      }
    }

    public bool OverrideColor
    {
      get
      {
        return (this.tableBorderPropertyFlags_0 & TableBorderPropertyFlags.Color) != TableBorderPropertyFlags.None;
      }
      set
      {
        if (value)
          this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.Color;
        else
          this.tableBorderPropertyFlags_0 &= ~TableBorderPropertyFlags.Color;
      }
    }

    public double DoubleLineSpacing
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
        this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.DoubleLineSpacing;
        this.HasData = true;
      }
    }

    public bool OverrideDoubleLineSpacing
    {
      get
      {
        return (this.tableBorderPropertyFlags_0 & TableBorderPropertyFlags.DoubleLineSpacing) != TableBorderPropertyFlags.None;
      }
      set
      {
        if (value)
          this.tableBorderPropertyFlags_0 |= TableBorderPropertyFlags.DoubleLineSpacing;
        else
          this.tableBorderPropertyFlags_0 &= ~TableBorderPropertyFlags.DoubleLineSpacing;
      }
    }

    public TableBorderPropertyFlags PropertyOverrideFlags
    {
      get
      {
        return this.tableBorderPropertyFlags_0;
      }
      set
      {
        this.tableBorderPropertyFlags_0 = value;
      }
    }

    public bool HasData
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public DxfTableBorder GetEffectiveBorder(DxfTableBorderOverrides borderOverrides)
    {
      return new DxfTableBorder() { LineWeight = borderOverrides.LineWeight.HasValue ? borderOverrides.LineWeight.Value : this.short_0, LineType = borderOverrides.LineType != null ? borderOverrides.LineType : this.LineType, BorderType = borderOverrides.BorderType.HasValue ? borderOverrides.BorderType.Value : this.borderType_0, Visible = borderOverrides.Visible.HasValue ? borderOverrides.Visible.Value : this.bool_0, Color = borderOverrides.Color.HasValue ? borderOverrides.Color.Value : this.color_0, DoubleLineSpacing = borderOverrides.DoubleLineSpacing.HasValue ? borderOverrides.DoubleLineSpacing.Value : this.double_0 };
    }

    public void ApplyOverrides(DxfTableBorder overrides)
    {
      if (overrides.OverrideLineWeight)
        this.short_0 = overrides.short_0;
      if (overrides.OverrideLineType)
        this.LineType = overrides.LineType;
      if (overrides.OverrideBorderType)
        this.borderType_0 = overrides.borderType_0;
      if (overrides.OverrideVisibility)
        this.bool_0 = overrides.bool_0;
      if (overrides.OverrideColor)
        this.color_0 = overrides.color_0;
      if (!overrides.OverrideDoubleLineSpacing)
        return;
      this.double_0 = overrides.double_0;
    }

    public void CopyFrom(DxfTableBorder from, CloneContext cloneContext)
    {
      this.short_0 = from.short_0;
      if (from.LineType == null)
      {
        this.LineType = (DxfLineType) null;
      }
      else
      {
        DxfLineType lineType;
        if (cloneContext.SourceModel == cloneContext.TargetModel)
          lineType = from.LineType;
        else if (!cloneContext.TargetModel.LineTypes.TryGetValue(from.LineType.Name, out lineType))
        {
          if (cloneContext.ReferenceResolutionType == ReferenceResolutionType.CloneMissing)
          {
            lineType = (DxfLineType) from.LineType.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.LineTypes.Add(lineType);
          }
          else if (cloneContext.ReferenceResolutionType == ReferenceResolutionType.FailOnMissing)
            throw new DxfException("Line type with name " + from.LineType.Name + " is not present in target model.");
        }
        this.method_0(lineType);
      }
      this.borderType_0 = from.borderType_0;
      this.bool_0 = from.bool_0;
      this.color_0 = from.color_0;
      this.double_0 = from.double_0;
      this.tableBorderPropertyFlags_0 = from.tableBorderPropertyFlags_0;
      this.bool_1 = from.bool_1;
    }

    internal void SetLineWeight(short lineWeight)
    {
      this.short_0 = lineWeight;
    }

    internal void method_0(DxfLineType lineType)
    {
      this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) lineType);
    }

    internal void method_1(BorderType borderType)
    {
      this.borderType_0 = borderType;
    }

    internal void method_2(bool visible)
    {
      this.bool_0 = visible;
    }

    internal void SetColor(Color color)
    {
      this.color_0 = color;
    }

    internal void method_3(double doubleLineSpacing)
    {
      this.double_0 = doubleLineSpacing;
    }

    internal static bool smethod_0(DxfTableBorder a, DxfTableBorder b)
    {
      if (a == null && b == null)
        return true;
      if (a != null && b != null)
        return !a.bool_0 && !b.bool_0 || (int) a.short_0 == (int) b.short_0 && a.dxfObjectReference_0 == b.dxfObjectReference_0 && (a.borderType_0 == b.borderType_0 && a.bool_0 == b.bool_0) && a.color_0 == b.color_0 && (a.borderType_0 == BorderType.Single || a.double_0 == b.double_0);
      return false;
    }

    internal static double smethod_1(DxfTableBorder border)
    {
      if (DxfTableBorder.smethod_2(border))
        return border.double_0;
      return 0.0;
    }

    internal static bool smethod_2(DxfTableBorder border)
    {
      if (border != null && border.bool_0)
        return border.borderType_0 == BorderType.Double;
      return false;
    }

    internal void method_4(DxfModel model)
    {
    }

    internal void Write(DxfWriter w, int borderId)
    {
      if (!this.bool_1)
        return;
      w.Write(95, (object) borderId);
      this.method_5(w);
    }

    private void method_5(DxfWriter w)
    {
      w.Write(302, (object) "GRIDFORMAT");
      w.Write(1, (object) "GRIDFORMAT_BEGIN");
      w.Write(90, (object) (int) this.tableBorderPropertyFlags_0);
      w.Write(91, (object) (int) this.borderType_0);
      w.method_230(62, this.color_0);
      w.Write(92, (object) (int) this.short_0);
      if (this.LineType != null)
        w.method_218(340, (DxfHandledObject) this.LineType);
      else
        w.Write(340, (object) 0UL);
      w.Write(93, (object) (this.bool_0 ? 0 : 1));
      w.Write(40, (object) this.double_0);
      w.Write(309, (object) "GRIDFORMAT_END");
    }
  }
}
