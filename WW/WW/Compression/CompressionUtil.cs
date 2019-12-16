// Decompiled with JetBrains decompiler
// Type: WW.Compression.CompressionUtil
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.IO;
using System.IO.Compression;

namespace WW.Compression
{
  public static class CompressionUtil
  {
    public static Stream GetGZipStream(Stream stream, bool needRandomAccess)
    {
      Stream input = (Stream) new GZipStream(stream, CompressionMode.Decompress, false);
      if (needRandomAccess)
        input = CompressionUtil.GetMemoryStream(input);
      return input;
    }

    public static Stream GetMemoryStream(Stream input)
    {
      MemoryStream memoryStream = new MemoryStream();
      int count1 = 10240;
      byte[] buffer = new byte[10240];
      while (true)
      {
        int count2 = input.Read(buffer, 0, count1);
        if (count2 > 0)
          memoryStream.Write(buffer, 0, count2);
        else
          break;
      }
      input.Close();
      input.Dispose();
      memoryStream.Position = 0L;
      return (Stream) memoryStream;
    }
  }
}
