// Decompiled with JetBrains decompiler
// Type: WW.ComponentModel.GlobalizedPropertyAttribute
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.ComponentModel
{
  [AttributeUsage(AttributeTargets.Property)]
  public class GlobalizedPropertyAttribute : Attribute
  {
    private string string_0;
    private string string_1;
    private string string_2;
    private string string_3;

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

    public string DisplayNameId
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public string DescriptionId
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public string CategoryId
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value;
      }
    }
  }
}
