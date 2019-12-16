// Decompiled with JetBrains decompiler
// Type: WW.IO.PagedMemoryStream
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.IO;

namespace WW.IO
{
  public class PagedMemoryStream : Stream
  {
    private bool bool_0 = true;
    public const int DefaultPageSize = 65536;
    private const int int_0 = 20;
    private int int_1;
    private List<byte[]> list_0;
    private int int_2;
    private long long_0;
    private long long_1;
    private IMemoryPageCache imemoryPageCache_0;

    public PagedMemoryStream()
      : this(0L, 65536)
    {
    }

    public PagedMemoryStream(long capacity)
      : this(capacity, 65536)
    {
    }

    public PagedMemoryStream(long capacity, int pageSize)
    {
      this.int_1 = pageSize;
      int capacity1 = (int) ((capacity - 1L) / (long) pageSize + 1L);
      if (capacity1 <= 0)
        return;
      this.list_0 = new List<byte[]>(capacity1);
    }

    public PagedMemoryStream(PagedMemoryStream source)
    {
      this.int_1 = source.int_1;
      this.list_0 = source.list_0;
      this.long_1 = source.long_1;
    }

    public PagedMemoryStream(Stream source, long length)
      : this(length)
    {
      this.method_0(source, length);
    }

    public PagedMemoryStream(
      Stream source,
      long length,
      int pageSize,
      IMemoryPageCache memoryPageCache)
      : this(length)
    {
      this.imemoryPageCache_0 = memoryPageCache;
      this.int_1 = pageSize;
      this.SetLength(length);
      int index1 = (int) (length / (long) pageSize);
      for (int index2 = 0; index2 < index1; ++index2)
        source.Read(this.list_0[index2], 0, pageSize);
      int count = (int) (length - (long) (index1 * pageSize));
      if (count <= 0)
        return;
      source.Read(this.list_0[index1], 0, count);
    }

    public PagedMemoryStream(MemoryStream source, long length)
      : this(length)
    {
      this.long_1 = length;
      if (length > 65536L)
      {
        this.method_1(source.GetBuffer(), length);
      }
      else
      {
        this.int_1 = (int) length;
        this.list_0 = new List<byte[]>(1)
        {
          source.GetBuffer()
        };
      }
      this.bool_0 = false;
    }

    public IMemoryPageCache PageCache
    {
      get
      {
        return this.imemoryPageCache_0;
      }
      set
      {
        this.imemoryPageCache_0 = value;
      }
    }

    public int PageSize
    {
      get
      {
        return this.int_1;
      }
    }

    public override void Flush()
    {
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      switch (origin)
      {
        case SeekOrigin.Begin:
          this.long_0 = offset;
          break;
        case SeekOrigin.Current:
          this.long_0 += offset;
          break;
        case SeekOrigin.End:
          this.long_0 = this.long_1 - offset;
          break;
      }
      if (this.long_0 < 0L)
        throw new IOException("Seeking position beyond start of stream.");
      if (this.long_0 >= this.long_1)
        throw new IOException("Seeking position beyond end of stream.");
      this.int_2 = (int) (this.long_0 / (long) this.int_1);
      return this.long_0;
    }

    public override void SetLength(long value)
    {
      this.long_1 = value;
      int num = (int) ((this.long_1 - 1L) / (long) this.int_1) + 1;
      for (int index = this.list_0 == null ? 0 : this.list_0.Count; index < num; ++index)
        this.list_0.Add(this.imemoryPageCache_0 == null ? new byte[this.int_1] : this.imemoryPageCache_0.GetPage(this.int_1));
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      if (this.long_0 >= this.long_1)
        return 0;
      count = System.Math.Min(count, (int) (this.long_1 - this.long_0));
      if (count == 0)
        return 0;
      int num1 = (int) (this.long_0 % (long) this.int_1);
      int count1 = System.Math.Min(count, this.int_1 - num1);
      int num2 = num1 + count1;
      int dstOffset = offset;
      byte[] numArray1 = this.list_0[this.int_2];
      int srcOffset = num1;
      if (count1 >= 20)
      {
        Buffer.BlockCopy((Array) numArray1, srcOffset, (Array) buffer, dstOffset, count1);
        srcOffset += count1;
        dstOffset += count1;
      }
      else
      {
        for (; srcOffset < num2; ++srcOffset)
          buffer[dstOffset++] = numArray1[srcOffset];
      }
      if (srcOffset == this.int_1)
        ++this.int_2;
      if (count1 < count)
      {
        int num3 = (count - count1) / this.int_1;
        int num4 = 0;
        while (num4 < num3)
        {
          Buffer.BlockCopy((Array) this.list_0[this.int_2++], 0, (Array) buffer, dstOffset, this.int_1);
          ++num4;
          dstOffset += this.int_1;
        }
        count1 += num3 * this.int_1;
        if (count1 < count)
        {
          int count2 = count - count1;
          byte[] numArray2 = this.list_0[this.int_2];
          if (count2 >= 20)
          {
            Buffer.BlockCopy((Array) numArray2, 0, (Array) buffer, dstOffset, count2);
          }
          else
          {
            for (int index = 0; index < count2; ++index)
              buffer[dstOffset++] = numArray2[index];
          }
          count1 += count2;
        }
      }
      this.long_0 += (long) count;
      return count1;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      long num1 = this.long_0 + (long) count;
      if (num1 > this.long_1)
        this.SetLength(num1);
      int num2 = (int) (this.long_0 % (long) this.int_1);
      int count1 = System.Math.Min(count, this.int_1 - num2);
      int num3 = num2 + count1;
      int srcOffset = offset;
      byte[] numArray1 = this.list_0[this.int_2];
      int dstOffset = num2;
      if (count1 >= 20)
      {
        Buffer.BlockCopy((Array) buffer, srcOffset, (Array) numArray1, dstOffset, count1);
        dstOffset += count1;
        srcOffset += count1;
      }
      else
      {
        for (; dstOffset < num3; ++dstOffset)
          numArray1[dstOffset] = buffer[srcOffset++];
      }
      if (dstOffset == this.int_1)
        ++this.int_2;
      if (count1 < count)
      {
        int num4 = (count - count1) / this.int_1;
        for (int index = 0; index < num4; ++index)
        {
          byte[] numArray2 = this.list_0[this.int_2++];
          Buffer.BlockCopy((Array) buffer, srcOffset, (Array) numArray2, 0, this.int_1);
          srcOffset += this.int_1;
        }
        int num5 = count1 + num4 * this.int_1;
        if (num5 < count)
        {
          int count2 = count - num5;
          byte[] numArray2 = this.list_0[this.int_2];
          if (count2 >= 20)
          {
            Buffer.BlockCopy((Array) buffer, srcOffset, (Array) numArray2, 0, count2);
          }
          else
          {
            for (int index = 0; index < count2; ++index)
              numArray2[index] = buffer[srcOffset++];
          }
          int num6 = num5 + count2;
        }
      }
      this.long_0 += (long) count;
    }

