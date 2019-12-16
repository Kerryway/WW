// Decompiled with JetBrains decompiler
// Type: WW.Actions.InteractorWrapper
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Windows.Input;

namespace WW.Actions
{
  public abstract class InteractorWrapper : IInteractor
  {
    private IInteractor iinteractor_0;

    protected InteractorWrapper(IInteractor wrappee)
    {
      this.iinteractor_0 = wrappee;
      this.iinteractor_0.Deactivated += new EventHandler(this.iinteractor_0_Deactivated);
    }

    public IInteractor Wrappee
    {
      get
      {
        return this.iinteractor_0;
      }
    }

    public event EventHandler Activated;

    public event EventHandler Deactivated;

    public virtual bool IsEnabled
    {
      get
      {
        return this.iinteractor_0.IsEnabled;
      }
      set
      {
        this.iinteractor_0.IsEnabled = value;
      }
    }

    public virtual bool IsActive
    {
      get
      {
        return this.iinteractor_0.IsActive;
      }
    }

    public virtual void Activate()
    {
      this.iinteractor_0.Activate();
    }

    public virtual void Deactivate()
    {
      this.iinteractor_0.Deactivate();
    }

    public virtual bool ProcessMouseButtonDown(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      return this.iinteractor_0.ProcessMouseButtonDown(e, context);
    }

    public virtual bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
    {
      return this.iinteractor_0.ProcessMouseMove(e, context);
    }

    public virtual bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context)
    {
      return this.iinteractor_0.ProcessMouseButtonUp(e, context);
    }

    public virtual bool ProcessMouseWheel(CanonicalMouseEventArgs e, InteractionContext context)
    {
      return this.iinteractor_0.ProcessMouseWheel(e, context);
    }

    public bool ProcessMouseClick(CanonicalMouseEventArgs e, InteractionContext context)
    {
      return this.iinteractor_0.ProcessMouseClick(e, context);
    }

    public bool ProcessMouseDoubleClick(CanonicalMouseEventArgs e, InteractionContext context)
    {
      return this.iinteractor_0.ProcessMouseDoubleClick(e, context);
    }

    public bool ProcessKeyDown(
      CanonicalMouseEventArgs e,
      Key key,
      ModifierKeys modifierKeys,
      InteractionContext context)
    {
      return this.iinteractor_0.ProcessKeyDown(e, key, modifierKeys, context);
    }

    public bool ProcessTextInput(string text, InteractionContext context)
    {
      return this.iinteractor_0.ProcessTextInput(text, context);
    }

    public virtual object GetStateForStore()
    {
      return this.iinteractor_0.GetStateForStore();
    }

    public virtual void SetStateFromStore(object state)
    {
      this.iinteractor_0.SetStateFromStore(state);
    }

    public virtual void ResetState()
    {
      this.iinteractor_0.ResetState();
    }

    protected virtual void OnActivated(EventArgs e)
    {
      if (this.Activated == null)
        return;
      this.Activated((object) this, e);
    }

    protected virtual void OnDeactivated(EventArgs e)
    {
      if (this.Deactivated == null)
        return;
      this.Deactivated((object) this, e);
    }

    public string UserHint
    {
      get
      {
        return this.iinteractor_0.UserHint;
      }
    }

    private void iinteractor_0_Deactivated(object sender, EventArgs e)
    {
      this.OnDeactivated(e);
    }
  }
}
