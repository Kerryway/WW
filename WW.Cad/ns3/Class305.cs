// Decompiled with JetBrains decompiler
// Type: ns3.Class305
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class305 : Class285
  {
    private ulong ulong_6;

    public Class305(DxfMText text)
      : base((DxfEntity) text)
    {
    }

    public ulong TextStyleHandle
    {
      get
      {
        return this.ulong_6;
      }
      set
      {
        this.ulong_6 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      if (this.ulong_6 == 0UL)
        return;
      DxfHandledObject dxfHandledObject = modelBuilder.method_3(this.ulong_6);
      if (dxfHandledObject == null)
        return;
      DxfTextStyle dxfTextStyle = dxfHandledObject as DxfTextStyle;
      if (dxfTextStyle != null)
        ((DxfMText) this.Entity).Style = dxfTextStyle;
      else
        modelBuilder.Messages.Add(new DxfMessage(DxfStatus.WrongType, Severity.Error)
        {
          Parameters = {
            {
              "Handle",
              (object) this.ulong_6
            },
            {
              "Type",
              (object) dxfHandledObject.GetType()
            },
            {
              "ExpectedType",
              (object) typeof (DxfTextStyle)
            },
            {
              "ReferencingObjectHandle",
              (object) this.Entity.Handle
            }
          }
        });
    }
  }
}
