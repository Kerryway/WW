// Decompiled with JetBrains decompiler
// Type: ns28.Class724
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns34;
using ns35;
using ns43;
using System;
using System.IO;
using System.Text;
using WW;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.IO;
using WW.Math;

namespace ns28
{
  internal abstract class Class724 : Interface29, Interface40
  {
    protected const byte byte_0 = 127;
    protected const byte byte_1 = 63;
    protected const byte byte_2 = 128;
    private Stream stream_0;
    private int int_0;
    private byte byte_3;
    private int int_1;
    private Encoding encoding_0;
    private DxfVersion dxfVersion_0;

    protected Class724(Stream stream, Encoding encoding, DxfVersion version)
    {
      this.stream_0 = stream;
      this.encoding_0 = encoding;
      this.dxfVersion_0 = version;
      this.int_1 = (int) Class952.smethod_1((DrawingCodePage) encoding.CodePage);
    }

    public Stream Stream
    {
      get
      {
        return this.stream_0;
      }
    }

    public DxfVersion Version
    {
      get
      {
        return this.dxfVersion_0;
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
      }
    }

    public int BitIndex
    {
      get
      {
        return this.int_0;
      }
    }

    public Encoding Encoding
    {
      get
      {
        return this.encoding_0;
      }
    }

    public virtual Encoding EffectiveEncoding
    {
      get
      {
        return this.encoding_0;
      }
    }

    public int DwgCodePage
    {
      get
      {
        return this.int_1;
      }
    }

    public Interface40 MainBitStreamWriter
    {
      get
      {
        return (Interface40) this;
      }
    }

    public Interface40 StringBitStreamWriter
    {
      get
      {
        return (Interface40) this;
      }
    }

    public Interface40 HandleBitStreamWriter
    {
      get
      {
        return (Interface40) this;
      }
    }

    public long HandleStreamBitPosition
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public static Interface29 smethod_0(
      DxfVersion version,
      Stream stream,
      Encoding encoding)
    {
      if (version >= DxfVersion.Dxf13 && version < DxfVersion.Dxf15)
        return (Interface29) new Class725(stream, encoding, version);
      if (version < DxfVersion.Dxf18)
        return (Interface29) new Class726(stream, encoding, version);
      if (version < DxfVersion.Dxf21)
        return (Interface29) new Class727(stream, encoding, version);
      if (version == DxfVersion.Dxf21)
        return (Interface29) new Class728(stream, encoding, version);
      if (version < DxfVersion.Dxf24 && version > DxfVersion.Dxf27)
        throw new InternalException("Version " + version.ToString() + " not supported.");
      return (Interface29) new Class729(stream, encoding, version);
    }

    public static Interface29 Create(
      DxfVersion version,
      Stream stream,
      Encoding encoding)
    {
      if (version >= DxfVersion.Dxf13 && version < DxfVersion.Dxf15)
        return (Interface29) new Class725(stream, encoding, version);
      if (version < DxfVersion.Dxf18)
        return (Interface29) new Class726(stream, encoding, version);
      if (version < DxfVersion.Dxf21)
        return (Interface29) new Class727(stream, encoding, version);
      if (version == DxfVersion.Dxf21)
        return (Interface29) new Class990(stream, (Interface40) new Class728(stream, encoding, version), (Interface40) new Class728((Stream) new MemoryStream(), encoding, version), (Interface40) new Class728((Stream) new MemoryStream(), encoding, version));
      if (version < DxfVersion.Dxf24 && version > DxfVersion.Dxf27)
        throw new InternalException("Version " + version.ToString() + " not supported.");
      return (Interface29) new Class990(stream, (Interface40) new Class729(stream, encoding, version), (Interface40) new Class729((Stream) new MemoryStream(), encoding, version), (Interface40) new Class729((Stream) new MemoryStream(), encoding, version));
    }

