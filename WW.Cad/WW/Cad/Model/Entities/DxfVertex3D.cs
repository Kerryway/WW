// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfVertex3D
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Math;

namespace WW.Cad.Model.Entities
{
  public class DxfVertex3D : DxfVertex
  {
    private WW.Math.Point3D point3D_0;

    public DxfVertex3D()
    {
    }

    public DxfVertex3D(double x, double y, double z)
    {
      if (double.IsNaN(x) || double.IsNaN(y) || double.IsNaN(z))
        throw new DxfException("One of the vertex components is not a number (nan).");
      this.point3D_0 = new WW.Math.Point3D(x, y, z);
    }

    public DxfVertex3D(WW.Math.Point3D position)
    {
      if (double.IsNaN(position.X) || double.IsNaN(position.Y) || double.IsNaN(position.Z))
        throw new DxfException("One of the vertex components is not a number (nan).");
      this.point3D_0 = position;
    }

    public WW.Math.Point3D Position
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

    public double X
    {
      get
      {
        return this.point3D_0.X;
      }
      set
      {
        this.point3D_0.X = value;
      }
    }

    public double Y
    {
      get
      {
        return this.point3D_0.Y;
      }
      set
      {
        this.point3D_0.Y = value;
      }
    }

    public double Z
    {
      get
      {
        return this.point3D_0.Z;
      }
      set
      {
        this.point3D_0.Z = value;
      }
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfVertex3D.Class642 class642 = new DxfVertex3D.Class642();
      // ISSUE: reference to a compiler-generated field
      class642.dxfVertex3D_0 = this;
      // ISSUE: reference to a compiler-generated field
      class642.point3D_0 = this.point3D_0;
      this.point3D_0 = matrix.Transform(this.point3D_0);
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfVertex3D.Class643()
      {
        class642_0 = class642,
        point3D_0 = this.point3D_0
      }.method_0), new System.Action(class642.method_0)));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfVertex3D dxfVertex3D = (DxfVertex3D) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfVertex3D == null)
      {
        dxfVertex3D = new DxfVertex3D();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfVertex3D);
        dxfVertex3D.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfVertex3D;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.point3D_0 = ((DxfVertex3D) from).point3D_0;
    }

    public override string ToString()
    {
      return this.point3D_0.ToString();
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override short vmethod_6(Class432 w)
    {
      DxfPolylineBase objectSoftReference = (DxfPolylineBase) this.OwnerObjectSoftReference;
      if (objectSoftReference == null)
        throw new Exception("Vertex does not have an owner.");
      return objectSoftReference.vmethod_14(w);
    }
  }
}
