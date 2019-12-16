// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfDimensionObjectContextData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns3;
using System;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Objects.Annotations
{
  public abstract class DxfDimensionObjectContextData : DxfAnnotationScaleObjectContextData
  {
    private DxfObjectReference dxfObjectReference_4 = DxfObjectReference.Null;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3;
    private bool bool_4;
    private bool bool_5;
    private bool bool_6;
    private bool bool_7;
    private bool bool_8;
    private WW.Math.Point2D point2D_0;
    private double double_0;
    private short short_1;
    private short short_2;
    private DxfDimensionObjectContextData.Enum33 enum33_0;

    public DxfBlock Block
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_4.Value;
      }
      set
      {
        this.dxfObjectReference_4 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public bool DefaultTextLocation
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public bool SuppressOutsideExtensions
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.bool_3 = value;
      }
    }

    public bool OverrideSuppressOutsideExtensions
    {
      get
      {
        return (this.enum33_0 & DxfDimensionObjectContextData.Enum33.flag_1) == (DxfDimensionObjectContextData.Enum33) 0;
      }
      set
      {
        if (value)
          this.enum33_0 &= ~DxfDimensionObjectContextData.Enum33.flag_1;
        else
          this.enum33_0 |= DxfDimensionObjectContextData.Enum33.flag_1;
      }
    }

    public bool TextOutsideExtensions
    {
      get
      {
        return this.bool_4;
      }
      set
      {
        this.bool_4 = value;
      }
    }

    public bool OverrideTextOutsideExtensions
    {
      get
      {
        return (this.enum33_0 & DxfDimensionObjectContextData.Enum33.flag_0) == (DxfDimensionObjectContextData.Enum33) 0;
      }
      set
      {
        if (value)
          this.enum33_0 &= ~DxfDimensionObjectContextData.Enum33.flag_0;
        else
          this.enum33_0 |= DxfDimensionObjectContextData.Enum33.flag_0;
      }
    }

    public bool TextInsideExtensions
    {
      get
      {
        return this.bool_5;
      }
      set
      {
        this.bool_5 = value;
      }
    }

    public bool OverrideTextInsideExtensions
    {
      get
      {
        return (this.enum33_0 & DxfDimensionObjectContextData.Enum33.flag_3) != (DxfDimensionObjectContextData.Enum33) 0;
      }
      set
      {
        if (value)
          this.enum33_0 |= DxfDimensionObjectContextData.Enum33.flag_3;
        else
          this.enum33_0 &= ~DxfDimensionObjectContextData.Enum33.flag_3;
      }
    }

    public bool FlipFirstArrow
    {
      get
      {
        return this.bool_8;
      }
      set
      {
        this.bool_8 = value;
      }
    }

    public bool FlipSecondArrow
    {
      get
      {
        return this.bool_7;
      }
      set
      {
        this.bool_7 = value;
      }
    }

    public WW.Math.Point2D TextLocation
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

    public double TextRotation
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

    public ArrowsTextFitType ArrowsTextFit
    {
      get
      {
        return (ArrowsTextFitType) this.short_1;
      }
      set
      {
        this.short_1 = (short) value;
      }
    }

    public bool OverrideArrowsTextFit
    {
      get
      {
        return (this.enum33_0 & DxfDimensionObjectContextData.Enum33.flag_2) != (DxfDimensionObjectContextData.Enum33) 0;
      }
      set
      {
        if (value)
          this.enum33_0 |= DxfDimensionObjectContextData.Enum33.flag_2;
        else
          this.enum33_0 &= ~DxfDimensionObjectContextData.Enum33.flag_2;
      }
    }

    public TextMovement TextMovement
    {
      get
      {
        return (TextMovement) this.short_2;
      }
      set
      {
        this.short_2 = (short) value;
      }
    }

    public bool OverrideTextMovement
    {
      get
      {
        return (this.enum33_0 & DxfDimensionObjectContextData.Enum33.flag_4) != (DxfDimensionObjectContextData.Enum33) 0;
      }
      set
      {
        if (value)
          this.enum33_0 |= DxfDimensionObjectContextData.Enum33.flag_4;
        else
          this.enum33_0 &= ~DxfDimensionObjectContextData.Enum33.flag_4;
      }
    }

    protected DxfDimensionObjectContextData()
    {
    }

    protected DxfDimensionObjectContextData(DxfDimension dimension, DxfScale scale)
      : base(scale)
    {
      this.Block = dimension.Block;
      this.double_0 = dimension.TextRotation;
      this.bool_2 = !dimension.UseTextMiddlePoint;
      this.enum33_0 = (DxfDimensionObjectContextData.Enum33) 0;
      if (dimension.DimensionStyleOverrides.OverrideSuppressOutsideExtensions)
      {
        this.bool_3 = dimension.DimensionStyleOverrides.SuppressOutsideExtensions;
      }
      else
      {
        this.enum33_0 |= DxfDimensionObjectContextData.Enum33.flag_1;
        this.bool_3 = false;
      }
      if (dimension.DimensionStyleOverrides.OverrideTextOutsideExtensions)
      {
        this.bool_4 = dimension.DimensionStyleOverrides.TextOutsideExtensions;
      }
      else
      {
        this.enum33_0 |= DxfDimensionObjectContextData.Enum33.flag_0;
        this.bool_4 = false;
      }
      if (dimension.DimensionStyleOverrides.OverrideArrowsTextFit)
      {
        this.short_1 = (short) dimension.DimensionStyleOverrides.ArrowsTextFit;
        this.enum33_0 |= DxfDimensionObjectContextData.Enum33.flag_2;
      }
      else
        this.short_1 = (short) 0;
      if (dimension.DimensionStyleOverrides.OverrideTextInsideExtensions)
      {
        this.bool_5 = dimension.DimensionStyleOverrides.TextInsideExtensions;
        this.enum33_0 |= DxfDimensionObjectContextData.Enum33.flag_3;
      }
      else
        this.bool_5 = false;
      if (dimension.DimensionStyleOverrides.OverrideTextMovement)
      {
        this.short_2 = (short) dimension.DimensionStyleOverrides.TextMovement;
        this.enum33_0 |= DxfDimensionObjectContextData.Enum33.flag_4;
      }
      else
        this.short_2 = (short) 0;
      this.bool_6 = false;
      this.bool_7 = false;
      this.bool_8 = false;
    }

    public override string AcClass
    {
      get
      {
        return "AcDbDimensionObjectContextData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACDB_DIMENSIONOBJECTCONTEXTDATA_CLASS";
      }
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfDimensionObjectContextData objectContextData = (DxfDimensionObjectContextData) from;
      this.Block = objectContextData.Block == null ? (DxfBlock) null : (DxfBlock) objectContextData.Block.Clone(cloneContext);
      this.bool_1 = objectContextData.bool_1;
      this.bool_2 = objectContextData.bool_2;
      this.bool_3 = objectContextData.bool_3;
      this.bool_4 = objectContextData.bool_4;
      this.bool_5 = objectContextData.bool_5;
      this.bool_6 = objectContextData.bool_6;
      this.bool_7 = objectContextData.bool_7;
      this.bool_8 = objectContextData.bool_8;
      this.point2D_0 = objectContextData.point2D_0;
      this.double_0 = objectContextData.double_0;
      this.short_1 = objectContextData.short_1;
      this.short_2 = objectContextData.short_2;
      this.enum33_0 = objectContextData.enum33_0;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf18OrHigher;
    }

    internal override void Write(Class432 dow)
    {
      base.Write(dow);
      Interface29 objectWriter = dow.ObjectWriter;
      objectWriter.imethod_25(this.point2D_0);
      objectWriter.imethod_14(this.bool_2);
      objectWriter.imethod_16(this.double_0);
      objectWriter.imethod_41((DxfHandledObject) this.Block);
      objectWriter.imethod_14(this.bool_1);
      objectWriter.imethod_14(this.bool_4);
      objectWriter.imethod_14(this.bool_3);
      objectWriter.imethod_14(this.short_1 != (short) 0);
      objectWriter.imethod_14(this.bool_5);
      objectWriter.imethod_14(this.short_2 != (short) 0);
      objectWriter.imethod_11((byte) this.enum33_0);
      objectWriter.imethod_14(this.bool_6);
      objectWriter.imethod_14(this.bool_7);
      objectWriter.imethod_14(this.bool_8);
    }

    internal override Class259 vmethod_9(FileFormat fileFormat)
    {
      return (Class259) new DxfDimensionObjectContextData.Class313((DxfHandledObject) this);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.point2D_0 = objectBitStream.imethod_38();
      this.bool_2 = objectBitStream.imethod_6();
      this.double_0 = objectBitStream.imethod_8();
      ((DxfDimensionObjectContextData.Class313) ob).BlockHandle = or.method_100();
      this.bool_1 = objectBitStream.imethod_6();
      this.bool_4 = objectBitStream.imethod_6();
      this.bool_3 = objectBitStream.imethod_6();
      this.short_1 = objectBitStream.imethod_6() ? (short) 1 : (short) 0;
      this.bool_5 = objectBitStream.imethod_6();
      this.short_2 = objectBitStream.imethod_6() ? (short) 1 : (short) 0;
      this.enum33_0 = (DxfDimensionObjectContextData.Enum33) objectBitStream.imethod_18();
      this.bool_6 = objectBitStream.imethod_6();
      this.bool_7 = objectBitStream.imethod_6();
      if (this.bool_6)
        this.bool_7 = !this.bool_7;
      this.bool_8 = objectBitStream.imethod_6();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbDimensionObjectContextData");
      if (this.Block != null)
        w.Write(2, (object) this.Block.Name);
      w.Write(293, (object) this.bool_1);
      w.Write(10, this.point2D_0);
      w.Write(294, (object) this.bool_2);
      w.Write(140, (object) this.double_0);
      w.Write(298, (object) this.bool_4);
      w.Write(291, (object) this.bool_3);
      w.Write(70, (object) this.short_1);
      w.Write(292, (object) this.bool_5);
      w.Write(71, (object) this.short_2);
      w.Write(280, (object) (byte) this.enum33_0);
      w.Write(295, (object) this.bool_6);
      w.Write(296, (object) (bool) (this.bool_6 ? (this.bool_7 ? 1 : 0) : (!this.bool_7 ? 1 : 0)));
      w.Write(297, (object) this.bool_8);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      if (r.CurrentGroup.Code != 100 || (string) r.CurrentGroup.Value != "AcDbDimensionObjectContextData")
        throw new DxfException("Expected subclass marker.");
      r.method_85();
      while (!r.method_92("AcDbDimensionObjectContextData"))
      {
        switch (r.CurrentGroup.Code)
        {
          case 2:
            ((DxfDimensionObjectContextData.Class313) objectBuilder).BlockName = (string) r.CurrentGroup.Value;
            break;
          case 10:
            this.point2D_0.X = (double) r.CurrentGroup.Value;
            break;
          case 20:
            this.point2D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 70:
            this.short_1 = (short) r.CurrentGroup.Value;
            break;
          case 71:
            this.short_2 = (short) r.CurrentGroup.Value;
            break;
          case 140:
            this.double_0 = (double) r.CurrentGroup.Value;
            break;
          case 280:
            this.enum33_0 = (DxfDimensionObjectContextData.Enum33) r.CurrentGroup.Value;
            break;
          case 291:
            this.bool_3 = (bool) r.CurrentGroup.Value;
            break;
          case 292:
            this.bool_5 = (bool) r.CurrentGroup.Value;
            break;
          case 293:
            this.bool_1 = (bool) r.CurrentGroup.Value;
            break;
          case 294:
            this.bool_2 = (bool) r.CurrentGroup.Value;
            break;
          case 295:
            this.bool_6 = (bool) r.CurrentGroup.Value;
            break;
          case 296:
            this.bool_7 = (bool) r.CurrentGroup.Value;
            break;
          case 297:
            this.bool_8 = (bool) r.CurrentGroup.Value;
            break;
          case 298:
            this.bool_4 = (bool) r.CurrentGroup.Value;
            break;
          default:
            throw new DxfException("Unexpected group code.");
        }
        r.method_85();
      }
      if (!this.bool_6)
        return;
      this.bool_7 = !this.bool_7;
    }

    [Flags]
    private enum Enum33 : byte
    {
      flag_0 = 1,
      flag_1 = 2,
      flag_2 = 4,
      flag_3 = 8,
      flag_4 = 16, // 0x10
    }

    internal class Class313 : DxfAnnotationScaleObjectContextData.Class310
    {
      public Class313(DxfHandledObject handledObject)
        : base(handledObject)
      {
      }

      public ulong BlockHandle { private get; set; }

      public string BlockName { private get; set; }

      public override void ResolveReferences(Class374 modelBuilder)
      {
        base.ResolveReferences(modelBuilder);
        if (this.BlockName != null)
        {
          ((DxfDimensionObjectContextData) this.HandledObject).Block = modelBuilder.Model.GetBlockWithName(this.BlockName);
        }
        else
        {
          if (this.BlockHandle == 0UL)
            return;
          ((DxfDimensionObjectContextData) this.HandledObject).Block = modelBuilder.method_4<DxfBlock>(this.BlockHandle);
        }
      }
    }

    public class Aligned : DxfDimensionObjectContextData
    {
      private WW.Math.Point3D point3D_0;

      public WW.Math.Point3D DimensionLineLocation
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public Aligned()
      {
      }

      public Aligned(DxfDimension.Aligned dimension, DxfScale scale)
        : base((DxfDimension) dimension, scale)
      {
        this.point3D_0 = dimension.DimensionLineLocation;
      }

      public override void Accept(IObjectVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override string AcClass
      {
        get
        {
          return "AcDbAlignedDimensionObjectContextData";
        }
      }

      public override string ObjectType
      {
        get
        {
          return "ACDB_ALDIMOBJECTCONTEXTDATA_CLASS";
        }
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        this.point3D_0 = ((DxfDimensionObjectContextData.Aligned) from).DimensionLineLocation;
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimensionObjectContextData.Aligned aligned = (DxfDimensionObjectContextData.Aligned) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (aligned == null)
        {
          aligned = new DxfDimensionObjectContextData.Aligned();
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) aligned);
          aligned.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) aligned;
      }

      internal override short vmethod_6(Class432 w)
      {
        return w.KnownClasses.class1031_0.dxfClass_6.ClassNumber;
      }

      internal override void Write(Class432 ow)
      {
        base.Write(ow);
        ow.ObjectWriter.imethod_24(this.point3D_0);
      }

      internal override void Read(Class434 or, Class259 ob)
      {
        base.Read(or, ob);
        this.point3D_0 = or.ObjectBitStream.imethod_39();
      }

      internal override void Write(DxfWriter w)
      {
        base.Write(w);
        w.method_234("AcDbAlignedDimensionObjectContextData");
        w.Write(11, this.point3D_0);
      }

      internal override void Read(DxfReader r, Class259 objectBuilder)
      {
        base.Read(r, objectBuilder);
        while (!r.method_92("AcDbAlignedDimensionObjectContextData"))
        {
          switch (r.CurrentGroup.Code)
          {
            case 11:
              this.point3D_0.X = (double) r.CurrentGroup.Value;
              break;
            case 21:
              this.point3D_0.Y = (double) r.CurrentGroup.Value;
              break;
            case 31:
              this.point3D_0.Z = (double) r.CurrentGroup.Value;
              break;
          }
          r.method_85();
        }
      }
    }

    public class Angular : DxfDimensionObjectContextData
    {
      private WW.Math.Point3D point3D_0;

      public WW.Math.Point3D DimensionLineArcPoint
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public Angular()
      {
      }

      public Angular(DxfDimension.Angular3Point dimension, DxfScale scale)
        : base((DxfDimension) dimension, scale)
      {
        this.point3D_0 = dimension.DimensionLineArcPoint;
      }

      public Angular(DxfDimension.Angular4Point dimension, DxfScale scale)
        : base((DxfDimension) dimension, scale)
      {
        this.point3D_0 = dimension.DimensionLineArcPoint;
      }

      public override void Accept(IObjectVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override string AcClass
      {
        get
        {
          return "AcDbAngularDimensionObjectContextData";
        }
      }

      public override string ObjectType
      {
        get
        {
          return "ACDB_ANGDIMOBJECTCONTEXTDATA_CLASS";
        }
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        this.point3D_0 = ((DxfDimensionObjectContextData.Angular) from).DimensionLineArcPoint;
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimensionObjectContextData.Angular angular = (DxfDimensionObjectContextData.Angular) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (angular == null)
        {
          angular = new DxfDimensionObjectContextData.Angular();
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) angular);
          angular.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) angular;
      }

      internal override short vmethod_6(Class432 w)
      {
        return w.KnownClasses.class1031_0.dxfClass_7.ClassNumber;
      }

      internal override void Write(Class432 ow)
      {
        base.Write(ow);
        ow.ObjectWriter.imethod_24(this.point3D_0);
      }

      internal override void Read(Class434 or, Class259 ob)
      {
        base.Read(or, ob);
        this.point3D_0 = or.ObjectBitStream.imethod_39();
      }

      internal override void Write(DxfWriter w)
      {
        base.Write(w);
        w.method_234("AcDbAngularDimensionObjectContextData");
        w.Write(11, this.point3D_0);
      }

      internal override void Read(DxfReader r, Class259 objectBuilder)
      {
        base.Read(r, objectBuilder);
        while (!r.method_92("AcDbAngularDimensionObjectContextData"))
        {
          switch (r.CurrentGroup.Code)
          {
            case 11:
              this.point3D_0.X = (double) r.CurrentGroup.Value;
              break;
            case 21:
              this.point3D_0.Y = (double) r.CurrentGroup.Value;
              break;
            case 31:
              this.point3D_0.Z = (double) r.CurrentGroup.Value;
              break;
          }
          r.method_85();
        }
      }
    }

    public class Diametric : DxfDimensionObjectContextData
    {
      private WW.Math.Point3D point3D_0;
      private WW.Math.Point3D point3D_1;

      public WW.Math.Point3D ArcLineIntersectionPoint1
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public WW.Math.Point3D ArcLineIntersectionPoint2
      {
        get
        {
          return this.point3D_1;
        }
        set
        {
          this.point3D_1 = value;
        }
      }

      public Diametric()
      {
      }

      public Diametric(DxfDimension.Diametric dimension, DxfScale scale)
        : base((DxfDimension) dimension, scale)
      {
        this.point3D_0 = dimension.ArcLineIntersectionPoint1;
        this.point3D_1 = dimension.ArcLineIntersectionPoint2;
      }

      public override void Accept(IObjectVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override string AcClass
      {
        get
        {
          return "AcDbDiametricDimensionObjectContextData";
        }
      }

      public override string ObjectType
      {
        get
        {
          return "ACDB_DMDIMOBJECTCONTEXTDATA_CLASS";
        }
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        DxfDimensionObjectContextData.Diametric diametric = (DxfDimensionObjectContextData.Diametric) from;
        this.point3D_0 = diametric.point3D_0;
        this.point3D_1 = diametric.point3D_1;
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimensionObjectContextData.Diametric diametric = (DxfDimensionObjectContextData.Diametric) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (diametric == null)
        {
          diametric = new DxfDimensionObjectContextData.Diametric();
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) diametric);
          diametric.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) diametric;
      }

      internal override short vmethod_6(Class432 w)
      {
        return w.KnownClasses.class1031_0.dxfClass_8.ClassNumber;
      }

      internal override void Write(Class432 ow)
      {
        base.Write(ow);
        ow.ObjectWriter.imethod_24(this.point3D_0);
        ow.ObjectWriter.imethod_24(this.point3D_1);
      }

      internal override void Read(Class434 or, Class259 ob)
      {
        base.Read(or, ob);
        this.point3D_0 = or.ObjectBitStream.imethod_39();
        this.point3D_1 = or.ObjectBitStream.imethod_39();
      }

      internal override void Write(DxfWriter w)
      {
        base.Write(w);
        w.method_234("AcDbDiametricDimensionObjectContextData");
        w.Write(11, this.point3D_0);
        w.Write(12, this.point3D_1);
      }

      internal override void Read(DxfReader r, Class259 objectBuilder)
      {
        base.Read(r, objectBuilder);
        while (!r.method_92("AcDbDiametricDimensionObjectContextData"))
        {
          switch (r.CurrentGroup.Code)
          {
            case 11:
              this.point3D_0.X = (double) r.CurrentGroup.Value;
              break;
            case 12:
              this.point3D_1.X = (double) r.CurrentGroup.Value;
              break;
            case 21:
              this.point3D_0.Y = (double) r.CurrentGroup.Value;
              break;
            case 22:
              this.point3D_1.Y = (double) r.CurrentGroup.Value;
              break;
            case 31:
              this.point3D_0.Z = (double) r.CurrentGroup.Value;
              break;
            case 32:
              this.point3D_1.Z = (double) r.CurrentGroup.Value;
              break;
          }
          r.method_85();
        }
      }
    }

    public class Ordinate : DxfDimensionObjectContextData
    {
      private WW.Math.Point3D point3D_0;
      private WW.Math.Point3D point3D_1;

      public WW.Math.Point3D Origin
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public WW.Math.Point3D LeaderEndPoint
      {
        get
        {
          return this.point3D_1;
        }
        set
        {
          this.point3D_1 = value;
        }
      }

      public Ordinate()
      {
      }

      public Ordinate(DxfDimension.Ordinate dimension, DxfScale scale)
        : base((DxfDimension) dimension, scale)
      {
        this.point3D_0 = dimension.UcsOrigin;
        this.point3D_1 = dimension.LeaderEndPoint;
      }

      public override void Accept(IObjectVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override string AcClass
      {
        get
        {
          return "AcDbOrdinateDimensionObjectContextData";
        }
      }

      public override string ObjectType
      {
        get
        {
          return "ACDB_ORDDIMOBJECTCONTEXTDATA_CLASS";
        }
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        DxfDimensionObjectContextData.Ordinate ordinate = (DxfDimensionObjectContextData.Ordinate) from;
        this.point3D_0 = ordinate.point3D_0;
        this.point3D_1 = ordinate.point3D_1;
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimensionObjectContextData.Ordinate ordinate = (DxfDimensionObjectContextData.Ordinate) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (ordinate == null)
        {
          ordinate = new DxfDimensionObjectContextData.Ordinate();
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) ordinate);
          ordinate.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) ordinate;
      }

      internal override short vmethod_6(Class432 w)
      {
        return w.KnownClasses.class1031_0.dxfClass_9.ClassNumber;
      }

      internal override void Write(Class432 ow)
      {
        base.Write(ow);
        ow.ObjectWriter.imethod_24(this.point3D_0);
        ow.ObjectWriter.imethod_24(this.point3D_1);
      }

      internal override void Read(Class434 or, Class259 ob)
      {
        base.Read(or, ob);
        this.point3D_0 = or.ObjectBitStream.imethod_39();
        this.point3D_1 = or.ObjectBitStream.imethod_39();
      }

      internal override void Write(DxfWriter w)
      {
        base.Write(w);
        w.method_234("AcDbOrdinateDimensionObjectContextData");
        w.Write(11, this.point3D_0);
        w.Write(12, this.point3D_1);
      }

      internal override void Read(DxfReader r, Class259 objectBuilder)
      {
        base.Read(r, objectBuilder);
        while (!r.method_92("AcDbOrdinateDimensionObjectContextData"))
        {
          switch (r.CurrentGroup.Code)
          {
            case 11:
              this.point3D_0.X = (double) r.CurrentGroup.Value;
              break;
            case 12:
              this.point3D_1.X = (double) r.CurrentGroup.Value;
              break;
            case 21:
              this.point3D_0.Y = (double) r.CurrentGroup.Value;
              break;
            case 22:
              this.point3D_1.Y = (double) r.CurrentGroup.Value;
              break;
            case 31:
              this.point3D_0.Z = (double) r.CurrentGroup.Value;
              break;
            case 32:
              this.point3D_1.Z = (double) r.CurrentGroup.Value;
              break;
          }
          r.method_85();
        }
      }
    }

    public class Radial : DxfDimensionObjectContextData
    {
      private WW.Math.Point3D point3D_0;

      public WW.Math.Point3D ArcLineIntersectionPoint
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public Radial()
      {
      }

      public Radial(DxfDimension.Radial dimension, DxfScale scale)
        : base((DxfDimension) dimension, scale)
      {
        this.point3D_0 = dimension.ArcLineIntersectionPoint;
      }

      public override void Accept(IObjectVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override string AcClass
      {
        get
        {
          return "AcDbRadialDimensionObjectContextData";
        }
      }

      public override string ObjectType
      {
        get
        {
          return "ACDB_RADIMOBJECTCONTEXTDATA_CLASS";
        }
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        this.point3D_0 = ((DxfDimensionObjectContextData.Radial) from).ArcLineIntersectionPoint;
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimensionObjectContextData.Radial radial = (DxfDimensionObjectContextData.Radial) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (radial == null)
        {
          radial = new DxfDimensionObjectContextData.Radial();
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) radial);
          radial.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) radial;
      }

      internal override short vmethod_6(Class432 w)
      {
        return w.KnownClasses.class1031_0.dxfClass_10.ClassNumber;
      }

      internal override void Write(Class432 ow)
      {
        base.Write(ow);
        ow.ObjectWriter.imethod_24(this.point3D_0);
      }

      internal override void Read(Class434 or, Class259 ob)
      {
        base.Read(or, ob);
        this.point3D_0 = or.ObjectBitStream.imethod_39();
      }

      internal override void Write(DxfWriter w)
      {
        base.Write(w);
        w.method_234("AcDbRadialDimensionObjectContextData");
        w.Write(11, this.point3D_0);
      }

      internal override void Read(DxfReader r, Class259 objectBuilder)
      {
        base.Read(r, objectBuilder);
        while (!r.method_92("AcDbRadialDimensionObjectContextData"))
        {
          switch (r.CurrentGroup.Code)
          {
            case 11:
              this.point3D_0.X = (double) r.CurrentGroup.Value;
              break;
            case 21:
              this.point3D_0.Y = (double) r.CurrentGroup.Value;
              break;
            case 31:
              this.point3D_0.Z = (double) r.CurrentGroup.Value;
              break;
          }
          r.method_85();
        }
      }
    }
  }
}
