// Decompiled with JetBrains decompiler
// Type: ns28.Class444
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns43;
using System;
using System.IO;
using System.Text;
using WW;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.IO;
using WW.Math;

namespace ns28
{
  internal abstract class Class444 : Interface30
  {
    protected static readonly ushort[] ushort_0 = new ushort[256]{ (ushort) 0, (ushort) 49345, (ushort) 49537, (ushort) 320, (ushort) 49921, (ushort) 960, (ushort) 640, (ushort) 49729, (ushort) 50689, (ushort) 1728, (ushort) 1920, (ushort) 51009, (ushort) 1280, (ushort) 50625, (ushort) 50305, (ushort) 1088, (ushort) 52225, (ushort) 3264, (ushort) 3456, (ushort) 52545, (ushort) 3840, (ushort) 53185, (ushort) 52865, (ushort) 3648, (ushort) 2560, (ushort) 51905, (ushort) 52097, (ushort) 2880, (ushort) 51457, (ushort) 2496, (ushort) 2176, (ushort) 51265, (ushort) 55297, (ushort) 6336, (ushort) 6528, (ushort) 55617, (ushort) 6912, (ushort) 56257, (ushort) 55937, (ushort) 6720, (ushort) 7680, (ushort) 57025, (ushort) 57217, (ushort) 8000, (ushort) 56577, (ushort) 7616, (ushort) 7296, (ushort) 56385, (ushort) 5120, (ushort) 54465, (ushort) 54657, (ushort) 5440, (ushort) 55041, (ushort) 6080, (ushort) 5760, (ushort) 54849, (ushort) 53761, (ushort) 4800, (ushort) 4992, (ushort) 54081, (ushort) 4352, (ushort) 53697, (ushort) 53377, (ushort) 4160, (ushort) 61441, (ushort) 12480, (ushort) 12672, (ushort) 61761, (ushort) 13056, (ushort) 62401, (ushort) 62081, (ushort) 12864, (ushort) 13824, (ushort) 63169, (ushort) 63361, (ushort) 14144, (ushort) 62721, (ushort) 13760, (ushort) 13440, (ushort) 62529, (ushort) 15360, (ushort) 64705, (ushort) 64897, (ushort) 15680, (ushort) 65281, (ushort) 16320, (ushort) 16000, (ushort) 65089, (ushort) 64001, (ushort) 15040, (ushort) 15232, (ushort) 64321, (ushort) 14592, (ushort) 63937, (ushort) 63617, (ushort) 14400, (ushort) 10240, (ushort) 59585, (ushort) 59777, (ushort) 10560, (ushort) 60161, (ushort) 11200, (ushort) 10880, (ushort) 59969, (ushort) 60929, (ushort) 11968, (ushort) 12160, (ushort) 61249, (ushort) 11520, (ushort) 60865, (ushort) 60545, (ushort) 11328, (ushort) 58369, (ushort) 9408, (ushort) 9600, (ushort) 58689, (ushort) 9984, (ushort) 59329, (ushort) 59009, (ushort) 9792, (ushort) 8704, (ushort) 58049, (ushort) 58241, (ushort) 9024, (ushort) 57601, (ushort) 8640, (ushort) 8320, (ushort) 57409, (ushort) 40961, (ushort) 24768, (ushort) 24960, (ushort) 41281, (ushort) 25344, (ushort) 41921, (ushort) 41601, (ushort) 25152, (ushort) 26112, (ushort) 42689, (ushort) 42881, (ushort) 26432, (ushort) 42241, (ushort) 26048, (ushort) 25728, (ushort) 42049, (ushort) 27648, (ushort) 44225, (ushort) 44417, (ushort) 27968, (ushort) 44801, (ushort) 28608, (ushort) 28288, (ushort) 44609, (ushort) 43521, (ushort) 27328, (ushort) 27520, (ushort) 43841, (ushort) 26880, (ushort) 43457, (ushort) 43137, (ushort) 26688, (ushort) 30720, (ushort) 47297, (ushort) 47489, (ushort) 31040, (ushort) 47873, (ushort) 31680, (ushort) 31360, (ushort) 47681, (ushort) 48641, (ushort) 32448, (ushort) 32640, (ushort) 48961, (ushort) 32000, (ushort) 48577, (ushort) 48257, (ushort) 31808, (ushort) 46081, (ushort) 29888, (ushort) 30080, (ushort) 46401, (ushort) 30464, (ushort) 47041, (ushort) 46721, (ushort) 30272, (ushort) 29184, (ushort) 45761, (ushort) 45953, (ushort) 29504, (ushort) 45313, (ushort) 29120, (ushort) 28800, (ushort) 45121, (ushort) 20480, (ushort) 37057, (ushort) 37249, (ushort) 20800, (ushort) 37633, (ushort) 21440, (ushort) 21120, (ushort) 37441, (ushort) 38401, (ushort) 22208, (ushort) 22400, (ushort) 38721, (ushort) 21760, (ushort) 38337, (ushort) 38017, (ushort) 21568, (ushort) 39937, (ushort) 23744, (ushort) 23936, (ushort) 40257, (ushort) 24320, (ushort) 40897, (ushort) 40577, (ushort) 24128, (ushort) 23040, (ushort) 39617, (ushort) 39809, (ushort) 23360, (ushort) 39169, (ushort) 22976, (ushort) 22656, (ushort) 38977, (ushort) 34817, (ushort) 18624, (ushort) 18816, (ushort) 35137, (ushort) 19200, (ushort) 35777, (ushort) 35457, (ushort) 19008, (ushort) 19968, (ushort) 36545, (ushort) 36737, (ushort) 20288, (ushort) 36097, (ushort) 19904, (ushort) 19584, (ushort) 35905, (ushort) 17408, (ushort) 33985, (ushort) 34177, (ushort) 17728, (ushort) 34561, (ushort) 18368, (ushort) 18048, (ushort) 34369, (ushort) 33281, (ushort) 17088, (ushort) 17280, (ushort) 33601, (ushort) 16640, (ushort) 33217, (ushort) 32897, (ushort) 16448 };
    protected readonly byte[] byte_4 = new byte[1];
    protected readonly byte[] byte_5 = new byte[4];
    protected readonly byte[] byte_6 = new byte[8];
    protected readonly byte[] byte_7 = new byte[8];
    protected const byte byte_0 = 127;
    protected const byte byte_1 = 63;
    protected const byte byte_2 = 128;
    protected DwgReader dwgReader_0;
    protected Stream stream_0;
    protected Encoding encoding_0;
    protected int int_0;
    protected byte byte_3;
    protected uint uint_0;
    private bool bool_0;

