// Decompiled with JetBrains decompiler
// Type: ns3.Class327
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
  internal class Class327 : Class259
  {
    private List<ulong> list_1 = new List<ulong>();

    public Class327(DxfHandledObject tableControl)
      : base(tableControl)
    {
    }

    public List<ulong> TableRecordHandles
    {
      get
      {
        return this.list_1;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      int i = 0;
      foreach (ulong handle in this.list_1)
      {
        this.method_1(modelBuilder, handle, i);
        ++i;
      }
    }

    private void method_1(Class374 modelBuilder, ulong handle, int i)
    {
      DxfModel model = modelBuilder.Model;
      DxfHandledObject dxfHandledObject = modelBuilder.method_3(handle);
      DxfVPort dxfVport = dxfHandledObject as DxfVPort;
      if (dxfVport != null)
      {
        model.VPorts.Add(dxfVport);
      }
      else
      {
        if (dxfHandledObject == null)
          return;
        modelBuilder.Messages.Add(new DxfMessage(DxfStatus.WrongType, Severity.Error)
        {
          Parameters = {
            {
              "Handle",
              (object) handle
            },
            {
              "Type",
              (object) dxfHandledObject.GetType()
            },
            {
              "ExpectedType",
              (object) typeof (DxfAppId)
            },
            {
              "Index",
              (object) i
            }
          }
        });
      }
    }
  }
}
