// Decompiled with JetBrains decompiler
// Type: ns28.Class726
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using System.Text;
using WW.Cad.Model;
using WW.Math;

namespace ns28
{
  internal class Class726 : Class725
  {
    public Class726(Stream stream, Encoding encoding, DxfVersion version)
      : base(stream, encoding, version)
    {
    }

    public override void imethod_1(double value)
    {
      if (value == 0.0)
      {
        this.imethod_14(true);
      }
      else
      {
        this.imethod_14(false);
        this.imethod_16(value);
      }
    }

    public override void imethod_3(Vector3D value)
    {
      if (value == Vector3D.ZAxis)
      {
        this.imethod_14(true);
      }
      else
      {
        this.imethod_14(false);
        this.imethod_29(value);
      }
    }
  }
}
