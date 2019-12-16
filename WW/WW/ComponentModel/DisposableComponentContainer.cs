// Decompiled with JetBrains decompiler
// Type: WW.ComponentModel.DisposableComponentContainer
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.ComponentModel;

namespace WW.ComponentModel
{
  public class DisposableComponentContainer : IDisposable, IComponent
  {
    private IDisposable idisposable_0;
    private ISite isite_0;

    public DisposableComponentContainer()
    {
    }

    public DisposableComponentContainer(IDisposable disposable)
    {
      this.idisposable_0 = disposable;
    }

    public IDisposable Disposable
    {
      get
      {
        return this.idisposable_0;
      }
      set
      {
        this.idisposable_0 = value;
      }
    }

    public event EventHandler Disposed;

    protected virtual void OnDisposed(EventArgs e)
    {
      if (this.Disposed == null)
        return;
      this.Disposed((object) this, e);
    }

    public ISite Site
    {
      get
      {
        return this.isite_0;
      }
      set
      {
        this.isite_0 = value;
      }
    }

    public void Dispose()
    {
      if (this.idisposable_0 == null)
        return;
      this.idisposable_0.Dispose();
      this.idisposable_0 = (IDisposable) null;
      this.OnDisposed(EventArgs.Empty);
    }
  }
}
