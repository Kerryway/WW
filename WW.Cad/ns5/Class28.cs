// Decompiled with JetBrains decompiler
// Type: ns5.Class28
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns5
{
  internal class Class28 : ActiveDxfHandledObjectCollection<DxfViewportEntityHeader>
  {
    internal void method_0(DxfModel model)
    {
      if (this.Count == 0)
        this.Add(new DxfViewportEntityHeader());
      DxfLayout dxfLayout = model.method_15();
      if (dxfLayout != null && dxfLayout.Viewports.Count != 0)
      {
        DxfViewportEntityHeader viewportEntityHeader1 = this[0];
        viewportEntityHeader1.Viewport = (DxfViewport) null;
        viewportEntityHeader1.Name = string.Empty;
        viewportEntityHeader1.Flags = StandardFlags.IsReferenced;
        for (int index = 0; index < dxfLayout.Viewports.Count; ++index)
        {
          DxfViewport viewport = dxfLayout.Viewports[index];
          DxfViewportEntityHeader viewportEntityHeader2;
          if (index + 1 < this.Count)
          {
            viewportEntityHeader2 = this[index + 1];
          }
          else
          {
            viewportEntityHeader2 = new DxfViewportEntityHeader();
            this.Add(viewportEntityHeader2);
          }
          viewportEntityHeader2.Viewport = viewport;
          viewportEntityHeader2.Flags = StandardFlags.IsReferenced;
          viewportEntityHeader2.IsViewportOn = !viewport.Disabled;
          viewport.method_13(viewportEntityHeader2);
          viewportEntityHeader2.Name = index == 0 ? "1" : string.Empty;
        }
        while (this.Count > dxfLayout.Viewports.Count + 1)
          this.RemoveAt(this.Count - 1);
      }
      else
        this.Clear();
    }

    public DxfViewportEntityHeader this[string name]
    {
      get
      {
        if (string.IsNullOrEmpty(name))
          return (DxfViewportEntityHeader) null;
        foreach (DxfViewportEntityHeader viewportEntityHeader in (DxfHandledObjectCollection<DxfViewportEntityHeader>) this)
        {
          if (string.Compare(viewportEntityHeader.Name, name, StringComparison.InvariantCultureIgnoreCase) == 0)
            return viewportEntityHeader;
        }
        return (DxfViewportEntityHeader) null;
      }
    }

    public bool TryGetValue(string name, out DxfViewportEntityHeader item)
    {
      item = this[name];
      return item != null;
    }

    public bool Contains(string name)
    {
      return this[name] != null;
    }
  }
}
