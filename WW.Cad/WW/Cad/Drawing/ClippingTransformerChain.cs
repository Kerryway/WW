// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.ClippingTransformerChain
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class ClippingTransformerChain : ICloneable, IClippingTransformer
  {
    private readonly LinkedList<IClippingTransformer> linkedList_0 = new LinkedList<IClippingTransformer>();
    private IClippingTransformer iclippingTransformer_0;
    private Matrix4D matrix4D_0;
    private Matrix3D matrix3D_0;
    private ILineTypeScaler ilineTypeScaler_0;

    public void Push(IClippingTransformer transformer)
    {
      this.linkedList_0.AddFirst(transformer);
      this.iclippingTransformer_0 = this.linkedList_0.Count == 1 ? this.linkedList_0.First.Value : (IClippingTransformer) null;
      this.method_0();
    }

    public void Pop()
    {
      this.linkedList_0.RemoveFirst();
      this.iclippingTransformer_0 = this.linkedList_0.Count == 1 ? this.linkedList_0.First.Value : (IClippingTransformer) null;
      this.method_0();
    }

    public object Clone()
    {
      ClippingTransformerChain transformerChain = new ClippingTransformerChain();
      foreach (IClippingTransformer clippingTransformer in this.linkedList_0)
        transformerChain.linkedList_0.AddLast((IClippingTransformer) clippingTransformer.Clone());
      transformerChain.iclippingTransformer_0 = transformerChain.linkedList_0.Count == 1 ? transformerChain.linkedList_0.First.Value : (IClippingTransformer) null;
      transformerChain.matrix4D_0 = this.matrix4D_0;
      transformerChain.matrix3D_0 = this.matrix3D_0;
      transformerChain.ilineTypeScaler_0 = this.ilineTypeScaler_0;
      return (object) transformerChain;
    }

    public Matrix4D Matrix
    {
      get
      {
        return this.matrix4D_0;
      }
    }

    public Matrix3D Matrix3D
    {
      get
      {
        return this.matrix3D_0;
      }
    }

    public ILineTypeScaler LineTypeScaler
    {
      get
      {
        return this.ilineTypeScaler_0;
      }
    }

    public Vector4D? Transform(Point3D v)
    {
      if (this.iclippingTransformer_0 != null)
        return this.iclippingTransformer_0.Transform(v);
      Vector4D? nullable = new Vector4D?();
      int count = this.linkedList_0.Count;
      foreach (IClippingTransformer clippingTransformer in this.linkedList_0)
      {
        nullable = clippingTransformer.Transform(v);
        if (nullable.HasValue)
        {
          if (--count != 0)
            v = (Point3D) nullable.Value;
          else
            break;
        }
        else
          break;
      }
      return nullable;
    }

    public IList<Segment4D> Transform(Segment3D segment)
    {
      if (this.iclippingTransformer_0 != null)
        return this.iclippingTransformer_0.Transform(segment);
      List<Segment4D> segment4DList = new List<Segment4D>();
      List<Segment3D> segment3DList = new List<Segment3D>();
      segment3DList.Add(segment);
      int count = this.linkedList_0.Count;
      foreach (IClippingTransformer clippingTransformer in this.linkedList_0)
      {
        segment4DList.Clear();
        foreach (Segment3D segment1 in segment3DList)
          segment4DList.AddRange((IEnumerable<Segment4D>) clippingTransformer.Transform(segment1));
        if (segment4DList.Count != 0)
        {
          if (--count != 0)
          {
            segment3DList.Clear();
            foreach (Segment4D segment4D in segment4DList)
              segment3DList.Add(new Segment3D((Point3D) segment4D.Start, (Point3D) segment4D.End));
          }
          else
            break;
        }
        else
          break;
      }
      return (IList<Segment4D>) segment4DList;
    }

    public IList<Polyline4D> Transform(Polyline3D polyline, bool filled)
    {
      if (this.iclippingTransformer_0 != null)
        return this.iclippingTransformer_0.Transform(polyline, filled);
      List<Polyline3D> polyline3DList = new List<Polyline3D>();
      polyline3DList.Add(polyline);
      List<Polyline4D> polyline4DList = new List<Polyline4D>();
      int count = this.linkedList_0.Count;
      foreach (IClippingTransformer clippingTransformer in this.linkedList_0)
      {
        polyline4DList.Clear();
        foreach (Polyline3D polyline1 in polyline3DList)
          polyline4DList.AddRange((IEnumerable<Polyline4D>) clippingTransformer.Transform(polyline1, filled));
        if (polyline4DList.Count != 0)
        {
          if (--count != 0)
          {
            polyline3DList.Clear();
            foreach (Polyline4D polyline4D in polyline4DList)
            {
              Polyline3D polyline3D = new Polyline3D(polyline4D.Count, polyline4D.Closed);
              foreach (Vector4D vector4D in (List<Vector4D>) polyline4D)
                polyline3D.Add((Point3D) vector4D);
              polyline3DList.Add(polyline3D);
            }
          }
          else
            break;
        }
        else
          break;
      }
      return (IList<Polyline4D>) polyline4DList;
    }

    public IShape4D Transform(IShape4D shape)
    {
      foreach (IClippingTransformer clippingTransformer in this.linkedList_0)
        shape = clippingTransformer.Transform(shape);
      return shape;
    }

    public void SetPreTransform(Matrix4D preTransform)
    {
      this.linkedList_0.First.Value.SetPreTransform(preTransform);
      this.method_0();
    }

    public InsideTestResult TryIsInside(Bounds3D bounds)
    {
      InsideTestResult insideTestResult1 = InsideTestResult.None;
      foreach (IClippingTransformer clippingTransformer in this.linkedList_0)
      {
        InsideTestResult insideTestResult2 = clippingTransformer.TryIsInside(bounds);
        if (insideTestResult2 == InsideTestResult.Outside)
          return insideTestResult2;
        insideTestResult1 |= insideTestResult2;
        bounds = DxfUtil.Transform(bounds, clippingTransformer.Matrix);
      }
      return insideTestResult1;
    }

    public InsideTestResult IsInside(IShape4D shape, out bool transformedShape)
    {
      transformedShape = false;
      InsideTestResult insideTestResult1 = InsideTestResult.None;
      foreach (IClippingTransformer clippingTransformer in this.linkedList_0)
      {
        bool transformedShape1;
        InsideTestResult insideTestResult2 = clippingTransformer.IsInside(shape, out transformedShape1);
        transformedShape |= transformedShape1;
        if (insideTestResult2 == InsideTestResult.Outside)
          return insideTestResult2;
        insideTestResult1 |= insideTestResult2;
        if (!transformedShape1)
        {
          shape.Transform(clippingTransformer.Matrix);
          transformedShape = true;
        }
      }
      return insideTestResult1;
    }

    private void method_0()
    {
      if (this.iclippingTransformer_0 != null)
      {
        this.matrix4D_0 = this.iclippingTransformer_0.Matrix;
      }
      else
      {
        this.matrix4D_0 = Matrix4D.Identity;
        foreach (IClippingTransformer clippingTransformer in this.linkedList_0)
          this.matrix4D_0 = clippingTransformer.Matrix * this.matrix4D_0;
      }
      if (this.iclippingTransformer_0 != null)
      {
        this.matrix3D_0 = this.iclippingTransformer_0.Matrix3D;
      }
      else
      {
        this.matrix3D_0 = Matrix3D.Identity;
        foreach (IClippingTransformer clippingTransformer in this.linkedList_0)
          this.matrix3D_0 = clippingTransformer.Matrix3D * this.matrix3D_0;
      }
      this.ilineTypeScaler_0 = Class624.Create(this.matrix3D_0);
    }
  }
}
