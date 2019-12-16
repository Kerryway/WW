// Decompiled with JetBrains decompiler
// Type: WW.Actions.CommandGroup
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Actions
{
  public class CommandGroup : ICommand
  {
    private Stack<ICommand> stack_0 = new Stack<ICommand>();
    private Stack<ICommand> stack_1 = new Stack<ICommand>();
    private object object_0;

    public CommandGroup()
    {
    }

    public CommandGroup(object target)
    {
      this.object_0 = target;
    }

    public CommandGroup(object target, params ICommand[] actions)
    {
      this.object_0 = target;
      for (int index = actions.Length - 1; index >= 0; --index)
        this.stack_0.Push(actions[index]);
    }

    public CommandGroup(params ICommand[] actions)
    {
      for (int index = actions.Length - 1; index >= 0; --index)
        this.stack_0.Push(actions[index]);
    }

    public Stack<ICommand> DoStack
    {
      get
      {
        return this.stack_0;
      }
    }

    public Stack<ICommand> UndoStack
    {
      get
      {
        return this.stack_1;
      }
    }

    public void UndoSingle(CommandInvoker commandInvoker)
    {
      if (this.stack_1.Count <= 0)
        return;
      ICommand command = this.stack_1.Pop();
      this.stack_0.Push(command);
      commandInvoker.Undo(command);
    }

    public void DoSingle(CommandInvoker commandInvoker)
    {
      if (this.stack_0.Count <= 0)
        return;
      ICommand command = this.stack_0.Pop();
      this.stack_1.Push(command);
      commandInvoker.Do(command);
    }

    public void Clear()
    {
      this.stack_0.Clear();
      this.stack_1.Clear();
    }

    public object Target
    {
      get
      {
        return this.object_0;
      }
    }

    public void Undo(CommandInvoker commandInvoker)
    {
      while (this.stack_1.Count > 0)
      {
        ICommand command = this.stack_1.Pop();
        this.stack_0.Push(command);
        commandInvoker.Undo(command);
      }
    }

    public void Do(CommandInvoker commandInvoker)
    {
      while (this.stack_0.Count > 0)
      {
        ICommand command = this.stack_0.Pop();
        this.stack_1.Push(command);
        commandInvoker.Do(command);
      }
    }
  }
}
