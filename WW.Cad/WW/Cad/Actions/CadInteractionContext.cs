// Decompiled with JetBrains decompiler
// Type: WW.Cad.Actions.CadInteractionContext
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Actions;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Actions
{
  public class CadInteractionContext : InteractionContext
  {
    private bool bool_0;

    public CadInteractionContext(
      Rectangle2D canvasRectangle,
      Matrix4D projectionTransform,
      bool projectionFlipsOrientation,
      ArgbColor backgroundColor)
      : base(canvasRectangle, projectionTransform, projectionFlipsOrientation, backgroundColor)
    {
    }

    public bool DefaultNonDiagonalLines
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
  }
}
