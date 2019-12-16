// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfUcs
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Math;

namespace WW.Cad.Model.Tables
{
  public class DxfUcs : DxfTableRecord
  {
    private WW.Math.Point3D point3D_0 = WW.Math.Point3D.Zero;
    private Vector3D vector3D_0 = Vector3D.XAxis;
    private Vector3D vector3D_1 = Vector3D.YAxis;
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;
    private Vector3D vector3D_2 = Vector3D.Zero;
    private Vector3D vector3D_3 = Vector3D.Zero;
    private Vector3D vector3D_4 = Vector3D.Zero;
    private Vector3D vector3D_5 = Vector3D.Zero;
    private Vector3D vector3D_6 = Vector3D.Zero;
    private Vector3D vector3D_7 = Vector3D.Zero;
    private string string_0;
    private double double_0;
    private StandardFlags standardFlags_0;
    private OrthographicType orthographicType_0;

    public DxfUcs()
    {
    }

    public DxfUcs(string name)
    {
      this.string_0 = name;
    }

    public DxfUcs(string name, WW.Math.Point3D origin, Vector3D xAxis, Vector3D yAxis)
    {
      this.string_0 = name;
      this.point3D_0 = origin;
      this.vector3D_0 = xAxis;
      this.vector3D_1 = yAxis;
    }

    public double Elevation
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
        this.string_0 = value;
      }
    }

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

    public override bool IsExternallyDependent
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsExternallyDependent) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsExternallyDependent;
        else
          this.standardFlags_0 &= ~StandardFlags.IsExternallyDependent;
      }
    }

    public override bool IsResolvedExternalRef
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsResolvedExternalRef) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsResolvedExternalRef;
        else
          this.standardFlags_0 &= ~StandardFlags.IsResolvedExternalRef;
      }
    }

    public override bool IsReferenced
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsReferenced) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsReferenced;
        else
          this.standardFlags_0 &= ~StandardFlags.IsReferenced;
      }
    }

    public OrthographicType OrthographicViewType
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

    public DxfUcs OrthographicReference
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

    public Vector3D OrthographicBackDOrigin
    {
      get
      {
        return this.vector3D_7;
      }
      set
      {
        this.vector3D_7 = value;
      }
    }

    public Vector3D OrthographicBottomDOrigin
    {
      get
      {
        return this.vector3D_3;
      }
      set
      {
        this.vector3D_3 = value;
      }
    }

    public Vector3D OrthographicFrontDOrigin
    {
      get
      {
        return this.vector3D_6;
      }
      set
      {
        this.vector3D_6 = value;
      }
    }

    public Vector3D OrthographicLeftDOrigin
    {
      get
      {
        return this.vector3D_4;
      }
      set
      {
        this.vector3D_4 = value;
      }
    }

    public Vector3D OrthographicRightDOrigin
    {
      get
      {
        return this.vector3D_5;
      }
      set
      {
        this.vector3D_5 = value;
      }
    }

    public Vector3D OrthographicTopDOrigin
    {
      get
      {
        return this.vector3D_2;
      }
      set
      {
        this.vector3D_2 = value;
      }
    }

    public Vector3D XAxis
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

    public Vector3D YAxis
    {
      get
      {
        return this.vector3D_1;
      }
      set
      {
        this.vector3D_1 = value;
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

    public WW.Math.Point3D GetOrigin(OrthographicType orthographic)
    {
      switch (orthographic)
      {
        case OrthographicType.Top:
          return this.point3D_0 + this.vector3D_2;
        case OrthographicType.Bottom:
          return this.point3D_0 + this.vector3D_3;
        case OrthographicType.Front:
          return this.point3D_0 + this.vector3D_6;
        case OrthographicType.Back:
          return this.point3D_0 + this.vector3D_7;
        case OrthographicType.Left:
          return this.point3D_0 + this.vector3D_4;
        case OrthographicType.Right:
          return this.point3D_0 + this.vector3D_5;
        default:
          throw new Exception("Illegal OrthographicType.");
      }
    }

    public Vector3D GetRelativeOrigin(OrthographicType orthographic)
    {
      switch (orthographic)
      {
        case OrthographicType.Top:
          return this.vector3D_2;
        case OrthographicType.Bottom:
          return this.vector3D_3;
        case OrthographicType.Front:
          return this.vector3D_6;
        case OrthographicType.Back:
          return this.vector3D_7;
        case OrthographicType.Left:
          return this.vector3D_4;
        case OrthographicType.Right:
          return this.vector3D_5;
        default:
          throw new Exception("Illegal OrthographicType.");
      }
    }

    public void SetRelativeOrigin(OrthographicType orthographic, Vector3D relativeOrigin)
    {
      switch (orthographic)
      {
        case OrthographicType.Top:
          this.vector3D_2 = relativeOrigin;
          break;
        case OrthographicType.Bottom:
          this.vector3D_3 = relativeOrigin;
          break;
        case OrthographicType.Front:
          this.vector3D_6 = relativeOrigin;
          break;
        case OrthographicType.Back:
          this.vector3D_7 = relativeOrigin;
          break;
        case OrthographicType.Left:
          this.vector3D_4 = relativeOrigin;
          break;
        case OrthographicType.Right:
          this.vector3D_5 = relativeOrigin;
          break;
        default:
          throw new Exception("Illegal OrthographicType.");
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfUcs dxfUcs = (DxfUcs) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfUcs == null)
      {
        dxfUcs = new DxfUcs();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfUcs);
        dxfUcs.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfUcs;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfUcs dxfUcs = (DxfUcs) from;
      this.string_0 = dxfUcs.string_0;
      this.point3D_0 = dxfUcs.point3D_0;
      this.vector3D_0 = dxfUcs.vector3D_0;
      this.vector3D_1 = dxfUcs.vector3D_1;
      this.double_0 = dxfUcs.double_0;
      this.standardFlags_0 = dxfUcs.standardFlags_0;
      this.vector3D_2 = dxfUcs.vector3D_2;
      this.vector3D_3 = dxfUcs.vector3D_3;
      this.vector3D_4 = dxfUcs.vector3D_4;
      this.vector3D_5 = dxfUcs.vector3D_5;
      this.vector3D_6 = dxfUcs.vector3D_6;
      this.vector3D_7 = dxfUcs.vector3D_7;
    }

    internal StandardFlags Flags
    {
      get
      {
        return this.standardFlags_0;
      }
      set
      {
        this.standardFlags_0 = value;
      }
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      this.vmethod_2((IDxfHandledObject) modelContext.UcsTable);
    }

    internal override void vmethod_4(DxfModel modelContext)
    {
      base.vmethod_4(modelContext);
      this.vmethod_2((IDxfHandledObject) null);
    }
  }
}
