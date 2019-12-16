// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Color
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns43;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using WW.Cad.Base;
using WW.Cad.Model.Entities;
using WW.Cad.Windows.Forms;
using WW.Drawing;
using WW.Text;

namespace WW.Cad.Model
{
  [System.ComponentModel.TypeConverter(typeof (Color.TypeConverter))]
  [Editor(typeof (Color.UITypeEditor), typeof (System.Drawing.Design.UITypeEditor))]
  public struct Color : IEquatable<Color>
  {
    public static readonly Color ByLayer = new Color(3221225472U);
    public static readonly Color ByBlock = new Color(3238002688U);
    public static readonly Color None = new Color(3355443200U);
    internal const uint uint_0 = 4278190080;
    private readonly uint uint_1;
    private readonly string string_0;
    private readonly string string_1;

    private Color(uint data)
    {
      this.uint_1 = data;
      this.string_0 = string.Empty;
      this.string_1 = string.Empty;
    }

    private Color(uint data, string colorBookName, string name)
    {
      this.uint_1 = data;
      this.string_0 = colorBookName ?? string.Empty;
      this.string_1 = name ?? string.Empty;
    }

    public ColorType ColorType
    {
      get
      {
        return (ColorType) (this.uint_1 >> 24);
      }
    }

    public byte R
    {
      get
      {
        return (byte) (this.uint_1 >> 16 & (uint) byte.MaxValue);
      }
    }

    public byte G
    {
      get
      {
        return (byte) (this.uint_1 >> 8 & (uint) byte.MaxValue);
      }
    }

    public byte B
    {
      get
      {
        return (byte) (this.uint_1 & (uint) byte.MaxValue);
      }
    }

    public short ColorIndex
    {
      get
      {
        return (short) ((int) this.uint_1 & (int) ushort.MaxValue);
      }
    }

    public int Rgb
    {
      get
      {
        return (int) this.uint_1 & 16777215;
      }
    }

    public string Name
    {
      get
      {
        return this.string_1;
      }
    }

    public string ColorBookName
    {
      get
      {
        return this.string_0;
      }
    }

    public static Color CreateFromColorIndex(short colorIndex)
    {
      switch (colorIndex)
      {
        case 0:
          return Color.ByBlock;
        case 256:
          return Color.ByLayer;
        case 257:
          return Color.None;
        default:
          return new Color(3271557120U | (uint) colorIndex);
      }
    }

    public static Color CreateFromColorIndex(ColorType colorType, short colorIndex)
    {
      if (colorType == ColorType.ByColorIndex)
        return Color.CreateFromColorIndex(colorIndex);
      return new Color((uint) colorType << 24 | (uint) colorIndex);
    }

    public static Color CreateFromRgb(
      byte red,
      byte green,
      byte blue,
      string colorBookName,
      string name)
    {
      return new Color((uint) (-1040187392 | (int) red << 16 | (int) green << 8) | (uint) blue, colorBookName, name);
    }

    public static Color CreateFromRgb(int rgb)
    {
      return new Color((uint) (-1040187392 | rgb & 16777215));
    }

    public static Color CreateFromRgb(int rgb, string colorBookName, string name)
    {
      return new Color((uint) (-1040187392 | rgb & 16777215), colorBookName, name);
    }

    public static Color CreateFromRgb(byte red, byte green, byte blue)
    {
      return new Color((uint) (-1040187392 | (int) red << 16 | (int) green << 8) | (uint) blue);
    }

    public static Color CreateFromRgb(
      ColorType colorType,
      byte red,
      byte green,
      byte blue,
      string colorBookName,
      string name)
    {
      return new Color((uint) ((int) colorType << 24 | (int) red << 16 | (int) green << 8) | (uint) blue, colorBookName, name);
    }

    public static Color CreateFromRgb(ColorType colorType, byte red, byte green, byte blue)
    {
      return new Color((uint) ((int) colorType << 24 | (int) red << 16 | (int) green << 8) | (uint) blue);
    }

