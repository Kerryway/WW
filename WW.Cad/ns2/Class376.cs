// Decompiled with JetBrains decompiler
// Type: ns2.Class376
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns3;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns2
{
  internal class Class376 : Class374
  {
    public Class376(DxfModel model, DxfMessageCollection messages)
      : base(model, messages)
    {
    }

    public override FileFormat FileFormat
    {
      get
      {
        return FileFormat.Dwg;
      }
    }

    protected override void vmethod_0()
    {
      DxfBlock dxfBlock = DxfBlock.smethod_2(this.Model, true, false);
      if (dxfBlock == null)
        return;
      this.Model.method_24(dxfBlock.Entities);
    }

    protected override void vmethod_2()
    {
      foreach (DxfLayout layout in this.Layouts)
      {
        Class284 class284 = this.method_5(layout.Handle) as Class284;
        if (class284 != null && !class284.HasViewportHandles)
        {
          DxfBlock ownerBlock = layout.OwnerBlock;
          if (ownerBlock != null)
          {
            Class318 class318 = this.method_5(ownerBlock.Handle) as Class318;
            if (class318 != null && class318.OrderedViewports.Count > 0)
              layout.Viewports.AddRange((IEnumerable<DxfViewport>) class318.OrderedViewports);
          }
        }
      }
      DxfLayout dxfLayout = this.Model.method_15();
      if (dxfLayout != null)
      {
        foreach (Class259 entityHeaderBuilder in this.ViewportEntityHeaderBuilders)
        {
          DxfViewport viewport = ((DxfViewportEntityHeader) entityHeaderBuilder.HandledObject).Viewport;
          if (viewport != null && !dxfLayout.Viewports.Contains(viewport))
            dxfLayout.Viewports.Add(viewport);
        }
      }
      foreach (Class308 viewportBuilder in this.ViewportBuilders)
      {
        DxfViewport handledObject = (DxfViewport) viewportBuilder.HandledObject;
        if (viewportBuilder.EntityMode == (byte) 0)
        {
          if (viewportBuilder.ParentEntityRefHandle != 0UL)
          {
            DxfBlock dxfBlock = this.method_4<DxfBlock>(viewportBuilder.ParentEntityRefHandle);
            handledObject.vmethod_2((IDxfHandledObject) dxfBlock);
            if (dxfBlock.Layout != null && !dxfBlock.Layout.Viewports.Contains(handledObject))
              dxfBlock.Layout.Viewports.Add(handledObject);
          }
        }
        else if (viewportBuilder.EntityMode == (byte) 1)
        {
          if (this.PaperSpaceBlockRecordHandle != 0UL)
          {
            DxfBlock dxfBlock = this.method_4<DxfBlock>(this.PaperSpaceBlockRecordHandle);
            if (dxfBlock != null && dxfBlock.Layout != null && !dxfBlock.Layout.Viewports.Contains(handledObject))
              dxfBlock.Layout.Viewports.Add(handledObject);
          }
        }
        else if (viewportBuilder.EntityMode == (byte) 2 && this.ModelSpaceBlockRecordHandle != 0UL)
        {
          DxfBlock dxfBlock = this.method_4<DxfBlock>(this.ModelSpaceBlockRecordHandle);
          if (dxfBlock != null && dxfBlock.Layout != null && !dxfBlock.Layout.Viewports.Contains(handledObject))
            dxfBlock.Layout.Viewports.Add(handledObject);
        }
      }
    }
  }
}
