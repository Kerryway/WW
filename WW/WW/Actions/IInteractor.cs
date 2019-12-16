// Decompiled with JetBrains decompiler
// Type: WW.Actions.IInteractor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Windows.Input;

namespace WW.Actions
{
  public interface IInteractor
  {
    event EventHandler Activated;

    event EventHandler Deactivated;

    bool IsEnabled { get; set; }

    bool IsActive { get; }

    void Activate();

    void Deactivate();

    bool ProcessMouseButtonDown(CanonicalMouseEventArgs e, InteractionContext context);

    bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context);

    bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context);

    bool ProcessMouseWheel(CanonicalMouseEventArgs e, InteractionContext context);

    bool ProcessMouseClick(CanonicalMouseEventArgs e, InteractionContext context);

    bool ProcessMouseDoubleClick(CanonicalMouseEventArgs e, InteractionContext context);

    bool ProcessKeyDown(
      CanonicalMouseEventArgs e,
      Key key,
      ModifierKeys modifierKeys,
      InteractionContext context);

    bool ProcessTextInput(string text, InteractionContext context);

    object GetStateForStore();

    void SetStateFromStore(object state);

    void ResetState();

    string UserHint { get; }
  }
}
