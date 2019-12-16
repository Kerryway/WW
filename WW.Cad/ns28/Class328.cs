// Decompiled with JetBrains decompiler
// Type: ns28.Class328
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using WW;
using WW.Cad.Model;

namespace ns28
{
  internal class Class328
  {
    private static readonly byte[] byte_0 = new byte[16]{ (byte) 31, (byte) 37, (byte) 109, (byte) 7, (byte) 212, (byte) 54, (byte) 40, (byte) 40, (byte) 157, (byte) 87, (byte) 202, (byte) 63, (byte) 157, (byte) 68, (byte) 16, (byte) 43 };
    private static readonly byte[] byte_1 = new byte[16]{ (byte) 224, (byte) 218, (byte) 146, (byte) 248, (byte) 43, (byte) 201, (byte) 215, (byte) 215, (byte) 98, (byte) 168, (byte) 53, (byte) 192, (byte) 98, (byte) 187, (byte) 239, (byte) 212 };
    private Stream stream_0;

    public Class328(Stream stream, DxfModel model)
    {
      this.stream_0 = stream;
    }

    public void Write()
    {
      this.stream_0.Write(Class328.byte_0, 0, Class328.byte_0.Length);
      this.stream_0.Write(LittleEndianBitConverter.GetBytes(1), 0, 4);
      this.stream_0.WriteByte((byte) 0);
      this.stream_0.Write(Class328.byte_1, 0, Class328.byte_1.Length);
    }
  }
}
