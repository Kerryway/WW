// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.WireTransform
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Model.Entities
{
  public class WireTransform
  {
    private Vector3D vector3D_0 = Vector3D.XAxis;
    private Vector3D vector3D_1 = Vector3D.YAxis;
    private Vector3D vector3D_2 = Vector3D.Zero;
    private Vector3D vector3D_3 = Vector3D.Zero;
    private double double_0 = 1.0;
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;

    public Vector3D XAxis
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public Vector3D YAxis
    {
      get
      {
        return this.vector3D_1;
      }
      set
      {
        this.vector3D_1 = value;
      }
    }

    public Vector3D ZAxis
    {
      get
      {
        return this.vector3D_2;
      }
      set
      {
        this.vector3D_2 = value;
      }
    }

    public Vector3D Translation
    {
      get
      {
        return this.vector3D_3;
      }
      set
      {
        this.vector3D_3 = value;
      }
    }

    public double Scale
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public bool HasRotation
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

    public bool HasReflection
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public bool HasShear
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }
  }
}
