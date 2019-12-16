// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.MessageForwarder
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;
using System.Windows.Forms;

namespace WW.Windows.Forms
{
  public class MessageForwarder : Control, IMessageFilter
  {
    private const int int_0 = 8192;
    private Control control_0;
    private HashSet<int> hashSet_0;
    private bool bool_0;

    public MessageForwarder(Control control, int message)
      : this(control, (IEnumerable<int>) new int[1]{ message })
    {
    }

    public MessageForwarder(Control control, IEnumerable<int> messages)
    {
      this.control_0 = control;
      this.hashSet_0 = new HashSet<int>(messages);
    }

    public void AddMessageFilter()
    {
      if (this.bool_0)
        return;
      Application.AddMessageFilter((IMessageFilter) this);
      this.bool_0 = true;
    }

    public void RemoveMessageFilter()
    {
      if (!this.bool_0)
        return;
      Application.RemoveMessageFilter((IMessageFilter) this);
      this.bool_0 = false;
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      this.RemoveMessageFilter();
      if (this.control_0 == null)
        return;
      this.control_0 = (Control) null;
    }

    public bool PreFilterMessage(ref Message m)
    {
      if (!this.hashSet_0.Contains(m.Msg) || !this.control_0.CanFocus || this.control_0.Focused)
        return false;
      m.Msg -= 8192;
      Control.ReflectMessage(this.control_0.Handle, ref m);
      return true;
    }
  }
}
