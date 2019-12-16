// Decompiled with JetBrains decompiler
// Type: WW.Actions.InteractorMouseEventArgs
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Actions
{
  public class InteractorMouseEventArgs : EventArgs
  {
    private CanonicalMouseEventArgs canonicalMouseEventArgs_0;
    private InteractionContext interactionContext_0;

    public InteractorMouseEventArgs(
      CanonicalMouseEventArgs mouseEventArgs,
      InteractionContext interactionContext)
    {
      this.canonicalMouseEventArgs_0 = mouseEventArgs;
      this.interactionContext_0 = interactionContext;
    }

    public CanonicalMouseEventArgs MouseEventArgs
    {
      get
      {
        return this.canonicalMouseEventArgs_0;
      }
    }

    public InteractionContext InteractionContext
    {
      get
      {
        return this.interactionContext_0;
      }
    }
  }
}
