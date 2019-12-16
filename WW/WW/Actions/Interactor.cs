// Decompiled with JetBrains decompiler
// Type: WW.Actions.Interactor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using WW.Drawing;
using WW.Math;

namespace WW.Actions
{
  public class Interactor : IInteractor
  {
    private bool bool_0 = true;
    private bool bool_1;

    public event EventHandler<CommandEventArgs> CommandCreated;

    public bool IsEnabled
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public bool IsActive
    {
      get
      {
        return this.bool_1;
      }
    }

    public virtual Transaction Transaction
    {
      get
      {
        return (Transaction) null;
      }
    }

    public event EventHandler Activated;

    public event EventHandler Deactivated;

    public virtual void Activate()
    {
      if (this.bool_1)
        return;
      this.bool_1 = true;
      this.OnActivated(EventArgs.Empty);
    }

    public virtual void Deactivate()
    {
      if (!this.bool_1)
        return;
      this.bool_1 = false;
      this.OnDeactivated(EventArgs.Empty);
    }

    public virtual bool ProcessMouseButtonDown(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      return false;
    }

    public virtual bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
    {
      return false;
    }

    public virtual bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context)
    {
      return false;
    }

    public virtual bool ProcessMouseWheel(CanonicalMouseEventArgs e, InteractionContext context)
    {
      return false;
    }

    public virtual bool ProcessMouseClick(CanonicalMouseEventArgs e, InteractionContext context)
    {
      return false;
    }

    public virtual bool ProcessMouseDoubleClick(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      return false;
    }

    public virtual bool ProcessKeyDown(
      CanonicalMouseEventArgs e,
      Key key,
      ModifierKeys modifierKeys,
      InteractionContext context)
    {
      return false;
    }

    public virtual bool ProcessTextInput(string text, InteractionContext context)
    {
      return false;
    }

    public virtual object GetStateForStore()
    {
      return (object) null;
    }

    public virtual void SetStateFromStore(object state)
    {
    }

    public virtual void ResetState()
    {
    }

    public virtual string UserHint
    {
      get
      {
        return string.Empty;
      }
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

    protected virtual void OnCommandCreated(CommandEventArgs e)
    {
      if (this.CommandCreated == null)
        return;
      this.CommandCreated((object) this, e);
    }

    public class WinFormsDrawable : IInteractorWinFormsDrawable
    {
      public virtual void DrawBackground(
        PaintEventArgs e,
        GraphicsHelper graphicsHelper,
        InteractionContext context)
      {
      }

      public virtual void Draw(
        PaintEventArgs e,
        GraphicsHelper graphicsHelper,
        InteractionContext context)
      {
      }

      public virtual System.Windows.Forms.Cursor GetCursor()
      {
        return (System.Windows.Forms.Cursor) null;
      }

      public virtual bool TryCreateCaretBitmap(
        GraphicsHelper graphicsHelper,
        InteractionContext context,
        out Bitmap caretBitmap,
        out Point2D dcsPosition)
      {
        caretBitmap = (Bitmap) null;
        dcsPosition = Point2D.Zero;
        return false;
      }
    }
  }
}
