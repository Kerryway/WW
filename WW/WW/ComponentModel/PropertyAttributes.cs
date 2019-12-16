// Decompiled with JetBrains decompiler
// Type: WW.ComponentModel.PropertyAttributes
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.ComponentModel
{
  public class PropertyAttributes : IComparable
  {
    private string string_0;
    private bool bool_0;
    private bool bool_1;
    private string string_1;
    private string string_2;
    private string string_3;
    private int int_0;

    public PropertyAttributes(string name)
    {
      this.string_0 = name;
    }

    public string Name
    {
      get
      {
        return this.string_0;
      }
    }

    public bool IsBrowsable
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public bool IsReadOnly
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public string DisplayName
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

    public string Description
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

    public string Category
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

    public int Order
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public int CompareTo(object obj)
    {
      PropertyAttributes propertyAttributes = (PropertyAttributes) obj;
      if (this.int_0 == propertyAttributes.int_0)
        return string.Compare(this.string_1, propertyAttributes.string_1);
      return this.int_0 >= propertyAttributes.int_0 ? 1 : -1;
    }
  }
}
