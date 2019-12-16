// Decompiled with JetBrains decompiler
// Type: WW.Actions.Transaction
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Actions
{
  public class Transaction : IDisposable, ITransaction
  {
    private CommandGroup commandGroup_0 = new CommandGroup();
    private TransactionStatus transactionStatus_0 = TransactionStatus.Open;
    private CommandInvoker commandInvoker_0;

    public event EventHandler<CommandEventArgs> CommandAdded;

    public event EventHandler Committed;

    public event EventHandler RolledBack;

    public event EventHandler Completed;

    public Transaction(CommandInvoker commandInvoker)
    {
      this.commandInvoker_0 = commandInvoker;
      commandInvoker.CommandUndone += new EventHandler<CommandEventArgs>(this.method_0);
    }

    public CommandInvoker CommandInvoker
    {
      get
      {
        return this.commandInvoker_0;
      }
    }

    public CommandGroup CommandGroup
    {
      get
      {
        return this.commandGroup_0;
      }
    }

    public TransactionStatus Status
    {
      get
      {
        return this.transactionStatus_0;
      }
    }

    public virtual void Add(ICommand command)
    {
      this.commandInvoker_0.Do(command);
      this.CommandGroup.UndoStack.Push(command);
      this.OnCommandAdded(new CommandEventArgs(command));
    }

    public virtual void Commit()
    {
      if (this.transactionStatus_0 != TransactionStatus.Open)
        return;
      this.transactionStatus_0 = TransactionStatus.Committed;
      this.Dispose();
      this.OnCommitted(EventArgs.Empty);
      this.OnCompleted(EventArgs.Empty);
    }

    public virtual void Rollback()
    {
      if (this.transactionStatus_0 != TransactionStatus.Open)
        return;
      this.transactionStatus_0 = TransactionStatus.RolledBack;
      this.commandInvoker_0.Undo((ICommand) this.commandGroup_0);
      this.OnRolledBack(EventArgs.Empty);
      this.OnCompleted(EventArgs.Empty);
    }

    protected virtual void OnCommandAdded(CommandEventArgs e)
    {
      if (this.CommandAdded == null)
        return;
      this.CommandAdded((object) this, e);
    }

    protected virtual void OnCommitted(EventArgs e)
    {
      if (this.Committed == null)
        return;
      this.Committed((object) this, e);
    }

    protected virtual void OnRolledBack(EventArgs e)
    {
      if (this.RolledBack == null)
        return;
      this.RolledBack((object) this, e);
    }

    protected virtual void OnCompleted(EventArgs e)
    {
      if (this.Completed == null)
        return;
      this.Completed((object) this, e);
    }

    private void method_0(object sender, CommandEventArgs e)
    {
      if (this.commandGroup_0.DoStack.Count <= 0 || this.commandGroup_0.DoStack.Peek() != e.Command || (this.commandGroup_0.UndoStack.Count != 0 || this.transactionStatus_0 != TransactionStatus.Open))
        return;
      this.Rollback();
    }

    public void Dispose()
    {
      if (this.commandInvoker_0 == null)
        return;
      this.commandInvoker_0.CommandUndone -= new EventHandler<CommandEventArgs>(this.method_0);
      this.commandInvoker_0 = (CommandInvoker) null;
    }
  }
}