    public static Color CreateFromRgb(
      ColorType colorType,
      int rgb,
      string colorBookName,
      string name)
    {
      return new Color((uint) ((int) colorType << 24 | rgb & 16777215), colorBookName, name);
    }

    public static Color CreateFromRgb(ColorType colorType, int rgb)
    {
      return new Color((uint) ((int) colorType << 24 | rgb & 16777215));
    }

    public static Color CreateFrom(ArgbColor color)
    {
      int colorDifference;
      short colorIndex = DxfIndexedColorSet.GetColorIndex(color, out colorDifference);
      return colorDifference != 0 ? Color.CreateFromRgb(color.Argb) : Color.CreateFromColorIndex(colorIndex);
    }

    public static Color CreateFrom(EntityColor color)
    {
      return new Color(color.Data);
    }

    [Obsolete("Use ToArgbColor(DxfIndexColor) instead")]
    public System.Drawing.Color ToSystemDrawingColor()
    {
      return (System.Drawing.Color) this.ToArgbColor();
    }

    public static implicit operator Color(System.Drawing.Color color)
    {
      return Color.CreateFromRgb(color.ToArgb() & 16777215);
    }

    public ArgbColor ToArgbColor(DxfIndexedColorSet indexedColors)
    {
      switch (this.ColorType)
      {
        case ColorType.ByColor:
          return new ArgbColor((int) this.uint_1 & 16777215 | -16777216);
        case ColorType.ByColorIndex:
          return indexedColors[(int) this.ColorIndex];
        default:
          return ArgbColors.Black;
      }
    }

    public ArgbColor ToArgbColor(DxfIndexedColorSet indexedColors, byte alpha)
    {
      ArgbColor argbColor = this.ToArgbColor(indexedColors);
      argbColor.A = alpha;
      return argbColor;
    }

    [Obsolete("Use ToArgbColor(DxfIndexedColorSet) instead")]
    public ArgbColor ToArgbColor()
    {
      switch (this.ColorType)
      {
        case ColorType.ByColor:
          return new ArgbColor((int) this.uint_1 & 16777215 | -16777216);
        case ColorType.ByColorIndex:
          return DxfIndexedColor.Color[(int) this.ColorIndex];
        default:
          return new ArgbColor(0, 0, 0);
      }
    }

    public System.Drawing.Color ToSystemDrawingColor(
      DxfIndexedColorSet indexedColors,
      byte alpha)
    {
      return (System.Drawing.Color) this.ToArgbColor(indexedColors, alpha);
    }

    public System.Drawing.Color ToSystemDrawingColor(byte alpha)
    {
      ColorType colorType = this.ColorType;
      if (alpha == byte.MaxValue)
        return this.ToSystemDrawingColor();
      switch (colorType)
      {
        case ColorType.ByColor:
          return System.Drawing.Color.FromArgb((int) this.uint_1 & 16777215 | (int) alpha << 24);
        case ColorType.ByColorIndex:
          return System.Drawing.Color.FromArgb((int) alpha, (System.Drawing.Color) DxfIndexedColor.Color[(int) this.ColorIndex]);
        default:
          return System.Drawing.Color.FromArgb((int) alpha, System.Drawing.Color.Black);
      }
    }

    public int ToArgb(DxfIndexedColorSet indexedColors)
    {
      switch (this.ColorType)
      {
        case ColorType.ByColor:
          return (int) this.uint_1 & 16777215 | -16777216;
        case ColorType.ByColorIndex:
          return indexedColors[(int) this.ColorIndex].Argb;
        default:
          return -16777216;
      }
    }

    [Obsolete]
    public int ToArgb()
    {
      switch (this.ColorType)
      {
        case ColorType.ByColor:
          return (int) this.uint_1 & 16777215 | -16777216;
        case ColorType.ByColorIndex:
          return DxfIndexedColor.Color[(int) this.ColorIndex].Argb;
        default:
          return -16777216;
      }
    }

