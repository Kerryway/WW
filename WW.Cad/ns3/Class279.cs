// Decompiled with JetBrains decompiler
// Type: ns3.Class279
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class279 : Class260
  {
    private readonly List<Pair<ulong>> list_1 = new List<Pair<ulong>>();
    private ulong ulong_2;
    private readonly DxfMessageCollection dxfMessageCollection_0;

    public Class279(DxfSortEntsTable obj, DxfMessageCollection messages)
      : base((DxfObject) obj)
    {
      this.dxfMessageCollection_0 = messages;
    }

    public ulong OwnerBlockHandle
    {
      get
      {
        return this.ulong_2;
      }
      set
      {
        this.ulong_2 = value;
      }
    }

    public List<Pair<ulong>> EntityHandlePairs
    {
      get
      {
        return this.list_1;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfSortEntsTable handledObject = (DxfSortEntsTable) this.HandledObject;
      if (this.ulong_2 != 0UL)
      {
        DxfHandledObject dxfHandledObject = modelBuilder.method_3(this.ulong_2);
        DxfBlock dxfBlock = dxfHandledObject as DxfBlock;
        if (dxfBlock != null)
          handledObject.OwnerBlock = dxfBlock;
        else if (dxfHandledObject != null)
          this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.WrongType, Severity.Warning, "ExpectedType", (object) typeof (DxfBlock))
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
          this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning, "Handle", (object) this.ulong_2));
      }
      foreach (Pair<ulong> pair in this.list_1)
      {
        DxfHandledObject dxfHandledObject = modelBuilder.method_3(pair.First);
        DxfEntity entity = dxfHandledObject as DxfEntity;
        if (entity != null)
          handledObject.method_9(entity, pair.Second);
        else if (dxfHandledObject != null)
          this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.WrongType, Severity.Warning, "ExpectedType", (object) typeof (DxfEntity))
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
          this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning, "Handle", (object) this.ulong_2));
      }
    }
  }
}
