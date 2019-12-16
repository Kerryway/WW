// Decompiled with JetBrains decompiler
// Type: WW.Cad.Windows.Forms.CadColorEditor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WW.Cad.Model;
using WW.Drawing;
using WW.Windows.Forms;

namespace WW.Cad.Windows.Forms
{
  public class CadColorEditor : UserControl
  {
    private DxfIndexedColorSet dxfIndexedColorSet_0 = DxfIndexedColorSet.AcadClassicIndexedColors;
    private List<WW.Cad.Model.Color> list_0 = new List<WW.Cad.Model.Color>();
    private List<WW.Cad.Model.Color> list_1 = new List<WW.Cad.Model.Color>();
    private List<WW.Cad.Model.Color> list_2 = new List<WW.Cad.Model.Color>();
    private List<WW.Cad.Model.Color> list_3 = new List<WW.Cad.Model.Color>();
    private WW.Cad.Model.Color color_0;
    private Font font_0;
    private Font font_1;
    private bool bool_0;
    private IContainer icontainer_0;
    private TabControl tabControl1;
    private TabPage indexColorTabPage;
    private TabPage trueColorTabPage;
    private TabPage colorBookColorTabPage;
    private Label label1;
    private ColorListPicker indexedColorSet1ListPicker;
    private Label label2;
    private ColorListPicker standardColorListPicker;
    private Label label3;
    private ColorListPicker grayColorListPicker;
    private Button byLayerButton;
    private Button byBlockButton;
    private ColorRgbEditor colorRgbEditor;
    private TextBox colorBookNameTextBox;
    private Label label4;
    private Label label5;
    private TextBox colorNameTextBox;
    private ColorListPicker indexedColorSet2ListPicker;

    public CadColorEditor()
    {
      this.InitializeComponent();
      for (short colorIndex = 1; colorIndex < (short) 256; ++colorIndex)
      {
        WW.Cad.Model.Color fromColorIndex = WW.Cad.Model.Color.CreateFromColorIndex(colorIndex);
        ArgbColor argbColor = fromColorIndex.ToArgbColor(this.dxfIndexedColorSet_0);
        if ((int) argbColor.R == (int) argbColor.G && (int) argbColor.R == (int) argbColor.B)
          this.list_3.Add(fromColorIndex);
        if (colorIndex <= (short) 9)
          this.list_2.Add(fromColorIndex);
      }
      for (short index1 = 0; index1 < (short) 5; ++index1)
      {
        for (short index2 = 0; index2 < (short) 24; ++index2)
        {
          short colorIndex = (short) (10 + (int) index1 * 2 + (int) index2 * 5 * 2);
          this.list_0.Add(WW.Cad.Model.Color.CreateFromColorIndex(colorIndex));
          this.list_1.Add(WW.Cad.Model.Color.CreateFromColorIndex((short) ((int) colorIndex + 1)));
        }
      }
      this.list_3.Sort((Comparison<WW.Cad.Model.Color>) ((a, b) => (int) a.ToArgbColor(this.dxfIndexedColorSet_0).R >= (int) b.ToArgbColor(this.dxfIndexedColorSet_0).R ? 1 : -1));
      this.font_0 = this.byLayerButton.Font;
      this.font_1 = new Font(this.font_0, FontStyle.Bold);
      this.method_1(this.indexedColorSet1ListPicker, this.list_0);
      this.method_1(this.indexedColorSet2ListPicker, this.list_1);
      this.method_1(this.grayColorListPicker, this.list_3);
      this.method_1(this.standardColorListPicker, this.list_2);
    }

