// Decompiled with JetBrains decompiler
// Type: ns2.Class348
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using System.Text;

namespace ns2
{
  internal class Class348 : Class347
  {
    internal Class348(BinaryWriter w, Encoding encoding)
      : base(w, encoding)
    {
    }

    protected internal override void vmethod_0(int groupCode)
    {
      this.binaryWriter_0.Write((short) groupCode);
    }
  }
}