    public static Interface29 smethod_1(
      DxfVersion version,
      Stream stream,
      Encoding encoding)
    {
      if (version >= DxfVersion.Dxf13 && version < DxfVersion.Dxf15)
        return (Interface29) new Class440(stream, (Interface40) new Class725(stream, encoding, version), (Interface40) new Class725((Stream) new MemoryStream(), encoding, version));
      if (version < DxfVersion.Dxf18)
        return (Interface29) new Class440(stream, (Interface40) new Class726(stream, encoding, version), (Interface40) new Class726((Stream) new MemoryStream(), encoding, version));
      if (version < DxfVersion.Dxf21)
        return (Interface29) new Class440(stream, (Interface40) new Class727(stream, encoding, version), (Interface40) new Class727((Stream) new MemoryStream(), encoding, version));
      if (version == DxfVersion.Dxf21)
        return (Interface29) new Class990(stream, (Interface40) new Class728(stream, encoding, version), (Interface40) new Class728((Stream) new MemoryStream(), encoding, version), (Interface40) new Class728((Stream) new MemoryStream(), encoding, version));
      if (version <= DxfVersion.Dxf21)
        throw new InternalException("Version " + version.ToString() + " not supported.");
      return (Interface29) new Class990(stream, (Interface40) new Class729(stream, encoding, version), (Interface40) new Class729((Stream) new MemoryStream(), encoding, version), (Interface40) new Class729((Stream) new MemoryStream(), encoding, version));
    }

    public static void smethod_2(PagedMemoryStream from, Interface29 to)
    {
      int length1 = (int) from.Length;
      for (int index = 0; index < from.Pages.Count; ++index)
      {
        int length2 = System.Math.Min(length1, from.PageSize);
        to.imethod_13(from.Pages[index], 0, length2);
        length1 -= length2;
        if (length1 <= 0)
          break;
      }
    }

    public abstract void imethod_1(double value);

    public abstract void imethod_2(Vector3D value);

    public abstract void imethod_3(Vector3D value);

    public abstract void imethod_4(string value);

    public abstract void imethod_5(string value);

    public abstract void imethod_6(Color color);

    public virtual void imethod_7(Interface29 stringWriter, Color color)
    {
      throw new NotImplementedException();
    }

    public virtual void imethod_8(Color color)
    {
      this.imethod_9((Interface29) this, color);
    }

    public virtual void imethod_9(Interface29 stringWriter, Color color)
    {
      this.imethod_32((short) 0);
      this.imethod_33((int) color.Data);
      byte num = 0;
      bool flag1;
      if (flag1 = !string.IsNullOrEmpty(color.Name))
        num |= (byte) 1;
      bool flag2;
      if (flag2 = !string.IsNullOrEmpty(color.ColorBookName))
        num |= (byte) 2;
      this.imethod_11(num);
      if (flag1)
        stringWriter.imethod_4(color.Name);
      if (!flag2)
        return;
      stringWriter.imethod_4(color.ColorBookName);
    }

    public abstract void imethod_10(
      EntityColor color,
      Transparency transparency,
      bool isColorBookColor);

    public void Clear()
    {
      this.stream_0.Position = 0L;
      this.method_2();
      this.stream_0.SetLength(0L);
    }

    public void imethod_11(byte value)
    {
      if (this.int_0 == 0)
      {
        this.method_3(value);
      }
      else
      {
        int num = 8 - this.int_0;
        this.method_3((byte) ((uint) this.byte_3 | (uint) value >> this.int_0));
        this.byte_3 = (byte) ((uint) value << num);
      }
    }

    public void imethod_12(byte[] bytes)
    {
      if (this.int_0 == 0)
      {
        for (int index = 0; index < bytes.Length; ++index)
          this.method_3(bytes[index]);
      }
      else
      {
        int num1 = 8 - this.int_0;
        for (int index = 0; index < bytes.Length; ++index)
        {
          byte num2 = bytes[index];
          this.method_3((byte) ((uint) this.byte_3 | (uint) num2 >> this.int_0));
          this.byte_3 = (byte) ((uint) num2 << num1);
        }
      }
    }

    public void imethod_13(byte[] bytes, int offset, int length)
    {
      if (this.int_0 == 0)
      {
        int num = 0;
        int index = offset;
        while (num < length)
        {
          this.method_3(bytes[index]);
          ++num;
          ++index;
        }
      }
      else
      {
        int num1 = 8 - this.int_0;
        int num2 = 0;
        int index = offset;
        while (num2 < length)
        {
          byte num3 = bytes[index];
          this.method_3((byte) ((uint) this.byte_3 | (uint) num3 >> this.int_0));
          this.byte_3 = (byte) ((uint) num3 << num1);
          ++num2;
          ++index;
        }
      }
    }

    public void imethod_14(bool value)
    {
      if (this.int_0 < 7)
      {
        if (value)
          this.byte_3 |= (byte) (1 << 7 - this.int_0);
        ++this.int_0;
      }
      else
      {
        if (value)
          this.byte_3 |= (byte) 1;
        this.method_3(this.byte_3);
        this.method_2();
      }
    }

