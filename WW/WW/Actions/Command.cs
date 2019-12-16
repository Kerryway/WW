// Decompiled with JetBrains decompiler
// Type: WW.Actions.Command
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Actions
{
  public class Command : ICommand
  {
    public static readonly Action EmptyAction = (Action) (() => {});
    public static readonly Command Empty = new Command(Command.EmptyAction, Command.EmptyAction);
    private readonly object object_0;
    private readonly Action action_0;
    private readonly Action action_1;

    public Command(Action doAction, Action undoAction)
    {
      this.action_0 = undoAction;
      this.action_1 = doAction;
    }

    public Command(object target, Action doAction, Action undoAction)
    {
      this.object_0 = target;
      this.action_0 = undoAction;
      this.action_1 = doAction;
    }

    public object Target
    {
      get
      {
        return this.object_0;
      }
    }

    public void Do(CommandInvoker commandInvoker)
    {
      this.action_1();
    }

    public void Undo(CommandInvoker commandInvoker)
    {
      this.action_0();
    }
  }
}