    public WW.Cad.Model.Color Color
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        this.method_2((Control) null);
        switch (this.color_0.ColorType)
        {
          case ColorType.ByColor:
            this.tabControl1.SelectTab(this.trueColorTabPage);
            break;
          case ColorType.ByColorIndex:
            this.tabControl1.SelectTab(this.indexColorTabPage);
            break;
          default:
            if (string.IsNullOrEmpty(this.color_0.ColorBookName) && string.IsNullOrEmpty(this.color_0.Name))
              break;
            this.tabControl1.SelectTab(this.colorBookColorTabPage);
            break;
        }
      }
    }

    public DxfIndexedColorSet ColorSet
    {
      get
      {
        return this.dxfIndexedColorSet_0;
      }
      set
      {
        this.dxfIndexedColorSet_0 = value;
      }
    }

    public bool ShowColorBookTab
    {
      get
      {
        return this.colorBookColorTabPage.Enabled;
      }
      set
      {
        this.colorBookColorTabPage.Enabled = value;
        if (value)
        {
          if (this.tabControl1.TabPages.Contains(this.colorBookColorTabPage))
            return;
          this.tabControl1.TabPages.Add(this.colorBookColorTabPage);
        }
        else
        {
          if (!this.tabControl1.TabPages.Contains(this.colorBookColorTabPage))
            return;
          this.tabControl1.TabPages.Remove(this.colorBookColorTabPage);
        }
      }
    }

    private void byLayerButton_Click(object sender, EventArgs e)
    {
      if (this.bool_0)
        return;
      this.color_0 = WW.Cad.Model.Color.ByLayer;
      this.method_2((Control) this.byLayerButton);
    }

    private void byBlockButton_Click(object sender, EventArgs e)
    {
      if (this.bool_0)
        return;
      this.color_0 = WW.Cad.Model.Color.ByBlock;
      this.method_2((Control) this.byBlockButton);
    }

    private void indexedColorSet1ListPicker_SelectedColorIndexChanged(object sender, EventArgs e)
    {
      this.method_0(this.indexedColorSet1ListPicker);
    }

    private void indexedColorSet2ListPicker_SelectedColorIndexChanged(object sender, EventArgs e)
    {
      this.method_0(this.indexedColorSet2ListPicker);
    }

    private void standardColorListPicker_SelectedColorIndexChanged(object sender, EventArgs e)
    {
      this.method_0(this.standardColorListPicker);
    }

    private void grayColorListPicker_SelectedColorIndexChanged(object sender, EventArgs e)
    {
      this.method_0(this.grayColorListPicker);
    }

    private void colorRgbEditor_ColorChanged(object sender, EventArgs e)
    {
      if (this.bool_0)
        return;
      this.color_0 = WW.Cad.Model.Color.CreateFromRgb(this.colorRgbEditor.Color.ToArgb() & 16777215);
      this.method_2((Control) this.colorRgbEditor);
    }

    private void method_0(ColorListPicker colorListPicker)
    {
      if (this.bool_0 || colorListPicker.SelectedColorIndex < 0)
        return;
      this.color_0 = ((List<WW.Cad.Model.Color>) colorListPicker.Tag)[colorListPicker.SelectedColorIndex];
      this.method_2((Control) colorListPicker);
    }

    private void method_1(ColorListPicker colorsListPicker, List<WW.Cad.Model.Color> indexedColors)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      CadColorEditor.Class334 class334 = new CadColorEditor.Class334();
      // ISSUE: reference to a compiler-generated field
      class334.list_0 = indexedColors;
      // ISSUE: reference to a compiler-generated field
      class334.cadColorEditor_0 = this;
      // ISSUE: reference to a compiler-generated field
      colorsListPicker.ColorProviderColorCount = class334.list_0.Count;
      // ISSUE: reference to a compiler-generated method
      colorsListPicker.ColorProvider = new Func<int, System.Drawing.Color>(class334.method_0);
      // ISSUE: reference to a compiler-generated field
      colorsListPicker.Tag = (object) class334.list_0;
      // ISSUE: reference to a compiler-generated method
      colorsListPicker.ColorBoxPainter = new ColorListPicker.ColorBoxPaintDelegate(class334.method_1);
    }

    private void method_2(Control modifyingControl)
    {
      if (this.bool_0)
        return;
      this.bool_0 = true;
      try
      {
        if (this.color_0.ColorType == ColorType.ByColorIndex)
        {
          if (modifyingControl != this.indexedColorSet1ListPicker)
            this.indexedColorSet1ListPicker.SelectedColorIndex = this.list_0.IndexOf(this.color_0);
          if (modifyingControl != this.indexedColorSet2ListPicker)
            this.indexedColorSet2ListPicker.SelectedColorIndex = this.list_1.IndexOf(this.color_0);
          if (modifyingControl != this.grayColorListPicker)
            this.grayColorListPicker.SelectedColorIndex = this.list_3.IndexOf(this.color_0);
          if (modifyingControl != this.standardColorListPicker)
            this.standardColorListPicker.SelectedColorIndex = this.list_2.IndexOf(this.color_0);
        }
        else
        {
          this.indexedColorSet1ListPicker.SelectedColorIndex = -1;
          this.indexedColorSet2ListPicker.SelectedColorIndex = -1;
          this.grayColorListPicker.SelectedColorIndex = -1;
          this.standardColorListPicker.SelectedColorIndex = -1;
          if (this.color_0.ColorType == ColorType.ByColor && modifyingControl != this.colorRgbEditor)
            this.colorRgbEditor.Color = this.color_0.ToSystemDrawingColor();
        }
        this.byLayerButton.Font = this.color_0 == WW.Cad.Model.Color.ByLayer ? this.font_1 : this.font_0;
        this.byBlockButton.Font = this.color_0 == WW.Cad.Model.Color.ByBlock ? this.font_1 : this.font_0;
        if (modifyingControl != this.colorRgbEditor)
          this.colorRgbEditor.Color = (System.Drawing.Color) this.color_0.ToArgbColor(this.dxfIndexedColorSet_0);
        if (modifyingControl != this.colorBookNameTextBox)
          this.colorBookNameTextBox.Text = this.color_0.ColorBookName;
        if (modifyingControl == this.colorNameTextBox)
          return;
        this.colorNameTextBox.Text = this.color_0.Name;
      }
      finally
      {
        this.bool_0 = false;
      }
    }

    private void colorBookNameTextBox_Validated(object sender, EventArgs e)
    {
      this.color_0 = WW.Cad.Model.Color.smethod_1(this.color_0.Data, this.colorBookNameTextBox.Text, this.colorNameTextBox.Text);
    }

    private void colorNameTextBox_Validated(object sender, EventArgs e)
    {
      this.color_0 = WW.Cad.Model.Color.smethod_1(this.color_0.Data, this.colorBookNameTextBox.Text, this.colorNameTextBox.Text);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tabControl1 = new TabControl();
      this.indexColorTabPage = new TabPage();
      this.indexedColorSet2ListPicker = new ColorListPicker();
      this.byBlockButton = new Button();
      this.byLayerButton = new Button();
      this.grayColorListPicker = new ColorListPicker();
      this.label3 = new Label();
      this.standardColorListPicker = new ColorListPicker();
      this.label2 = new Label();
      this.label1 = new Label();
      this.indexedColorSet1ListPicker = new ColorListPicker();
      this.trueColorTabPage = new TabPage();
      this.colorRgbEditor = new ColorRgbEditor();
      this.colorBookColorTabPage = new TabPage();
      this.colorNameTextBox = new TextBox();
      this.label5 = new Label();
      this.colorBookNameTextBox = new TextBox();
      this.label4 = new Label();
      this.tabControl1.SuspendLayout();
      this.indexColorTabPage.SuspendLayout();
      this.trueColorTabPage.SuspendLayout();
      this.colorBookColorTabPage.SuspendLayout();
      this.SuspendLayout();
      this.tabControl1.Controls.Add((Control) this.indexColorTabPage);
      this.tabControl1.Controls.Add((Control) this.trueColorTabPage);
      this.tabControl1.Controls.Add((Control) this.colorBookColorTabPage);
      this.tabControl1.Dock = DockStyle.Fill;
      this.tabControl1.Location = new Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(643, 424);
      this.tabControl1.TabIndex = 0;
      this.indexColorTabPage.Controls.Add((Control) this.indexedColorSet2ListPicker);
      this.indexColorTabPage.Controls.Add((Control) this.byBlockButton);
      this.indexColorTabPage.Controls.Add((Control) this.byLayerButton);
      this.indexColorTabPage.Controls.Add((Control) this.grayColorListPicker);
      this.indexColorTabPage.Controls.Add((Control) this.label3);
      this.indexColorTabPage.Controls.Add((Control) this.standardColorListPicker);
      this.indexColorTabPage.Controls.Add((Control) this.label2);
      this.indexColorTabPage.Controls.Add((Control) this.label1);
      this.indexColorTabPage.Controls.Add((Control) this.indexedColorSet1ListPicker);
      this.indexColorTabPage.Location = new Point(4, 22);
      this.indexColorTabPage.Name = "indexColorTabPage";
      this.indexColorTabPage.Padding = new Padding(3);
      this.indexColorTabPage.Size = new Size(635, 398);
      this.indexColorTabPage.TabIndex = 0;
      this.indexColorTabPage.Text = "Index color";
      this.indexColorTabPage.UseVisualStyleBackColor = true;
      this.indexedColorSet2ListPicker.BackColor = SystemColors.ControlLightLight;
      this.indexedColorSet2ListPicker.ColorBoxDistance = new Size(18, 18);
      this.indexedColorSet2ListPicker.ColorBoxMargin = new Size(5, 5);
      this.indexedColorSet2ListPicker.ColorBoxPainter = (ColorListPicker.ColorBoxPaintDelegate) null;
      this.indexedColorSet2ListPicker.ColorBoxSize = new Size(14, 14);
      this.indexedColorSet2ListPicker.ColorProvider = (Func<int, System.Drawing.Color>) null;
      this.indexedColorSet2ListPicker.ColorProviderColorCount = 0;
      this.indexedColorSet2ListPicker.Location = new Point(6, 170);
      this.indexedColorSet2ListPicker.Name = "indexedColorSet2ListPicker";
      this.indexedColorSet2ListPicker.RowMaxColorCount = 24;
      this.indexedColorSet2ListPicker.SelectedColorIndex = -1;
      this.indexedColorSet2ListPicker.Size = new Size(624, 95);
      this.indexedColorSet2ListPicker.TabIndex = 8;
      this.indexedColorSet2ListPicker.Text = "indexedColorSet2ListPicker";
      this.indexedColorSet2ListPicker.SelectedColorIndexChanged += new EventHandler(this.indexedColorSet2ListPicker_SelectedColorIndexChanged);
      this.byBlockButton.Location = new Point(8, 347);
      this.byBlockButton.Name = "byBlockButton";
      this.byBlockButton.Size = new Size(75, 23);
      this.byBlockButton.TabIndex = 7;
      this.byBlockButton.Text = "By block";
      this.byBlockButton.UseVisualStyleBackColor = true;
      this.byBlockButton.Click += new EventHandler(this.byBlockButton_Click);
      this.byLayerButton.Location = new Point(9, 318);
      this.byLayerButton.Name = "byLayerButton";
      this.byLayerButton.Size = new Size(75, 23);
      this.byLayerButton.TabIndex = 6;
      this.byLayerButton.Text = "By layer";
      this.byLayerButton.UseVisualStyleBackColor = true;
      this.byLayerButton.Click += new EventHandler(this.byLayerButton_Click);
      this.grayColorListPicker.BackColor = SystemColors.ControlLightLight;
      this.grayColorListPicker.ColorBoxDistance = new Size(26, 26);
      this.grayColorListPicker.ColorBoxMargin = new Size(5, 5);
      this.grayColorListPicker.ColorBoxPainter = (ColorListPicker.ColorBoxPaintDelegate) null;
      this.grayColorListPicker.ColorBoxSize = new Size(20, 20);
      this.grayColorListPicker.ColorProvider = (Func<int, System.Drawing.Color>) null;
      this.grayColorListPicker.ColorProviderColorCount = 0;
      this.grayColorListPicker.Location = new Point(6, 284);
      this.grayColorListPicker.Name = "grayColorListPicker";
      this.grayColorListPicker.RowMaxColorCount = 0;
      this.grayColorListPicker.SelectedColorIndex = -1;
      this.grayColorListPicker.Size = new Size(623, 28);
      this.grayColorListPicker.TabIndex = 5;
      this.grayColorListPicker.Text = "colorListPicker3";
      this.grayColorListPicker.SelectedColorIndexChanged += new EventHandler(this.grayColorListPicker_SelectedColorIndexChanged);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(6, 268);
      this.label3.Name = "label3";
      this.label3.Size = new Size(37, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Grays:";
      this.standardColorListPicker.BackColor = SystemColors.ControlLightLight;
      this.standardColorListPicker.ColorBoxDistance = new Size(26, 26);
      this.standardColorListPicker.ColorBoxMargin = new Size(5, 5);
      this.standardColorListPicker.ColorBoxPainter = (ColorListPicker.ColorBoxPaintDelegate) null;
      this.standardColorListPicker.ColorBoxSize = new Size(20, 20);
      this.standardColorListPicker.ColorProvider = (Func<int, System.Drawing.Color>) null;
      this.standardColorListPicker.ColorProviderColorCount = 0;
      this.standardColorListPicker.Location = new Point(6, 19);
      this.standardColorListPicker.Name = "standardColorListPicker";
      this.standardColorListPicker.RowMaxColorCount = 0;
      this.standardColorListPicker.SelectedColorIndex = -1;
      this.standardColorListPicker.Size = new Size(623, 28);
      this.standardColorListPicker.TabIndex = 3;
      this.standardColorListPicker.Text = "standardColorListPicker";
      this.standardColorListPicker.SelectedColorIndexChanged += new EventHandler(this.standardColorListPicker_SelectedColorIndexChanged);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(6, 3);
      this.label2.Name = "label2";
      this.label2.Size = new Size(84, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Standard colors:";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(7, 50);
      this.label1.Name = "label1";
      this.label1.Size = new Size(67, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Color circles:";
      this.indexedColorSet1ListPicker.BackColor = SystemColors.ControlLightLight;
      this.indexedColorSet1ListPicker.ColorBoxDistance = new Size(18, 18);
      this.indexedColorSet1ListPicker.ColorBoxMargin = new Size(5, 5);
      this.indexedColorSet1ListPicker.ColorBoxPainter = (ColorListPicker.ColorBoxPaintDelegate) null;
      this.indexedColorSet1ListPicker.ColorBoxSize = new Size(14, 14);
      this.indexedColorSet1ListPicker.ColorProvider = (Func<int, System.Drawing.Color>) null;
      this.indexedColorSet1ListPicker.ColorProviderColorCount = 0;
      this.indexedColorSet1ListPicker.Location = new Point(6, 66);
      this.indexedColorSet1ListPicker.Name = "indexedColorSet1ListPicker";
      this.indexedColorSet1ListPicker.RowMaxColorCount = 24;
      this.indexedColorSet1ListPicker.SelectedColorIndex = -1;
      this.indexedColorSet1ListPicker.Size = new Size(624, 95);
      this.indexedColorSet1ListPicker.TabIndex = 0;
      this.indexedColorSet1ListPicker.Text = "indexedColorSet1ListPicker";
      this.indexedColorSet1ListPicker.SelectedColorIndexChanged += new EventHandler(this.indexedColorSet1ListPicker_SelectedColorIndexChanged);
      this.trueColorTabPage.Controls.Add((Control) this.colorRgbEditor);
      this.trueColorTabPage.Location = new Point(4, 22);
      this.trueColorTabPage.Name = "trueColorTabPage";
      this.trueColorTabPage.Padding = new Padding(3);
      this.trueColorTabPage.Size = new Size(635, 398);
      this.trueColorTabPage.TabIndex = 1;
      this.trueColorTabPage.Text = "True color";
      this.trueColorTabPage.UseVisualStyleBackColor = true;
      this.colorRgbEditor.BackColor = SystemColors.ControlLightLight;
      this.colorRgbEditor.Color = System.Drawing.Color.Black;
      this.colorRgbEditor.Location = new Point(6, 6);
      this.colorRgbEditor.Name = "colorRgbEditor";
      this.colorRgbEditor.Size = new Size(625, 295);
      this.colorRgbEditor.TabIndex = 0;
      this.colorRgbEditor.ColorChanged += new EventHandler(this.colorRgbEditor_ColorChanged);
      this.colorBookColorTabPage.Controls.Add((Control) this.colorNameTextBox);
      this.colorBookColorTabPage.Controls.Add((Control) this.label5);
      this.colorBookColorTabPage.Controls.Add((Control) this.colorBookNameTextBox);
      this.colorBookColorTabPage.Controls.Add((Control) this.label4);
      this.colorBookColorTabPage.Location = new Point(4, 22);
      this.colorBookColorTabPage.Name = "colorBookColorTabPage";
      this.colorBookColorTabPage.Padding = new Padding(3);
      this.colorBookColorTabPage.Size = new Size(635, 398);
      this.colorBookColorTabPage.TabIndex = 2;
      this.colorBookColorTabPage.Text = "Color book";
      this.colorBookColorTabPage.UseVisualStyleBackColor = true;
      this.colorNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.colorNameTextBox.Location = new Point(96, 41);
      this.colorNameTextBox.Name = "colorNameTextBox";
      this.colorNameTextBox.Size = new Size(533, 20);
      this.colorNameTextBox.TabIndex = 3;
      this.colorNameTextBox.Validated += new EventHandler(this.colorNameTextBox_Validated);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(6, 44);
      this.label5.Name = "label5";
      this.label5.Size = new Size(35, 13);
      this.label5.TabIndex = 2;
      this.label5.Text = "Name";
      this.colorBookNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.colorBookNameTextBox.Location = new Point(96, 11);
      this.colorBookNameTextBox.Name = "colorBookNameTextBox";
      this.colorBookNameTextBox.Size = new Size(533, 20);
      this.colorBookNameTextBox.TabIndex = 1;
      this.colorBookNameTextBox.Validated += new EventHandler(this.colorBookNameTextBox_Validated);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(6, 14);
      this.label4.Name = "label4";
      this.label4.Size = new Size(58, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "Color book";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.tabControl1);
      this.Name = nameof (CadColorEditor);
      this.Size = new Size(643, 424);
      this.tabControl1.ResumeLayout(false);
      this.indexColorTabPage.ResumeLayout(false);
      this.indexColorTabPage.PerformLayout();
      this.trueColorTabPage.ResumeLayout(false);
      this.colorBookColorTabPage.ResumeLayout(false);
      this.colorBookColorTabPage.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
