// Decompiled with JetBrains decompiler
// Type: ns28.Interface30
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;
using System.Text;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.IO;
using WW.Math;

namespace ns28
{
  internal interface Interface30
  {
    bool LoggingEnabled { get; set; }

    int BitIndex { get; set; }

    void imethod_0(int byteCount);

    void imethod_1(int byteCount);

    Encoding Encoding { get; set; }

    ushort imethod_2(ushort initialCrc, byte[] bytes);

    long imethod_3();

    void imethod_4(long bitPosition);

    long imethod_5(long stringStreamEndBitPosition);

    bool imethod_6();

    short imethod_7();

    double imethod_8();

    Vector3D imethod_9();

    Vector3D imethod_10();

    int imethod_11();

    long imethod_12();

    byte imethod_13();

    short imethod_14();

    bool imethod_15();

    Color imethod_16();

    double imethod_17();

    byte imethod_18();

    byte[] imethod_19(int length);

    void imethod_20(int length, PagedMemoryStream targetStream);

    uint imethod_21(PagedMemoryStream targetStream);

    Color imethod_22();

    Color imethod_23(Interface30 stringReader);

    Color imethod_24();

    Color imethod_25(Interface30 stringReader);

    void imethod_26(
      out EntityColor color,
      out Transparency transparencySource,
      out bool isColorBookColor);

    ushort imethod_27();

    DateTime imethod_28();

    double imethod_29(double defaultValue);

    string imethod_30();

    ulong imethod_31();

    ulong imethod_32(bool enqueueForRead);

    ulong imethod_33(ulong referenceHandle, bool enqueueForRead);

    ulong imethod_34(ulong referenceHandle, bool enqueueForRead, out ReferenceType referenceType);

    int imethod_35();

    WW.Math.Point2D imethod_36();

    WW.Math.Point2D imethod_37(WW.Math.Point2D defaultPoint);

    WW.Math.Point2D imethod_38();

    WW.Math.Point3D imethod_39();

    WW.Math.Point3D imethod_40(WW.Math.Point3D defaultPoint);

    WW.Math.Point3D imethod_41();

    double imethod_42();

    int imethod_43();

    uint imethod_44();

    short imethod_45();

    ulong imethod_46();

    ulong imethod_47();

    DxfTimeSpan imethod_48();

    string ReadString();

    Vector2D imethod_49();

    Vector2D imethod_50();

    Vector3D imethod_51();

    void imethod_52(int n);

    void imethod_53(int position);

    Stream Stream { get; }

    void imethod_54(Stream stream, uint sizeInBits);

    long StreamPosition { get; set; }

    short imethod_55();

    uint SizeInBits { get; set; }
  }
}
