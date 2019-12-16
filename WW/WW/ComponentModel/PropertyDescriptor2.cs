// Decompiled with JetBrains decompiler
// Type: WW.ComponentModel.PropertyDescriptor2
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.ComponentModel;

namespace WW.ComponentModel
{
  public class PropertyDescriptor2 : PropertyDescriptor
  {
    private PropertyDescriptor propertyDescriptor_0;
    private PropertyAttributes propertyAttributes_0;

    public PropertyDescriptor2(
      PropertyDescriptor basePropertyDescriptor,
      PropertyAttributes propertyAttributes)
      : base((MemberDescriptor) basePropertyDescriptor)
    {
      this.propertyDescriptor_0 = basePropertyDescriptor;
      this.propertyAttributes_0 = propertyAttributes;
    }

    public override bool CanResetValue(object component)
    {
      return this.propertyDescriptor_0.CanResetValue(component);
    }

    public override Type ComponentType
    {
      get
      {
        return this.propertyDescriptor_0.ComponentType;
      }
    }

    public override string DisplayName
    {
      get
      {
        return this.propertyAttributes_0.DisplayName;
      }
    }

    public override string Description
    {
      get
      {
        return this.propertyAttributes_0.Description;
      }
    }

    public override string Category
    {
      get
      {
        return this.propertyAttributes_0.Category;
      }
    }

    public override object GetValue(object component)
    {
      return this.propertyDescriptor_0.GetValue(component);
    }

    public override bool IsReadOnly
    {
      get
      {
        return this.propertyAttributes_0.IsReadOnly;
      }
    }

    public override bool IsBrowsable
    {
      get
      {
        return this.propertyAttributes_0.IsBrowsable;
      }
    }

    public override string Name
    {
      get
      {
        return this.propertyDescriptor_0.Name;
      }
    }

    public override Type PropertyType
    {
      get
      {
        return this.propertyDescriptor_0.PropertyType;
      }
    }

    public override void ResetValue(object component)
    {
      this.propertyDescriptor_0.ResetValue(component);
    }

    public override bool ShouldSerializeValue(object component)
    {
      return this.propertyDescriptor_0.ShouldSerializeValue(component);
    }

    public override void SetValue(object component, object value)
    {
      this.propertyDescriptor_0.SetValue(component, value);
    }
  }
}
