// Decompiled with JetBrains decompiler
// Type: ns2.Class822
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using System.Text;
using WW.Cad.IO;

namespace ns2
{
  internal class Class822 : Interface33
  {
    protected BinaryReader binaryReader_0;
    private Encoding encoding_0;
    private MemoryStream memoryStream_0;
    private int int_0;

    internal Class822(BinaryReader r, Encoding encoding)
    {
      this.binaryReader_0 = r;
      this.encoding_0 = encoding;
      this.int_0 = 1;
      this.memoryStream_0 = new MemoryStream(100);
    }

    internal Encoding Encoding
    {
      get
      {
        return this.encoding_0;
      }
    }

    internal MemoryStream MemStream
    {
      get
      {
        return this.memoryStream_0;
      }
    }

    internal BinaryReader Reader
    {
      get
      {
        return this.binaryReader_0;
      }
    }

    protected internal virtual int vmethod_0()
    {
      try
      {
        int num = (int) this.binaryReader_0.ReadByte();
        if (num == (int) byte.MaxValue)
          num = (int) this.binaryReader_0.ReadInt16();
        return num;
      }
      catch (EndOfStreamException ex)
      {
        return int.MinValue;
      }
    }

    public Struct18 imethod_0(DxfReader dxfReader)
    {
      int code = this.vmethod_0();
      if (code == int.MinValue)
        return Struct18.struct18_0;
      ++this.int_0;
      try
      {
        object obj = Class820.GetValue(code, this);
        ++this.int_0;
        return new Struct18(code, obj);
      }
      catch (EndOfStreamException ex)
      {
        return Struct18.struct18_0;
      }
    }

    public Struct18 imethod_1(DxfReader dxfReader, int baseGroupCode)
    {
      int code = this.vmethod_0();
      if (code == int.MinValue)
        return Struct18.struct18_0;
      ++this.int_0;
      try
      {
        object obj = Class820.GetValue(baseGroupCode, this);
        ++this.int_0;
        return new Struct18(code, obj);
      }
      catch (EndOfStreamException ex)
      {
        return Struct18.struct18_0;
      }
    }

    public Struct18 imethod_2(DxfReader dxfReader)
    {
      return this.imethod_0(dxfReader);
    }

    public void imethod_3(bool close)
    {
      if (close && this.binaryReader_0 != null)
        this.binaryReader_0.Close();
      this.binaryReader_0 = (BinaryReader) null;
    }

    public string Position
    {
      get
      {
        return "byte " + this.binaryReader_0.BaseStream.Position.ToString() + " (line number " + this.int_0.ToString() + ")";
      }
    }
  }
}
