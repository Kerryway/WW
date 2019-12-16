// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfMLineStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using System;
using System.Collections.Generic;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Objects
{
  public class DxfMLineStyle : DxfObject, INamedObject
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private Color color_0 = Color.ByLayer;
    private double double_0 = Math.PI / 2.0;
    private double double_1 = Math.PI / 2.0;
    private readonly List<DxfMLineStyle.Element> list_0 = new List<DxfMLineStyle.Element>();
    public const string DefaultMLineStyleName = "STANDARD";
    private MLineStyleFlags mlineStyleFlags_0;

    public DxfMLineStyle(string name)
    {
      this.string_0 = name;
    }

    internal DxfMLineStyle()
    {
    }

    public string Description
    {
      get
      {
        return this.string_1;
      }
      set
      {
        if (value != null && value.Length > (int) byte.MaxValue)
          throw new ArgumentException("MLineStyle description length exceeds 255 characters.");
        this.string_1 = value;
      }
    }

    public List<DxfMLineStyle.Element> Elements
    {
      get
      {
        return this.list_0;
      }
    }

    public double EndAngle
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public Color FillColor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
      }
    }

    public MLineStyleFlags Flags
    {
      get
      {
        return this.mlineStyleFlags_0;
      }
      set
      {
        this.mlineStyleFlags_0 = value;
      }
    }

    public bool IsFillOn
    {
      get
      {
        return (this.mlineStyleFlags_0 & MLineStyleFlags.FillOn) != MLineStyleFlags.None;
      }
      set
      {
        if (value)
          this.mlineStyleFlags_0 |= MLineStyleFlags.FillOn;
        else
          this.mlineStyleFlags_0 &= ~MLineStyleFlags.FillOn;
      }
    }

    public bool DisplayMiters
    {
      get
      {
        return (this.mlineStyleFlags_0 & MLineStyleFlags.DisplayMiters) != MLineStyleFlags.None;
      }
      set
      {
        if (value)
          this.mlineStyleFlags_0 |= MLineStyleFlags.DisplayMiters;
        else
          this.mlineStyleFlags_0 &= ~MLineStyleFlags.DisplayMiters;
      }
    }

    public bool StartHasSquareEndCap
    {
      get
      {
        return (this.mlineStyleFlags_0 & MLineStyleFlags.StartSquareEndCap) != MLineStyleFlags.None;
      }
      set
      {
        if (value)
          this.mlineStyleFlags_0 |= MLineStyleFlags.StartSquareEndCap;
        else
          this.mlineStyleFlags_0 &= ~MLineStyleFlags.StartSquareEndCap;
      }
    }

    public bool StartHasInnerArcsCap
    {
      get
      {
        return (this.mlineStyleFlags_0 & MLineStyleFlags.StartInnerArcsCap) != MLineStyleFlags.None;
      }
      set
      {
        if (value)
          this.mlineStyleFlags_0 |= MLineStyleFlags.StartInnerArcsCap;
        else
          this.mlineStyleFlags_0 &= ~MLineStyleFlags.StartInnerArcsCap;
      }
    }

    public bool StartHasRoundCap
    {
      get
      {
        return (this.mlineStyleFlags_0 & MLineStyleFlags.StartRoundCap) != MLineStyleFlags.None;
      }
      set
      {
        if (value)
          this.mlineStyleFlags_0 |= MLineStyleFlags.StartRoundCap;
        else
          this.mlineStyleFlags_0 &= ~MLineStyleFlags.StartRoundCap;
      }
    }

    public bool EndHasSquareCap
    {
      get
      {
        return (this.mlineStyleFlags_0 & MLineStyleFlags.EndSquareCap) != MLineStyleFlags.None;
      }
      set
      {
        if (value)
          this.mlineStyleFlags_0 |= MLineStyleFlags.EndSquareCap;
        else
          this.mlineStyleFlags_0 &= ~MLineStyleFlags.EndSquareCap;
      }
    }

    public bool EndHasInnerArcs
    {
      get
      {
        return (this.mlineStyleFlags_0 & MLineStyleFlags.EndInnerArcsCap) != MLineStyleFlags.None;
      }
      set
      {
        if (value)
          this.mlineStyleFlags_0 |= MLineStyleFlags.EndInnerArcsCap;
        else
          this.mlineStyleFlags_0 &= ~MLineStyleFlags.EndInnerArcsCap;
      }
    }

    public bool EndHasRoundCap
    {
      get
      {
        return (this.mlineStyleFlags_0 & MLineStyleFlags.EndRoundCap) != MLineStyleFlags.None;
      }
      set
      {
        if (value)
          this.mlineStyleFlags_0 |= MLineStyleFlags.EndRoundCap;
        else
          this.mlineStyleFlags_0 &= ~MLineStyleFlags.EndRoundCap;
      }
    }

    public string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        if (value != null && value.Length > 32)
          throw new ArgumentException("MLineStyle name length exceeds 32 characters.");
        this.string_0 = value;
      }
    }

    public double StartAngle
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return 73;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf13OrHigher;
    }

    public override string ObjectType
    {
      get
      {
        return "MLINESTYLE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbMlineStyle";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfMLineStyle dxfMlineStyle = (DxfMLineStyle) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfMlineStyle == null)
      {
        dxfMlineStyle = new DxfMLineStyle();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfMlineStyle);
        dxfMlineStyle.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfMlineStyle;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfMLineStyle dxfMlineStyle = (DxfMLineStyle) from;
      this.string_0 = dxfMlineStyle.string_0;
      this.mlineStyleFlags_0 = dxfMlineStyle.mlineStyleFlags_0;
      this.string_1 = dxfMlineStyle.string_1;
      this.color_0 = dxfMlineStyle.color_0;
      this.double_0 = dxfMlineStyle.double_0;
      this.double_1 = dxfMlineStyle.double_1;
      foreach (DxfMLineStyle.Element element in dxfMlineStyle.list_0)
        this.list_0.Add(element.Clone(cloneContext));
      if (dxfMlineStyle.Handle != 24UL)
        return;
      this.SetHandle(24UL);
    }

    public override string ToString()
    {
      return this.string_0;
    }

    internal static DxfMLineStyle smethod_2(DxfModel model, bool useFixedHandles)
    {
      DxfMLineStyle dxfMlineStyle = new DxfMLineStyle();
      if (useFixedHandles)
      {
        dxfMlineStyle.SetHandle(24UL);
        dxfMlineStyle.vmethod_2((IDxfHandledObject) model.DictionaryAcadMLineStyle);
      }
      dxfMlineStyle.Name = "STANDARD";
      dxfMlineStyle.list_0.Add(new DxfMLineStyle.Element(0.5, Color.ByBlock, model.ByLayerLineType));
      dxfMlineStyle.list_0.Add(new DxfMLineStyle.Element(-0.5, Color.ByBlock, model.ByLayerLineType));
      return dxfMlineStyle;
    }

    public class Element
    {
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
      private double double_0;
      private Color color_0;

      public Element(DxfModel model)
        : this(model, 0.0)
      {
      }

      public Element(DxfModel model, double offset)
        : this(model, offset, Color.ByLayer)
      {
      }

      public Element(DxfModel model, double offset, Color color)
        : this(offset, color, model.ContinuousLineType)
      {
      }

      public Element(double offset, DxfLineType lineType)
        : this(offset, Color.ByLayer, lineType)
      {
      }

      public Element(double offset, Color color, DxfLineType lineType)
      {
        this.double_0 = offset;
        this.color_0 = color;
        this.LineType = lineType;
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
        }
      }

      public double Offset
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      public DxfMLineStyle.Element Clone(CloneContext cloneContext)
      {
        DxfMLineStyle.Element element = new DxfMLineStyle.Element(cloneContext.TargetModel);
        element.CopyFrom(this, cloneContext);
        return element;
      }

      public void CopyFrom(DxfMLineStyle.Element from, CloneContext cloneContext)
      {
        this.double_0 = from.double_0;
        this.color_0 = from.color_0;
        this.LineType = Class906.GetLineType(cloneContext, from.LineType);
      }
    }
  }
}
