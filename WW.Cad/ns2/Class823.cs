// Decompiled with JetBrains decompiler
// Type: ns2.Class823
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using System.Text;

namespace ns2
{
  internal class Class823 : Class822
  {
    internal Class823(BinaryReader r, Encoding encoding)
      : base(r, encoding)
    {
    }

    protected internal override int vmethod_0()
    {
      try
      {
        return (int) this.binaryReader_0.ReadInt16();
      }
      catch (EndOfStreamException ex)
      {
        return int.MinValue;
      }
    }
  }
}
