// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.GeoMeshFace
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects
{
  public class GeoMeshFace
  {
    private int int_0;
    private int int_1;
    private int int_2;

    public GeoMeshFace()
    {
    }

    public GeoMeshFace(int faceIndex1, int faceIndex2, int faceIndex3)
    {
      this.int_0 = faceIndex1;
      this.int_1 = faceIndex2;
      this.int_2 = faceIndex3;
    }

    public int FaceIndex1
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public int FaceIndex2
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public int FaceIndex3
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
      }
    }

    public override string ToString()
    {
      return string.Format("Face indexes 1, 2 and 3: {0}, {1}, {2}", (object) this.int_0, (object) this.int_1, (object) this.int_2);
    }
  }
}
