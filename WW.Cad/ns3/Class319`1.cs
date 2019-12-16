// Decompiled with JetBrains decompiler
// Type: ns3.Class319`1
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
  internal class Class319<T> : Class259 where T : DxfTableRecord
  {
    private List<ulong> list_1 = new List<ulong>();
    private KeyedDxfHandledObjectCollection<string, T> keyedDxfHandledObjectCollection_0;

    public Class319(
      DxfHandledObject tableControl,
      KeyedDxfHandledObjectCollection<string, T> tableRecords)
      : base(tableControl)
    {
      this.keyedDxfHandledObjectCollection_0 = tableRecords;
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
      DxfHandledObject dxfHandledObject = modelBuilder.method_3(handle);
      T obj = dxfHandledObject as T;
      if ((object) obj != null)
      {
        if (this.keyedDxfHandledObjectCollection_0.Contains(obj.Name))
        {
          string name = obj.Name;
          do
          {
            obj.Name = string.Format("AUDIT_{0}", (object) modelBuilder.method_21());
          }
          while (this.keyedDxfHandledObjectCollection_0.Contains(obj.Name));
          this.keyedDxfHandledObjectCollection_0.Add(obj);
          modelBuilder.Messages.Add(new DxfMessage(DxfStatus.AuditRepairedDuplicateName, Severity.Warning)
          {
            Parameters = {
              {
                "Class",
                (object) obj.GetType().FullName
              },
              {
                "OriginalName",
                (object) name
              },
              {
                "RepairedName",
                (object) obj.Name
              }
            }
          });
        }
        else
          this.keyedDxfHandledObjectCollection_0.Add(obj);
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
