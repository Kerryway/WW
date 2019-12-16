// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.ColorComponentEditor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WW.Windows.Forms
{
  public class ColorComponentEditor : UserControl
  {
    private bool bool_0;
    private IContainer icontainer_0;
    private ColorComponentBar colorComponentBar;
    private System.Windows.Forms.Label label;
    private NumericUpDown numericUpDown;

    public event EventHandler ColorComponentValueChanged;

    public ColorComponentEditor()
    {
      this.InitializeComponent();
    }

    public string Label
    {
      get
      {
        return this.label.Text;
      }
      set
      {
        this.label.Text = value;
      }
    }

    public int ColorComponentValue
    {
      get
      {
        return this.colorComponentBar.ColorComponentValue;
      }
      set
      {
        if (this.colorComponentBar.ColorComponentValue == value)
          return;
        this.colorComponentBar.ColorComponentValue = value;
        if (!this.bool_0)
        {
          this.bool_0 = true;
          try
          {
            this.numericUpDown.Value = (Decimal) value;
          }
          finally
          {
            this.bool_0 = false;
          }
        }
        this.OnColorComponentValueChanged(EventArgs.Empty);
      }
    }

    public int ColorComponentMaxValue
    {
      get
      {
        return this.colorComponentBar.ColorComponentMaxValue;
      }
      set
      {
        this.colorComponentBar.ColorComponentMaxValue = value;
        this.numericUpDown.Maximum = (Decimal) value;
      }
    }

    public Func<int, Color> ColorComponentToColorMapper
    {
      get
      {
        return this.colorComponentBar.ColorComponentToColorMapper;
      }
      set
      {
        this.colorComponentBar.ColorComponentToColorMapper = value;
      }
    }

    protected virtual void OnColorComponentValueChanged(EventArgs e)
    {
      if (this.ColorComponentValueChanged == null)
        return;
      this.ColorComponentValueChanged((object) this, e);
    }

    protected override void OnInvalidated(InvalidateEventArgs e)
    {
      base.OnInvalidated(e);
      this.colorComponentBar.Invalidate();
    }

    private void numericUpDown_ValueChanged(object sender, EventArgs e)
    {
      if (this.bool_0)
        return;
      this.bool_0 = true;
      try
      {
        this.ColorComponentValue = (int) (byte) this.numericUpDown.Value;
      }
      finally
      {
        this.bool_0 = false;
      }
    }

    private void colorComponentBar_ColorComponentValueChanged(object sender, EventArgs e)
    {
      if (this.bool_0)
        return;
      this.bool_0 = true;
      try
      {
        this.numericUpDown.Value = (Decimal) this.ColorComponentValue;
        this.OnColorComponentValueChanged(EventArgs.Empty);
      }
      finally
      {
        this.bool_0 = false;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label = new System.Windows.Forms.Label();
      this.numericUpDown = new NumericUpDown();
      this.colorComponentBar = new ColorComponentBar();
      this.numericUpDown.BeginInit();
      this.SuspendLayout();
      this.label.AutoSize = true;
      this.label.Location = new Point(3, 9);
      this.label.Name = "label";
      this.label.Size = new Size(35, 13);
      this.label.TabIndex = 1;
      this.label.Text = "[label]";
      this.numericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.numericUpDown.Location = new Point(349, 5);
      this.numericUpDown.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown.Name = "numericUpDown";
      this.numericUpDown.Size = new Size(59, 20);
      this.numericUpDown.TabIndex = 2;
      this.numericUpDown.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
      this.colorComponentBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.colorComponentBar.BarPosition = new Point(6, 3);
      this.colorComponentBar.BarSize = new Size(256, 10);
      this.colorComponentBar.ColorComponentMaxValue = (int) byte.MaxValue;
      this.colorComponentBar.ColorComponentToColorMapper = (Func<int, Color>) null;
      this.colorComponentBar.ColorComponentValue = 0;
      this.colorComponentBar.Location = new Point(74, 3);
      this.colorComponentBar.Name = "colorComponentBar";
      this.colorComponentBar.Size = new Size(270, 24);
      this.colorComponentBar.TabIndex = 0;
      this.colorComponentBar.Text = "colorComponentBar";
      this.colorComponentBar.ColorComponentValueChanged += new EventHandler(this.colorComponentBar_ColorComponentValueChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.numericUpDown);
      this.Controls.Add((Control) this.label);
      this.Controls.Add((Control) this.colorComponentBar);
      this.Name = nameof (ColorComponentEditor);
      this.Size = new Size(414, 30);
      this.numericUpDown.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
