// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.IPathDrawer
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model
{
  public interface IPathDrawer
  {
    void DrawPath(IShape4D path, Color color, short lineWeight);

    void DrawPath(
      IShape2D path,
      Matrix4D transform,
      Color color,
      short lineWeight,
      bool filled,
      bool forText,
      double extrusion);

    void DrawCharPath(
      IShape2D path,
      Matrix4D transform,
      Color color,
      short lineWeight,
      bool filled,
      double extrusion);

    bool IsSeparateCharDrawingPreferred();
  }
}