    public Class444(DwgReader dwgReader, Stream stream)
    {
      this.dwgReader_0 = dwgReader;
      this.stream_0 = stream;
    }

    public bool LoggingEnabled
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public Encoding Encoding
    {
      get
      {
        return this.encoding_0;
      }
      set
      {
        this.encoding_0 = value;
      }
    }

    public Stream Stream
    {
      get
      {
        return this.stream_0;
      }
    }

    public long StreamPosition
    {
      get
      {
        return this.stream_0.Position;
      }
      set
      {
        this.stream_0.Position = value;
        this.int_0 = 0;
      }
    }

    public int BitIndex
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public uint SizeInBits
    {
      get
      {
        return this.uint_0;
      }
      set
      {
        this.uint_0 = value;
      }
    }

    public static Interface30 Create(DxfVersion version, Stream stream)
    {
      return Class444.Create(version, stream, false);
    }

    public static Interface30 Create(
      DxfVersion version,
      Stream stream,
      bool enableLogging)
    {
      return Class444.Create(version, (DwgReader) null, stream, enableLogging);
    }

    public static Interface30 Create(
      DxfVersion version,
      DwgReader dwgReader,
      Stream stream,
      bool enableLogging)
    {
      if (version >= DxfVersion.Dxf13 && version < DxfVersion.Dxf15)
        return (Interface30) new Class445(dwgReader, stream);
      if (version < DxfVersion.Dxf18)
        return (Interface30) new Class446(dwgReader, stream);
      if (version < DxfVersion.Dxf21)
        return (Interface30) new Class447(dwgReader, stream);
      if (version < DxfVersion.Dxf24)
        return (Interface30) new Class448(dwgReader, stream);
      if (version >= DxfVersion.Dxf24 && version <= DxfVersion.Dxf27)
        return (Interface30) new Class449(dwgReader, stream);
      throw new DxfException("Version " + version.ToString() + " not supported.");
    }

    public void imethod_54(Stream stream, uint sizeInBits)
    {
      this.stream_0 = stream;
      this.int_0 = 0;
      this.byte_3 = (byte) 0;
      this.uint_0 = sizeInBits;
    }

    public abstract double imethod_17();

    public abstract Vector3D imethod_9();

    public abstract Vector3D imethod_10();

    public void imethod_4(long bitPosition)
    {
      this.StreamPosition = bitPosition >> 3;
      this.int_0 = (int) (bitPosition & 7L);
      if (this.int_0 == 0)
        return;
      this.method_6();
    }

    public long imethod_3()
    {
      long num = this.stream_0.Position * 8L;
      if (this.int_0 != 0)
        num += (long) (this.int_0 - 8);
      return num;
    }

    public long imethod_5(long stringStreamEndBitPosition)
    {
      this.imethod_4(stringStreamEndBitPosition);
      bool flag = this.imethod_6();
      long bitPosition = stringStreamEndBitPosition;
      if (flag)
      {
        long stringStreamSizePositionInBits;
        long stringDataSizeInBits;
        this.vmethod_0(stringStreamEndBitPosition, out stringStreamSizePositionInBits, out stringDataSizeInBits);
        bitPosition = stringStreamSizePositionInBits - stringDataSizeInBits;
        this.uint_0 = (uint) stringStreamSizePositionInBits;
        this.imethod_4(bitPosition);
      }
      else
        this.uint_0 = 0U;
      return bitPosition;
    }

