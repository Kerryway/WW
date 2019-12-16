// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.Dxf3DSolid
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Cad.Drawing;

namespace WW.Cad.Model.Entities
{
  public class Dxf3DSolid : DxfModelerGeometry
  {
    private ulong ulong_0;

    public ulong HistoryId
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

    public static Dxf3DSolid CreateSphere(double radius)
    {
      Dxf3DSolid dxf3Dsolid = new Dxf3DSolid();
      string str = string.Format("106 6 1 0\nbody $-1 $1 $-1 $-1 #\nlump $-1 $-1 $2 $0 #\nshell $-1 $-1 $-1 $3 $1 #\nface $4 $-1 $-1 $2 $-1 $5 forward single #\ncolor-adesk-attrib $-1 $-1 $-1 $3 256 #\nsphere-surface $-1 0 0 0 {0} 1 0 0 0 0 1 0 I I I I #\n", (object) radius);
      dxf3Dsolid.SatText = str;
      return dxf3Dsolid;
    }

    public static Dxf3DSolid CreateBox(double xSide, double ySide, double zSide)
    {
      Dxf3DSolid dxf3Dsolid = new Dxf3DSolid();
      double num1 = xSide / 2.0;
      double num2 = ySide / 2.0;
      double num3 = zSide / 2.0;
      string str = string.Format("106 103 1 0 \nbody $-1 $1 $-1 $-1 #\nlump $-1 $-1 $2 $0 #\nshell $-1 $-1 $-1 $3 $1 #\nface $4 $5 $6 $2 $-1 $7 0 0 #\ncolor-adesk-attrib $-1 $-1 $-1 $3 256 #\nface $8 $9 $10 $2 $-1 $11 1 0 #\nloop $-1 $-1 $12 $3 #\nplane-surface $-1 0 0 {2} 0 0 1 1 0 0 0 0 0 0 0 #\ncolor-adesk-attrib $-1 $-1 $-1 $5 256 #\nface $13 $14 $15 $2 $-1 $16 1 0 #\nloop $-1 $-1 $17 $5 #\nplane-surface $-1 0 0 {2} 0 0 1 1 0 0 0 0 0 0 0 #\ncoedge $-1 $18 $19 $20 $21 0 $6 $-1 #\ncolor-adesk-attrib $-1 $-1 $-1 $9 256 #\nface $22 $23 $24 $2 $-1 $25 1 0 #\nloop $-1 $-1 $26 $9 #\nplane-surface $-1 0 {1} 0 0 1 0 0 0 1 0 0 0 0 0 #\ncoedge $-1 $27 $28 $29 $30 0 $10 $-1 #\ncoedge $-1 $31 $12 $32 $33 0 $6 $-1 #\ncoedge $-1 $12 $31 $34 $35 0 $6 $-1 #\ncoedge $-1 $36 $37 $12 $21 1 $38 $-1 #\nedge $39 $40 $41 $20 $42 0 #\ncolor-adesk-attrib $-1 $-1 $-1 $14 256 #\nface $43 $44 $45 $2 $-1 $46 1 0 #\nloop $-1 $-1 $47 $14 #\nplane-surface $-1 {0} 0 0 1 0 0 0 0 -1 0 0 0 0 0 #\ncoedge $-1 $48 $34 $49 $50 0 $15 $-1 #\ncoedge $-1 $51 $17 $48 $52 0 $10 $-1 #\ncoedge $-1 $17 $51 $53 $54 0 $10 $-1 #\ncoedge $-1 $37 $36 $17 $30 1 $38 $-1 #\nedge $55 $56 $57 $29 $58 0 #\ncoedge $-1 $19 $18 $59 $60 0 $6 $-1 #\ncoedge $-1 $61 $62 $18 $33 1 $45 $-1 #\nedge $63 $41 $64 $32 $65 0 #\ncoedge $-1 $26 $66 $19 $35 1 $15 $-1 #\nedge $67 $68 $40 $34 $69 0 #\ncoedge $-1 $29 $20 $66 $70 0 $38 $-1 #\ncoedge $-1 $20 $29 $61 $71 1 $38 $-1 #\nloop $-1 $-1 $36 $44 #\ncolor-adesk-attrib $-1 $-1 $-1 $21 256 #\nvertex $-1 $21 $72 #\nvertex $-1 $21 $73 #\nstraight-curve $-1 {0} 0 {2} 0 1 0 0 0 #\ncolor-adesk-attrib $-1 $-1 $-1 $23 256 #\nface $74 $-1 $38 $2 $-1 $75 1 0 #\nloop $-1 $-1 $61 $23 #\nplane-surface $-1 0 {1} 0 0 -1 0 0 0 -1 0 0 0 0 0 #\ncoedge $-1 $76 $59 $62 $77 0 $24 $-1 #\ncoedge $-1 $66 $26 $27 $52 1 $15 $-1 #\ncoedge $-1 $59 $76 $26 $50 1 $24 $-1 #\nedge $78 $68 $79 $49 $80 0 #\ncoedge $-1 $28 $27 $76 $81 0 $10 $-1 #\nedge $82 $57 $79 $48 $83 0 #\ncoedge $-1 $62 $61 $28 $54 1 $45 $-1 #\nedge $84 $85 $56 $53 $86 0 #\ncolor-adesk-attrib $-1 $-1 $-1 $30 256 #\nvertex $-1 $30 $87 #\nvertex $-1 $70 $88 #\nstraight-curve $-1 {0} 0 {5} 0 -1 0 0 0 #\ncoedge $-1 $47 $49 $31 $60 1 $24 $-1 #\nedge $89 $64 $68 $59 $90 0 #\ncoedge $-1 $53 $32 $37 $71 0 $45 $-1 #\ncoedge $-1 $32 $53 $47 $77 1 $45 $-1 #\ncolor-adesk-attrib $-1 $-1 $-1 $33 256 #\nvertex $-1 $33 $91 #\nstraight-curve $-1 0 {1} {2} -1 0 0 0 0 #\ncoedge $-1 $34 $48 $36 $70 1 $15 $-1 #\ncolor-adesk-attrib $-1 $-1 $-1 $35 256 #\nvertex $-1 $60 $92 #\nstraight-curve $-1 0 {4} {2} 1 0 0 0 0 #\nedge $93 $40 $57 $36 $94 0 #\nedge $95 $41 $56 $37 $96 0 #\npoint $-1 {0} {4} {2} #\npoint $-1 {0} {1} {2} #\ncolor-adesk-attrib $-1 $-1 $-1 $44 256 #\nplane-surface $-1 {0} 0 0 -1 0 0 0 0 1 0 0 0 0 0 #\ncoedge $-1 $49 $47 $51 $81 1 $24 $-1 #\nedge $97 $64 $85 $62 $98 0 #\ncolor-adesk-attrib $-1 $-1 $-1 $50 256 #\nvertex $-1 $81 $99 #\nstraight-curve $-1 {3} {4} 0 0 0 -1 0 0 #\nedge $100 $79 $85 $76 $101 0 #\ncolor-adesk-attrib $-1 $-1 $-1 $52 256 #\nstraight-curve $-1 0 {4} {5} -1 0 0 0 0 #\ncolor-adesk-attrib $-1 $-1 $-1 $54 256 #\nvertex $-1 $54 $102 #\nstraight-curve $-1 0 {1} {5} 1 0 0 0 0 #\npoint $-1 {0} {1} {5} #\npoint $-1 {0} {4} {5} #\ncolor-adesk-attrib $-1 $-1 $-1 $60 256 #\nstraight-curve $-1 {3} 0 {2} 0 -1 0 0 0 #\npoint $-1 {3} {1} {2} #\npoint $-1 {3} {4} {2} #\ncolor-adesk-attrib $-1 $-1 $-1 $70 256 #\nstraight-curve $-1 {0} {4} 0 0 0 -1 0 0 #\ncolor-adesk-attrib $-1 $-1 $-1 $71 256 #\nstraight-curve $-1 {0} {1} 0 0 0 -1 0 0 #\ncolor-adesk-attrib $-1 $-1 $-1 $77 256 #\nstraight-curve $-1 {3} {1} 0 0 0 -1 0 0 #\npoint $-1 {3} {4} {5} #\ncolor-adesk-attrib $-1 $-1 $-1 $81 256 #\nstraight-curve $-1 {3} 0 {5} 0 1 0 0 0 #\npoint $-1 {3} {1} {5} #\n", (object) num1, (object) num2, (object) num3, (object) -num1, (object) -num2, (object) -num3);
      dxf3Dsolid.SatText = str;
      return dxf3Dsolid;
    }

    public override string EntityType
    {
      get
      {
        return "3DSOLID";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDb3dSolid";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.ulong_0 = 0UL;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      Dxf3DSolid dxf3Dsolid = (Dxf3DSolid) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxf3Dsolid == null)
      {
        dxf3Dsolid = new Dxf3DSolid();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxf3Dsolid);
        dxf3Dsolid.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxf3Dsolid;
    }

    internal override short vmethod_6(Class432 w)
    {
      return 38;
    }
  }
}
