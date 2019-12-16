// Decompiled with JetBrains decompiler
// Type: WW.ComponentModel.PropertyAttributesProviderAttribute
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Reflection;

namespace WW.ComponentModel
{
  [AttributeUsage(AttributeTargets.Property)]
  public class PropertyAttributesProviderAttribute : Attribute
  {
    private string string_0;

    public PropertyAttributesProviderAttribute(string propertyAttributesProviderName)
    {
      this.string_0 = propertyAttributesProviderName;
    }

    public MethodInfo GetPropertyAttributesProvider(object target)
    {
      return target.GetType().GetMethod(this.string_0);
    }

    public string Name
    {
      get
      {
        return this.string_0;
      }
    }
  }
}
