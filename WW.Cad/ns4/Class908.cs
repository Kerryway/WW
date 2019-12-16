// Decompiled with JetBrains decompiler
// Type: ns4.Class908
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.Model;
using WW.Math;
using WW.Math.Geometry;

namespace ns4
{
  internal class Class908
  {
    private static readonly IShape2D[] ishape2D_0 = new IShape2D[0];
    private readonly Interface34 interface34_0;
    private Matrix4D matrix4D_0;
    private IShape2D[] ishape2D_1;

    public Class908(Interface34 text, Matrix4D transformation)
    {
      this.interface34_0 = text;
      this.matrix4D_0 = transformation;
    }

    public Interface34 Text
    {
      get
      {
        return this.interface34_0;
      }
    }

    public WW.Math.Point3D Position
    {
      get
      {
        return new WW.Math.Point3D(this.matrix4D_0.M03, this.matrix4D_0.M13, this.matrix4D_0.M23);
      }
    }

    public Matrix4D Transformation
    {
      get
      {
        return this.matrix4D_0;
      }
    }

    public Interface14 Font
    {
      get
      {
        return this.interface34_0.Font;
      }
    }

    public Color Color
    {
      get
      {
        return this.interface34_0.Color;
      }
    }

    public IShape2D[] Linings
    {
      get
      {
        return this.ishape2D_1 ?? Class908.ishape2D_0;
      }
    }

    public void Draw(IPathDrawer drawer, Matrix4D insertionTransformation, double extrusion)
    {
      Matrix4D matrix4D = insertionTransformation * this.Transformation;
      this.interface34_0.Draw(drawer, matrix4D, extrusion);
      if (this.ishape2D_1 == null)
        return;
      foreach (IShape2D path in this.ishape2D_1)
        drawer.DrawPath(path, matrix4D, this.interface34_0.Color, this.interface34_0.LineWeight, false, true, extrusion);
    }

    public void method_0(IPathDrawer drawer, Matrix4D insertionTransformation, double extrusion)
    {
      Matrix4D transformation = insertionTransformation * this.Transformation;
      this.interface34_0.Draw(drawer, transformation, extrusion);
    }

    public void method_1(IPathDrawer drawer, Matrix4D insertionTransformation, double extrusion)
    {
      if (this.ishape2D_1 == null)
        return;
      Matrix4D transform = insertionTransformation * this.Transformation;
      foreach (IShape2D path in this.ishape2D_1)
        drawer.DrawPath(path, transform, this.interface34_0.Color, this.interface34_0.LineWeight, false, true, extrusion);
    }

    public IShape2D FontPath
    {
      get
      {
        return this.interface34_0.TransformedPath;
      }
    }

    public void method_2(WW.Math.Point2D start, WW.Math.Point2D end)
    {
      this.method_4((IShape2D) new Line2D(start, end - start));
    }

    public void method_3(double startX, double startY, double endX, double endY)
    {
      this.method_4((IShape2D) new Line2D(startX, startY, endX - startX, endY - startY));
    }

    public void method_4(IShape2D lining)
    {
      if (this.ishape2D_1 == null)
      {
        this.ishape2D_1 = new IShape2D[1]{ lining };
      }
      else
      {
        IShape2D[] shape2DArray = new IShape2D[this.ishape2D_1.Length + 1];
        Array.Copy((Array) this.ishape2D_1, (Array) shape2DArray, this.ishape2D_1.Length);
        shape2DArray[this.ishape2D_1.Length] = lining;
        this.ishape2D_1 = shape2DArray;
      }
    }

    public void Transform(ITransformer4D transformer)
    {
      WW.Math.Point3D position = this.Position;
      Vector4D vector4D1 = new Vector4D(position.X, position.Y, position.Z, 1.0);
      WW.Math.Point3D point3D1 = transformer.TransformToPoint3D(this.matrix4D_0 * vector4D1);
      Bounds2D bounds = this.interface34_0.Font.Metrics.GetBounds(this.interface34_0.Text, Enum24.flag_0);
      Vector4D vector4D2 = vector4D1 + new Vector4D(bounds.Delta.X, 0.0, 0.0, 0.0);
      WW.Math.Point3D point3D2 = transformer.TransformToPoint3D(this.matrix4D_0 * vector4D2);
      Vector4D vector4D3 = vector4D1 + new Vector4D(0.0, bounds.Delta.Y, 0.0, 0.0);
      WW.Math.Point3D point3D3 = transformer.TransformToPoint3D(this.matrix4D_0 * vector4D3);
      Vector3D vector3D1 = (point3D2 - point3D1) / bounds.Delta.X;
      Vector3D vector3D2 = (point3D3 - point3D1) / bounds.Delta.Y;
      Vector3D zaxis = Vector3D.CrossProduct(vector3D1, vector3D2);
      this.matrix4D_0 = Transformation4D.GetCoordSystem(vector3D1, vector3D2, zaxis, point3D1);
    }

    public override string ToString()
    {
      if (this.interface34_0 != null)
        return this.interface34_0.ToString();
      return "null";
    }
  }
}