    public void imethod_15(byte value)
    {
      if (this.int_0 < 6)
      {
        this.byte_3 |= (byte) ((uint) value << 6 - this.int_0);
        this.int_0 += 2;
      }
      else if (this.int_0 == 6)
      {
        this.byte_3 |= value;
        this.method_3(this.byte_3);
        this.method_2();
      }
      else
      {
        this.byte_3 |= (byte) ((uint) value >> 1);
        this.method_3(this.byte_3);
        this.byte_3 = (byte) ((uint) value << 7);
        this.int_0 = 1;
      }
    }

    public void imethod_16(double value)
    {
      if (value == 0.0)
        this.imethod_15((byte) 2);
      else if (value == 1.0)
      {
        this.imethod_15((byte) 1);
      }
      else
      {
        this.imethod_15((byte) 0);
        this.imethod_12(LittleEndianBitConverter.GetBytes(value));
      }
    }

    public void imethod_17(double value, double defaultValue)
    {
      if (value == defaultValue)
      {
        this.imethod_15((byte) 0);
      }
      else
      {
        byte[] bytes1 = LittleEndianBitConverter.GetBytes(value);
        byte[] bytes2 = LittleEndianBitConverter.GetBytes(defaultValue);
        int num = 0;
        for (int index = 7; index >= 0 && (int) bytes1[index] == (int) bytes2[index]; --index)
          ++num;
        if (num >= 4)
        {
          this.imethod_15((byte) 1);
          this.imethod_13(bytes1, 0, 4);
        }
        else if (num >= 2)
        {
          this.imethod_15((byte) 2);
          this.imethod_11(bytes1[4]);
          this.imethod_11(bytes1[5]);
          this.imethod_11(bytes1[0]);
          this.imethod_11(bytes1[1]);
          this.imethod_11(bytes1[2]);
          this.imethod_11(bytes1[3]);
        }
        else
        {
          this.imethod_15((byte) 3);
          this.imethod_12(bytes1);
        }
      }
    }

    public void imethod_18(short value)
    {
      this.imethod_12(LittleEndianBitConverter.GetBytes(value));
    }

    public void method_0(ushort value)
    {
      this.imethod_12(LittleEndianBitConverter.GetBytes(value));
    }

    public void imethod_19(int value)
    {
      this.imethod_12(LittleEndianBitConverter.GetBytes(value));
    }

    public void imethod_20(double value)
    {
      this.imethod_12(LittleEndianBitConverter.GetBytes(value));
    }

    public void imethod_21(uint value)
    {
      this.imethod_12(LittleEndianBitConverter.GetBytes(value));
    }

    public void imethod_22(ulong value)
    {
      this.imethod_12(LittleEndianBitConverter.GetBytes(value));
    }

    public void imethod_23(WW.Math.Point2D value)
    {
      this.imethod_16(value.X);
      this.imethod_16(value.Y);
    }

    public void imethod_24(WW.Math.Point3D value)
    {
      this.imethod_16(value.X);
      this.imethod_16(value.Y);
      this.imethod_16(value.Z);
    }

    public void imethod_25(WW.Math.Point2D value)
    {
      this.imethod_20(value.X);
      this.imethod_20(value.Y);
    }

    public void imethod_26(WW.Math.Point3D value)
    {
      this.imethod_20(value.X);
      this.imethod_20(value.Y);
      this.imethod_20(value.Z);
    }

    public void imethod_27(Vector2D value)
    {
      this.imethod_16(value.X);
      this.imethod_16(value.Y);
    }

    public void imethod_28(Vector2D value)
    {
      this.imethod_20(value.X);
      this.imethod_20(value.Y);
    }

    public void imethod_29(Vector3D value)
    {
      this.imethod_16(value.X);
      this.imethod_16(value.Y);
      this.imethod_16(value.Z);
    }

    public void imethod_30(WW.Math.Point2D value, WW.Math.Point2D defaultValue)
    {
      this.imethod_17(value.X, defaultValue.X);
      this.imethod_17(value.Y, defaultValue.Y);
    }

    public void imethod_31(WW.Math.Point3D value, WW.Math.Point3D defaultValue)
    {
      this.imethod_17(value.X, defaultValue.X);
      this.imethod_17(value.Y, defaultValue.Y);
      this.imethod_17(value.Z, defaultValue.Z);
    }

