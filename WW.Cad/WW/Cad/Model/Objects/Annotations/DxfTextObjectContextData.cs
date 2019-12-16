// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfTextObjectContextData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns3;
using WW.Cad.IO;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model.Objects.Annotations
{
  public class DxfTextObjectContextData : DxfAnnotationScaleObjectContextData
  {
    private TextHorizontalAlignment textHorizontalAlignment_0;
    private double double_0;
    private WW.Math.Point2D point2D_0;
    private WW.Math.Point2D point2D_1;

    public double Rotation
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

    public TextHorizontalAlignment HorizontalAlignment
    {
      get
      {
        return this.textHorizontalAlignment_0;
      }
      set
      {
        this.textHorizontalAlignment_0 = value;
      }
    }

    public WW.Math.Point2D Position
    {
      get
      {
        return this.point2D_1;
      }
      set
      {
        this.point2D_1 = value;
      }
    }

    public WW.Math.Point2D AlignmentPoint
    {
      get
      {
        return this.point2D_0;
      }
      set
      {
        this.point2D_0 = value;
      }
    }

    public DxfTextObjectContextData()
    {
    }

    public DxfTextObjectContextData(DxfText text, DxfScale scale)
      : base(scale)
    {
      this.textHorizontalAlignment_0 = text.HorizontalAlignment;
      this.double_0 = text.Rotation;
      this.point2D_1.X = text.AlignmentPoint1.X;
      this.point2D_1.Y = text.AlignmentPoint1.Y;
      if (text.AlignmentPoint2.HasValue)
      {
        this.point2D_0.X = text.AlignmentPoint2.Value.X;
        this.point2D_0.Y = text.AlignmentPoint2.Value.Y;
      }
      else
        this.point2D_0 = this.point2D_1;
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string AcClass
    {
      get
      {
        return "AcDbTextObjectContextData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACDB_TEXTOBJECTCONTEXTDATA_CLASS";
      }
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfTextObjectContextData objectContextData = (DxfTextObjectContextData) from;
      this.textHorizontalAlignment_0 = objectContextData.textHorizontalAlignment_0;
      this.double_0 = objectContextData.double_0;
      this.point2D_0 = objectContextData.point2D_0;
      this.point2D_1 = objectContextData.point2D_1;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfTextObjectContextData objectContextData = (DxfTextObjectContextData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (objectContextData == null)
      {
        objectContextData = new DxfTextObjectContextData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) objectContextData);
        objectContextData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) objectContextData;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1031_0.dxfClass_13.ClassNumber;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_32((short) this.textHorizontalAlignment_0);
      objectWriter.imethod_16(this.double_0);
      objectWriter.imethod_25(this.point2D_1);
      objectWriter.imethod_25(this.point2D_0);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.textHorizontalAlignment_0 = (TextHorizontalAlignment) objectBitStream.imethod_14();
      this.double_0 = objectBitStream.imethod_8();
      this.point2D_1 = objectBitStream.imethod_38();
      this.point2D_0 = objectBitStream.imethod_38();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_219(70, (short) this.textHorizontalAlignment_0);
      w.Write(50, (object) (this.double_0 * (180.0 / System.Math.PI)));
      w.Write(10, this.point2D_1);
      w.Write(11, this.point2D_0);
    }

    internal bool method_8(Struct18 g)
    {
      switch (g.Code)
      {
        case 10:
          this.point2D_1.X = (double) g.Value;
          break;
        case 11:
          this.point2D_0.X = (double) g.Value;
          break;
        case 20:
          this.point2D_1.Y = (double) g.Value;
          break;
        case 21:
          this.point2D_0.Y = (double) g.Value;
          break;
        case 50:
          this.double_0 = (double) g.Value * (System.Math.PI / 180.0);
          break;
        case 70:
          this.textHorizontalAlignment_0 = (TextHorizontalAlignment) g.Value;
          break;
        default:
          return false;
      }
      return true;
    }

    internal virtual void vmethod_11(DxfReader r, Class259 objectBuilder)
    {
      while (!r.method_92("AcDbTextObjectContextData"))
      {
        this.method_8(r.CurrentGroup);
        r.method_85();
      }
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      this.vmethod_11(r, objectBuilder);
    }
  }
}
