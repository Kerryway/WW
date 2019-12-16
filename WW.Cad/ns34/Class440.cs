// Decompiled with JetBrains decompiler
// Type: ns34.Class440
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;
using System.IO;
using System.Text;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Math;

namespace ns34
{
  internal class Class440 : Interface29
  {
    private Stream stream_0;
    private Interface40 interface40_0;
    private Interface40 interface40_1;
    private bool bool_0;
    private long long_0;

    public Class440(Stream stream, Interface40 mainWriter, Interface40 handleWriter)
    {
      this.stream_0 = stream;
      this.interface40_0 = mainWriter;
      this.interface40_1 = handleWriter;
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
        return this.interface40_0.Version;
      }
    }

    public Interface40 MainBitStreamWriter
    {
      get
      {
        return this.interface40_0;
      }
    }

    public Interface40 StringBitStreamWriter
    {
      get
      {
        return this.interface40_0;
      }
    }

    public Interface40 HandleBitStreamWriter
    {
      get
      {
        return this.interface40_1;
      }
    }

    public long HandleStreamBitPosition
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public long imethod_0()
    {
      this.bool_0 = true;
      return this.long_0 = this.interface40_0.imethod_0();
    }

    public void Clear()
    {
      this.interface40_0.Clear();
      this.interface40_1.Clear();
    }

    public Encoding Encoding
    {
      get
      {
        return this.interface40_0.Encoding;
      }
    }

    public Encoding EffectiveEncoding
    {
      get
      {
        return this.interface40_0.EffectiveEncoding;
      }
    }

    public void Flush()
    {
      int num = (int) this.interface40_0.imethod_48();
      if (this.bool_0)
      {
        this.interface40_0.Flush();
        this.interface40_0.imethod_47(this.long_0);
        this.interface40_0.imethod_19(num);
        this.interface40_0.imethod_49();
        this.interface40_0.imethod_47((long) num);
      }
      this.interface40_1.Flush();
      this.interface40_0.imethod_13(((MemoryStream) this.interface40_1.Stream).GetBuffer(), 0, (int) this.interface40_1.Stream.Length);
      this.interface40_0.Flush();
    }

    public void imethod_1(double value)
    {
      this.interface40_0.imethod_1(value);
    }

    public void imethod_2(Vector3D value)
    {
      this.interface40_0.imethod_2(value);
    }

    public void imethod_3(Vector3D value)
    {
      this.interface40_0.imethod_3(value);
    }

    public void imethod_4(string value)
    {
      this.interface40_0.imethod_4(value);
    }

    public void imethod_5(string value)
    {
      this.interface40_0.imethod_5(value);
    }

    public void imethod_11(byte value)
    {
      this.interface40_0.imethod_11(value);
    }

    public void imethod_12(byte[] bytes)
    {
      this.interface40_0.imethod_12(bytes);
    }

    public void imethod_13(byte[] bytes, int offset, int length)
    {
      this.interface40_0.imethod_13(bytes, offset, length);
    }

    public void imethod_14(bool value)
    {
      this.interface40_0.imethod_14(value);
    }

    public void imethod_15(byte value)
    {
      this.interface40_0.imethod_15(value);
    }

    public void imethod_16(double value)
    {
      this.interface40_0.imethod_16(value);
    }

    public void imethod_17(double value, double defaultValue)
    {
      this.interface40_0.imethod_17(value, defaultValue);
    }

    public void imethod_18(short value)
    {
      this.interface40_0.imethod_18(value);
    }

    public void imethod_19(int value)
    {
      this.interface40_0.imethod_19(value);
    }

    public void imethod_20(double value)
    {
      this.interface40_0.imethod_20(value);
    }

    public void imethod_21(uint value)
    {
      this.interface40_0.imethod_21(value);
    }

    public void imethod_22(ulong value)
    {
      this.interface40_0.imethod_22(value);
    }

    public void imethod_23(WW.Math.Point2D value)
    {
      this.interface40_0.imethod_23(value);
    }

    public void imethod_24(WW.Math.Point3D value)
    {
      this.interface40_0.imethod_24(value);
    }

    public void imethod_25(WW.Math.Point2D value)
    {
      this.interface40_0.imethod_25(value);
    }

    public void imethod_26(WW.Math.Point3D value)
    {
      this.interface40_0.imethod_26(value);
    }

    public void imethod_27(Vector2D value)
    {
      this.interface40_0.imethod_27(value);
    }

    public void imethod_28(Vector2D value)
    {
      this.interface40_0.imethod_28(value);
    }

    public void imethod_29(Vector3D value)
    {
      this.interface40_0.imethod_29(value);
    }

    public void imethod_30(WW.Math.Point2D value, WW.Math.Point2D defaultValue)
    {
      this.interface40_0.imethod_30(value, defaultValue);
    }

    public void imethod_31(WW.Math.Point3D value, WW.Math.Point3D defaultValue)
    {
      this.interface40_0.imethod_31(value, defaultValue);
    }

    public void imethod_32(short value)
    {
      this.interface40_0.imethod_32(value);
    }

    public void imethod_33(int value)
    {
      this.interface40_0.imethod_33(value);
    }

    public void imethod_34(long value)
    {
      this.interface40_0.imethod_34(value);
    }

    public void imethod_35(ReferenceType? referenceType, ulong handle)
    {
      this.interface40_0.imethod_35(referenceType, handle);
    }

    public void imethod_36(byte handleType, DxfHandledObject handledObject)
    {
      this.interface40_1.imethod_36(handleType, handledObject);
    }

    public void imethod_37(byte handleType, ulong handle)
    {
      this.interface40_1.imethod_37(handleType, handle);
    }

    public void imethod_38(DxfHandledObject handledObject)
    {
      this.interface40_1.imethod_38(handledObject);
    }

    public void imethod_39(DxfHandledObject handledObject)
    {
      this.interface40_1.imethod_39(handledObject);
    }

    public void imethod_40(DxfHandledObject handledObject)
    {
      this.interface40_1.imethod_40(handledObject);
    }

    public void imethod_41(DxfHandledObject handledObject)
    {
      this.interface40_1.imethod_41(handledObject);
    }

    public void imethod_42(ReferenceType referenceType, DxfHandledObject handledObject)
    {
      this.interface40_1.imethod_42(referenceType, handledObject);
    }

    public void imethod_43(ReferenceType? referenceType, ulong handle)
    {
      this.interface40_1.imethod_43(referenceType, handle);
    }

    public void imethod_44(DateTime value)
    {
      this.interface40_0.imethod_44(value);
    }

    public void imethod_45(DxfTimeSpan value)
    {
      this.interface40_0.imethod_45(value);
    }

    public void imethod_6(Color color)
    {
      this.interface40_0.imethod_6(color);
    }

    public void imethod_7(Interface29 stringWriter, Color color)
    {
      throw new NotSupportedException();
    }

    public void imethod_10(EntityColor color, Transparency transparency, bool isColorBookColor)
    {
      this.interface40_0.imethod_10(color, transparency, isColorBookColor);
    }

    public void imethod_8(Color color)
    {
      this.interface40_0.imethod_8(color);
    }

    public void imethod_9(Interface29 stringWriter, Color color)
    {
      throw new NotSupportedException();
    }

    public void imethod_46(short objectType)
    {
      this.interface40_0.imethod_46(objectType);
    }
  }
}
