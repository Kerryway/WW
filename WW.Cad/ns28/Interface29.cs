// Decompiled with JetBrains decompiler
// Type: ns28.Interface29
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;
using System.Text;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Math;

namespace ns28
{
  internal interface Interface29
  {
    Stream Stream { get; }

    Interface40 MainBitStreamWriter { get; }

    Interface40 StringBitStreamWriter { get; }

    Interface40 HandleBitStreamWriter { get; }

    DxfVersion Version { get; }

    long HandleStreamBitPosition { get; }

    void Clear();

    Encoding Encoding { get; }

    Encoding EffectiveEncoding { get; }

    long imethod_0();

    void Flush();

    void imethod_1(double value);

    void imethod_2(Vector3D value);

    void imethod_3(Vector3D value);

    void imethod_4(string value);

    void imethod_5(string value);

    void imethod_6(Color color);

    void imethod_7(Interface29 stringWriter, Color color);

    void imethod_8(Color color);

    void imethod_9(Interface29 stringWriter, Color color);

    void imethod_10(EntityColor color, Transparency transparency, bool isColorBookColor);

    void imethod_11(byte value);

    void imethod_12(byte[] bytes);

    void imethod_13(byte[] bytes, int offset, int length);

    void imethod_14(bool value);

    void imethod_15(byte value);

    void imethod_16(double value);

    void imethod_17(double value, double defaultValue);

    void imethod_18(short value);

    void imethod_19(int value);

    void imethod_20(double value);

    void imethod_21(uint value);

    void imethod_22(ulong value);

    void imethod_23(WW.Math.Point2D value);

    void imethod_24(WW.Math.Point3D value);

    void imethod_25(WW.Math.Point2D value);

    void imethod_26(WW.Math.Point3D value);

    void imethod_27(Vector2D value);

    void imethod_28(Vector2D value);

    void imethod_29(Vector3D value);

    void imethod_30(WW.Math.Point2D value, WW.Math.Point2D defaultValue);

    void imethod_31(WW.Math.Point3D value, WW.Math.Point3D defaultValue);

    void imethod_32(short value);

    void imethod_33(int value);

    void imethod_34(long value);

    void imethod_35(ReferenceType? referenceType, ulong handle);

    void imethod_36(byte handleType, DxfHandledObject handledObject);

    void imethod_37(byte handleType, ulong handle);

    void imethod_38(DxfHandledObject handledObject);

    void imethod_39(DxfHandledObject handledObject);

    void imethod_40(DxfHandledObject handledObject);

    void imethod_41(DxfHandledObject handledObject);

    void imethod_42(ReferenceType referenceType, DxfHandledObject handledObject);

    void imethod_43(ReferenceType? referenceType, ulong handle);

    void imethod_44(DateTime value);

    void imethod_45(DxfTimeSpan value);

    void imethod_46(short objectType);
  }
}
