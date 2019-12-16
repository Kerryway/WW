// Decompiled with JetBrains decompiler
// Type: ns7.Interface9
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns9;
using System.Collections.Generic;
using WW.Math;

namespace ns7
{
  internal interface Interface9 : Interface6, Interface7
  {
    void imethod_4(int value);

    void imethod_5(int value);

    void imethod_6(Class80 entity);

    void imethod_7(double value);

    void imethod_8();

    void imethod_9();

    void WriteString(string value);

    void imethod_10(string[] values, int value);

    void imethod_11(string[] values, int[] indexes, int value);

    void imethod_12(Interface39 values);

    void imethod_13(string value);

    void imethod_14();

    void imethod_15();

    void imethod_16(Class987 header);

    void imethod_17(Point3D value);

    void imethod_18(Vector3D value);

    void imethod_19(List<Class561> unknownData, bool comesFromSat);

    Interface9 imethod_20();

    int FileFormatVersion { get; }

    string SAT { get; }
  }
}
