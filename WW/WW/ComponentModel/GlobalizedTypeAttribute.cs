// Decompiled with JetBrains decompiler
// Type: WW.ComponentModel.GlobalizedTypeAttribute
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.ComponentModel
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
  public class GlobalizedTypeAttribute : Attribute
  {
    private string string_0;

    public string BaseName
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }
  }
}