    public void imethod_32(short value)
    {
      if (value == (short) 0)
        this.imethod_15((byte) 2);
      else if (value > (short) 0 && value < (short) 256)
      {
        this.imethod_15((byte) 1);
        this.imethod_11((byte) value);
      }
      else if (value == (short) 256)
      {
        this.imethod_15((byte) 3);
      }
      else
      {
        this.imethod_15((byte) 0);
        this.imethod_11((byte) value);
        this.imethod_11((byte) ((uint) value >> 8));
      }
    }

    public void imethod_33(int value)
    {
      if (value == 0)
        this.imethod_15((byte) 2);
      else if (value > 0 && value < 256)
      {
        this.imethod_15((byte) 1);
        this.imethod_11((byte) value);
      }
      else
      {
        this.imethod_15((byte) 0);
        this.imethod_11((byte) value);
        this.imethod_11((byte) (value >> 8));
        this.imethod_11((byte) (value >> 16));
        this.imethod_11((byte) (value >> 24));
      }
    }

    public virtual void imethod_34(long value)
    {
      throw new NotImplementedException();
    }

    public void imethod_35(ReferenceType? referenceType, ulong handle)
    {
      this.imethod_43(referenceType, handle);
    }

    public void imethod_36(byte handleType, DxfHandledObject handledObject)
    {
      this.imethod_42((ReferenceType) handleType, handledObject);
    }

    public void imethod_37(byte handleType, ulong handle)
    {
      this.imethod_43(new ReferenceType?((ReferenceType) handleType), handle);
    }

    public void imethod_38(DxfHandledObject handledObject)
    {
      this.imethod_42(ReferenceType.SoftOwnershipReference, handledObject);
    }

    public void imethod_39(DxfHandledObject handledObject)
    {
      this.imethod_42(ReferenceType.HardOwnershipReference, handledObject);
    }

    public void imethod_40(DxfHandledObject handledObject)
    {
      this.imethod_42(ReferenceType.SoftPointerReference, handledObject);
    }

    public void imethod_41(DxfHandledObject handledObject)
    {
      this.imethod_42(ReferenceType.HardPointerReference, handledObject);
    }

    public void imethod_42(ReferenceType referenceType, DxfHandledObject handledObject)
    {
      if (handledObject == null)
        this.imethod_43(new ReferenceType?(referenceType), 0UL);
      else
        this.imethod_43(new ReferenceType?(referenceType), handledObject.Handle);
    }

    public void imethod_43(ReferenceType? referenceType, ulong handle)
    {
      Class724.smethod_3(referenceType, handle, new System.Action<byte>(this.imethod_11));
    }

    public static void smethod_3(
      ReferenceType? referenceType,
      ulong handle,
      System.Action<byte> writeByte)
    {
      Enum10 enum10 = Enum10.const_0;
      if (referenceType.HasValue)
      {
        switch (referenceType.Value)
        {
          case ReferenceType.SoftPointerReference:
            enum10 = Enum10.const_3;
            break;
          case ReferenceType.HardPointerReference:
            enum10 = Enum10.const_4;
            break;
          case ReferenceType.SoftOwnershipReference:
            enum10 = Enum10.const_1;
            break;
          case ReferenceType.HardOwnershipReference:
            enum10 = Enum10.const_2;
            break;
          default:
            throw new Exception("Invalid reference type.");
        }
      }
      byte num1 = (byte) ((uint) enum10 << 4);
      if (handle == 0UL)
        writeByte(num1);
      else if (handle < 256UL)
      {
        byte num2 = (byte) ((uint) num1 | 1U);
        writeByte(num2);
        writeByte((byte) handle);
      }
      else if (handle < 65536UL)
      {
        byte num2 = (byte) ((uint) num1 | 2U);
        writeByte(num2);
        writeByte((byte) (handle >> 8));
        writeByte((byte) handle);
      }
      else if (handle < 16777216UL)
      {
        byte num2 = (byte) ((uint) num1 | 3U);
        writeByte(num2);
        writeByte((byte) (handle >> 16));
        writeByte((byte) (handle >> 8));
        writeByte((byte) handle);
      }
      else if (handle < 4294967296UL)
      {
        byte num2 = (byte) ((uint) num1 | 4U);
        writeByte(num2);
        writeByte((byte) (handle >> 24));
        writeByte((byte) (handle >> 16));
        writeByte((byte) (handle >> 8));
        writeByte((byte) handle);
      }
      else if (handle < 1099511627776UL)
      {
        byte num2 = (byte) ((uint) num1 | 5U);
        writeByte(num2);
        writeByte((byte) (handle >> 32));
        writeByte((byte) (handle >> 24));
        writeByte((byte) (handle >> 16));
        writeByte((byte) (handle >> 8));
        writeByte((byte) handle);
      }
      else if (handle < 281474976710656UL)
      {
        byte num2 = (byte) ((uint) num1 | 6U);
        writeByte(num2);
        writeByte((byte) (handle >> 40));
        writeByte((byte) (handle >> 32));
        writeByte((byte) (handle >> 24));
        writeByte((byte) (handle >> 16));
        writeByte((byte) (handle >> 8));
        writeByte((byte) handle);
      }
      else if (handle < 72057594037927936UL)
      {
        byte num2 = (byte) ((uint) num1 | 7U);
        writeByte(num2);
        writeByte((byte) (handle >> 48));
        writeByte((byte) (handle >> 40));
        writeByte((byte) (handle >> 32));
        writeByte((byte) (handle >> 24));
        writeByte((byte) (handle >> 16));
        writeByte((byte) (handle >> 8));
        writeByte((byte) handle);
      }
      else
      {
        byte num2 = (byte) ((uint) num1 | 8U);
        writeByte(num2);
        writeByte((byte) (handle >> 56));
        writeByte((byte) (handle >> 48));
        writeByte((byte) (handle >> 40));
        writeByte((byte) (handle >> 32));
        writeByte((byte) (handle >> 24));
        writeByte((byte) (handle >> 16));
        writeByte((byte) (handle >> 8));
        writeByte((byte) handle);
      }
    }

