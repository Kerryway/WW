// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Point3DT
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing
{
  public struct Point3DT
  {
    public static readonly Point3DT Zero = new Point3DT(Point3D.Zero, 0U);
    public Point3D Position;
    public uint Type;

    public unsafe Point3DT(Point3D position)
    {
       this = new Point3DT();
      this.Position = position;
    }

    public Point3DT(Point3D position, uint type)
    {
      this.Position = position;
      this.Type = type;
    }
  }
}
