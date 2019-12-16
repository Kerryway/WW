// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.EntityColor
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
using WW.Cad.Windows.Forms;
using WW.Drawing;
using WW.Text;

namespace WW.Cad.Model.Entities
{
  [System.ComponentModel.TypeConverter(typeof (EntityColor.TypeConverter))]
  [Editor(typeof (EntityColor.UITypeEditor), typeof (System.Drawing.Design.UITypeEditor))]
  public struct EntityColor
  {
    public static readonly EntityColor ByLayer = new EntityColor(3221225472U);
    public static readonly EntityColor ByBlock = new EntityColor(3238002688U);
    public static readonly EntityColor None = new EntityColor(3355443200U);
    private readonly uint uint_0;

    private EntityColor(uint data)
    {
      this.uint_0 = data;
    }

    public ColorType ColorType
    {
      get
      {
        return (ColorType) (this.uint_0 >> 24);
      }
    }

    public byte R
    {
      get
      {
        return (byte) (this.uint_0 >> 16 & (uint) byte.MaxValue);
      }
    }

    public byte G
    {
      get
      {
        return (byte) (this.uint_0 >> 8 & (uint) byte.MaxValue);
      }
    }

    public byte B
    {
      get
      {
        return (byte) (this.uint_0 & (uint) byte.MaxValue);
      }
    }

    public short ColorIndex
    {
      get
      {
        return (short) ((int) this.uint_0 & (int) ushort.MaxValue);
      }
    }

    public int Rgb
    {
      get
      {
        return (int) this.uint_0 & 16777215;
      }
    }

    public static EntityColor CreateFromColorIndex(short colorIndex)
    {
      switch (colorIndex)
      {
        case 0:
          return EntityColor.ByBlock;
        case 256:
          return EntityColor.ByLayer;
        case 257:
          return EntityColor.None;
        default:
          return new EntityColor(3271557120U | (uint) colorIndex);
      }
    }

    public static EntityColor CreateFromColorIndex(ColorType colorType, short colorIndex)
    {
      if (colorType == ColorType.ByColorIndex)
        return EntityColor.CreateFromColorIndex(colorIndex);
      return new EntityColor((uint) colorType << 24 | (uint) colorIndex);
    }

    public static EntityColor CreateFromRgb(int rgb)
    {
      return new EntityColor((uint) (-1040187392 | rgb & 16777215));
    }

    public static EntityColor CreateFromRgb(byte red, byte green, byte blue)
    {
      return new EntityColor((uint) (-1040187392 | (int) red << 16 | (int) green << 8) | (uint) blue);
    }

    public static EntityColor CreateFromRgb(
      ColorType colorType,
      byte red,
      byte green,
      byte blue)
    {
      return new EntityColor((uint) ((int) colorType << 24 | (int) red << 16 | (int) green << 8) | (uint) blue);
    }

    public static EntityColor CreateFromRgb(ColorType colorType, int rgb)
    {
      return new EntityColor((uint) ((int) colorType << 24 | rgb & 16777215));
    }

    public static EntityColor CreateFrom(ArgbColor color)
    {
      int colorDifference;
      short colorIndex = DxfIndexedColorSet.GetColorIndex(color, out colorDifference);
      if (colorDifference != 0)
        return EntityColor.CreateFromRgb(color.Argb);
      return EntityColor.CreateFromColorIndex(colorIndex);
    }

    public static EntityColor CreateFrom(WW.Cad.Model.Color color)
    {
      return new EntityColor(color.Data);
    }

    [Obsolete("Use ToArgbColor(DxfIndexedColorSet) instead.")]
    public System.Drawing.Color ToSystemDrawingColor()
    {
      switch (this.ColorType)
      {
        case ColorType.ByColor:
          return System.Drawing.Color.FromArgb((int) this.uint_0 & 16777215 | -16777216);
        case ColorType.ByColorIndex:
          return (System.Drawing.Color) DxfIndexedColor.Color[(int) this.ColorIndex];
        default:
          return System.Drawing.Color.Black;
      }
    }

    public ArgbColor ToArgbColor(DxfIndexedColorSet indexedColors)
    {
      return new ArgbColor(this.ToArgb(indexedColors));
    }

    [Obsolete("Use ToArgbColor(DxfIndexedColorSet) instead.")]
    public ArgbColor ToArgbColor()
    {
      return new ArgbColor(this.ToArgb());
    }

    public System.Drawing.Color ToSystemDrawingColor(
      DxfIndexedColorSet indexedColors,
      byte alpha)
    {
      ArgbColor argbColor = this.ToArgbColor(indexedColors);
      argbColor.A = alpha;
      return (System.Drawing.Color) argbColor;
    }