    public void imethod_44(DateTime value)
    {
      int days;
      int milliseconds;
      Class644.smethod_1(value, out days, out milliseconds);
      this.imethod_33(days);
      this.imethod_33(milliseconds);
    }

    public void imethod_45(DxfTimeSpan value)
    {
      this.imethod_33(value.Days);
      this.imethod_33(value.Milliseconds);
    }

    public static int smethod_4(int value, byte[] buffer)
    {
      int index = 0;
      int num;
      if (value < 0)
      {
        for (value = -value; value >= 64; value >>= 7)
        {
          buffer[index] = (byte) (value & (int) sbyte.MaxValue | 128);
          ++index;
        }
        buffer[index] = (byte) (value | 64);
        num = index + 1;
      }
      else
      {
        for (; value >= 64; value >>= 7)
        {
          buffer[index] = (byte) (value & (int) sbyte.MaxValue | 128);
          ++index;
        }
        buffer[index] = (byte) value;
        num = index + 1;
      }
      return num;
    }

    public static int smethod_5(ulong value, byte[] buffer)
    {
      int index = 0;
      for (; value >= 128UL; value >>= 7)
      {
        buffer[index] = (byte) ((long) value & (long) sbyte.MaxValue | 128L);
        ++index;
      }
      buffer[index] = (byte) value;
      return index + 1;
    }

    public long imethod_48()
    {
      return this.stream_0.Position * 8L + (long) this.int_0;
    }

    public long imethod_0()
    {
      long num = this.imethod_48();
      this.imethod_19(0);
      return num;
    }

    public void method_1(long sizePosition)
    {
      throw new NotImplementedException();
    }

    public void imethod_47(long bitPosition)
    {
      long num1 = bitPosition / 8L;
      this.int_0 = (int) (bitPosition % 8L);
      this.stream_0.Position = num1;
      if (this.int_0 > 0)
      {
        int num2 = this.stream_0.ReadByte();
        if (num2 < 0)
          throw new EndOfStreamException();
        this.byte_3 = (byte) num2;
      }
      else
        this.byte_3 = (byte) 0;
      this.stream_0.Position = num1;
    }

    public virtual void imethod_50(long lengthInBits)
    {
      throw new NotSupportedException();
    }

    public virtual void imethod_46(short objectType)
    {
      this.imethod_32(objectType);
    }

    public void Flush()
    {
      if (this.int_0 <= 0)
        return;
      for (int int0 = this.int_0; int0 < 8; ++int0)
        this.imethod_14(false);
    }

    public void imethod_49()
    {
      if (this.int_0 <= 0)
        return;
      long position = this.stream_0.Position;
      byte num = (byte) ((uint) this.byte_3 | (uint) (byte) this.stream_0.ReadByte() & (uint) ((int) byte.MaxValue >> this.int_0));
      this.stream_0.Position = position;
      this.stream_0.WriteByte(num);
    }

    private void method_2()
    {
      this.int_0 = 0;
      this.byte_3 = (byte) 0;
    }

    private void method_3(byte value)
    {
      this.stream_0.WriteByte(value);
    }
  }
}
