// Decompiled with JetBrains decompiler
// Type: ns28.Stream0
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;

namespace ns28
{
  internal class Stream0 : Stream
  {
    private Interface30 interface30_0;
    private long long_0;
    private int int_0;
    private int int_1;

    public Stream0(Interface30 bitStreamReader, int length)
    {
      this.interface30_0 = bitStreamReader;
      this.int_1 = length;
      this.long_0 = bitStreamReader.imethod_3();
    }

    public bool method_0(out byte b)
    {
      bool flag;
      if (this.int_0 < this.int_1)
      {
        b = this.interface30_0.imethod_18();
        flag = true;
      }
      else
      {
        b = byte.MaxValue;
        flag = false;
      }
      ++this.int_0;
      return flag;
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
        return false;
      }
    }

    public override void Flush()
    {
      throw new NotImplementedException();
    }

    public override long Length
    {
      get
      {
        return (long) this.int_1;
      }
    }

    public override long Position
    {
      get
      {
        return (long) this.int_0;
      }
      set
      {
        this.int_0 = (int) value;
        this.interface30_0.imethod_4(this.long_0 + (long) this.int_0);
      }
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      int num = Math.Min(count, this.int_1 - this.int_0);
      this.int_0 += num;
      for (int index = 0; index < num; ++index)
        buffer[offset + index] = this.interface30_0.imethod_18();
      return num;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      throw new NotImplementedException();
    }

    public override void SetLength(long value)
    {
      throw new NotImplementedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      throw new NotImplementedException();
    }
  }
}
