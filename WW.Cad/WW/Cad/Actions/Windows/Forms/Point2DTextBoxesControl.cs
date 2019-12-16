// Decompiled with JetBrains decompiler
// Type: WW.Cad.Actions.Windows.Forms.Point2DTextBoxesControl
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WW.Actions;
using WW.Math;

namespace WW.Cad.Actions.Windows.Forms
{
  public class Point2DTextBoxesControl : UserControl
  {
    private IContainer icontainer_0;
    private Label label1;
    private TextBox xTextBox;
    private Label label2;
    private TextBox yTextBox;
    private Point2D point2D_0;
    private DialogResult dialogResult_0;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.xTextBox = new TextBox();
      this.label2 = new Label();
      this.yTextBox = new TextBox();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 6);
      this.label1.Name = "label1";
      this.label1.Size = new Size(14, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "X";
      this.xTextBox.Location = new System.Drawing.Point(23, 3);
      this.xTextBox.Name = "xTextBox";
      this.xTextBox.Size = new Size(100, 20);
      this.xTextBox.TabIndex = 1;
      this.xTextBox.TextChanged += new EventHandler(this.xTextBox_TextChanged);
      this.xTextBox.KeyPress += new KeyPressEventHandler(this.yTextBox_KeyPress);
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(129, 6);
      this.label2.Name = "label2";
      this.label2.Size = new Size(14, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Y";
      this.yTextBox.Location = new System.Drawing.Point(149, 3);
      this.yTextBox.Name = "yTextBox";
      this.yTextBox.Size = new Size(100, 20);
      this.yTextBox.TabIndex = 3;
      this.yTextBox.TextChanged += new EventHandler(this.yTextBox_TextChanged);
      this.yTextBox.KeyPress += new KeyPressEventHandler(this.yTextBox_KeyPress);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.yTextBox);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.xTextBox);
      this.Controls.Add((Control) this.label1);
      this.Name = nameof (Point2DTextBoxesControl);
      this.Size = new Size((int) byte.MaxValue, 26);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public event EventHandler PointChanged;

    public event EventHandler Closed;

    public Point2DTextBoxesControl()
    {
      this.InitializeComponent();
    }

    public Point2D Point
    {
      get
      {
        return this.point2D_0;
      }
    }

    public DialogResult DialogResult
    {
      get
      {
        return this.dialogResult_0;
      }
    }

    public void SetPoint(Point2D value, InteractionContext context)
    {
      this.point2D_0 = value;
      this.xTextBox.Text = this.point2D_0.X.ToString(context.LengthFormatString);
      this.xTextBox.SelectAll();
      this.yTextBox.Text = this.point2D_0.Y.ToString(context.LengthFormatString);
      this.yTextBox.SelectAll();
      this.xTextBox.Focus();
    }

    protected virtual void OnPointChanged(EventArgs e)
    {
      if (this.eventHandler_0 == null)
        return;
      this.eventHandler_0((object) this, e);
    }

    protected virtual void OnClosed(EventArgs e)
    {
      if (this.eventHandler_1 == null)
        return;
      this.eventHandler_1((object) this, e);
    }

    private void xTextBox_TextChanged(object sender, EventArgs e)
    {
      double result;
      if (!double.TryParse(this.xTextBox.Text, out result))
        return;
      this.point2D_0.X = result;
      this.OnPointChanged(EventArgs.Empty);
    }

    private void yTextBox_TextChanged(object sender, EventArgs e)
    {
      double result;
      if (!double.TryParse(this.yTextBox.Text, out result))
        return;
      this.point2D_0.Y = result;
      this.OnPointChanged(EventArgs.Empty);
    }

    private void yTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\r')
      {
        this.dialogResult_0 = DialogResult.OK;
        this.OnClosed(EventArgs.Empty);
      }
      else
      {
        if (e.KeyChar != '\x001B')
          return;
        this.dialogResult_0 = DialogResult.Cancel;
        this.OnClosed(EventArgs.Empty);
      }
    }
  }
}
