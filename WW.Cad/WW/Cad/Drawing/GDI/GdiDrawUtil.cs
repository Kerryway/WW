// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.GDI.GdiDrawUtil
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using WW.Math;

namespace WW.Cad.Drawing.GDI
{
  public static class GdiDrawUtil
  {
    public static void DrawEditHandle(
      Graphics graphics,
      Pen pen,
      PointF position,
      double editHandleSize)
    {
      GdiDrawUtil.DrawEditHandle(graphics, pen, (Point2D) position, editHandleSize);
    }

    public static void DrawEditHandle(
      Graphics graphics,
      Pen pen,
      Point2D position,
      double editHandleSize)
    {
      int x = (int) System.Math.Round(position.X - 0.5 * editHandleSize);
      int y = (int) System.Math.Round(position.Y - 0.5 * editHandleSize);
      int num1 = x + (int) System.Math.Round(editHandleSize);
      int num2 = y + (int) System.Math.Round(editHandleSize);
      graphics.DrawRectangle(pen, x, y, num1 - x, num2 - y);
    }
  }
}
