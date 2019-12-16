// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfSpatialFilter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;
using System.Collections.Generic;
using WW.Cad.Model.Entities;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Objects
{
  public class DxfSpatialFilter : DxfFilter
  {
    private List<WW.Math.Point2D> list_0 = new List<WW.Math.Point2D>(2);
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.ZAxis;
    private WW.Math.Point3D point3D_0 = WW.Math.Point3D.Zero;
    private bool bool_0 = true;
    private Matrix4D matrix4D_0 = Matrix4D.Identity;
    private Matrix4D matrix4D_1 = Matrix4D.Identity;
    public const string DictKeySpatialFilter = "SPATIAL";
    private double? nullable_0;
    private double? nullable_1;

    public IList<WW.Math.Point2D> ClipBoundaryPoints
    {
      get
      {
        return (IList<WW.Math.Point2D>) this.list_0;
      }
      set
      {
        this.list_0.Clear();
        this.list_0.AddRange((IEnumerable<WW.Math.Point2D>) value);
      }
    }

    public WW.Math.Vector3D ClipBoundaryPlaneNormal
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public WW.Math.Point3D ClipBoundaryPlaneOrigin
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

    public bool ClipBoundaryDisplayEnabled
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

    public double? FrontClippingPlaneDistance
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

    public double? BackClippingPlaneDistance
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

    public Matrix4D InverseInsertionTransform
    {
      get
      {
        return this.matrix4D_0;
      }
      set
      {
        this.matrix4D_0 = value;
        ref Matrix4D local1 = ref this.matrix4D_0;
        ref Matrix4D local2 = ref this.matrix4D_0;
        ref Matrix4D local3 = ref this.matrix4D_0;
        double num1 = 0.0;
        local3.M32 = 0.0;
        double num2 = num1;
        double num3 = 0.0;
        local2.M31 = num2;
        double num4 = num3;
        local1.M30 = num4;
        this.matrix4D_0.M33 = 1.0;
      }
    }

    public Matrix4D ClipBoundaryTransform
    {
      get
      {
        return this.matrix4D_1;
      }
      set
      {
        this.matrix4D_1 = value;
        ref Matrix4D local1 = ref this.matrix4D_1;
        ref Matrix4D local2 = ref this.matrix4D_1;
        ref Matrix4D local3 = ref this.matrix4D_1;
        double num1 = 0.0;
        local3.M32 = 0.0;
        double num2 = num1;
        double num3 = 0.0;
        local2.M31 = num2;
        double num4 = num3;
        local1.M30 = num4;
        this.matrix4D_1.M33 = 1.0;
      }
    }

    public Polygon2D GetClipBoundaryPolygon()
    {
      if (this.list_0.Count != 2)
        return new Polygon2D((IEnumerable<WW.Math.Point2D>) this.list_0);
      Polygon2D polygon2D = new Polygon2D(4);
      WW.Math.Point2D point2D1 = this.list_0[0];
      WW.Math.Point2D point2D2 = this.list_0[1];
      polygon2D.Add(point2D1);
      polygon2D.Add(new WW.Math.Point2D(point2D2.X, point2D1.Y));
      polygon2D.Add(point2D2);
      polygon2D.Add(new WW.Math.Point2D(point2D1.X, point2D2.Y));
      return polygon2D;
    }

    public void UpdateTransforms(DxfInsert insert)
    {
      if (insert != null)
      {
        bool couldInvert;
        this.matrix4D_0 = insert.BasicBlockInsertionTransformation.GetInverse(out couldInvert);
        if (!couldInvert)
          throw new ArgumentException("insert defines uninvertable transformation!");
      }
      Matrix4D arbitraryCoordSystem = Transformation4D.GetArbitraryCoordSystem(this.vector3D_0);
      arbitraryCoordSystem.M03 = this.point3D_0.X;
      arbitraryCoordSystem.M13 = this.point3D_0.Y;
      arbitraryCoordSystem.M13 = this.point3D_0.Z;
      this.matrix4D_1 = arbitraryCoordSystem;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_20.ClassNumber;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf14OrHigher;
    }

    public override string ObjectType
    {
      get
      {
        return "SPATIAL_FILTER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbSpatialFilter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfSpatialFilter dxfSpatialFilter = (DxfSpatialFilter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfSpatialFilter == null)
      {
        dxfSpatialFilter = new DxfSpatialFilter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfSpatialFilter);
        dxfSpatialFilter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfSpatialFilter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfSpatialFilter dxfSpatialFilter = (DxfSpatialFilter) from;
      this.list_0 = new List<WW.Math.Point2D>((IEnumerable<WW.Math.Point2D>) dxfSpatialFilter.list_0);
      this.vector3D_0 = dxfSpatialFilter.vector3D_0;
      this.point3D_0 = dxfSpatialFilter.point3D_0;
      this.bool_0 = dxfSpatialFilter.bool_0;
      this.nullable_0 = dxfSpatialFilter.nullable_0;
      this.nullable_1 = dxfSpatialFilter.nullable_1;
      this.matrix4D_0 = dxfSpatialFilter.matrix4D_0;
      this.matrix4D_1 = dxfSpatialFilter.matrix4D_1;
    }
  }
}
