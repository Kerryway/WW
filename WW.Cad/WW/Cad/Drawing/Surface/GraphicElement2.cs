// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.GraphicElement2
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class GraphicElement2 : GraphicElement1
  {
    private DxfLineType dxfLineType_0;
    private double double_0;
    private bool bool_0;

    public GraphicElement2()
    {
    }

    public GraphicElement2(
      ArgbColor color,
      DxfLineType lineType,
      double lineTypeScale,
      bool plinegen)
      : base(color)
    {
      this.dxfLineType_0 = lineType;
      this.double_0 = lineTypeScale;
      this.bool_0 = plinegen;
    }

    public GraphicElement2(
      Geometry geometry,
      ArgbColor color,
      DxfLineType lineType,
      double lineTypeScale,
      bool plinegen)
      : base(geometry, color)
    {
      this.dxfLineType_0 = lineType;
      this.double_0 = lineTypeScale;
      this.bool_0 = plinegen;
    }

    public DxfLineType LineType
    {
      get
      {
        return this.dxfLineType_0;
      }
      set
      {
        this.dxfLineType_0 = value;
      }
    }

    public double LineTypeScale
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

    public bool Plinegen
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public bool Matches(
      ArgbColor color,
      DxfLineType lineType,
      double lineTypeScale,
      bool plinegen)
    {
      if (this.Matches(color) && lineType == this.dxfLineType_0 && plinegen == this.bool_0)
        return MathUtil.AreApproxEqual(lineTypeScale, this.double_0, 8.88178419700125E-16);
      return false;
    }

    public override void Accept(IGraphicElementVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
