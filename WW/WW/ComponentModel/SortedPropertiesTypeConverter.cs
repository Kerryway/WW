// Decompiled with JetBrains decompiler
// Type: WW.ComponentModel.SortedPropertiesTypeConverter
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using WW.Windows.Forms;

namespace WW.ComponentModel
{
  public class SortedPropertiesTypeConverter : ExpandableObjectConverter
  {
    public override PropertyDescriptorCollection GetProperties(
      ITypeDescriptorContext context,
      object value,
      Attribute[] attributes)
    {
      PropertyGrid2 propertyGrid = PropertyGrid2.GetPropertyGrid(context) as PropertyGrid2;
      bool flag = false;
      if (propertyGrid != null)
        flag = propertyGrid.IsReadOnly;
      PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value, attributes);
      PropertyDescriptorCollection descriptorCollection = new PropertyDescriptorCollection((PropertyDescriptor[]) null);
      string resourceBaseNameForType = (string) null;
      foreach (Attribute customAttribute in value.GetType().GetCustomAttributes(true))
      {
        if (customAttribute.GetType().Equals(typeof (GlobalizedTypeAttribute)))
          resourceBaseNameForType = ((GlobalizedTypeAttribute) customAttribute).BaseName;
      }
      ArrayList arrayList1 = new ArrayList();
      foreach (PropertyDescriptor propertyDescriptor in properties)
      {
        PropertyAttributes propertyAttributes = this.method_0(propertyDescriptor, value, resourceBaseNameForType);
        if (flag)
          propertyAttributes.IsReadOnly = true;
        if (propertyAttributes.IsBrowsable)
        {
          arrayList1.Add((object) propertyAttributes);
          descriptorCollection.Add((PropertyDescriptor) new PropertyDescriptor2(propertyDescriptor, propertyAttributes));
        }
      }
      arrayList1.Sort();
      ArrayList arrayList2 = new ArrayList();
      foreach (PropertyAttributes propertyAttributes in arrayList1)
        arrayList2.Add((object) propertyAttributes.Name);
      return descriptorCollection.Sort((string[]) arrayList2.ToArray(typeof (string)));
    }

    private PropertyAttributes method_0(
      PropertyDescriptor propertyDescriptor,
      object target,
      string resourceBaseNameForType)
    {
      PropertyAttributes propertyAttributes = new PropertyAttributes(propertyDescriptor.Name);
      string baseName = (string) null;
      string str = (string) null;
      string name1 = (string) null;
      string name2 = (string) null;
      string name3 = (string) null;
      foreach (Attribute attribute in propertyDescriptor.Attributes)
      {
        Type type = attribute.GetType();
        if (type.Equals(typeof (DisplayNameAttribute)))
          str = ((DisplayNameAttribute) attribute).DisplayName;
        else if (type.Equals(typeof (GlobalizedPropertyAttribute)))
        {
          name1 = ((GlobalizedPropertyAttribute) attribute).DisplayNameId;
          name2 = ((GlobalizedPropertyAttribute) attribute).DescriptionId;
          name3 = ((GlobalizedPropertyAttribute) attribute).CategoryId;
          baseName = ((GlobalizedPropertyAttribute) attribute).BaseName;
        }
        else if (type.Equals(typeof (PropertyIndexAttribute)))
          propertyAttributes.Order = ((PropertyIndexAttribute) attribute).Index;
      }
      if (baseName == null)
        baseName = resourceBaseNameForType != null ? resourceBaseNameForType : propertyDescriptor.ComponentType.Namespace + "." + propertyDescriptor.ComponentType.Name;
      Assembly assembly = propertyDescriptor.ComponentType.Assembly;
      ResourceManager resourceManager;
      if (assembly.GetManifestResourceInfo(baseName + ".resources") == null)
      {
        resourceManager = (ResourceManager) null;
      }
      else
      {
        resourceManager = new ResourceManager(baseName, assembly);
        if (name1 == null)
          name1 = propertyDescriptor.DisplayName + "_DisplayName";
        if (name2 == null)
          name2 = propertyDescriptor.DisplayName + "_Description";
        if (name3 == null)
          name3 = propertyDescriptor.Category + "_Category";
      }
      propertyAttributes.DisplayName = resourceManager == null ? (string) null : resourceManager.GetString(name1);
      if (propertyAttributes.DisplayName == null)
        propertyAttributes.DisplayName = str;
      if (propertyAttributes.DisplayName == null)
        propertyAttributes.DisplayName = propertyDescriptor.DisplayName;
      propertyAttributes.Description = resourceManager == null ? (string) null : resourceManager.GetString(name2);
      if (propertyAttributes.Description == null)
        propertyAttributes.Description = propertyDescriptor.Description;
      propertyAttributes.Category = resourceManager == null ? (string) null : resourceManager.GetString(name3);
      if (propertyAttributes.Category == null)
        propertyAttributes.Category = propertyDescriptor.Category;
      propertyAttributes.IsReadOnly = propertyDescriptor.IsReadOnly;
      propertyAttributes.IsBrowsable = propertyDescriptor.IsBrowsable;
      PropertyAttributesProviderAttribute attribute1 = (PropertyAttributesProviderAttribute) propertyDescriptor.Attributes[typeof (PropertyAttributesProviderAttribute)];
      if (attribute1 != null)
      {
        MethodInfo attributesProvider = attribute1.GetPropertyAttributesProvider(target);
        if (attributesProvider != (MethodInfo) null)
          attributesProvider.Invoke(target, new object[1]
          {
            (object) propertyAttributes
          });
      }
      return propertyAttributes;
    }
  }
}
