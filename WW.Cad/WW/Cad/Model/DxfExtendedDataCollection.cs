// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfExtendedDataCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;
using WW.Cad.Base;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model
{
  public class DxfExtendedDataCollection : KeyedCollection<DxfAppId, DxfExtendedData>
  {
    protected override DxfAppId GetKeyForItem(DxfExtendedData item)
    {
      return item.AppId;
    }

    public bool TryGetValue(DxfAppId appId, out DxfExtendedData extendedData)
    {
      if (this.Dictionary != null)
        return this.Dictionary.TryGetValue(appId, out extendedData);
      extendedData = (DxfExtendedData) null;
      return false;
    }

    public bool TryGetValue(DxfModel model, string appIdName, out DxfExtendedData extendedData)
    {
      if (this.Dictionary == null)
      {
        extendedData = (DxfExtendedData) null;
        return false;
      }
      DxfAppId key;
      if (model.AppIds.TryGetValue(appIdName, out key))
        return this.Dictionary.TryGetValue(key, out extendedData);
      extendedData = (DxfExtendedData) null;
      return false;
    }

    public DxfExtendedData Get(DxfModel model, string appIdName)
    {
      DxfExtendedData extendedData;
      this.TryGetValue(model, appIdName, out extendedData);
      return extendedData;
    }

    public DxfExtendedDataCollection Clone(CloneContext cloneContext)
    {
      switch (cloneContext.ReferenceResolutionType)
      {
        case ReferenceResolutionType.IgnoreMissing:
          return (DxfExtendedDataCollection) null;
        case ReferenceResolutionType.CloneMissing:
          DxfExtendedDataCollection extendedDataCollection = new DxfExtendedDataCollection();
          foreach (DxfExtendedData dxfExtendedData in (IEnumerable<DxfExtendedData>) this.Items)
            extendedDataCollection.Add(dxfExtendedData.Clone(cloneContext));
          return extendedDataCollection;
        case ReferenceResolutionType.FailOnMissing:
          throw new DxfException(string.Format("Could not create necessary extended data for cloning."));
        default:
          return (DxfExtendedDataCollection) null;
      }
    }

    public bool Contains(DxfModel model, string appIdName)
    {
      DxfAppId key;
      if (model.AppIds.TryGetValue(appIdName, out key))
        return this.Contains(key);
      return false;
    }

    internal void method_0(DxfExtendedData item, DxfAppId appId)
    {
      this.ChangeItemKey(item, appId);
      item.AppId = appId;
    }
  }
}