    public int ToArgb(DxfIndexedColorSet indexedColors, byte alpha)
    {
      if (alpha == byte.MaxValue)
        return this.ToArgb();
      switch (this.ColorType)
      {
        case ColorType.ByColor:
          return (int) this.uint_1 & 16777215 | (int) alpha << 24;
        case ColorType.ByColorIndex:
          return (int) ((long) indexedColors[(int) this.ColorIndex].Argb & 16777215L | (long) ((uint) alpha << 24));
        default:
          return (int) alpha << 24;
      }
    }

    [Obsolete]
    public int ToArgb(byte alpha)
    {
      if (alpha == byte.MaxValue)
        return this.ToArgb();
      switch (this.ColorType)
      {
        case ColorType.ByColor:
          return (int) this.uint_1 & 16777215 | (int) alpha << 24;
        case ColorType.ByColorIndex:
          return (int) ((long) DxfIndexedColor.Color[(int) this.ColorIndex].Argb & 16777215L | (long) ((uint) alpha << 24));
        default:
          return (int) alpha << 24;
      }
    }

    public override string ToString()
    {
      ColorType colorType = this.ColorType;
      string str;
      switch (colorType)
      {
        case ColorType.ByLayer:
          str = "By layer";
          break;
        case ColorType.ByBlock:
          str = "By block";
          break;
        case ColorType.ByColorIndex:
        case ColorType.ByPenIndex:
          str = string.Format("Color type: {0}, Index: {1}", (object) colorType, (object) (uint) ((int) this.uint_1 & (int) ushort.MaxValue));
          break;
        case ColorType.Foreground:
          str = "Foreground";
          break;
        case ColorType.None:
          str = "None";
          break;
        default:
          str = string.Format("Color type: {0}, RGB: 0x{1}", (object) colorType, (object) (this.uint_1 & 16777215U).ToString("x"));
          break;
      }
      if (!string.IsNullOrEmpty(this.string_1) || !string.IsNullOrEmpty(this.string_0))
        str += string.Format(", Name: \"{0}\", Color book name: \"{1}\".", (object) this.string_1, (object) this.string_0);
      return str;
    }