    protected virtual void vmethod_0(
      long stringStreamEndBitPosition,
      out long stringStreamSizePositionInBits,
      out long stringDataSizeInBits)
    {
      stringStreamSizePositionInBits = stringStreamEndBitPosition - 16L;
      this.imethod_4(stringStreamSizePositionInBits);
      stringDataSizeInBits = (long) this.method_4();
      if ((stringDataSizeInBits & 32768L) == 0L)
        return;
      stringStreamSizePositionInBits -= 16L;
      this.imethod_4(stringStreamSizePositionInBits);
      stringDataSizeInBits &= (long) short.MaxValue;
      int num = (int) this.method_4();
      stringDataSizeInBits += (long) ((num & (int) ushort.MaxValue) << 15);
    }

    public byte imethod_18()
    {
      if (this.int_0 == 0)
      {
        if (this.stream_0.Read(this.byte_4, 0, 1) != 1)
          throw new EndOfStreamException();
        this.byte_3 = this.byte_4[0];
        return this.byte_3;
      }
      byte num = (byte) ((uint) this.byte_3 << this.int_0);
      if (this.stream_0.Read(this.byte_4, 0, 1) != 1)
        throw new EndOfStreamException();
      this.byte_3 = this.byte_4[0];
      return (byte) ((uint) num | (uint) (byte) ((uint) this.byte_3 >> 8 - this.int_0));
    }

    public void imethod_52(int n)
    {
      if (n > 1)
        this.stream_0.Position += (long) (n - 1);
      int num = (int) this.imethod_18();
    }

    public bool imethod_6()
    {
      if (this.int_0 == 0)
      {
        this.method_6();
        bool flag = ((int) this.byte_3 & 128) == 128;
        this.int_0 = 1;
        return flag;
      }
      bool flag1 = ((int) this.byte_3 << this.int_0 & 128) == 128;
      ++this.int_0;
      this.int_0 &= 7;
      return flag1;
    }

    public short imethod_7()
    {
      return !this.imethod_6() ? (short) 0 : (short) 1;
    }

    public byte imethod_13()
    {
      byte num1;
      if (this.int_0 == 0)
      {
        this.method_6();
        num1 = (byte) ((uint) this.byte_3 >> 6);
        this.int_0 = 2;
      }
      else if (this.int_0 == 7)
      {
        byte num2 = (byte) ((int) this.byte_3 << 1 & 2);
        this.method_6();
        num1 = (byte) ((uint) num2 | (uint) (byte) ((uint) this.byte_3 >> 7));
        this.int_0 = 1;
      }
      else
      {
        num1 = (byte) ((int) this.byte_3 >> 6 - this.int_0 & 3);
        ++this.int_0;
        ++this.int_0;
        this.int_0 &= 7;
      }
      return num1;
    }

    public unsafe short imethod_14()
    {
      short num;
      switch (this.imethod_13())
      {
        case 0:
          fixed (byte* pointer = this.byte_5)
          {
            this.method_0(pointer);
            num = LittleEndianBitConverter.ToInt16(this.byte_5);
          }
          break;
        case 1:
          if (this.int_0 == 0)
          {
            this.method_6();
            num = (short) this.byte_3;
            break;
          }
          num = (short) this.method_7();
          break;
        case 2:
          num = (short) 0;
          break;
        case 3:
          num = (short) 256;
          break;
        default:
          throw new DxfException("Illegal short.");
      }
      return num;
    }

    public bool imethod_15()
    {
      return this.imethod_14() != (short) 0;
    }

    public Color imethod_16()
    {
      return Color.CreateFromColorIndex(this.imethod_14());
    }

    public unsafe int imethod_11()
    {
      int num;
      switch (this.imethod_13())
      {
        case 0:
          fixed (byte* pointer = this.byte_5)
          {
            this.method_1(pointer);
            num = LittleEndianBitConverter.ToInt32(this.byte_5);
          }
          break;
        case 1:
          if (this.int_0 == 0)
          {
            this.method_6();
            num = (int) this.byte_3;
            break;
          }
          num = (int) this.method_7();
          break;
        case 2:
          num = 0;
          break;
        default:
          throw new DxfException("Illegal int.");
      }
      return num;
    }

    public virtual long imethod_12()
    {
      throw new NotImplementedException();
    }

    public double imethod_8()
    {
      double num;
      switch (this.imethod_13())
      {
        case 0:
          num = this.imethod_42();
          break;
        case 1:
          num = 1.0;
          break;
        case 2:
          num = 0.0;
          break;
        default:
          throw new DxfException("Illegal double.");
      }
      return num;
    }

    public unsafe double imethod_42()
    {
      double num;
      fixed (byte* pointer = this.byte_6)
      {
        this.method_2(pointer);
        num = LittleEndianBitConverter.ToDouble(this.byte_6);
      }
      return num;
    }

