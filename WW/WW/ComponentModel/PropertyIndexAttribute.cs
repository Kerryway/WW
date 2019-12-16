// Decompiled with JetBrains decompiler
// Type: WW.ComponentModel.PropertyIndexAttribute
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.ComponentModel
{
  [AttributeUsage(AttributeTargets.Property)]
  public class PropertyIndexAttribute : Attribute
  {
    private readonly int int_0;

    public PropertyIndexAttribute(int index)
    {
      this.int_0 = index;
    }

    public int Index
    {
      get
      {
        return this.int_0;
      }
    }
  }
}