    public override int ReadByte()
    {
      if (this.long_0 >= this.long_1)
        return -1;
      int num = (int) this.list_0[this.int_2][this.long_0 % (long) this.int_1];
      ++this.Position;
      return num;
    }

    public override void WriteByte(byte value)
    {
      if (this.Position >= this.long_1)
        this.SetLength(this.Position + 1L);
      this.list_0[this.int_2][this.long_0 % (long) this.int_1] = value;
      ++this.Position;
    }

    public override bool CanRead
    {
      get
      {
        return true;
      }
    }

    public override bool CanSeek
    {
      get
      {
        return true;
      }
    }

    public override bool CanWrite
    {
      get
      {
        return true;
      }
    }

    public override long Length
    {
      get
      {
        return this.long_1;
      }
    }

    public override long Position
    {
      get
      {
        return this.long_0;
      }
      set
      {
        this.long_0 = value;
        this.int_2 = (int) (this.long_0 / (long) this.int_1);
      }
    }

    public void Write(Stream stream, int length)
    {
      int num = length / 1024;
      byte[] buffer = new byte[1024];
      for (int index = 0; index < num; ++index)
      {
        stream.Read(buffer, 0, 1024);
        this.Write(buffer, 0, 1024);
      }
      int count = length % 1024;
      if (count <= 0)
        return;
      stream.Read(buffer, 0, count);
      this.Write(buffer, 0, count);
    }

    public void WriteTo(Stream stream)
    {
      int index1 = (int) (this.long_1 / (long) this.int_1);
      for (int index2 = 0; index2 < index1; ++index2)
        stream.Write(this.list_0[index2], 0, this.int_1);
      int count = (int) (this.long_1 - (long) (index1 * this.int_1));
      if (count <= 0)
        return;
      stream.Write(this.list_0[index1], 0, count);
    }

    public void WriteTo(int offset, Stream stream, int length)
    {
      int index1 = offset / this.int_1;
      int num = length;
      int offset1 = offset % this.int_1;
      int count1 = System.Math.Min(length, this.int_1 - offset1);
      stream.Write(this.list_0[index1], offset1, count1);
      int index2 = index1 + 1;
      int count2 = num - count1;
      int index3;
      for (index3 = (offset + length) / this.int_1; index2 < index3; ++index2)
      {
        stream.Write(this.list_0[index2], 0, this.int_1);
        count2 -= this.int_1;
      }
      if (count2 <= 0)
        return;
      stream.Write(this.list_0[index3], 0, count2);
    }

    public List<byte[]> Pages
    {
      get
      {
        return this.list_0;
      }
    }

    public PagedMemoryStream Clone()
    {
      PagedMemoryStream pagedMemoryStream = new PagedMemoryStream((long) this.PageSize, this.PageSize);
      foreach (byte[] page in this.Pages)
      {
        byte[] numArray = new byte[page.Length];
        Array.Copy((Array) page, (Array) numArray, page.Length);
        pagedMemoryStream.Pages.Add(numArray);
      }
      pagedMemoryStream.SetLength(this.Length);
      return pagedMemoryStream;
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (this.imemoryPageCache_0 != null && this.bool_0)
      {
        foreach (byte[] page in this.list_0)
          this.imemoryPageCache_0.ReleasePage(page);
      }
      this.list_0.Clear();
    }

    private void method_0(Stream source, long length)
    {
      this.SetLength(length);
      int index1 = (int) (length / (long) this.int_1);
      for (int index2 = 0; index2 < index1; ++index2)
        source.Read(this.list_0[index2], 0, this.int_1);
      int count = (int) (length - (long) index1 * (long) this.int_1);
      if (count <= 0)
        return;
      source.Read(this.list_0[index1], 0, count);
    }

    private void method_1(byte[] source, long length)
    {
      this.SetLength(length);
      int index1 = (int) (length / (long) this.int_1);
      for (int index2 = 0; index2 < index1; ++index2)
        Array.Copy((Array) source, (long) index2 * (long) this.int_1, (Array) this.list_0[index2], 0L, (long) this.int_1);
      int num = (int) (length - (long) index1 * (long) this.int_1);
      if (num <= 0)
        return;
      Array.Copy((Array) source, (long) index1 * (long) this.int_1, (Array) this.list_0[index1], 0L, (long) num);
    }
  }
}
