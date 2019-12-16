// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.ColorRgbEditor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace WW.Windows.Forms
{
  public class ColorRgbEditor : UserControl
  {
    private Color color_0 = Color.Black;
    private Color color_1;
    private Color color_2;
    private Color color_3;
    private bool bool_0;
    private IContainer icontainer_0;
    private ColorWheel colorWheel;
    private ColorComponentEditor redComponentEditor;
    private ColorComponentEditor greenComponentEditor;
    private ColorComponentEditor blueComponentEditor;
    private ColorComponentEditor hueComponentEditor;
    private ColorComponentEditor saturationComponentEditor;
    private ColorComponentEditor lightnessComponentEditor;
    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox hexValueTextBox;
    private Panel colorPanel;
    private ColorListPicker colorListPicker;

    public event EventHandler ColorChanged;

    public ColorRgbEditor()
    {
      this.InitializeComponent();
      this.redComponentEditor.ColorComponentToColorMapper = new Func<int, Color>(this.method_2);
      this.greenComponentEditor.ColorComponentToColorMapper = new Func<int, Color>(this.method_3);
      this.blueComponentEditor.ColorComponentToColorMapper = new Func<int, Color>(this.method_4);
      this.hueComponentEditor.ColorComponentToColorMapper = new Func<int, Color>(this.method_6);
      this.saturationComponentEditor.ColorComponentToColorMapper = new Func<int, Color>(this.method_7);
      this.lightnessComponentEditor.ColorComponentToColorMapper = new Func<int, Color>(this.method_8);
      this.colorListPicker.Colors.AddRange((IEnumerable<Color>) new Color[9]
      {
        Color.Black,
        Color.White,
        Color.Gray,
        Color.Red,
        Color.Green,
        Color.Blue,
        Color.Yellow,
        Color.Magenta,
        Color.Turquoise
      });
      this.method_1((Control) null);
    }

    public Color Color
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        this.color_1 = value;
        this.color_2 = value;
        this.color_3 = value;
        this.method_1((Control) null);
        this.OnColorChanged(EventArgs.Empty);
      }
    }

    public ColorListPicker ColorListPicker
    {
      get
      {
        return this.colorListPicker;
      }
    }

    protected virtual void OnColorChanged(EventArgs e)
    {
      if (this.ColorChanged == null)
        return;
      this.ColorChanged((object) this, e);
    }

    protected override void OnBackColorChanged(EventArgs e)
    {
      base.OnBackColorChanged(e);
      if (!(this.BackColor != Color.Transparent))
        return;
      foreach (Control control in (ArrangedElementCollection) this.Controls)
        control.BackColor = this.BackColor;
    }

    private void colorWheel_ColorChanged(object sender, EventArgs e)
    {
      if (this.bool_0 || !this.colorWheel.Color.HasValue)
        return;
      this.method_0(this.colorWheel.Color.Value, (Control) this.colorWheel);
    }

    private void redComponentEditor_ColorComponentValueChanged(object sender, EventArgs e)
    {
      if (this.bool_0)
        return;
      this.method_0(Color.FromArgb(this.color_0.A == (byte) 0 ? (int) byte.MaxValue : (int) this.color_0.A, this.redComponentEditor.ColorComponentValue, (int) this.color_0.G, (int) this.color_0.B), (Control) this.redComponentEditor);
    }

    private void greenComponentEditor_ColorComponentValueChanged(object sender, EventArgs e)
    {
      if (this.bool_0)
        return;
      this.method_0(Color.FromArgb(this.color_0.A == (byte) 0 ? (int) byte.MaxValue : (int) this.color_0.A, (int) this.color_0.R, this.greenComponentEditor.ColorComponentValue, (int) this.color_0.B), (Control) this.greenComponentEditor);
    }

    private void blueComponentEditor_ColorComponentValueChanged(object sender, EventArgs e)
    {
      if (this.bool_0)
        return;
      this.method_0(Color.FromArgb(this.color_0.A == (byte) 0 ? (int) byte.MaxValue : (int) this.color_0.A, (int) this.color_0.R, (int) this.color_0.G, this.blueComponentEditor.ColorComponentValue), (Control) this.blueComponentEditor);
    }

    private void hueComponentEditor_ColorComponentValueChanged(object sender, EventArgs e)
    {
      if (this.bool_0)
        return;
      this.method_0(this.method_5(this.hueComponentEditor.ColorComponentValue), (Control) this.hueComponentEditor);
    }

    private void saturationComponentEditor_ColorComponentValueChanged(object sender, EventArgs e)
    {
      if (this.bool_0)
        return;
      this.method_0(this.method_7(this.saturationComponentEditor.ColorComponentValue), (Control) this.saturationComponentEditor);
    }

    private void lightnessComponentEditor_ColorComponentValueChanged(object sender, EventArgs e)
    {
      if (this.bool_0)
        return;
      this.method_0(this.method_8(this.lightnessComponentEditor.ColorComponentValue), (Control) this.lightnessComponentEditor);
    }

    private void hexValueTextBox_Validated(object sender, EventArgs e)
    {
      int result;
      if (this.bool_0 || !int.TryParse(this.hexValueTextBox.Text, NumberStyles.HexNumber, (IFormatProvider) CultureInfo.InvariantCulture, out result))
        return;
      if (((long) result & 4278190080L) == 0L)
        result = (int) ((long) result | 4278190080L);
      this.method_0(Color.FromArgb(result), (Control) this.hexValueTextBox);
    }

    private void colorListPicker_SelectedColorIndexChanged(object sender, EventArgs e)
    {
      if (this.bool_0 || this.colorListPicker.SelectedColorIndex < 0)
        return;
      this.method_0(this.colorListPicker.Colors[this.colorListPicker.SelectedColorIndex], (Control) this.colorListPicker);
    }

    private void method_0(Color value, Control modifyingControl)
    {
      this.color_0 = value;
      this.method_1(modifyingControl);
      this.OnColorChanged(EventArgs.Empty);
    }

        private void method_1(Control modifyingControl)
        {
            if (!this.bool_0)
            {
                this.bool_0 = true;
                try
                {
                    if (modifyingControl != this.hueComponentEditor)
                    {
                        this.color_1 = this.color_0;
                    }
                    if (modifyingControl != this.saturationComponentEditor)
                    {
                        this.color_2 = this.color_0;
                    }
                    if (modifyingControl != this.lightnessComponentEditor)
                    {
                        this.color_3 = this.color_0;
                    }
                    if (modifyingControl != this.colorWheel)
                    {
                        this.colorWheel.Color = new Color?(this.color_0);
                    }
                    if (modifyingControl != this.redComponentEditor)
                    {
                        this.redComponentEditor.ColorComponentValue = this.color_0.R;
                    }
                    if (modifyingControl != this.greenComponentEditor)
                    {
                        this.greenComponentEditor.ColorComponentValue = this.color_0.G;
                    }
                    if (modifyingControl != this.blueComponentEditor)
                    {
                        this.blueComponentEditor.ColorComponentValue = this.color_0.B;
                    }
                    if (modifyingControl != this.hueComponentEditor)
                    {
                        this.hueComponentEditor.ColorComponentValue = (int)this.color_0.GetHue();
                    }
                    if (modifyingControl != this.saturationComponentEditor)
                    {
                        this.saturationComponentEditor.ColorComponentValue = (int)(100f * this.color_0.GetSaturation());
                    }
                    if (modifyingControl != this.lightnessComponentEditor)
                    {
                        this.lightnessComponentEditor.ColorComponentValue = (int)((double)(100 * System.Math.Max(this.color_0.R, System.Math.Max(this.color_0.G, this.color_0.B))) / 255);
                    }
                    if (modifyingControl != this.hexValueTextBox)
                    {
                        if (this.color_0.A != 255)
                        {
                            TextBox str = this.hexValueTextBox;
                            int argb = this.color_0.ToArgb();
                            str.Text = argb.ToString("x8");
                        }
                        else
                        {
                            int num = this.color_0.ToArgb() & 16777215;
                            this.hexValueTextBox.Text = num.ToString("x6");
                        }
                    }
                    if (modifyingControl != this.colorListPicker)
                    {
                        int argb1 = this.color_0.ToArgb();
                        this.colorListPicker.SelectedColorIndex = this.colorListPicker.Colors.FindIndex((Color o) => o.ToArgb() == argb1);
                    }
                    this.colorPanel.BackColor = this.color_0;
                    base.Invalidate(true);
                }
                finally
                {
                    this.bool_0 = false;
                }
            }
        }

        public static Color FromHSL(double H, double S, double L)
    {
      return ColorRgbEditor.FromHSLA(H, S, L, 1.0);
    }

    public static Color FromHSLA(double H, double S, double L, double A)
    {
      if (A > 1.0)
        A = 1.0;
      double num1 = L;
      double num2 = L;
      double num3 = L;
      double num4 = L <= 0.5 ? L * (1.0 + S) : L + S - L * S;
      if (num4 > 0.0)
      {
        double num5 = L + L - num4;
        double num6 = (num4 - num5) / num4;
        H *= 6.0;
        int num7 = (int) H;
        double num8 = H - (double) num7;
        double num9 = num4 * num6 * num8;
        double num10 = num5 + num9;
        double num11 = num4 - num9;
        switch (num7)
        {
          case 0:
            num1 = num4;
            num2 = num10;
            num3 = num5;
            break;
          case 1:
            num1 = num11;
            num2 = num4;
            num3 = num5;
            break;
          case 2:
            num1 = num5;
            num2 = num4;
            num3 = num10;
            break;
          case 3:
            num1 = num5;
            num2 = num11;
            num3 = num4;
            break;
          case 4:
            num1 = num10;
            num2 = num5;
            num3 = num4;
            break;
          case 5:
            num1 = num4;
            num2 = num5;
            num3 = num11;
            break;
        }
      }
      return Color.FromArgb((int) ColorRgbEditor.smethod_0(A * (double) byte.MaxValue), (int) ColorRgbEditor.smethod_0(num1 * (double) byte.MaxValue), (int) ColorRgbEditor.smethod_0(num2 * (double) byte.MaxValue), (int) ColorRgbEditor.smethod_0(num3 * (double) byte.MaxValue));
    }

    private static byte smethod_0(double d)
    {
      d = System.Math.Round(d);
      if (d > (double) byte.MaxValue)
        return byte.MaxValue;
      if (d < 0.0)
        return 0;
      return (byte) d;
    }

    private Color method_2(int component)
    {
      return Color.FromArgb((int) byte.MaxValue, component, (int) this.color_0.G, (int) this.color_0.B);
    }

    private Color method_3(int component)
    {
      return Color.FromArgb((int) byte.MaxValue, (int) this.color_0.R, component, (int) this.color_0.B);
    }

    private Color method_4(int component)
    {
      return Color.FromArgb((int) byte.MaxValue, (int) this.color_0.R, (int) this.color_0.G, component);
    }

    private Color method_5(int component)
    {
      float num1 = this.color_1.GetSaturation();
      if ((double) num1 == 0.0)
        num1 = 1f;
      float num2 = this.color_1.GetBrightness();
      if ((double) num2 == 0.0)
        num2 = 0.5f;
      return ColorRgbEditor.FromHSLA((double) component / 360.0, (double) num1, (double) num2, (double) this.color_0.A / (double) byte.MaxValue);
    }

    private Color method_6(int component)
    {
      return ColorRgbEditor.FromHSLA((double) component / 360.0, 1.0, 0.5, 1.0);
    }

    private Color method_7(int component)
    {
      return ColorRgbEditor.FromHSLA((double) this.color_2.GetHue() / 360.0, (double) component / 100.0, (double) this.color_2.GetBrightness(), (double) this.color_0.A / (double) byte.MaxValue);
    }

    private Color method_8(int component)
    {
      double num1 = (double)System.Math.Max(this.color_3.R, System.Math.Max(this.color_3.G, this.color_3.B));
      if (num1 == 0.0)
      {
        int num2 = (int)System.Math.Round((double) component * (double) byte.MaxValue / 100.0);
        return Color.FromArgb((int) byte.MaxValue, num2, num2, num2);
      }
      double num3 = num1 * 100.0;
      double num4 = System.Math.Round((double) component * (double) byte.MaxValue * (double) this.color_3.R / num3);
      if (num4 > (double) byte.MaxValue)
        num4 = (double) byte.MaxValue;
      double num5 = System.Math.Round((double) component * (double) byte.MaxValue * (double) this.color_3.G / num3);
      if (num5 > (double) byte.MaxValue)
        num5 = (double) byte.MaxValue;
      double num6 = System.Math.Round((double) component * (double) byte.MaxValue * (double) this.color_3.B / num3);
      if (num6 > (double) byte.MaxValue)
        num6 = (double) byte.MaxValue;
      return Color.FromArgb((int) byte.MaxValue, (int) num4, (int) num5, (int) num6);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.hexValueTextBox = new TextBox();
      this.colorPanel = new Panel();
      this.colorListPicker = new ColorListPicker();
      this.lightnessComponentEditor = new ColorComponentEditor();
      this.saturationComponentEditor = new ColorComponentEditor();
      this.hueComponentEditor = new ColorComponentEditor();
      this.blueComponentEditor = new ColorComponentEditor();
      this.greenComponentEditor = new ColorComponentEditor();
      this.redComponentEditor = new ColorComponentEditor();
      this.colorWheel = new ColorWheel();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(229, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(33, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "RGB";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(229, 176);
      this.label2.Name = "label2";
      this.label2.Size = new Size(31, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "HSL";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(229, 133);
      this.label3.Name = "label3";
      this.label3.Size = new Size(26, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Hex";
      this.hexValueTextBox.Location = new Point(559, 133);
      this.hexValueTextBox.MaxLength = 8;
      this.hexValueTextBox.Name = "hexValueTextBox";
      this.hexValueTextBox.Size = new Size(59, 20);
      this.hexValueTextBox.TabIndex = 10;
      this.hexValueTextBox.Validated += new EventHandler(this.hexValueTextBox_Validated);
      this.colorPanel.BorderStyle = BorderStyle.FixedSingle;
      this.colorPanel.Location = new Point(88, 200);
      this.colorPanel.Name = "colorPanel";
      this.colorPanel.Size = new Size(50, 50);
      this.colorPanel.TabIndex = 11;
      this.colorListPicker.ColorBoxDistance = new Size(22, 22);
      this.colorListPicker.ColorBoxMargin = new Size(2, 2);
      this.colorListPicker.ColorBoxSize = new Size(18, 18);
      this.colorListPicker.Location = new Point(8, 258);
      this.colorListPicker.Name = "colorListPicker";
      this.colorListPicker.SelectedColorIndex = -1;
      this.colorListPicker.Size = new Size(214, 26);
      this.colorListPicker.TabIndex = 12;
      this.colorListPicker.Text = "colorListPicker";
      this.colorListPicker.SelectedColorIndexChanged += new EventHandler(this.colorListPicker_SelectedColorIndexChanged);
      this.lightnessComponentEditor.ColorComponentMaxValue = 100;
      this.lightnessComponentEditor.ColorComponentToColorMapper = (Func<int, Color>) null;
      this.lightnessComponentEditor.ColorComponentValue = 0;
      this.lightnessComponentEditor.Label = "Lightness";
      this.lightnessComponentEditor.Location = new Point(225, 258);
      this.lightnessComponentEditor.Name = "lightnessComponentEditor";
      this.lightnessComponentEditor.Size = new Size(400, 30);
      this.lightnessComponentEditor.TabIndex = 6;
      this.lightnessComponentEditor.ColorComponentValueChanged += new EventHandler(this.lightnessComponentEditor_ColorComponentValueChanged);
      this.saturationComponentEditor.ColorComponentMaxValue = 100;
      this.saturationComponentEditor.ColorComponentToColorMapper = (Func<int, Color>) null;
      this.saturationComponentEditor.ColorComponentValue = 0;
      this.saturationComponentEditor.Label = "Saturation";
      this.saturationComponentEditor.Location = new Point(225, 225);
      this.saturationComponentEditor.Name = "saturationComponentEditor";
      this.saturationComponentEditor.Size = new Size(400, 30);
      this.saturationComponentEditor.TabIndex = 5;
      this.saturationComponentEditor.ColorComponentValueChanged += new EventHandler(this.saturationComponentEditor_ColorComponentValueChanged);
      this.hueComponentEditor.ColorComponentMaxValue = 359;
      this.hueComponentEditor.ColorComponentToColorMapper = (Func<int, Color>) null;
      this.hueComponentEditor.ColorComponentValue = 0;
      this.hueComponentEditor.Label = "Hue";
      this.hueComponentEditor.Location = new Point(225, 192);
      this.hueComponentEditor.Name = "hueComponentEditor";
      this.hueComponentEditor.Size = new Size(400, 30);
      this.hueComponentEditor.TabIndex = 4;
      this.hueComponentEditor.ColorComponentValueChanged += new EventHandler(this.hueComponentEditor_ColorComponentValueChanged);
      this.blueComponentEditor.ColorComponentMaxValue = (int) byte.MaxValue;
      this.blueComponentEditor.ColorComponentToColorMapper = (Func<int, Color>) null;
      this.blueComponentEditor.ColorComponentValue = 0;
      this.blueComponentEditor.Label = "Blue";
      this.blueComponentEditor.Location = new Point(225, 91);
      this.blueComponentEditor.Name = "blueComponentEditor";
      this.blueComponentEditor.Size = new Size(400, 30);
      this.blueComponentEditor.TabIndex = 3;
      this.blueComponentEditor.ColorComponentValueChanged += new EventHandler(this.blueComponentEditor_ColorComponentValueChanged);
      this.greenComponentEditor.ColorComponentMaxValue = (int) byte.MaxValue;
      this.greenComponentEditor.ColorComponentToColorMapper = (Func<int, Color>) null;
      this.greenComponentEditor.ColorComponentValue = 0;
      this.greenComponentEditor.Label = "Green";
      this.greenComponentEditor.Location = new Point(225, 58);
      this.greenComponentEditor.Name = "greenComponentEditor";
      this.greenComponentEditor.Size = new Size(400, 30);
      this.greenComponentEditor.TabIndex = 2;
      this.greenComponentEditor.ColorComponentValueChanged += new EventHandler(this.greenComponentEditor_ColorComponentValueChanged);
      this.redComponentEditor.ColorComponentMaxValue = (int) byte.MaxValue;
      this.redComponentEditor.ColorComponentToColorMapper = (Func<int, Color>) null;
      this.redComponentEditor.ColorComponentValue = 0;
      this.redComponentEditor.Label = "Red";
      this.redComponentEditor.Location = new Point(225, 25);
      this.redComponentEditor.Name = "redComponentEditor";
      this.redComponentEditor.Size = new Size(400, 30);
      this.redComponentEditor.TabIndex = 1;
      this.redComponentEditor.ColorComponentValueChanged += new EventHandler(this.redComponentEditor_ColorComponentValueChanged);
      this.colorWheel.Color = new Color?();
      this.colorWheel.Location = new Point(0, 0);
      this.colorWheel.Name = "colorWheel";
      this.colorWheel.Padding = new Padding(15);
      this.colorWheel.Size = new Size(219, 194);
      this.colorWheel.TabIndex = 0;
      this.colorWheel.Text = "colorWheel1";
      this.colorWheel.ColorChanged += new EventHandler(this.colorWheel_ColorChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.colorListPicker);
      this.Controls.Add((Control) this.colorPanel);
      this.Controls.Add((Control) this.hexValueTextBox);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.lightnessComponentEditor);
      this.Controls.Add((Control) this.saturationComponentEditor);
      this.Controls.Add((Control) this.hueComponentEditor);
      this.Controls.Add((Control) this.blueComponentEditor);
      this.Controls.Add((Control) this.greenComponentEditor);
      this.Controls.Add((Control) this.redComponentEditor);
      this.Controls.Add((Control) this.colorWheel);
      this.Name = nameof (ColorRgbEditor);
      this.Size = new Size(625, 295);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
