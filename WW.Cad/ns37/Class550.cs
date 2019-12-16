// Decompiled with JetBrains decompiler
// Type: ns37.Class550
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace ns37
{
  internal class Class550
  {
    private Vector3D vector3D_0;
    private Vector3D vector3D_1;
    private double double_0;
    private double double_1;
    private double double_2;
    private double double_3;
    private int int_0;

    public Vector3D DistanceToTopLeft
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

    public Vector3D DistanceToCenter
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

    public double ContentWidth
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

    public double ContentHeight
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public double Width
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
      }
    }

    public double Height
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
      }
    }

    internal int UnknownFlags
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

    public Class550 Clone()
    {
      Class550 class550 = new Class550();
      class550.CopyFrom(this);
      return class550;
    }

    public void CopyFrom(Class550 from)
    {
      this.vector3D_0 = from.vector3D_0;
      this.vector3D_1 = from.vector3D_1;
      this.double_0 = from.double_0;
      this.double_1 = from.double_1;
      this.double_2 = from.double_2;
      this.double_3 = from.double_3;
      this.int_0 = from.int_0;
    }
  }
}
