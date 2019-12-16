// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfClassCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Model
{
  public class DxfClassCollection : List<DxfClass>
  {
    public DxfClassCollection()
    {
    }

    public DxfClassCollection(int capacity)
      : base(capacity)
    {
    }

    public DxfClass GetClassWithClassNumber(short objectType)
    {
      DxfClass dxfClass1 = (DxfClass) null;
      foreach (DxfClass dxfClass2 in (List<DxfClass>) this)
      {
        if ((int) dxfClass2.ClassNumber == (int) objectType)
        {
          dxfClass1 = dxfClass2;
          break;
        }
      }
      return dxfClass1;
    }

    public DxfClass GetClassWithCPlusPlusName(string cPlusPlusClassName)
    {
      DxfClass dxfClass1 = (DxfClass) null;
      foreach (DxfClass dxfClass2 in (List<DxfClass>) this)
      {
        if (dxfClass2.CPlusPlusClassName == cPlusPlusClassName)
        {
          dxfClass1 = dxfClass2;
          break;
        }
      }
      return dxfClass1;
    }

    public bool ContainsCPlusPlusName(string cPlusPlusClassName)
    {
      bool flag = false;
      foreach (DxfClass dxfClass in (List<DxfClass>) this)
      {
        if (dxfClass.CPlusPlusClassName == cPlusPlusClassName)
        {
          flag = true;
          break;
        }
      }
      return flag;
    }

    public DxfClass GetClassWithDxfName(string dxfName)
    {
      DxfClass dxfClass1 = (DxfClass) null;
      foreach (DxfClass dxfClass2 in (List<DxfClass>) this)
      {
        if (dxfClass2.DxfName == dxfName)
        {
          dxfClass1 = dxfClass2;
          break;
        }
      }
      return dxfClass1;
    }

    public bool ContainsDxfName(string dxfName)
    {
      bool flag = false;
      foreach (DxfClass dxfClass in (List<DxfClass>) this)
      {
        if (dxfClass.DxfName == dxfName)
        {
          flag = true;
          break;
        }
      }
      return flag;
    }
  }
}
