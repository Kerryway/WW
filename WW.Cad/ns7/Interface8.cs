// Decompiled with JetBrains decompiler
// Type: ns7.Interface8
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns9;
using System.Collections.Generic;
using WW.Math;

namespace ns7
{
  internal interface Interface8 : Interface6, Interface7
  {
    int imethod_4(int defaultNumber);

    int imethod_5();

    void imethod_6();

    int imethod_7();

    double imethod_8();

    void imethod_9();

    void imethod_10();

    string ReadString();

    int imethod_11(string[] values);

    int imethod_12(string[] values, int[] indexes);

    void imethod_13(Interface39 values);

    string imethod_14();

    bool imethod_15(ref List<Class561> unknownData);

    bool imethod_16(bool silentMod);

    void imethod_17(Class987 header);

    Point3D imethod_18();

    Vector3D imethod_19();

    Interface8 imethod_20();

    int FileFormatVersion { get; }
  }
}
