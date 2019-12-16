// Decompiled with JetBrains decompiler
// Type: ns4.Class865
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace ns4
{
  internal class Class865 : Interface34
  {
    private readonly string string_0;
    private readonly Interface14 interface14_0;
    private readonly Color color_0;
    private readonly short short_0;
    private readonly IShape2D ishape2D_0;
    private readonly Vector2D vector2D_0;
    private readonly Matrix2D matrix2D_0;
    private Matrix2D matrix2D_1;
    private Matrix2D matrix2D_2;
    private Class1063[] class1063_0;

    public Class865(
      string text,
      Interface14 font,
      Color color,
      short lineWeight,
      IShape2D path,
      Matrix2D charTransform,
      Matrix2D canonicalizeTransform,
      Vector2D advance)
    {
      this.string_0 = text;
      this.interface14_0 = font;
      this.color_0 = color;
      this.short_0 = lineWeight;
      this.ishape2D_0 = path;
      this.matrix2D_0 = charTransform;
      this.matrix2D_1 = canonicalizeTransform;
      this.vector2D_0 = advance;
      this.matrix2D_2 = charTransform * canonicalizeTransform;
    }

    public string Text
    {
      get
      {
        return this.string_0;
      }
    }

    public Interface14 Font
    {
      get
      {
        return this.interface14_0;
      }
    }

    public Color Color
    {
      get
      {
        return this.color_0;
      }
    }

    public short LineWeight
    {
      get
      {
        return this.short_0;
      }
    }

    public Vector3D Draw(IPathDrawer drawer, Matrix4D transformation, double extrusion)
    {
      Matrix4D a = Matrix4D.Multiply(transformation, this.matrix2D_0);
      Matrix4D transform = Matrix4D.Multiply(a, this.matrix2D_1);
      if (this.ishape2D_0 != null)
      {
        if (drawer.IsSeparateCharDrawingPreferred())
        {
          foreach (Class1063 splitPath in this.SplitPaths)
            drawer.DrawCharPath(splitPath.Shape, a * DxfUtil.smethod_61(splitPath.Transform), this.color_0, this.short_0, this.Filled, extrusion);
        }
        else
          drawer.DrawPath(this.ishape2D_0, transform, this.color_0, this.short_0, this.Filled, true, extrusion);
      }
      return (Vector3D) transform.TransformTo3D((WW.Math.Point2D) this.vector2D_0);
    }

    public Class1063[] SplitPaths
    {
      get
      {
        if (this.class1063_0 == null)
        {
          if (!this.ishape2D_0.HasSegments)
          {
            this.class1063_0 = new Class1063[1]
            {
              new Class1063(this.ishape2D_0, Matrix3D.Identity)
            };
          }
          else
          {
            GeneralShape2D generalShape2D1 = this.ishape2D_0 as GeneralShape2D ?? new GeneralShape2D(this.ishape2D_0);
            List<Class1063> class1063List = new List<Class1063>(this.string_0.Length);
            int index1 = 0;
            int index2 = 0;
            foreach (char c in this.string_0)
            {
              ICanonicalGlyph canonicalGlyph = this.interface14_0.imethod_1(c, false);
              GeneralShape2D generalShape2D2 = canonicalGlyph.Path as GeneralShape2D ?? new GeneralShape2D(canonicalGlyph.Path);
              if (generalShape2D2.HasSegments)
              {
                if (index1 < generalShape2D1.PointCount && index2 < generalShape2D1.SegmentCount && generalShape2D1.GetSegmentTypeAt(index2) == SegmentType.MoveTo)
                {
                  WW.Math.Point2D firstPoint = generalShape2D2.FirstPoint;
                  Matrix3D transform = Transformation3D.Translation(this.matrix2D_1.Transform(generalShape2D1.GetPointAt(index1)) - firstPoint);
                  class1063List.Add(new Class1063((IShape2D) generalShape2D2, transform));
                  index1 += generalShape2D2.PointCount;
                  index2 += generalShape2D2.SegmentCount;
                }
                else
                {
                  index2 = -1;
                  index1 = -1;
                  break;
                }
              }
            }
            if (index1 == generalShape2D1.PointCount && index2 == generalShape2D1.SegmentCount)
              this.class1063_0 = class1063List.ToArray();
            else
              this.class1063_0 = new Class1063[1]
              {
                new Class1063(this.ishape2D_0, Matrix3D.Identity)
              };
          }
        }
        return this.class1063_0;
      }
    }

    public IShape2D CanonicalPath
    {
      get
      {
        return this.ishape2D_0;
      }
    }

    public IShape2D TransformedPath
    {
      get
      {
        if (this.ishape2D_0 != null)
          return (IShape2D) new GeneralShape2D(this.ishape2D_0, this.matrix2D_2, true);
        return ShapeTool.NullShape;
      }
    }

    public Matrix2D BasicTransformation
    {
      get
      {
        return this.matrix2D_2;
      }
    }

    public bool Filled
    {
      get
      {
        return this.interface14_0.Filled;
      }
    }

    public Vector2D CanonicalAdvance
    {
      get
      {
        return this.vector2D_0;
      }
    }

    public Vector2D Advance
    {
      get
      {
        return this.matrix2D_2.Transform(this.vector2D_0);
      }
    }
  }
}
