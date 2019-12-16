// Decompiled with JetBrains decompiler
// Type: ns28.Class446
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using WW.Cad.IO;
using WW.Math;

namespace ns28
{
  internal class Class446 : Class445
  {
    public Class446(DwgReader dwgReader, Stream stream)
      : base(dwgReader, stream)
    {
    }

    public override double imethod_17()
    {
      if (this.imethod_6())
        return 0.0;
      return this.imethod_8();
    }

    public override Vector3D imethod_10()
    {
      if (this.imethod_6())
        return Vector3D.ZAxis;
      return this.imethod_51();
    }
  }
}
