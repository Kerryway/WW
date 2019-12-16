// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.EdgeStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects
{
  public class EdgeStyle
  {
    private EdgeModel edgeModel_0 = EdgeModel.Isolines;
    private EdgeStyleFlags edgeStyleFlags_0 = EdgeStyleFlags.Obscured;
    private Color color_0 = Color.CreateFromColorIndex((short) 7);
    private Color color_1 = Color.None;
    private LineType lineType_0 = LineType.Solid;
    private LineType lineType_1 = LineType.Solid;
    private double double_0 = 1.0;
    private Color color_2 = Color.None;
    private double double_1 = 1.0;
    private int int_0 = 1;
    private int int_1 = 6;
    private JitterAmount jitterAmount_0 = JitterAmount.Medium;
    private Color color_3 = Color.CreateFromColorIndex((short) 7);
    private int int_2 = 5;
    private WiggleAmount wiggleAmount_0 = WiggleAmount.Medium;
    private EdgeModifierFlags edgeModifierFlags_0;
    private int int_3;
    private int int_4;
    private bool bool_0;
    private EdgeStyleApplication edgeStyleApplication_0;

    public EdgeModel EdgeModel
    {
      get
      {
        return this.edgeModel_0;
      }
      set
      {
        this.edgeModel_0 = value;
      }
    }

    public EdgeStyleFlags EdgeStyleFlags
    {
      get
      {
        return this.edgeStyleFlags_0;
      }
      set
      {
        this.edgeStyleFlags_0 = value;
      }
    }

    public Color IntersectionColor
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

    public Color ObscuredColor
    {
      get
      {
        return this.color_1;
      }
      set
      {
        this.color_1 = value;
      }
    }

    public LineType ObscuredLineType
    {
      get
      {
        return this.lineType_0;
      }
      set
      {
        this.lineType_0 = value;
      }
    }

    public LineType IntersectionLineType
    {
      get
      {
        return this.lineType_1;
      }
      set
      {
        this.lineType_1 = value;
      }
    }

    public double CreaseAngle
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

    public EdgeModifierFlags EdgeModifierFlags
    {
      get
      {
        return this.edgeModifierFlags_0;
      }
      set
      {
        this.edgeModifierFlags_0 = value;
      }
    }

    public Color EdgeColor
    {
      get
      {
        return this.color_2;
      }
      set
      {
        this.color_2 = value;
      }
    }

    public double OpacityLevel
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

    public int EdgeWidth
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

    public int OverhangAmount
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

    public JitterAmount JitterAmount
    {
      get
      {
        return this.jitterAmount_0;
      }
      set
      {
        this.jitterAmount_0 = value;
      }
    }

    public Color SilhouetteColor
    {
      get
      {
        return this.color_3;
      }
      set
      {
        this.color_3 = value;
      }
    }

    public int SilhouetteWidth
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

    public int HaloGap
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

    public int IsolineCount
    {
      get
      {
        return this.int_4;
      }
      set
      {
        this.int_4 = value;
      }
    }

    public bool EdgePrecisionHidden
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

    public EdgeStyleApplication EdgeStyleApplication
    {
      get
      {
        return this.edgeStyleApplication_0;
      }
      set
      {
        this.edgeStyleApplication_0 = value;
      }
    }

    public WiggleAmount WiggleAmount
    {
      get
      {
        return this.wiggleAmount_0;
      }
      set
      {
        this.wiggleAmount_0 = value;
      }
    }

    public void CopyFrom(EdgeStyle from, CloneContext cloneContext)
    {
      this.edgeModel_0 = from.edgeModel_0;
      this.edgeStyleFlags_0 = from.edgeStyleFlags_0;
      this.color_0 = from.color_0;
      this.color_1 = from.color_1;
      this.lineType_0 = from.lineType_0;
      this.lineType_1 = from.lineType_1;
      this.double_0 = from.double_0;
      this.edgeModifierFlags_0 = from.edgeModifierFlags_0;
      this.color_2 = from.color_2;
      this.double_1 = from.double_1;
      this.int_0 = from.int_0;
      this.int_1 = from.int_1;
      this.jitterAmount_0 = from.jitterAmount_0;
      this.color_3 = from.color_3;
      this.int_2 = from.int_2;
      this.int_3 = from.int_3;
      this.int_4 = from.int_4;
      this.bool_0 = from.bool_0;
      this.edgeStyleApplication_0 = from.edgeStyleApplication_0;
      this.wiggleAmount_0 = from.wiggleAmount_0;
    }

    internal void Write(Class432 ow, DxfVisualStyle.Class488 pw)
    {
      if (ow.Version < DxfVersion.Dxf24)
      {
        pw.vmethod_4((int) this.edgeModel_0);
        pw.vmethod_4((int) this.edgeStyleFlags_0);
        pw.vmethod_6(this.color_0);
        pw.vmethod_6(this.color_1);
        pw.vmethod_4((int) this.lineType_0);
        pw.vmethod_5(this.double_0);
        pw.vmethod_4((int) this.edgeModifierFlags_0);
        pw.vmethod_6(this.color_2);
        pw.vmethod_5(this.double_1);
        pw.vmethod_3((short) this.int_0);
        pw.vmethod_3((short) this.int_1);
        pw.vmethod_4((int) this.jitterAmount_0);
        pw.vmethod_6(this.color_3);
        pw.vmethod_3((short) this.int_2);
        pw.vmethod_1((byte) this.int_3);
        pw.vmethod_3((short) this.int_4);
        pw.vmethod_0(this.bool_0);
        pw.vmethod_3((short) this.edgeStyleApplication_0);
        pw.vmethod_3((short) this.lineType_1);
      }
      else
      {
        pw.vmethod_4((int) this.edgeModel_0);
        pw.vmethod_4((int) this.edgeStyleFlags_0);
        pw.vmethod_6(this.color_0);
        pw.vmethod_6(this.color_1);
        pw.vmethod_4((int) this.lineType_0);
        pw.vmethod_4((int) this.lineType_1);
        pw.vmethod_5(this.double_0);
        pw.vmethod_4((int) this.edgeModifierFlags_0);
        pw.vmethod_6(this.color_2);
        pw.vmethod_5(this.double_1);
        pw.vmethod_4(this.int_0);
        pw.vmethod_4(this.int_1);
        pw.vmethod_4((int) this.jitterAmount_0);
        pw.vmethod_6(this.color_3);
        pw.vmethod_4(this.int_2);
        pw.vmethod_4(this.int_3);
        pw.vmethod_4(this.int_4);
        pw.vmethod_0(this.bool_0);
      }
    }

    internal void Read(Class434 or, DxfVisualStyle.Class486 pr)
    {
      if (or.Version < DxfVersion.Dxf24)
      {
        this.edgeModel_0 = (EdgeModel) pr.vmethod_3();
        this.edgeStyleFlags_0 = (EdgeStyleFlags) pr.vmethod_3();
        this.color_0 = pr.vmethod_5();
        this.color_1 = pr.vmethod_5();
        this.lineType_0 = (LineType) pr.vmethod_3();
        this.double_0 = pr.vmethod_4();
        this.edgeModifierFlags_0 = (EdgeModifierFlags) pr.vmethod_3();
        this.color_2 = pr.vmethod_5();
        this.double_1 = pr.vmethod_4();
        this.int_0 = (int) pr.vmethod_2();
        this.int_1 = (int) pr.vmethod_2();
        this.jitterAmount_0 = (JitterAmount) pr.vmethod_3();
        this.color_3 = pr.vmethod_5();
        this.int_2 = (int) pr.vmethod_2();
        this.int_3 = (int) pr.vmethod_1();
        this.int_4 = (int) pr.vmethod_2();
        this.bool_0 = pr.vmethod_0();
        this.edgeStyleApplication_0 = (EdgeStyleApplication) pr.vmethod_2();
        this.lineType_1 = (LineType) pr.vmethod_2();
      }
      else
      {
        this.edgeModel_0 = (EdgeModel) pr.vmethod_3();
        this.edgeStyleFlags_0 = (EdgeStyleFlags) pr.vmethod_3();
        this.color_0 = pr.vmethod_5();
        this.color_1 = pr.vmethod_5();
        this.lineType_0 = (LineType) pr.vmethod_3();
        this.lineType_1 = (LineType) pr.vmethod_3();
        this.double_0 = pr.vmethod_4();
        this.edgeModifierFlags_0 = (EdgeModifierFlags) pr.vmethod_3();
        this.color_2 = pr.vmethod_5();
        this.double_1 = pr.vmethod_4();
        this.int_0 = (int) (short) pr.vmethod_3();
        this.int_1 = (int) (short) pr.vmethod_3();
        this.jitterAmount_0 = (JitterAmount) pr.vmethod_3();
        this.color_3 = pr.vmethod_5();
        this.int_2 = (int) (short) pr.vmethod_3();
        this.int_3 = (int) (short) pr.vmethod_3();
        this.int_4 = (int) (short) pr.vmethod_3();
        this.bool_0 = pr.vmethod_0();
      }
    }

    internal void Write(DxfWriter w, DxfVisualStyle.Class490 pw)
    {
      pw.Write(74, (object) (short) this.EdgeModel);
      pw.Write(91, (object) (int) this.EdgeStyleFlags);
      pw.vmethod_0(64, this.IntersectionColor);
      pw.vmethod_0(65, this.ObscuredColor);
      pw.Write(75, (object) (short) this.ObscuredLineType);
      pw.Write(175, (object) (short) this.IntersectionLineType);
      pw.Write(42, (object) this.CreaseAngle);
      pw.Write(92, (object) (int) this.EdgeModifierFlags);
      pw.vmethod_0(66, this.EdgeColor);
      pw.Write(43, (object) this.OpacityLevel);
      pw.Write(76, (object) (short) this.EdgeWidth);
      pw.Write(77, (object) (short) this.OverhangAmount);
      pw.Write(78, (object) (short) this.JitterAmount);
      pw.vmethod_0(67, this.SilhouetteColor);
      pw.Write(79, (object) (short) this.SilhouetteWidth);
      pw.Write(170, (object) (short) this.HaloGap);
      pw.Write(171, (object) (short) this.IsolineCount);
      pw.Write(290, (object) this.EdgePrecisionHidden);
      if (w.Version >= DxfVersion.Dxf24)
        return;
      w.Write(174, (object) (short) this.EdgeStyleApplication);
    }
  }
}
