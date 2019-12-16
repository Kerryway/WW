// Decompiled with JetBrains decompiler
// Type: WW.Cad.Actions.ControlPointCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Math;

namespace WW.Cad.Actions
{
  public static class ControlPointCollection
  {
    public static readonly IControlPointCollection Empty = ControlPointCollection.Class1041.icontrolPointCollection_0;

    private class Class1041 : IControlPointCollection
    {
      public static readonly IControlPointCollection icontrolPointCollection_0 = (IControlPointCollection) new ControlPointCollection.Class1041();

      private Class1041()
      {
      }

      public void Set(int index, Point3D value)
      {
        throw new NotImplementedException();
      }

      public Point3D Get(int index)
      {
        throw new NotImplementedException();
      }

      public string GetDescription(int index)
      {
        throw new NotImplementedException();
      }

      public PointDisplayType GetDisplayType(int index)
      {
        throw new NotImplementedException();
      }

      public int Count
      {
        get
        {
          return 0;
        }
      }

      public bool IsCountFixed
      {
        get
        {
          return true;
        }
      }

      public void Insert(int index)
      {
        throw new NotSupportedException();
      }

      public void RemoveAt(int index)
      {
        throw new NotSupportedException();
      }
    }
  }
}
