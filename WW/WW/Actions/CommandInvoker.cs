// Decompiled with JetBrains decompiler
// Type: WW.Actions.CommandInvoker
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Actions
{
  public class CommandInvoker
  {
    public event EventHandler<CommandEventArgs> CommandDone;

    public event EventHandler<CommandEventArgs> CommandUndone;

    public void Do(ICommand command)
    {
      command.Do(this);
      this.OnCommandDone(new CommandEventArgs(command));
    }

    public void Undo(ICommand command)
    {
      command.Undo(this);
      this.OnCommandUndone(new CommandEventArgs(command));
    }

    protected virtual void OnCommandDone(CommandEventArgs e)
    {
      if (this.CommandDone == null)
        return;
      this.CommandDone((object) this, e);
    }

    protected virtual void OnCommandUndone(CommandEventArgs e)
    {
      if (this.CommandUndone == null)
        return;
      this.CommandUndone((object) this, e);
    }
  }
}
