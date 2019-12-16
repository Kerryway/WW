// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.NullShape4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace WW.Math.Geometry
{
  public class NullShape4D : IShape4D
  {
    private static readonly Polyline4D[] polyline4D_0 = new Polyline4D[0];
    public static readonly IShape4D Instance = (IShape4D) new NullShape4D();
    internal static GraphicsPath graphicsPath_0 = new GraphicsPath();

    private NullShape4D()
    {
    }

    public bool IsFilled
    {
      get
      {
        return false;
      }
    }

    public bool IsEmpty
    {
      get
      {
        return true;
      }
    }

    public InsideTestResult CheckClipping(IInsideTester4D region)
    {
      return InsideTestResult.Outside;
    }

    public void Transform(Matrix4D matrix)
    {
    }

    public void UpdateBounds(Bounds3D bounds, Matrix4D modelTransform)
    {
    }

    public IList<Polyline4D> ToPolylines4D(double shapeFlattenEpsilon)
    {
      return (IList<Polyline4D>) NullShape4D.polyline4D_0;
    }

    public IShape2D ToShape2D(Matrix4D matrix)
    {
      return ShapeTool.NullShape;
    }

    public GraphicsPath ToGraphicsPath(Matrix4D transform)
    {
      return NullShape4D.graphicsPath_0;
    }

    public ISegment2DIterator CreateIterator(Matrix4D transform)
    {
      return (ISegment2DIterator) NullSegment2DIterator.Instance;
    }

    public IShape4D GetFlattened(ITransformer4D transformer, double shapeFlattenEpsilon)
    {
      return (IShape4D) this;
    }

    public FlatShape4D ToFlatShape()
    {
      return new FlatShape4D(ShapeTool.NullShape, false);
    }
  }
}
