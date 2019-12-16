// Decompiled with JetBrains decompiler
// Type: WW.IO.StreamUtil
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.IO;

namespace WW.IO
{
  public static class StreamUtil
  {
    public static Stream OpenReadOnlyStream(string filename)
    {
      return (Stream) File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    }

    public static void Forward(Stream source, Stream target)
    {
      PagedMemoryStream pagedMemoryStream = source as PagedMemoryStream;
      if (pagedMemoryStream != null)
      {
        pagedMemoryStream.WriteTo(target);
      }
      else
      {
        MemoryStream memoryStream = source as MemoryStream;
        if (memoryStream != null)
        {
          target.Write(memoryStream.GetBuffer(), 0, (int) memoryStream.Length);
        }
        else
        {
          long position = source.Position;
          source.Position = 0L;
          byte[] buffer = new byte[65536];
          int num = (int) (source.Length / 65536L);
          for (int index = 0; index < num; ++index)
          {
            source.Read(buffer, 0, 65536);
            target.Write(buffer, 0, 65536);
          }
          int count = (int) (source.Length - (long) (num * 65536));
          if (count > 0)
          {
            source.Read(buffer, 0, count);
            target.Write(buffer, 0, count);
          }
          source.Position = position;
        }
      }
    }

    public static void Forward(Stream source, int sourceOffset, Stream target, int length)
    {
      PagedMemoryStream pagedMemoryStream = source as PagedMemoryStream;
      if (pagedMemoryStream != null)
      {
        pagedMemoryStream.WriteTo(sourceOffset, target, length);
      }
      else
      {
        MemoryStream memoryStream = source as MemoryStream;
        if (memoryStream != null)
        {
          target.Write(memoryStream.GetBuffer(), sourceOffset, length);
        }
        else
        {
          long position = source.Position;
          source.Position = (long) sourceOffset;
          byte[] buffer = new byte[65536];
          int num = length / 65536;
          for (int index = 0; index < num; ++index)
          {
            source.Read(buffer, 0, 65536);
            target.Write(buffer, 0, 65536);
          }
          int count = length - num * 65536;
          if (count > 0)
          {
            source.Read(buffer, 0, count);
            target.Write(buffer, 0, count);
          }
          source.Position = position;
        }
      }
    }
  }
}
