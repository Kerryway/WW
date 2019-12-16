// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.TreeView2
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Windows.Forms;

namespace WW.Windows.Forms
{
  public class TreeView2 : TreeView
  {
    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 515)
        m.Result = IntPtr.Zero;
      else
        base.WndProc(ref m);
    }
  }
}
