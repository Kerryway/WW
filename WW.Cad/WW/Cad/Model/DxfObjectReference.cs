// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfObjectReference
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model
{
  public class DxfObjectReference : IGraphCloneable
  {
    public static readonly DxfObjectReference Null = (DxfObjectReference) new DxfObjectReference.Class23();
    private ulong ulong_0;
    private IDxfHandledObject idxfHandledObject_0;

    private DxfObjectReference()
    {
    }

    protected DxfObjectReference(ulong handle)
    {
      this.ulong_0 = handle;
    }

    public DxfObjectReference(IDxfHandledObject value)
    {
      this.idxfHandledObject_0 = value;
    }

    public virtual ulong Handle
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

    public virtual IDxfHandledObject Value
    {
      get
      {
        return this.idxfHandledObject_0;
      }
      set
      {
        if (this.idxfHandledObject_0 != null)
          this.idxfHandledObject_0.Reference = (DxfObjectReference) null;
        this.idxfHandledObject_0 = value;
        if (value == null)
          return;
        value.Reference = this;
      }
    }

    public static DxfObjectReference GetReference(IDxfHandledObject o)
    {
      if (o != null)
        return o.Reference;
      return DxfObjectReference.Null;
    }

    public override string ToString()
    {
      if (this.idxfHandledObject_0 == null)
        return "null";
      return this.idxfHandledObject_0.ToString();
    }

    public virtual IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfObjectReference dxfObjectReference = (DxfObjectReference) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfObjectReference == null)
      {
        if (cloneContext.TargetModel == cloneContext.SourceModel)
        {
          dxfObjectReference = this;
        }
        else
        {
          dxfObjectReference = new DxfObjectReference();
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfObjectReference);
          IGraphCloneable idxfHandledObject0 = (IGraphCloneable) this.idxfHandledObject_0;
          dxfObjectReference.Value = (IDxfHandledObject) idxfHandledObject0.Clone(cloneContext);
        }
      }
      return (IGraphCloneable) dxfObjectReference;
    }

    private class Class23 : DxfObjectReference
    {
      public override ulong Handle
      {
        get
        {
          return 0;
        }
        set
        {
          throw new NotSupportedException();
        }
      }

      public override IDxfHandledObject Value
      {
        get
        {
          return (IDxfHandledObject) null;
        }
        set
        {
          throw new NotSupportedException();
        }
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        return (IGraphCloneable) DxfObjectReference.Null;
      }
    }

    internal class Class24 : DxfObjectReference
    {
      private System.Action<DxfObjectReference> action_0;

      public Class24(ulong handle, System.Action<DxfObjectReference> setReference)
        : base(handle)
      {
        this.action_0 = setReference;
      }

      public void method_0(DxfObjectReference objectReference)
      {
        this.action_0(objectReference);
      }

      public override IDxfHandledObject Value
      {
        get
        {
          throw new Exception("This is an unresolved object reference.");
        }
        set
        {
          throw new Exception("This is an unresolved object reference.");
        }
      }
    }
  }
}
