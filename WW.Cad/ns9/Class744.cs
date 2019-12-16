// Decompiled with JetBrains decompiler
// Type: ns9.Class744
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns9
{
  internal class Class744 : Interface3
  {
    private Vector3D vector3D_0 = Vector3D.XAxis;
    private Vector3D vector3D_1 = Vector3D.YAxis;
    private Vector3D vector3D_2 = Vector3D.ZAxis;
    private double double_0 = 1.0;
    private Class686.Class692 class692_0 = new Class686.Class692(false);
    private Class686.Class693 class693_0 = new Class686.Class693(false);
    private Class686.Class694 class694_0 = new Class686.Class694(false);
    private Vector3D vector3D_3;

    public void imethod_0(Interface8 reader)
    {
      this.vector3D_0 = reader.imethod_19();
      this.vector3D_1 = reader.imethod_19();
      this.vector3D_2 = reader.imethod_19();
      this.vector3D_3 = reader.imethod_19();
      this.double_0 = reader.imethod_8();
      this.class692_0 = new Class686.Class692(reader);
      this.class693_0 = new Class686.Class693(reader);
      this.class694_0 = new Class686.Class694(reader);
    }

    public void imethod_1(Interface9 writer)
    {
      writer.imethod_18(this.vector3D_0);
      writer.imethod_18(this.vector3D_1);
      writer.imethod_18(this.vector3D_2);
      writer.imethod_18(this.vector3D_3);
      writer.imethod_7(this.double_0);
      writer.imethod_12((Interface39) this.class692_0);
      writer.imethod_12((Interface39) this.class693_0);
      writer.imethod_12((Interface39) this.class694_0);
    }

    public Matrix4D Transformation
    {
      get
      {
        return new Matrix4D(this.vector3D_0.X * this.double_0, this.vector3D_1.X, this.vector3D_2.X, this.vector3D_3.X, this.vector3D_0.Y, this.vector3D_1.Y * this.double_0, this.vector3D_2.Y, this.vector3D_3.Y, this.vector3D_0.Z, this.vector3D_1.Z, this.vector3D_2.Z * this.double_0, this.vector3D_3.Z, 0.0, 0.0, 0.0, 1.0);
      }
      set
      {
        this.double_0 = this.vector3D_0.GetLengthSquared();
        double lengthSquared1 = this.vector3D_1.GetLengthSquared();
        if (this.double_0 < lengthSquared1)
          this.double_0 = lengthSquared1;
        double lengthSquared2 = this.vector3D_2.GetLengthSquared();
        if (this.double_0 < lengthSquared2)
          this.double_0 = lengthSquared2;
        Matrix4D matrix4D = value * Transformation4D.Scaling(this.double_0, this.double_0, this.double_0);
        this.vector3D_0[0] = matrix4D.M00;
        this.vector3D_0[1] = matrix4D.M10;
        this.vector3D_0[2] = matrix4D.M20;
        this.vector3D_1[0] = matrix4D.M01;
        this.vector3D_1[1] = matrix4D.M11;
        this.vector3D_1[2] = matrix4D.M21;
        this.vector3D_2[0] = matrix4D.M02;
        this.vector3D_2[1] = matrix4D.M12;
        this.vector3D_2[2] = matrix4D.M22;
        this.vector3D_3 = matrix4D.GetTranslation();
        this.class693_0.Value = matrix4D.GetDeterminant() < 0.0;
      }
    }
  }
}
