// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.GeoMeshPoint
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects
{
  public class GeoMeshPoint
  {
    private WW.Math.Point2D point2D_0;
    private WW.Math.Point2D point2D_1;

    public GeoMeshPoint()
    {
    }

    public GeoMeshPoint(WW.Math.Point2D source, WW.Math.Point2D destination)
    {
      this.point2D_0 = source;
      this.point2D_1 = destination;
    }

    public WW.Math.Point2D Source
    {
      get
      {
        return this.point2D_0;
      }
      set
      {
        this.point2D_0 = value;
      }
    }

    public WW.Math.Point2D Destination
    {
      get
      {
        return this.point2D_1;
      }
      set
      {
        this.point2D_1 = value;
      }
    }

    public override string ToString()
    {
      return string.Format("Source: {0}, destination: {1}", (object) this.point2D_0, (object) this.point2D_1);
    }
  }
}
