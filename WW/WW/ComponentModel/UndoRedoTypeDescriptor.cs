// Decompiled with JetBrains decompiler
// Type: WW.ComponentModel.UndoRedoTypeDescriptor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.ComponentModel;
using WW.Actions;

namespace WW.ComponentModel
{
  public class UndoRedoTypeDescriptor : ICustomTypeDescriptor
  {
    private object object_0;

    public event EventHandler<CommandEventArgs> CommandCreated;

    public UndoRedoTypeDescriptor(object component)
    {
      this.object_0 = component;
    }

    public object Component
    {
      get
      {
        return this.object_0;
      }
    }

    internal void method_0(CommandEventArgs e)
    {
      this.OnCommandCreated(e);
    }

    protected virtual void OnCommandCreated(CommandEventArgs e)
    {
      if (this.CommandCreated == null)
        return;
      this.CommandCreated((object) this, e);
    }

    public AttributeCollection GetAttributes()
    {
      return TypeDescriptor.GetAttributes(this.object_0);
    }

    public string GetClassName()
    {
      return TypeDescriptor.GetClassName(this.object_0);
    }

    public string GetComponentName()
    {
      return TypeDescriptor.GetComponentName(this.object_0);
    }

    public TypeConverter GetConverter()
    {
      return TypeDescriptor.GetConverter(this.object_0);
    }

    public EventDescriptor GetDefaultEvent()
    {
      return TypeDescriptor.GetDefaultEvent(this.object_0);
    }

    public PropertyDescriptor GetDefaultProperty()
    {
      return TypeDescriptor.GetDefaultProperty(this.object_0);
    }

    public object GetEditor(Type editorBaseType)
    {
      return TypeDescriptor.GetEditor(this.object_0, editorBaseType);
    }

    public EventDescriptorCollection GetEvents(Attribute[] attributes)
    {
      return TypeDescriptor.GetEvents(this.object_0, attributes);
    }

    public EventDescriptorCollection GetEvents()
    {
      return TypeDescriptor.GetEvents(this.object_0);
    }

    public object GetPropertyOwner(PropertyDescriptor pd)
    {
      return this.object_0;
    }

    public virtual PropertyDescriptorCollection GetProperties()
    {
      return this.WrapProperties(TypeDescriptor.GetProperties(this.object_0));
    }

    public virtual PropertyDescriptorCollection GetProperties(
      Attribute[] attributes)
    {
      return this.WrapProperties(TypeDescriptor.GetProperties(this.object_0, attributes));
    }

    protected virtual PropertyDescriptorCollection WrapProperties(
      PropertyDescriptorCollection properties)
    {
      PropertyDescriptor[] properties1 = new PropertyDescriptor[properties.Count];
      for (int index = 0; index < properties.Count; ++index)
        properties1[index] = (PropertyDescriptor) new UndoRedoPropertyDescriptor(properties[index], this);
      return new PropertyDescriptorCollection(properties1);
    }
  }
}
