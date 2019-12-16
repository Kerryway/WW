// Decompiled with JetBrains decompiler
// Type: ns3.Class891
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class891 : Interface10
  {
    private DxfLineType dxfLineType_0;
    private DxfLineType.Element element_0;
    private ulong ulong_0;

    public Class891(DxfLineType lineType, DxfLineType.Element element)
    {
      this.dxfLineType_0 = lineType;
      this.element_0 = element;
    }

    public DxfLineType.Element Element
    {
      get
      {
        return this.element_0;
      }
      set
      {
        this.element_0 = value;
      }
    }

    public ulong TextStyleHandle
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

    public void ResolveReferences(Class374 modelBuilder)
    {
      if (this.ulong_0 != 0UL)
      {
        DxfHandledObject dxfHandledObject = modelBuilder.method_3(this.ulong_0);
        if (dxfHandledObject != null)
        {
          DxfTextStyle dxfTextStyle = dxfHandledObject as DxfTextStyle;
          if (dxfTextStyle != null)
            this.element_0.TextStyle = dxfTextStyle;
          else
            modelBuilder.Messages.Add(new DxfMessage(DxfStatus.WrongType, Severity.Error)
            {
              Parameters = {
                {
                  "Handle",
                  (object) this.ulong_0
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
                  (object) this.dxfLineType_0.Handle
                }
              }
            });
        }
      }
      this.element_0.method_0(modelBuilder.Model);
    }
  }
}