    private unsafe void method_0(byte* pointer)
    {
      if (this.stream_0.Read(this.byte_7, 0, 2) < 2)
        throw new EndOfStreamException();
      fixed (byte* numPtr1 = this.byte_7)
      {
        if (this.int_0 == 0)
        {
          byte* numPtr2 = pointer++;
          byte* numPtr3 = numPtr1;
          byte* numPtr4 = numPtr3 + 1;
          int num = (int) *numPtr3;
          *numPtr2 = (byte) num;
          *pointer = *numPtr4;
        }
        else
        {
          int num1 = 8 - this.int_0;
          byte num2 = (byte) ((uint) this.byte_3 << this.int_0);
          byte* numPtr2 = numPtr1;
          byte* numPtr3 = numPtr2 + 1;
          this.byte_3 = *numPtr2;
          byte num3 = (byte) ((uint) num2 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num3;
          ++pointer;
          byte num4 = (byte) ((uint) this.byte_3 << this.int_0);
          this.byte_3 = *numPtr3;
          byte num5 = (byte) ((uint) num4 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num5;
        }
      }
    }

    private unsafe void method_1(byte* pointer)
    {
      if (this.stream_0.Read(this.byte_7, 0, 4) < 4)
        throw new EndOfStreamException();
      fixed (byte* numPtr1 = this.byte_7)
      {
        if (this.int_0 == 0)
        {
          byte* numPtr2 = pointer++;
          byte* numPtr3 = numPtr1;
          byte* numPtr4 = numPtr3 + 1;
          int num1 = (int) *numPtr3;
          *numPtr2 = (byte) num1;
          byte* numPtr5 = pointer++;
          byte* numPtr6 = numPtr4;
          byte* numPtr7 = numPtr6 + 1;
          int num2 = (int) *numPtr6;
          *numPtr5 = (byte) num2;
          byte* numPtr8 = pointer++;
          byte* numPtr9 = numPtr7;
          byte* numPtr10 = numPtr9 + 1;
          int num3 = (int) *numPtr9;
          *numPtr8 = (byte) num3;
          *pointer = *numPtr10;
        }
        else
        {
          int num1 = 8 - this.int_0;
          byte num2 = (byte) ((uint) this.byte_3 << this.int_0);
          byte* numPtr2 = numPtr1;
          byte* numPtr3 = numPtr2 + 1;
          this.byte_3 = *numPtr2;
          byte num3 = (byte) ((uint) num2 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num3;
          ++pointer;
          byte num4 = (byte) ((uint) this.byte_3 << this.int_0);
          byte* numPtr4 = numPtr3;
          byte* numPtr5 = numPtr4 + 1;
          this.byte_3 = *numPtr4;
          byte num5 = (byte) ((uint) num4 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num5;
          ++pointer;
          byte num6 = (byte) ((uint) this.byte_3 << this.int_0);
          byte* numPtr6 = numPtr5;
          byte* numPtr7 = numPtr6 + 1;
          this.byte_3 = *numPtr6;
          byte num7 = (byte) ((uint) num6 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num7;
          ++pointer;
          byte num8 = (byte) ((uint) this.byte_3 << this.int_0);
          this.byte_3 = *numPtr7;
          byte num9 = (byte) ((uint) num8 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num9;
        }
      }
    }

    private unsafe void method_2(byte* pointer)
    {
      if (this.stream_0.Read(this.byte_7, 0, 8) < 8)
        throw new EndOfStreamException();
      fixed (byte* numPtr1 = this.byte_7)
      {
        byte* numPtr2 = numPtr1;
        if (this.int_0 == 0)
        {
          for (int index = 0; index < 8; ++index)
            *pointer++ = *numPtr2++;
        }
        else
        {
          int num1 = 8 - this.int_0;
          byte num2 = (byte) ((uint) this.byte_3 << this.int_0);
          byte* numPtr3 = numPtr2;
          byte* numPtr4 = numPtr3 + 1;
          this.byte_3 = *numPtr3;
          byte num3 = (byte) ((uint) num2 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num3;
          ++pointer;
          byte num4 = (byte) ((uint) this.byte_3 << this.int_0);
          byte* numPtr5 = numPtr4;
          byte* numPtr6 = numPtr5 + 1;
          this.byte_3 = *numPtr5;
          byte num5 = (byte) ((uint) num4 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num5;
          ++pointer;
          byte num6 = (byte) ((uint) this.byte_3 << this.int_0);
          byte* numPtr7 = numPtr6;
          byte* numPtr8 = numPtr7 + 1;
          this.byte_3 = *numPtr7;
          byte num7 = (byte) ((uint) num6 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num7;
          ++pointer;
          byte num8 = (byte) ((uint) this.byte_3 << this.int_0);
          byte* numPtr9 = numPtr8;
          byte* numPtr10 = numPtr9 + 1;
          this.byte_3 = *numPtr9;
          byte num9 = (byte) ((uint) num8 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num9;
          ++pointer;
          byte num10 = (byte) ((uint) this.byte_3 << this.int_0);
          byte* numPtr11 = numPtr10;
          byte* numPtr12 = numPtr11 + 1;
          this.byte_3 = *numPtr11;
          byte num11 = (byte) ((uint) num10 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num11;
          ++pointer;
          byte num12 = (byte) ((uint) this.byte_3 << this.int_0);
          byte* numPtr13 = numPtr12;
          byte* numPtr14 = numPtr13 + 1;
          this.byte_3 = *numPtr13;
          byte num13 = (byte) ((uint) num12 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num13;
          ++pointer;
          byte num14 = (byte) ((uint) this.byte_3 << this.int_0);
          byte* numPtr15 = numPtr14;
          byte* numPtr16 = numPtr15 + 1;
          this.byte_3 = *numPtr15;
          byte num15 = (byte) ((uint) num14 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num15;
          ++pointer;
          byte num16 = (byte) ((uint) this.byte_3 << this.int_0);
          this.byte_3 = *numPtr16;
          byte num17 = (byte) ((uint) num16 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *pointer = num17;
        }
      }
    }

    public int imethod_35()
    {
      int num1;
      if (this.int_0 == 0)
      {
        int num2 = 0;
        this.method_6();
        if (((int) this.byte_3 & 128) == 0)
        {
          num1 = (int) this.byte_3 & 63;
          if (((int) this.byte_3 & 64) != 0)
            num1 = -num1;
        }
        else
        {
          int num3 = (int) this.byte_3 & (int) sbyte.MaxValue;
          while (true)
          {
            num2 += 7;
            this.method_6();
            if (((int) this.byte_3 & 128) != 0)
              num3 |= ((int) this.byte_3 & (int) sbyte.MaxValue) << num2;
            else
              break;
          }
          num1 = num3 | ((int) this.byte_3 & 63) << num2;
          if (((int) this.byte_3 & 64) != 0)
            num1 = -num1;
        }
      }
      else
      {
        int num2 = 0;
        byte num3 = this.method_7();
        if (((int) num3 & 128) == 0)
        {
          num1 = (int) num3 & 63;
          if (((int) num3 & 64) != 0)
            num1 = -num1;
        }
        else
        {
          int num4 = (int) num3 & (int) sbyte.MaxValue;
          byte num5;
          while (true)
          {
            num2 += 7;
            num5 = this.method_7();
            if (((int) num5 & 128) != 0)
              num4 |= ((int) num5 & (int) sbyte.MaxValue) << num2;
            else
              break;
          }
          num1 = num4 | ((int) num5 & 63) << num2;
          if (((int) num5 & 64) != 0)
            num1 = -num1;
        }
      }
      return num1;
    }

    public WW.Math.Point2D imethod_38()
    {
      return new WW.Math.Point2D(this.imethod_42(), this.imethod_42());
    }

    public WW.Math.Point2D imethod_37(WW.Math.Point2D defaultPoint)
    {
      return new WW.Math.Point2D(this.imethod_29(defaultPoint.X), this.imethod_29(defaultPoint.Y));
    }

    public Vector2D imethod_50()
    {
      return new Vector2D(this.imethod_42(), this.imethod_42());
    }

    public Vector2D imethod_49()
    {
      return new Vector2D(this.imethod_8(), this.imethod_8());
    }

    public WW.Math.Point2D imethod_36()
    {
      return new WW.Math.Point2D(this.imethod_8(), this.imethod_8());
    }

    public WW.Math.Point3D imethod_41()
    {
      return new WW.Math.Point3D(this.imethod_42(), this.imethod_42(), this.imethod_42());
    }

    public WW.Math.Point3D imethod_39()
    {
      return new WW.Math.Point3D(this.imethod_8(), this.imethod_8(), this.imethod_8());
    }

    public WW.Math.Point3D imethod_40(WW.Math.Point3D defaultPoint)
    {
      return new WW.Math.Point3D(this.imethod_29(defaultPoint.X), this.imethod_29(defaultPoint.Y), this.imethod_29(defaultPoint.Z));
    }

    public Vector3D imethod_51()
    {
      return new Vector3D(this.imethod_8(), this.imethod_8(), this.imethod_8());
    }

    public unsafe double imethod_29(double defaultValue)
    {
      byte num1 = this.imethod_13();
      switch (num1)
      {
        case 0:
          return defaultValue;
        case 1:
          byte[] bytes1 = LittleEndianBitConverter.GetBytes(defaultValue);
          fixed (byte* numPtr1 = bytes1)
          {
            if (this.int_0 == 0)
            {
              this.method_6();
              numPtr1[0] = this.byte_3;
              byte* numPtr2 = numPtr1 + 1;
              this.method_6();
              *numPtr2 = this.byte_3;
              byte* numPtr3 = numPtr2 + 1;
              this.method_6();
              *numPtr3 = this.byte_3;
              byte* numPtr4 = numPtr3 + 1;
              this.method_6();
              *numPtr4 = this.byte_3;
            }
            else
            {
              numPtr1[0] = (byte) ((uint) this.byte_3 << this.int_0);
              this.method_6();
              byte* numPtr2 = numPtr1;
              int num2 = (int) (byte) ((uint) *numPtr2 | (uint) (byte) ((uint) this.byte_3 >> 8 - this.int_0));
              *numPtr2 = (byte) num2;
              byte* numPtr3 = numPtr1 + 1;
              *numPtr3 = (byte) ((uint) this.byte_3 << this.int_0);
              this.method_6();
              byte* numPtr4 = numPtr3;
              int num3 = (int) (byte) ((uint) *numPtr4 | (uint) (byte) ((uint) this.byte_3 >> 8 - this.int_0));
              *numPtr4 = (byte) num3;
              byte* numPtr5 = numPtr3 + 1;
              *numPtr5 = (byte) ((uint) this.byte_3 << this.int_0);
              this.method_6();
              byte* numPtr6 = numPtr5;
              int num4 = (int) (byte) ((uint) *numPtr6 | (uint) (byte) ((uint) this.byte_3 >> 8 - this.int_0));
              *numPtr6 = (byte) num4;
              byte* numPtr7 = numPtr5 + 1;
              *numPtr7 = (byte) ((uint) this.byte_3 << this.int_0);
              this.method_6();
              byte* numPtr8 = numPtr7;
              int num5 = (int) (byte) ((uint) *numPtr8 | (uint) (byte) ((uint) this.byte_3 >> 8 - this.int_0));
              *numPtr8 = (byte) num5;
            }
          }
          return LittleEndianBitConverter.ToDouble(bytes1);
        case 2:
          byte[] bytes2 = LittleEndianBitConverter.GetBytes(defaultValue);
          if (this.int_0 == 0)
          {
            this.method_6();
            bytes2[4] = this.byte_3;
            this.method_6();
            bytes2[5] = this.byte_3;
            this.method_6();
            bytes2[0] = this.byte_3;
            this.method_6();
            bytes2[1] = this.byte_3;
            this.method_6();
            bytes2[2] = this.byte_3;
            this.method_6();
            bytes2[3] = this.byte_3;
          }
          else
          {
            bytes2[4] = (byte) ((uint) this.byte_3 << this.int_0);
            this.method_6();
            bytes2[4] |= (byte) ((uint) this.byte_3 >> 8 - this.int_0);
            bytes2[5] = (byte) ((uint) this.byte_3 << this.int_0);
            this.method_6();
            bytes2[5] |= (byte) ((uint) this.byte_3 >> 8 - this.int_0);
            bytes2[0] = (byte) ((uint) this.byte_3 << this.int_0);
            this.method_6();
            bytes2[0] |= (byte) ((uint) this.byte_3 >> 8 - this.int_0);
            bytes2[1] = (byte) ((uint) this.byte_3 << this.int_0);
            this.method_6();
            bytes2[1] |= (byte) ((uint) this.byte_3 >> 8 - this.int_0);
            bytes2[2] = (byte) ((uint) this.byte_3 << this.int_0);
            this.method_6();
            bytes2[2] |= (byte) ((uint) this.byte_3 >> 8 - this.int_0);
            bytes2[3] = (byte) ((uint) this.byte_3 << this.int_0);
            this.method_6();
            bytes2[3] |= (byte) ((uint) this.byte_3 >> 8 - this.int_0);
          }
          return LittleEndianBitConverter.ToDouble(bytes2);
        case 3:
          return this.imethod_42();
        default:
          throw new DxfException("Illegal double type. " + num1.ToString());
      }
    }

    public ulong imethod_31()
    {
      return this.imethod_32(false);
    }

    public ulong imethod_32(bool enqueueForRead)
    {
      ReferenceType referenceType;
      return this.imethod_34(0UL, enqueueForRead, out referenceType);
    }

    public ulong imethod_33(ulong referenceHandle, bool enqueueForRead)
    {
      ReferenceType referenceType;
      return this.imethod_34(referenceHandle, enqueueForRead, out referenceType);
    }

    public ulong imethod_34(
      ulong referenceHandle,
      bool enqueueForRead,
      out ReferenceType referenceType)
    {
      byte num1 = this.imethod_18();
      int count = (int) num1 & 15;
      byte num2 = (byte) ((uint) num1 >> 4);
      referenceType = (ReferenceType) ((uint) num2 & 3U);
      ulong num3;
      if (num2 <= (byte) 5)
        num3 = this.method_3(count);
      else if (num2 == (byte) 6)
        num3 = ++referenceHandle;
      else if (num2 == (byte) 8)
        num3 = --referenceHandle;
      else if (num2 == (byte) 10)
      {
        ulong num4 = this.method_3(count);
        num3 = referenceHandle + num4;
      }
      else
      {
        if (num2 != (byte) 12)
          throw new DxfException("Unknown handle type: " + num2.ToString());
        ulong num4 = this.method_3(count);
        num3 = referenceHandle - num4;
      }
      if (enqueueForRead && num3 != 0UL && this.dwgReader_0 != null)
        this.dwgReader_0.OwnedObjectHandles.Enqueue(num3);
      return num3;
    }

    private unsafe ulong method_3(int count)
    {
      if (this.stream_0.Read(this.byte_7, 0, count) < count)
        throw new EndOfStreamException();
      fixed (byte* numPtr1 = this.byte_6)
      {
        if (this.int_0 == 0)
        {
          byte* numPtr2 = numPtr1 + count - 1;
          fixed (byte* numPtr3 = this.byte_7)
          {
            byte* numPtr4 = numPtr3;
            for (int index = 0; index < count; ++index)
              *numPtr2-- = *numPtr4++;
          }
        }
        else
        {
          int num1 = 8 - this.int_0;
          byte* numPtr2 = numPtr1 + count - 1;
          fixed (byte* numPtr3 = this.byte_7)
          {
            byte* numPtr4 = numPtr3;
            for (int index = 0; index < count; ++index)
            {
              byte num2 = (byte) ((uint) this.byte_3 << this.int_0);
              this.byte_3 = *numPtr4++;
              byte num3 = (byte) ((uint) num2 | (uint) (byte) ((uint) this.byte_3 >> num1));
              *numPtr2-- = num3;
            }
          }
        }
        byte* numPtr5 = numPtr1 + count;
        for (int index = count; index < 8; ++index)
          *numPtr5++ = (byte) 0;
      }
      return LittleEndianBitConverter.ToUInt64(this.byte_6);
    }

    public abstract Color imethod_23(Interface30 stringReader);

    public Color imethod_22()
    {
      return this.imethod_23((Interface30) this);
    }

    public abstract Color imethod_25(Interface30 stringReader);

    public Color imethod_24()
    {
      return this.imethod_25((Interface30) this);
    }

    public abstract void imethod_26(
      out EntityColor color,
      out Transparency transparency,
      out bool isColorBookColor);

    public unsafe ushort imethod_2(ushort initialCrc, byte[] bytes)
    {
      ushort num1 = initialCrc;
      fixed (byte* numPtr1 = bytes)
      {
        byte* numPtr2 = numPtr1;
        int length = bytes.Length;
        while (length-- > 0)
        {
          byte num2 = (byte) ((uint) *numPtr2 ^ (uint) (byte) ((uint) num1 & (uint) byte.MaxValue));
          num1 = (ushort) ((uint) (ushort) ((int) num1 >> 8 & (int) byte.MaxValue) ^ (uint) Class444.ushort_0[(int) num2 & (int) byte.MaxValue]);
          ++numPtr2;
        }
      }
      return num1;
    }

    public unsafe short imethod_45()
    {
      short int16;
      fixed (byte* pointer = this.byte_5)
      {
        this.method_0(pointer);
        int16 = LittleEndianBitConverter.ToInt16(this.byte_5);
      }
      return int16;
    }

    public unsafe ushort method_4()
    {
      ushort uint16;
      fixed (byte* pointer = this.byte_5)
      {
        this.method_0(pointer);
        uint16 = LittleEndianBitConverter.ToUInt16(this.byte_5);
      }
      return uint16;
    }

    public unsafe int imethod_43()
    {
      int int32;
      fixed (byte* pointer = this.byte_5)
      {
        this.method_1(pointer);
        int32 = LittleEndianBitConverter.ToInt32(this.byte_5);
      }
      return int32;
    }

    public unsafe uint imethod_44()
    {
      uint uint32;
      fixed (byte* pointer = this.byte_5)
      {
        this.method_1(pointer);
        uint32 = LittleEndianBitConverter.ToUInt32(this.byte_5);
      }
      return uint32;
    }

    public unsafe ulong imethod_46()
    {
      ulong uint64;
      fixed (byte* pointer = this.byte_6)
      {
        this.method_2(pointer);
        uint64 = LittleEndianBitConverter.ToUInt64(this.byte_6);
      }
      return uint64;
    }

    public unsafe ulong imethod_47()
    {
      ulong uint64;
      fixed (byte* pointer = this.byte_6)
      {
        this.method_2(pointer);
        uint64 = BigEndianBitConverter.ToUInt64(this.byte_6);
      }
      return uint64;
    }

    public abstract string ReadString();

    public abstract string imethod_30();

    public ushort imethod_27()
    {
      if (this.int_0 != 0)
        this.int_0 = 0;
      this.method_6();
      ushort byte3 = (ushort) this.byte_3;
      this.method_6();
      return (ushort) ((uint) byte3 | (uint) (ushort) ((uint) this.byte_3 << 8));
    }

    public void imethod_53(int position)
    {
      this.stream_0.Seek((long) position - this.stream_0.Position, SeekOrigin.Current);
      this.int_0 = 0;
    }

    public DateTime imethod_28()
    {
      DateTime dateTime = Class644.smethod_4((double) this.imethod_11());
      double num = (double) this.imethod_11();
      if (dateTime == DateTime.MaxValue)
        return dateTime;
      dateTime = dateTime.AddMilliseconds(num);
      return dateTime;
    }

    public DxfTimeSpan imethod_48()
    {
      return new DxfTimeSpan(this.imethod_11(), this.imethod_11());
    }

    public virtual short imethod_55()
    {
      return this.imethod_14();
    }

    public void imethod_0(int byteCount)
    {
      long bitPosition = this.imethod_3();
      int bitIndex = this.BitIndex;
      StringBuilder stringBuilder = new StringBuilder(byteCount * 8);
      for (int index1 = 0; index1 < byteCount; ++index1)
      {
        byte num = this.imethod_18();
        for (int index2 = 7; index2 >= 0; --index2)
        {
          if (((int) num >> index2 & 1) == 1)
            stringBuilder.Append("1");
          else
            stringBuilder.Append("0");
        }
      }
      this.imethod_4(bitPosition);
    }

    public void imethod_1(int byteCount)
    {
      long bitPosition = this.imethod_3();
      StringBuilder stringBuilder = new StringBuilder(byteCount * 8);
      byte num1 = this.imethod_18();
      stringBuilder.Append(num1.ToString("x"));
      for (int index = 1; index < byteCount; ++index)
      {
        byte num2 = this.imethod_18();
        stringBuilder.Append(' ');
        stringBuilder.Append(num2.ToString("x2"));
      }
      this.imethod_4(bitPosition);
    }

    protected void method_5()
    {
      if (this.int_0 != 0)
        return;
      this.method_6();
    }

    public void method_6()
    {
      if (this.stream_0.Read(this.byte_4, 0, 1) == 0)
        throw new EndOfStreamException();
      this.byte_3 = this.byte_4[0];
    }

    protected byte method_7()
    {
      byte num = (byte) ((uint) this.byte_3 << this.int_0);
      this.method_6();
      return (byte) ((uint) num | (uint) (byte) ((uint) this.byte_3 >> 8 - this.int_0));
    }

    public byte[] imethod_19(int length)
    {
      byte[] bytes = new byte[length];
      this.method_8(length, bytes);
      return bytes;
    }

    private unsafe void method_8(int length, byte[] bytes)
    {
      if (this.stream_0.Read(bytes, 0, length) != length)
        throw new EndOfStreamException();
      if (this.int_0 == 0)
        return;
      fixed (byte* numPtr1 = bytes)
      {
        byte* numPtr2 = numPtr1;
        int num1 = 8 - this.int_0;
        for (int index = 0; index < length; ++index)
        {
          byte num2 = (byte) ((uint) this.byte_3 << this.int_0);
          this.byte_3 = *numPtr2;
          byte num3 = (byte) ((uint) num2 | (uint) (byte) ((uint) this.byte_3 >> num1));
          *numPtr2++ = num3;
        }
      }
    }

    public void imethod_20(int length, PagedMemoryStream targetStream)
    {
      this.method_9(length, targetStream, true);
    }

    private void method_9(int length, PagedMemoryStream targetStream, bool setTargetStreamLength)
    {
      if (setTargetStreamLength && (long) (targetStream.Pages.Count * targetStream.PageSize) - targetStream.Position < (long) length)
        targetStream.SetLength(targetStream.Position + (long) length);
      int val1 = length;
      for (int index = 0; index < targetStream.Pages.Count; ++index)
      {
        byte[] page = targetStream.Pages[index];
        int length1 = System.Math.Min(val1, targetStream.PageSize);
        this.method_8(length1, page);
        val1 -= length1;
        if (val1 <= 0)
          break;
      }
      targetStream.Position += (long) length;
    }

    public uint imethod_21(PagedMemoryStream targetStream)
    {
      if (this.uint_0 == 0U)
        return 0;
      uint num1 = (uint) ((ulong) this.uint_0 - (ulong) this.imethod_3());
      int length = (int) (num1 + 7U >> 3);
      int num2 = (int) (num1 % 8U);
      if (num2 == 0)
      {
        this.method_9(length, targetStream, true);
      }
      else
      {
        if (targetStream.Length - targetStream.Position < (long) length)
          targetStream.SetLength(targetStream.Position + (long) length);
        this.method_9(length - 1, targetStream, false);
        byte num3 = 0;
        for (int index = 0; index < num2; ++index)
        {
          num3 <<= 1;
          if (this.imethod_6())
            num3 |= (byte) 1;
        }
        byte num4 = (byte) ((uint) num3 << 8 - num2);
        targetStream.WriteByte(num4);
      }
      return num1;
    }
  }
}
