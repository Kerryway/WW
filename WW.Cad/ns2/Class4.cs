// Decompiled with JetBrains decompiler
// Type: ns2.Class4
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using System.Text;
using WW.Cad.Model.Entities;

namespace ns2
{
  internal class Class4 : Class2
  {
    internal Class4(BinaryReader r, Encoding encoding, ShxFile shxfile)
      : base(r, encoding, (CharRemapDelegate) null, shxfile)
    {
    }

    protected override void vmethod_0(
      Class2.Struct0[] shapeInfoList,
      out int degree,
      out int plusMinus,
      out int diameter)
    {
      degree = 256;
      plusMinus = 257;
      diameter = 258;
    }
  }
}