    public static bool TryParse(string s, out Color color)
    {
      color = Color.None;
      if (string.IsNullOrEmpty(s))
        return true;
      if (string.Compare(s, "by layer", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        color = Color.ByLayer;
        return true;
      }
      if (string.Compare(s, "by block", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        color = Color.ByBlock;
        return true;
      }
      if (string.Compare(s, "none", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        color = Color.None;
        return true;
      }
      if (string.Compare(s, "foreground", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        color = Color.smethod_0(3305111552U);
        return true;
      }
      Dictionary<string, string> properties = StringUtil.GetProperties(s);
      string s1;
      ColorType result1;
      if (!properties.TryGetValue("color type", out s1) || !EnumUtil.TryParse<ColorType>(s1, true, out result1))
        return false;
      string str;
      switch (result1)
      {
        case ColorType.ByColor:
          int result2;
          if (!properties.TryGetValue("rgb", out str) || !int.TryParse(str, NumberStyles.HexNumber, (IFormatProvider) CultureInfo.InvariantCulture, out result2))
            return false;
          color = Color.CreateFromRgb(result2);
          break;
        case ColorType.ByColorIndex:
          short result3;
          if (!properties.TryGetValue("index", out str) || !short.TryParse(str, out result3))
            return false;
          color = Color.CreateFromColorIndex(result3);
          break;
      }
      if (properties.TryGetValue("name", out str))
        color = new Color(color.uint_1, color.string_0, str);
      if (properties.TryGetValue("color book name", out str))
        color = new Color(color.uint_1, str, color.string_0);
      return true;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || !(obj is Color))
        return false;
      Color color = (Color) obj;
      if ((int) this.uint_1 == (int) color.uint_1 && this.string_1 == color.string_1)
        return this.string_0 == color.string_0;
      return false;
    }

    public override int GetHashCode()
    {
      return this.uint_1.GetHashCode();
    }

    public static bool operator ==(Color a, Color b)
    {
      if ((int) a.uint_1 == (int) b.uint_1 && a.string_1 == b.string_1)
        return a.string_0 == b.string_0;
      return false;
    }

    public static bool operator !=(Color a, Color b)
    {
      return !(a == b);
    }

    internal uint Data
    {
      get
      {
        return this.uint_1;
      }
    }

    internal static Color smethod_0(uint data)
    {
      return new Color(data);
    }

    internal static Color smethod_1(uint data, string colorBookName, string name)
    {
      return new Color(data, colorBookName, name);
    }

    internal string method_0()
    {
      return this.string_0 + "$" + this.string_1;
    }

    internal static ColorType smethod_2(uint data)
    {
      return (ColorType) (data >> 24);
    }

    public bool Equals(Color other)
    {
      if ((int) this.uint_1 == (int) other.uint_1 && this.string_1 == other.string_1)
        return this.string_0 == other.string_0;
      return false;
    }

    public class TypeConverter : System.ComponentModel.TypeConverter
    {
      public static Color[] StandardColors = new Color[9]{ Colors.ByLayer, Colors.ByBlock, Colors.White, Colors.Gray, Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow, Colors.Magenta };

      public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
      {
        if (!(sourceType == typeof (Color)))
          return sourceType == typeof (string);
        return true;
      }

      public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
      {
        if (!(destinationType == typeof (Color)))
          return destinationType == typeof (string);
        return true;
      }

      public override object ConvertFrom(
        ITypeDescriptorContext context,
        CultureInfo culture,
        object value)
      {
        string s = value as string;
        Color color;
        if (s != null && Color.TryParse(s, out color))
          return (object) color;
        return value;
      }

      public override object ConvertTo(
        ITypeDescriptorContext context,
        CultureInfo culture,
        object value,
        System.Type destinationType)
      {
        if (!(destinationType == typeof (string)))
          return value;
        if (value == null)
          return (object) string.Empty;
        return (object) value.ToString();
      }

      public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
      {
        return true;
      }

      public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(
        ITypeDescriptorContext context)
      {
        return new System.ComponentModel.TypeConverter.StandardValuesCollection((ICollection) Color.TypeConverter.StandardColors);
      }
    }

    public class UITypeEditor : System.Drawing.Design.UITypeEditor
    {
      private IWindowsFormsEditorService iwindowsFormsEditorService_0;

      public override object EditValue(
        ITypeDescriptorContext context,
        System.IServiceProvider provider,
        object value)
      {
        object obj = value;
        if (provider != null)
        {
          this.iwindowsFormsEditorService_0 = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
          if (this.iwindowsFormsEditorService_0 != null && (value is Color || value == null))
          {
            Color color = value == null ? Color.None : (Color) value;
            ListBox listBox = new ListBox();
            listBox.Click += new EventHandler(this.method_1);
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.DrawItem += new DrawItemEventHandler(this.method_0);
            listBox.Size = new Size(220, 150);
            bool flag = false;
            foreach (Color standardColor in Color.TypeConverter.StandardColors)
            {
              if (standardColor == color)
                flag = true;
            }
            if (!flag)
            {
              Color.UITypeEditor.ColorItem colorItem = new Color.UITypeEditor.ColorItem() { Color = color };
              listBox.Items.Add((object) colorItem);
            }
            foreach (Color standardColor in Color.TypeConverter.StandardColors)
            {
              Color.UITypeEditor.ColorItem colorItem = new Color.UITypeEditor.ColorItem() { Color = standardColor };
              listBox.Items.Add((object) colorItem);
            }
            Color.UITypeEditor.ColorItem colorItem1 = new Color.UITypeEditor.ColorItem() { Name = Class675.Other };
            listBox.Items.Add((object) colorItem1);
            this.iwindowsFormsEditorService_0.DropDownControl((Control) listBox);
            if (listBox.SelectedItem != null && listBox.SelectedIndices.Count == 1)
            {
              if ((Color.UITypeEditor.ColorItem) listBox.SelectedItem == colorItem1)
              {
                CadColorEditorDialog colorEditorDialog = new CadColorEditorDialog();
                if (value != null)
                  colorEditorDialog.Color = color;
                if (this.iwindowsFormsEditorService_0.ShowDialog((Form) colorEditorDialog) == DialogResult.OK)
                  obj = (object) colorEditorDialog.Color;
              }
              else
                obj = (object) ((Color.UITypeEditor.ColorItem) listBox.SelectedItem).Color;
            }
          }
        }
        return obj;
      }

      private void method_0(object sender, DrawItemEventArgs e)
      {
        Color.UITypeEditor.ColorItem colorItem = (Color.UITypeEditor.ColorItem) ((ListBox) sender).Items[e.Index];
        e.DrawBackground();
        int x = e.Bounds.Left + 1;
        int y = e.Bounds.Top + 1;
        int width = e.Bounds.Height - 2 + 4;
        int height = e.Bounds.Height - 2;
        if (colorItem.Color.ColorType == ColorType.ByColorIndex && colorItem.Color.ColorIndex == (short) 7)
        {
          e.Graphics.FillPolygon(Brushes.Black, new Point[3]
          {
            new Point(x, y),
            new Point(x + width, y),
            new Point(x, y + height)
          });
          e.Graphics.FillPolygon(Brushes.White, new Point[3]
          {
            new Point(x, y + height),
            new Point(x + width, y),
            new Point(x + width, y + height)
          });
          e.Graphics.DrawRectangle(Pens.Black, x, y, width, height);
        }
        else
        {
          using (Brush brush = (Brush) new SolidBrush((System.Drawing.Color) colorItem.Color.ToArgbColor(DxfIndexedColorSet.AcadClassicIndexedColors)))
            e.Graphics.FillRectangle(brush, x, y, width, height);
        }
        e.Graphics.DrawString(colorItem.ToString(), SystemFonts.DefaultFont, SystemBrushes.ControlText, new RectangleF((float) (x + width + 3), (float) e.Bounds.Top, (float) (e.Bounds.Right - (x + width) - 3), (float) e.Bounds.Height));
        e.DrawFocusRectangle();
      }

      private void method_1(object sender, EventArgs e)
      {
        this.iwindowsFormsEditorService_0.CloseDropDown();
      }

      public override UITypeEditorEditStyle GetEditStyle(
        ITypeDescriptorContext context)
      {
        return UITypeEditorEditStyle.DropDown;
      }

      public override bool GetPaintValueSupported(ITypeDescriptorContext context)
      {
        return true;
      }

      public override void PaintValue(PaintValueEventArgs e)
      {
        base.PaintValue(e);
        string s = e.Value as string;
        if (s != null)
        {
          Color color;
          if (!Color.TryParse(s, out color))
            return;
          using (Brush brush = (Brush) new SolidBrush((System.Drawing.Color) color.ToArgbColor(DxfIndexedColorSet.AcadClassicIndexedColors)))
            e.Graphics.FillRectangle(brush, e.Bounds);
        }
        else
        {
          if (!(e.Value is Color))
            return;
          using (Brush brush = (Brush) new SolidBrush((System.Drawing.Color) ((Color) e.Value).ToArgbColor(DxfIndexedColorSet.AcadClassicIndexedColors)))
            e.Graphics.FillRectangle(brush, e.Bounds);
        }
      }

      public class ColorItem
      {
        private Color color_0;
        private string string_0;

        public Color Color
        {
          get
          {
            return this.color_0;
          }
          set
          {
            this.color_0 = value;
          }
        }

        public string Name
        {
          get
          {
            return this.string_0;
          }
          set
          {
            this.string_0 = value;
          }
        }

        public override string ToString()
        {
          if (!string.IsNullOrEmpty(this.string_0))
            return this.string_0;
          return this.color_0.ToString();
        }
      }
    }
  }
}