    [Obsolete("Use ToSystemDrawingColor(DxfIndexedColorSet,byte) instead.")]
    public System.Drawing.Color ToSystemDrawingColor(byte alpha)
    {
      ColorType colorType = this.ColorType;
      if (alpha == byte.MaxValue)
        return this.ToSystemDrawingColor();
      switch (colorType)
      {
        case ColorType.ByColor:
          return System.Drawing.Color.FromArgb((int) this.uint_0 & 16777215 | (int) alpha << 24);
        case ColorType.ByColorIndex:
          return System.Drawing.Color.FromArgb((int) alpha, (System.Drawing.Color) DxfIndexedColor.Color[(int) this.ColorIndex]);
        default:
          return System.Drawing.Color.FromArgb((int) alpha, System.Drawing.Color.Black);
      }
    }

    public WW.Cad.Model.Color ToColor()
    {
      return WW.Cad.Model.Color.smethod_0(this.uint_0);
    }

    public int ToArgb(DxfIndexedColorSet indexedColors)
    {
      switch (this.ColorType)
      {
        case ColorType.ByColor:
          return (int) this.uint_0 & 16777215 | -16777216;
        case ColorType.ByColorIndex:
          return indexedColors[(int) this.ColorIndex].Argb;
        default:
          return -16777216;
      }
    }

    [Obsolete("Use ToArgb(DxfIndexedColorSet) instead")]
    public int ToArgb()
    {
      switch (this.ColorType)
      {
        case ColorType.ByColor:
          return (int) this.uint_0 & 16777215 | -16777216;
        case ColorType.ByColorIndex:
          return DxfIndexedColor.Color[(int) this.ColorIndex].Argb;
        default:
          return -16777216;
      }
    }

    public int ToArgb(DxfIndexedColorSet indexedColors, byte alpha)
    {
      if (alpha == byte.MaxValue)
        return this.ToArgb(indexedColors);
      switch (this.ColorType)
      {
        case ColorType.ByColor:
          return (int) this.uint_0 & 16777215 | (int) alpha << 24;
        case ColorType.ByColorIndex:
          return (int) ((long) indexedColors[(int) this.ColorIndex].Argb & 16777215L | (long) ((uint) alpha << 24));
        default:
          return (int) alpha << 24;
      }
    }

    public int ToArgb(byte alpha)
    {
      if (alpha == byte.MaxValue)
        return this.ToArgb();
      switch (this.ColorType)
      {
        case ColorType.ByColor:
          return (int) this.uint_0 & 16777215 | (int) alpha << 24;
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
          str = string.Format("Color type: {0}, Index: {1}", (object) colorType, (object) (uint) ((int) this.uint_0 & (int) ushort.MaxValue));
          break;
        case ColorType.Foreground:
          str = "Foreground";
          break;
        case ColorType.None:
          str = "None";
          break;
        default:
          str = string.Format("Color type: {0}, RGB: 0x{1}", (object) colorType, (object) (this.uint_0 & 16777215U).ToString("x"));
          break;
      }
      return str;
    }

