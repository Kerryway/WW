// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.FloatingForm
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;

namespace WW.Windows.Forms
{
  public class FloatingForm : Form
  {
    private const int int_0 = 70;
    private const int int_1 = 36;
    private IContainer icontainer_0;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(129, 33);
      this.ControlBox = false;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (FloatingForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.TopMost = true;
      this.ResumeLayout(false);
    }

    public FloatingForm()
    {
      this.InitializeComponent();
    }

    [SecuritySafeCritical]
    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);
      if (m.Msg != 36)
        return;
      FloatingForm.Struct5 lparam = (FloatingForm.Struct5) m.GetLParam(typeof (FloatingForm.Struct5));
      lparam.struct4_3.int_0 = this.MinimumSize.Width;
      lparam.struct4_3.int_1 = this.MinimumSize.Height;
      Marshal.StructureToPtr((object) lparam, m.LParam, true);
    }

    private struct Struct3
    {
      public IntPtr intptr_0;
      public IntPtr intptr_1;
      public int int_0;
      public int int_1;
      public int int_2;
      public int int_3;
      public uint uint_0;
    }

    private struct Struct4
    {
      public int int_0;
      public int int_1;
    }

    private struct Struct5
    {
      public FloatingForm.Struct4 struct4_0;
      public FloatingForm.Struct4 struct4_1;
      public FloatingForm.Struct4 struct4_2;
      public FloatingForm.Struct4 struct4_3;
      public FloatingForm.Struct4 struct4_4;
    }
  }
}
