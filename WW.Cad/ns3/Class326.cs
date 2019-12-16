// Decompiled with JetBrains decompiler
// Type: ns3.Class326
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
  internal class Class326 : Class259
  {
    private List<ulong> list_1 = new List<ulong>();

    public Class326(DxfHandledObject tableControl)
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
      DxfTextStyle dxfTextStyle = dxfHandledObject as DxfTextStyle;
      if (dxfTextStyle != null)
      {
        if (!string.IsNullOrEmpty(dxfTextStyle.Name) && model.TextStyles.Contains(dxfTextStyle.Name))
        {
          string name = dxfTextStyle.Name;
          do
          {
            dxfTextStyle.Name = string.Format("AUDIT_{0}", (object) modelBuilder.method_21());
          }
          while (model.TextStyles.Contains(dxfTextStyle.Name));
          model.TextStyles.Add(dxfTextStyle);
          modelBuilder.Messages.Add(new DxfMessage(DxfStatus.AuditRepairedDuplicateName, Severity.Warning)
          {
            Parameters = {
              {
                "Class",
                (object) "AcDbTextStyleTableRecord"
              },
              {
                "OriginalName",
                (object) name
              },
              {
                "RepairedName",
                (object) dxfTextStyle.Name
              }
            }
          });
        }
        else
          model.TextStyles.Add(dxfTextStyle);
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