    public static bool TryParse(string s, out EntityColor color)
    {
      color = EntityColor.None;
      if (string.IsNullOrEmpty(s))
        return true;
      if (string.Compare(s, "by layer", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        color = EntityColor.ByLayer;
        return true;
      }
      if (string.Compare(s, "by block", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        color = EntityColor.ByBlock;
        return true;
      }
      if (string.Compare(s, "none", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        color = EntityColor.None;
        return true;
      }
      if (string.Compare(s, "foreground", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        color = EntityColor.smethod_0(3305111552U);
        return true;
      }
      Dictionary<string, string> properties = StringUtil.GetProperties(s);
      string s1;
      ColorType result1;
      if (!properties.TryGetValue("color type", out s1) || !EnumUtil.TryParse<ColorType>(s1, true, out result1))
        return false;
      switch (result1)
      {
        case ColorType.ByColor:
          string s2;
          int result2;
          if (!properties.TryGetValue("rgb", out s2) || !int.TryParse(s2, NumberStyles.HexNumber, (IFormatProvider) CultureInfo.InvariantCulture, out result2))
            return false;
          color = EntityColor.CreateFromRgb(result2);
          break;
        case ColorType.ByColorIndex:
          string s3;
          short result3;
          if (!properties.TryGetValue("index", out s3) || !short.TryParse(s3, out result3))
            return false;
          color = EntityColor.CreateFromColorIndex(result3);
          break;
      }
      return true;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is EntityColor))
        return false;
      return (int) this.uint_0 == (int) ((EntityColor) obj).uint_0;
    }

    public override int GetHashCode()
    {
      return this.uint_0.GetHashCode();
    }

    public static bool operator ==(EntityColor a, EntityColor b)
    {
      return (int) a.uint_0 == (int) b.uint_0;
    }

    public static bool operator !=(EntityColor a, EntityColor b)
    {
      return !(a == b);
    }

    internal uint Data
    {
      get
      {
        return this.uint_0;
      }
    }

    internal static EntityColor smethod_0(uint data)
    {
      return new EntityColor(data);
    }

    public bool Equals(EntityColor other)
    {
      return (int) this.uint_0 == (int) other.uint_0;
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
          if (this.iwindowsFormsEditorService_0 != null && (value is EntityColor || value == null))
          {
            EntityColor color = value == null ? EntityColor.None : (EntityColor) value;
            ListBox listBox = new ListBox();
            listBox.Click += new EventHandler(this.method_1);
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.DrawItem += new DrawItemEventHandler(this.method_0);
            listBox.Size = new Size(220, 150);
            bool flag = false;
            foreach (EntityColor standardColor in EntityColor.TypeConverter.StandardColors)
            {
              if (standardColor == color)
                flag = true;
            }
            if (!flag)
            {
              EntityColor.UITypeEditor.ColorItem colorItem = new EntityColor.UITypeEditor.ColorItem() { Color = color };
              listBox.Items.Add((object) colorItem);
            }
            foreach (EntityColor standardColor in EntityColor.TypeConverter.StandardColors)
            {
              EntityColor.UITypeEditor.ColorItem colorItem = new EntityColor.UITypeEditor.ColorItem() { Color = standardColor };
              listBox.Items.Add((object) colorItem);
            }
            EntityColor.UITypeEditor.ColorItem colorItem1 = new EntityColor.UITypeEditor.ColorItem() { Name = Class675.Other };
            listBox.Items.Add((object) colorItem1);
            this.iwindowsFormsEditorService_0.DropDownControl((Control) listBox);
            if (listBox.SelectedItem != null && listBox.SelectedIndices.Count == 1)
            {
              if ((EntityColor.UITypeEditor.ColorItem) listBox.SelectedItem == colorItem1)
              {
                CadColorEditorDialog colorEditorDialog = new CadColorEditorDialog();
                if (value != null)
                  colorEditorDialog.Color = WW.Cad.Model.Color.CreateFrom(color);
                colorEditorDialog.ShowColorBookTab = false;
                if (this.iwindowsFormsEditorService_0.ShowDialog((Form) colorEditorDialog) == DialogResult.OK)
                  obj = (object) EntityColor.CreateFrom(colorEditorDialog.Color);
              }
              else
                obj = (object) ((EntityColor.UITypeEditor.ColorItem) listBox.SelectedItem).Color;
            }
          }
        }
        return obj;
      }

      private void method_0(object sender, DrawItemEventArgs e)
      {
        EntityColor.UITypeEditor.ColorItem colorItem = (EntityColor.UITypeEditor.ColorItem) ((ListBox) sender).Items[e.Index];
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
          EntityColor color;
          if (!EntityColor.TryParse(s, out color))
            return;
          using (Brush brush = (Brush) new SolidBrush((System.Drawing.Color) color.ToArgbColor(DxfIndexedColorSet.AcadClassicIndexedColors)))
            e.Graphics.FillRectangle(brush, e.Bounds);
        }
        else
        {
          if (!(e.Value is EntityColor))
            return;
          using (Brush brush = (Brush) new SolidBrush((System.Drawing.Color) ((EntityColor) e.Value).ToArgbColor(DxfIndexedColorSet.AcadClassicIndexedColors)))
            e.Graphics.FillRectangle(brush, e.Bounds);
        }
      }

      public class ColorItem
      {
        private EntityColor entityColor_0;
        private string string_0;

        public EntityColor Color
        {
          get
          {
            return this.entityColor_0;
          }
          set
          {
            this.entityColor_0 = value;
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
          return this.entityColor_0.ToString();
        }
      }
    }

    public class TypeConverter : System.ComponentModel.TypeConverter
    {
      public static EntityColor[] StandardColors = new EntityColor[9]{ EntityColors.ByLayer, EntityColors.ByBlock, EntityColors.White, EntityColors.Gray, EntityColors.Red, EntityColors.Green, EntityColors.Blue, EntityColors.Yellow, EntityColors.Magenta };

      public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
      {
        if (!(sourceType == typeof (EntityColor)))
          return sourceType == typeof (string);
        return true;
      }

      public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
      {
        if (!(destinationType == typeof (EntityColor)))
          return destinationType == typeof (string);
        return true;
      }

      public override object ConvertFrom(
        ITypeDescriptorContext context,
        CultureInfo culture,
        object value)
      {
        string s = value as string;
        EntityColor color;
        if (s != null && EntityColor.TryParse(s, out color))
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
        return new System.ComponentModel.TypeConverter.StandardValuesCollection((ICollection) EntityColor.TypeConverter.StandardColors);
      }
    }
  }
}
