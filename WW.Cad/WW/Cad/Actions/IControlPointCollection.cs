// Decompiled with JetBrains decompiler
// Type: WW.Cad.Actions.IControlPointCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Actions
{
  public interface IControlPointCollection
  {
    void Set(int index, Point3D value);

    Point3D Get(int index);

    string GetDescription(int index);

    PointDisplayType GetDisplayType(int index);

    int Count { get; }

    bool IsCountFixed { get; }

    void Insert(int index);

    void RemoveAt(int index);
  }
}
