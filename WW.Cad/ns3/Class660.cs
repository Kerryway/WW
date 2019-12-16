// Decompiled with JetBrains decompiler
// Type: ns3.Class660
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class660 : Interface10
  {
    private Class259 class259_0;
    private ulong ulong_0;
    private DxfExtendedData dxfExtendedData_0;
    private List<Interface10> list_0;

    public Class660(Class259 extendedDataOwner)
    {
      this.class259_0 = extendedDataOwner;
    }

    public Class259 ExtendedDataOwner
    {
      get
      {
        return this.class259_0;
      }
    }

    public ulong ApplicationHandle
    {
      get
      {
        return this.ulong_0;
      }
      set
      {
        this.ulong_0 = value;
      }
    }

    public DxfExtendedData ExtendedData
    {
      get
      {
        return this.dxfExtendedData_0;
      }
      set
      {
        this.dxfExtendedData_0 = value;
      }
    }

    public List<Interface10> ExtendedDataBuilders
    {
      get
      {
        if (this.list_0 == null)
          this.list_0 = new List<Interface10>();
        return this.list_0;
      }
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      if (this.dxfExtendedData_0 == null || this.ulong_0 == 0UL)
        return;
      DxfHandledObject dxfHandledObject = modelBuilder.method_3(this.ulong_0);
      if (dxfHandledObject == null)
      {
        DxfMessage dxfMessage = new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning, "AppIdHandle", (object) this.ulong_0);
        modelBuilder.Messages.Add(dxfMessage);
      }
      else
      {
        DxfAppId dxfAppId = dxfHandledObject as DxfAppId;
        if (dxfAppId == null)
          modelBuilder.Messages.Add(new DxfMessage(DxfStatus.WrongType, Severity.Warning, "ExpectedType", (object) typeof (DxfAppId))
          {
            Parameters = {
              {
                "ObjectType",
                (object) dxfHandledObject.GetType()
              },
              {
                "Object",
                (object) dxfHandledObject
              }
            }
          });
        else
          this.dxfExtendedData_0.AppId = dxfAppId;
        if (this.list_0 != null)
        {
          foreach (Interface10 nterface10 in this.list_0)
            nterface10.ResolveReferences(modelBuilder);
        }
      }
      if (this.class259_0 == null || this.class259_0.HandledObject == null)
        return;
      this.class259_0.HandledObject.ExtendedDataCollection.Add(this.dxfExtendedData_0);
    }
  }
}
