﻿// Decompiled with JetBrains decompiler
// Type: WW.Actions.CommandEventArgs
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Actions
{
  public class CommandEventArgs : EventArgs
  {
    public static readonly CommandEventArgs Empty = new CommandEventArgs((ICommand) null);
    private readonly ICommand icommand_0;

    public CommandEventArgs(ICommand command)
    {
      this.icommand_0 = command;
    }

    public ICommand Command
    {
      get
      {
        return this.icommand_0;
      }
    }
  }
}
