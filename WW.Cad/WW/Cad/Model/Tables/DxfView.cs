// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfView
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model.Entities;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Tables
{
  public class DxfView : DxfTableRecord, IComparable
  {
    private string string_0 = string.Empty;
    private WW.Math.Point2D point2D_0 = WW.Math.Point2D.Zero;
    private Size2D size2D_0 = Size2D.Zero;
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private WW.Math.Point3D point3D_0 = WW.Math.Point3D.Zero;
    private double double_0 = 50.0;
    private DxfObjectReference dxfObjectReference_3 = new DxfUcs().Reference;
    private ViewFlags viewFlags_0;
    private double double_1;
    private double double_2;
    private double double_3;
    private ViewMode viewMode_0;
    private RenderMode renderMode_0;
    private bool bool_0;
    private OrthographicType orthographicType_0;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3;

    public DxfView()
    {
    }

    public DxfView(string name)
    {
      this.Name = name;
    }

    public ViewFlags Flags
    {
      get
      {
        return this.viewFlags_0;
      }
      set
      {
        this.viewFlags_0 = value;
      }
    }

    public bool Paperspace
    {
      get
      {
        return (this.viewFlags_0 & ViewFlags.PaperSpace) != ViewFlags.None;
      }
      set
      {
        if (value)
          this.viewFlags_0 |= ViewFlags.PaperSpace;
        else
          this.viewFlags_0 &= ViewFlags.IsExternallyDependent | ViewFlags.IsResolvedExternalRef | ViewFlags.IsReferenced;
      }
    }

    public override bool IsExternallyDependent
    {
      get
      {
        return (this.viewFlags_0 & ViewFlags.IsExternallyDependent) != ViewFlags.None;
      }
      set
      {
        if (value)
          this.viewFlags_0 |= ViewFlags.IsExternallyDependent;
        else
          this.viewFlags_0 &= ~ViewFlags.IsExternallyDependent;
      }
    }

    public override bool IsResolvedExternalRef
    {
      get
      {
        return (this.viewFlags_0 & ViewFlags.IsResolvedExternalRef) != ViewFlags.None;
      }
      set
      {
        if (value)
          this.viewFlags_0 |= ViewFlags.IsResolvedExternalRef;
        else
          this.viewFlags_0 &= ~ViewFlags.IsResolvedExternalRef;
      }
    }

    public override bool IsReferenced
    {
      get
      {
        return (this.viewFlags_0 & ViewFlags.IsReferenced) != ViewFlags.None;
      }
      set
      {
        if (value)
          this.viewFlags_0 |= ViewFlags.IsReferenced;
        else
          this.viewFlags_0 &= ~ViewFlags.IsReferenced;
      }
    }

    public double BackClippingPlane
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
      }
    }

    public bool BackClippingActive
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        if (value)
          this.ViewMode |= ViewMode.ClipBack;
        else
          this.ViewMode &= ~ViewMode.ClipBack;
      }
    }

    public double FrontClippingPlane
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

    public bool FrontClippingActive
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        if (value)
          this.ViewMode |= ViewMode.ClipFront;
        else
          this.ViewMode &= ~ViewMode.ClipFront;
      }
    }

    public WW.Math.Point2D Center
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

    public Vector3D Direction
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

    public double LensLength
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

    public override string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value ?? string.Empty;
      }
    }

    public bool PerspectiveMode
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        if (value)
          this.ViewMode |= ViewMode.PerspectiveMode;
        else
          this.ViewMode &= ~ViewMode.PerspectiveMode;
      }
    }

    public RenderMode RenderMode
    {
      get
      {
        return this.renderMode_0;
      }
      set
      {
        this.renderMode_0 = value;
      }
    }

    public Size2D Size
    {
      get
      {
        return this.size2D_0;
      }
      set
      {
        this.size2D_0 = value;
      }
    }

    public WW.Math.Point3D Target
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

    public double TwistAngle
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
      }
    }

    public DxfUcs Ucs
    {
      get
      {
        return (DxfUcs) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public bool UcsPerView
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

    public OrthographicType UcsOrthographicType
    {
      get
      {
        return this.orthographicType_0;
      }
      set
      {
        this.orthographicType_0 = value;
      }
    }

    public ViewMode ViewMode
    {
      get
      {
        return this.viewMode_0;
      }
      set
      {
        this.viewMode_0 = value;
        this.bool_1 = (this.viewMode_0 & ViewMode.ClipFront) != ViewMode.None;
        this.bool_2 = (this.viewMode_0 & ViewMode.ClipBack) != ViewMode.None;
        this.bool_3 = (this.viewMode_0 & ViewMode.PerspectiveMode) != ViewMode.None;
      }
    }

    public bool FollowUcs
    {
      get
      {
        return (this.viewMode_0 & ViewMode.FollowUCS) != ViewMode.None;
      }
      set
      {
        if (value)
          this.viewMode_0 |= ViewMode.FollowUCS;
        else
          this.viewMode_0 &= ~ViewMode.FollowUCS;
      }
    }

    public bool ClipFrontNotAtEye
    {
      get
      {
        return (this.viewMode_0 & ViewMode.ClipFrontNotAtEye) != ViewMode.None;
      }
      set
      {
        if (value)
          this.viewMode_0 |= ViewMode.ClipFrontNotAtEye;
        else
          this.viewMode_0 &= ~ViewMode.ClipFrontNotAtEye;
      }
    }

    public IViewDescription ViewDescription
    {
      get
      {
        return (IViewDescription) new DxfView.Class469(this);
      }
    }

    public override void Accept(ITableRecordVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      return ValidateUtil.ValidateName((object) this, this.string_0, model, messages);
    }

    public int CompareTo(object other)
    {
      if (other == null)
        return -1;
      return string.CompareOrdinal(this.string_0, ((DxfView) other).string_0);
    }

    public Matrix4D GetTransform()
    {
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(this.vector3D_0);
      toWcsTransform.Transpose();
      Matrix4D matrix4D = Transformation4D.RotateZ(this.double_3) * toWcsTransform;
      return (!this.PerspectiveMode ? Matrix4D.Identity : new Matrix4D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, -1.0 / this.double_0, 0.0, 0.0, -1.0 / this.double_0, 0.0) * Transformation4D.Translation(0.0, 0.0, -this.vector3D_0.GetLength())) * Transformation4D.Translation(-this.point2D_0.X, -this.point2D_0.Y, 0.0) * matrix4D * Transformation4D.Translation(-(Vector3D) this.point3D_0);
    }

    public Matrix4D GetMappingTransform(Rectangle2D targetRectangle, bool invertY)
    {
      return ViewUtil.GetTransform(this.ViewDescription, targetRectangle, invertY);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfView dxfView = (DxfView) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfView == null)
      {
        dxfView = new DxfView();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfView);
        dxfView.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfView;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfView dxfView = (DxfView) from;
      this.string_0 = dxfView.string_0;
      this.viewFlags_0 = dxfView.viewFlags_0;
      this.point2D_0 = dxfView.point2D_0;
      this.size2D_0 = dxfView.size2D_0;
      this.vector3D_0 = dxfView.vector3D_0;
      this.point3D_0 = dxfView.point3D_0;
      this.double_0 = dxfView.double_0;
      this.double_1 = dxfView.double_1;
      this.double_2 = dxfView.double_2;
      this.double_3 = dxfView.double_3;
      this.ViewMode = dxfView.viewMode_0;
      this.renderMode_0 = dxfView.renderMode_0;
      this.bool_0 = dxfView.bool_0;
      this.Ucs = Class906.smethod_2(cloneContext, dxfView.Ucs);
      this.orthographicType_0 = dxfView.orthographicType_0;
    }

    public override string ToString()
    {
      return this.string_0;
    }

    internal void method_8(string newName)
    {
      this.string_0 = newName;
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      this.vmethod_2((IDxfHandledObject) modelContext.ViewTable);
    }

    internal override void vmethod_4(DxfModel modelContext)
    {
      base.vmethod_4(modelContext);
      this.vmethod_2((IDxfHandledObject) null);
    }

    private class Class469 : IViewDescription
    {
      private static readonly WW.Math.Point3D point3D_0 = new WW.Math.Point3D(0.5, 0.5, 0.0);
      private readonly DxfView dxfView_0;

      internal Class469(DxfView view)
      {
        this.dxfView_0 = view;
      }

      public ViewportStatusFlags ViewModeFlags
      {
        get
        {
          return (ViewportStatusFlags) this.dxfView_0.ViewMode;
        }
      }

      public WW.Math.Point3D ViewportCenter
      {
        get
        {
          return DxfView.Class469.point3D_0;
        }
      }

      public double ViewportWidth
      {
        get
        {
          return 1.0;
        }
      }

      public double ViewportHeight
      {
        get
        {
          return 1.0;
        }
      }

      public WW.Math.Point2D ViewCenter
      {
        get
        {
          return this.dxfView_0.Center;
        }
      }

      public Vector3D ViewDirection
      {
        get
        {
          return this.dxfView_0.Direction;
        }
      }

      public WW.Math.Point3D ViewTarget
      {
        get
        {
          return this.dxfView_0.Target;
        }
      }

      public double FocalLength
      {
        get
        {
          return this.dxfView_0.LensLength;
        }
      }

      public double FrontClipDistance
      {
        get
        {
          return this.dxfView_0.FrontClippingPlane;
        }
      }

      public double BackClipDistance
      {
        get
        {
          return this.dxfView_0.BackClippingPlane;
        }
      }

      public double ViewWidth
      {
        get
        {
          return this.dxfView_0.Size.X;
        }
      }

      public double ViewHeight
      {
        get
        {
          return this.dxfView_0.Size.Y;
        }
      }

      public double ViewTwistAngle
      {
        get
        {
          return this.dxfView_0.TwistAngle;
        }
      }

      public DxfEntity ClippingBoundaryEntity
      {
        get
        {
          return (DxfEntity) null;
        }
      }

      public RenderMode RenderMode
      {
        get
        {
          return this.dxfView_0.RenderMode;
        }
      }

      public bool IsTargetPaper
      {
        get
        {
          return false;
        }
      }

      public IList<DxfLayer> FrozenLayers
      {
        get
        {
          return (IList<DxfLayer>) null;
        }
      }
    }
  }
}
