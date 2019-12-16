// Decompiled with JetBrains decompiler
// Type: WW.IO.Compression.ZlibDecompressStream
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.IO;
using System.IO.Compression;

namespace WW.IO.Compression
{
  public class ZlibDecompressStream : DeflateStream
  {
    public ZlibDecompressStream(Stream stream)
      : base(stream, CompressionMode.Decompress)
    {
      ZlibDecompressStream.smethod_0(stream);
    }

    public ZlibDecompressStream(Stream stream, bool leaveOpen)
      : base(stream, CompressionMode.Decompress, leaveOpen)
    {
      ZlibDecompressStream.smethod_0(stream);
    }

    public override bool CanWrite
    {
      get
      {
        return false;
      }
    }

    private static void smethod_0(Stream stream)
    {
      stream.ReadByte();
      if ((stream.ReadByte() & 32) == 0)
        return;
      for (int index = 0; index < 4; ++index)
        stream.ReadByte();
    }
  }
}
