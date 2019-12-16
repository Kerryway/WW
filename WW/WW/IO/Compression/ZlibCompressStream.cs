// Decompiled with JetBrains decompiler
// Type: WW.IO.Compression.ZlibCompressStream
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.IO;
using System.IO.Compression;

namespace WW.IO.Compression
{
  public class ZlibCompressStream : DeflateStream
  {
    private uint uint_1 = 1;
    private const uint uint_0 = 65521;
    private uint uint_2;
    private bool bool_0;
    private Stream stream_0;

    public ZlibCompressStream(Stream stream)
      : base((Stream) new ZlibCompressStream.Stream0(stream), CompressionMode.Compress)
    {
      ((ZlibCompressStream.Stream0) this.BaseStream).Parent = this;
      this.stream_0 = this.BaseStream;
      this.method_2();
    }

    public ZlibCompressStream(Stream stream, bool leaveOpen)
      : base(leaveOpen ? stream : (Stream) new ZlibCompressStream.Stream0(stream), CompressionMode.Compress, leaveOpen)
    {
      if (!leaveOpen)
        ((ZlibCompressStream.Stream0) this.BaseStream).Parent = this;
      this.stream_0 = this.BaseStream;
      this.method_2();
    }

    public override bool CanSeek
    {
      get
      {
        return false;
      }
    }

    public override bool CanRead
    {
      get
      {
        return false;
      }
    }

    public override void Write(byte[] array, int offset, int count)
    {
      base.Write(array, offset, count);
      int index = offset;
      int num = 0;
      while (num < count)
      {
        this.uint_1 = (this.uint_1 + (uint) array[index]) % 65521U;
        this.uint_2 = (this.uint_2 + this.uint_1) % 65521U;
        ++num;
        ++index;
      }
    }

    public override void WriteByte(byte value)
    {
      this.uint_1 = (this.uint_1 + (uint) value) % 65521U;
      this.uint_2 = (this.uint_2 + this.uint_1) % 65521U;
      base.WriteByte(value);
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (this.stream_0 == null)
        return;
      if (!(this.stream_0 is ZlibCompressStream.Stream0) && !this.bool_0)
      {
        this.method_0(this.stream_0, this.method_1());
        this.bool_0 = true;
      }
      this.stream_0 = (Stream) null;
    }

    private void method_0(Stream stream, uint i)
    {
      stream.WriteByte((byte) (i >> 24 & (uint) byte.MaxValue));
      stream.WriteByte((byte) (i >> 16 & (uint) byte.MaxValue));
      stream.WriteByte((byte) (i >> 8 & (uint) byte.MaxValue));
      stream.WriteByte((byte) (i & (uint) byte.MaxValue));
    }

    private uint method_1()
    {
      return (this.uint_2 << 16) + this.uint_1;
    }

    private void method_2()
    {
      this.BaseStream.WriteByte((byte) 88);
      this.BaseStream.WriteByte((byte) 133);
    }

    private class Stream0 : Stream
    {
      private ZlibCompressStream zlibCompressStream_0;
      private Stream stream_0;

      public Stream0(Stream wrappedStream)
      {
        this.stream_0 = wrappedStream;
      }

      public ZlibCompressStream Parent
      {
        get
        {
          return this.zlibCompressStream_0;
        }
        set
        {
          this.zlibCompressStream_0 = value;
        }
      }

      public override void Flush()
      {
        this.stream_0.Flush();
      }

      public override long Seek(long offset, SeekOrigin origin)
      {
        throw new NotSupportedException();
      }

      public override void SetLength(long value)
      {
        this.stream_0.SetLength(value);
      }

      public override int Read(byte[] buffer, int offset, int count)
      {
        throw new NotSupportedException();
      }

      public override void Write(byte[] buffer, int offset, int count)
      {
        this.stream_0.Write(buffer, offset, count);
      }

      public override bool CanRead
      {
        get
        {
          return false;
        }
      }

      public override bool CanSeek
      {
        get
        {
          return false;
        }
      }

      public override bool CanWrite
      {
        get
        {
          return this.stream_0.CanWrite;
        }
      }

      public override long Length
      {
        get
        {
          return this.stream_0.Length;
        }
      }

      public override long Position
      {
        get
        {
          return this.stream_0.Position;
        }
        set
        {
          throw new NotSupportedException();
        }
      }

      protected override void Dispose(bool disposing)
      {
        if (this.stream_0 != null)
        {
          if (!this.zlibCompressStream_0.bool_0)
          {
            this.zlibCompressStream_0.method_0(this.stream_0, this.zlibCompressStream_0.method_1());
            this.zlibCompressStream_0.bool_0 = true;
          }
          this.stream_0.Dispose();
          this.stream_0 = (Stream) null;
        }
        base.Dispose(disposing);
      }
    }
  }
}
