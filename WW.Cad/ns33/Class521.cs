// Decompiled with JetBrains decompiler
// Type: ns33.Class521
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Drawing;
using WW.Cad.Model.Entities;
using WW.Math;
using WW.Math.Geometry;

namespace ns33
{
  internal class Class521
  {
    private static Dictionary<Class805, Class521> dictionary_0 = new Dictionary<Class805, Class521>();
    private Bounds2D bounds2D_0 = new Bounds2D();
    private int int_0;
    private Vector2D vector2D_0;
    private IList<Polyline2D> ilist_0;

    public Class521(ShxFile font, ShxShape shape, GraphicsConfig graphicsConfig)
    {
      this.int_0 = font.Above;
      Point2D endPoint;
      IShape2D glyphShape = shape.GetGlyphShape(false, out endPoint);
      this.vector2D_0 = (Vector2D) endPoint;
      this.ilist_0 = (IList<Polyline2D>) ShapeTool.GetFlattened(glyphShape, graphicsConfig.ShapeFlattenEpsilon);
      foreach (List<Point2D> point2DList in (IEnumerable<Polyline2D>) this.ilist_0)
      {
        foreach (Point2D p in point2DList)
          this.bounds2D_0.Update(p);
      }
    }

    public int Ascent
    {
      get
      {
        return this.int_0;
      }
    }

    public Vector2D Advance
    {
      get
      {
        return this.vector2D_0;
      }
    }

    public IList<Polyline2D> Polylines
    {
      get
      {
        return this.ilist_0;
      }
    }

    public Bounds2D Bounds
    {
      get
      {
        return this.bounds2D_0;
      }
    }

    public static Class521 GetPolylines(
      ShxFile font,
      char character,
      GraphicsConfig config)
    {
      Class805 key = new Class805(font, character);
      Class521 class521;
      if (Class521.dictionary_0.TryGetValue(key, out class521))
        return class521;
      ShxShape shape = font.GetShape(character);
      if (shape != null)
      {
        class521 = new Class521(font, shape, config);
        Class521.dictionary_0.Add(key, class521);
      }
      return class521;
    }
  }
}
