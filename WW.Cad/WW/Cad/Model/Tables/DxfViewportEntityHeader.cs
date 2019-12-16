// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfViewportEntityHeader
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model.Entities;

namespace WW.Cad.Model.Tables
{
  public class DxfViewportEntityHeader : DxfTableRecord
  {
    private string string_0 = string.Empty;
    private StandardFlags standardFlags_0;
    private DxfViewport dxfViewport_0;

    public override string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public override bool IsExternallyDependent
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsExternallyDependent) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsExternallyDependent;
        else
          this.standardFlags_0 &= ~StandardFlags.IsExternallyDependent;
      }
    }

    public override bool IsResolvedExternalRef
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsResolvedExternalRef) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsResolvedExternalRef;
        else
          this.standardFlags_0 &= ~StandardFlags.IsResolvedExternalRef;
      }
    }

    public override bool IsReferenced
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsReferenced) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsReferenced;
        else
          this.standardFlags_0 &= ~StandardFlags.IsReferenced;
      }
    }

    internal bool IsViewportOn
    {
      get
      {
        return (this.standardFlags_0 & (StandardFlags) 1) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= (StandardFlags) 1;
        else
          this.standardFlags_0 &= (StandardFlags) -2;
      }
    }

    public DxfViewport Viewport
    {
      get
      {
        return this.dxfViewport_0;
      }
      set
      {
        this.dxfViewport_0 = value;
      }
    }

    public override void Accept(ITableRecordVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfViewportEntityHeader viewportEntityHeader = (DxfViewportEntityHeader) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (viewportEntityHeader == null)
      {
        viewportEntityHeader = new DxfViewportEntityHeader();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) viewportEntityHeader);
        viewportEntityHeader.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) viewportEntityHeader;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.standardFlags_0 = ((DxfViewportEntityHeader) from).standardFlags_0;
    }

    internal StandardFlags Flags
    {
      get
      {
        return this.standardFlags_0;
      }
      set
      {
        this.standardFlags_0 = value;
      }
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      this.vmethod_2((IDxfHandledObject) modelContext.ViewportEntityHeaderTable);
    }
  }
}
