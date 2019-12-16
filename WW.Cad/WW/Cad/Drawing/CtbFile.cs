// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.CtbFile
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using WW.Cad.Model;
using WW.Drawing;
using WW.IO.Compression;
using WW.Text;

namespace WW.Cad.Drawing
{
  public class CtbFile
  {
    private static readonly double[] double_0 = new double[27]{ 0.0, 0.05, 0.09, 0.1, 0.13, 0.15, 0.18, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.53, 0.6, 0.65, 0.7, 0.8, 0.9, 1.0, 1.06, 1.2, 1.4, 1.58, 2.0, 2.11 };
    private static readonly CtbFile.Struct15 struct15_0 = new CtbFile.Struct15(3288334335U);
    private readonly List<CtbFile.ColorEntry> list_0 = new List<CtbFile.ColorEntry>((int) byte.MaxValue);
    private readonly List<double> list_1 = new List<double>((IEnumerable<double>) CtbFile.double_0);
    public const string FileHeader = "PIAFILEVERSION_2.0,CTBVER1,compress\r\npmzlibcodec";
    public const string EndOfContent = "\0";
    public const int PenNumberAutomatic = 0;
    public const int LineWeightIndexByObject = 0;
    public const short InvalidIndex = -1;
    private const uint uint_0 = 3288334335;
    internal const char char_0 = '{';
    internal const char char_1 = '}';
    internal const char char_2 = '=';
    private const string string_0 = "CTB file format error: ";
    private const string string_1 = "aci_table";
    private const string string_2 = "plot_style";
    private const string string_3 = "custom_lineweight_table";
    private const string string_4 = "aci_table_available";
    private const string string_5 = "scale_factor";
    private const string string_6 = "apply_factor";
    private const string string_7 = "custom_lineweight_display_units";
    private const string string_8 = "name";
    private const string string_9 = "localized_name";
    private const string string_10 = "description";
    private const string string_11 = "color";
    private const string string_12 = "mode_color";
    private const string string_13 = "color_policy";
    private const string string_14 = "physical_pen_number";
    private const string string_15 = "virtual_pen_number";
    private const string string_16 = "screen";
    private const string string_17 = "linepattern_size";
    private const string string_18 = "linetype";
    private const string string_19 = "adaptive_linetype";
    private const string string_20 = "lineweight";
    private const string string_21 = "fill_style";
    private const string string_22 = "end_style";
    private const string string_23 = "join_style";
    private string string_24;
    private CtbFile.DisplayUnit displayUnit_0;
    private bool bool_0;
    private double double_1;

    public CtbFile()
    {
      for (int index = 1; index <= (int) byte.MaxValue; ++index)
        this.list_0.Add(new CtbFile.ColorEntry(this, index));
    }

    public CtbFile(string filename)
    {
      this.ReadFrom(filename);
    }

    public void ReadFrom(string filename)
    {
      using (FileStream fileStream = File.OpenRead(filename))
        this.ReadFrom((Stream) fileStream);
    }

    public void ReadFrom(Stream stream)
    {
      byte[] numArray1 = new byte["PIAFILEVERSION_2.0,CTBVER1,compress\r\npmzlibcodec".Length];
      if (stream.Read(numArray1, 0, numArray1.Length) != numArray1.Length)
        throw new IOException("CTB file format error: Wrong header!");
      if ("PIAFILEVERSION_2.0,CTBVER1,compress\r\npmzlibcodec" != Encodings.Ascii.GetString(numArray1, 0, numArray1.Length))
        throw new IOException("CTB file format error: Wrong header!");
      int num1 = (int) CtbFile.smethod_8(stream);
      uint num2 = CtbFile.smethod_8(stream);
      byte[] numArray2 = new byte[(IntPtr) CtbFile.smethod_8(stream)];
      if (numArray2.Length != stream.Read(numArray2, 0, numArray2.Length))
        throw new IOException("CTB file format error: Compressed content is too short!");
      byte[] numArray3 = new byte[(IntPtr) num2];
      using (ZlibDecompressStream decompressStream = new ZlibDecompressStream((Stream) new MemoryStream(numArray2)))
      {
        if (numArray3.Length != decompressStream.Read(numArray3, 0, numArray3.Length))
          throw new IOException("CTB file format error: Expanded content is too short!");
      }
      int num3 = (int) CtbFile.smethod_0(numArray2, 0, numArray2.Length);
      this.method_0(Encodings.Ascii.GetString(numArray3, 0, numArray3.Length));
    }

    public void WriteTo(string filename)
    {
      using (FileStream fileStream = File.Create(filename))
        this.WriteTo((Stream) fileStream);
    }

    public void WriteTo(Stream stream)
    {
      byte[] bytes = Encodings.Ascii.GetBytes("PIAFILEVERSION_2.0,CTBVER1,compress\r\npmzlibcodec");
      stream.Write(bytes, 0, bytes.Length);
      MemoryStream memoryStream1 = new MemoryStream();
      this.method_1(new CtbFile.Class1003((Stream) memoryStream1));
      MemoryStream memoryStream2 = new MemoryStream((int) memoryStream1.Length);
      using (ZlibCompressStream zlibCompressStream = new ZlibCompressStream((Stream) memoryStream2, true))
      {
        memoryStream1.WriteTo((Stream) zlibCompressStream);
        zlibCompressStream.Flush();
      }
      uint num = CtbFile.smethod_0(memoryStream2.GetBuffer(), 0, (int) memoryStream2.Length);
      CtbFile.smethod_7(stream, num);
      CtbFile.smethod_7(stream, (uint) memoryStream1.Length);
      CtbFile.smethod_7(stream, (uint) memoryStream2.Length);
      memoryStream2.WriteTo(stream);
    }

    public void SortLineWeights()
    {
      List<double> doubleList = new List<double>((IEnumerable<double>) this.list_1);
      doubleList.Sort();
      int[] numArray = new int[this.list_1.Count];
      bool flag = false;
      for (int index = 0; index < numArray.Length; ++index)
      {
        double num1 = this.list_1[index];
        int num2 = doubleList.IndexOf(num1);
        if (num2 != index)
          flag = true;
        numArray[index] = num2;
      }
      if (!flag)
        return;
      this.list_1.Clear();
      this.list_1.AddRange((IEnumerable<double>) doubleList);
      foreach (CtbFile.ColorEntry colorEntry in this.list_0)
      {
        int lineWeightIndex = colorEntry.LineWeightIndex;
        if (lineWeightIndex > 0)
          colorEntry.LineWeightIndex = numArray[lineWeightIndex - 1] + 1;
      }
    }

    public int LineWeightCount
    {
      get
      {
        return this.list_1.Count;
      }
    }

    public double GetLineWeight(int index)
    {
      return this.list_1[index - 1];
    }

    public void SetLineWeight(int index, double lineWeight)
    {
      if (lineWeight < 0.0)
        throw new ArgumentException("lineWeight has to be non-negative!");
      if (index < 1)
        throw new ArgumentException("index has to be positive, first index is 1!");
      this.list_1[index - 1] = lineWeight;
    }

    public CtbFile.ColorEntry GetEntry(int colorIndex)
    {
      if (colorIndex < 1 || colorIndex > (int) byte.MaxValue)
        throw new ArgumentException("Color index has to be between 1 and 255!");
      return this.list_0[colorIndex - 1];
    }

    private void method_0(string content)
    {
      this.list_0.Clear();
      this.list_1.Clear();
      string[] lines = content.Split(new string[2]{ "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
      int l = 0;
      while (l < lines.Length)
      {
        if (CtbFile.smethod_1(lines[l]))
        {
          ++l;
        }
        else
        {
          CtbFile.Interface45 nterface45 = CtbFile.smethod_5(lines, ref l);
          switch (nterface45.Type)
          {
            case CtbFile.Enum43.const_0:
              switch (nterface45.Key)
              {
                case "description":
                  this.string_24 = nterface45.imethod_0(l);
                  continue;
                case "aci_table_available":
                  continue;
                case "scale_factor":
                  this.double_1 = nterface45.imethod_1(l);
                  continue;
                case "apply_factor":
                  this.bool_0 = nterface45.imethod_3(l);
                  continue;
                case "custom_lineweight_display_units":
                  this.displayUnit_0 = (CtbFile.DisplayUnit) nterface45.imethod_2(l);
                  continue;
                default:
                  throw new IOException("CTB file format error: Unknown global value " + nterface45.Key + " [line " + (object) l + "]");
              }
            case CtbFile.Enum43.const_1:
              switch (nterface45.Key)
              {
                case "aci_table":
                  CtbFile.smethod_2(lines, ref l);
                  continue;
                case "plot_style":
                  this.method_2(lines, ref l);
                  continue;
                case "custom_lineweight_table":
                  this.method_3(lines, ref l);
                  continue;
                default:
                  continue;
              }
            case CtbFile.Enum43.const_2:
              throw new IOException("CTB file format error: Unexpected close [line " + (object) l + "]");
            default:
              continue;
          }
        }
      }
    }

    private void method_1(CtbFile.Class1003 writer)
    {
      this.SortLineWeights();
      int count = this.list_0.Count;
      writer.Write((CtbFile.Interface45) new CtbFile.Class1005("description", this.string_24));
      writer.Write((CtbFile.Interface45) new CtbFile.Class1006("aci_table_available", true));
      writer.Write((CtbFile.Interface45) new CtbFile.Class1008("scale_factor", this.double_1));
      writer.Write((CtbFile.Interface45) new CtbFile.Class1006("apply_factor", this.bool_0));
      writer.Write((CtbFile.Interface45) new CtbFile.Class1007("custom_lineweight_display_units", (int) this.displayUnit_0));
      writer.method_1("aci_table");
      for (int index = 0; index < count; ++index)
        writer.Write((CtbFile.Interface45) new CtbFile.Class1005(index.ToString(), this.list_0[index].Name));
      writer.method_2();
      writer.method_1("plot_style");
      for (int index = 0; index < count; ++index)
      {
        writer.method_1(index.ToString());
        this.list_0[index].WriteTo(writer);
        writer.method_2();
      }
      writer.method_2();
      writer.method_1("custom_lineweight_table");
      for (int index = 0; index < this.list_1.Count; ++index)
        writer.Write((CtbFile.Interface45) new CtbFile.Class1008("0.0###", index.ToString(), this.list_1[index]));
      writer.method_2();
      writer.method_3();
    }

    private static uint smethod_0(byte[] bytes, int pos, int length)
    {
      uint num1 = 1;
      uint num2 = 0;
      while (length > 0)
      {
        int num3 = 3800 > length ? length : 3800;
        length -= num3;
        while (--num3 >= 0)
        {
          num1 += (uint) bytes[pos++] & (uint) byte.MaxValue;
          num2 += num1;
        }
        num1 %= 65521U;
        num2 %= 65521U;
      }
      return num2 << 16 | num1;
    }

    private static bool smethod_1(string line)
    {
      if (!("\0" == line) && !string.IsNullOrEmpty(line))
        return line.TrimEnd().Length == 0;
      return true;
    }

    private static void smethod_2(string[] lines, ref int l)
    {
      CtbFile.Interface45 token;
      do
        ;
      while ((token = CtbFile.smethod_5(lines, ref l)).Type == CtbFile.Enum43.const_0);
      CtbFile.smethod_4(token, l);
    }

    private void method_2(string[] lines, ref int l)
    {
      CtbFile.Interface45 token;
      while ((token = CtbFile.smethod_5(lines, ref l)).Type == CtbFile.Enum43.const_1)
      {
        CtbFile.smethod_3(this.list_0.Count, token.Key, l);
        CtbFile.ColorEntry colorEntry = new CtbFile.ColorEntry(this, l);
        colorEntry.method_0(lines, ref l);
        this.list_0.Add(colorEntry);
      }
      CtbFile.smethod_4(token, l);
    }

    private void method_3(string[] lines, ref int l)
    {
      CtbFile.Interface45 token;
      while ((token = CtbFile.smethod_5(lines, ref l)).Type == CtbFile.Enum43.const_0)
      {
        CtbFile.smethod_3(this.list_1.Count, token.Key, l);
        this.list_1.Add(token.imethod_1(l));
      }
      CtbFile.smethod_4(token, l);
    }

    private static void smethod_3(int expected, string key, int line)
    {
      int num = int.Parse(key);
      if (num != expected)
        throw new IOException("CTB file format error: Unexpected index for line weight (exp.: " + (object) expected + " / got: " + (object) num + " [line " + (object) line + "]");
    }

    private static void smethod_4(CtbFile.Interface45 token, int line)
    {
      if (token.Type != CtbFile.Enum43.const_2)
        throw new IOException("CTB file format error: Expected closing group [line " + (object) line + "]");
    }

    private static CtbFile.Interface45 smethod_5(string[] lines, ref int l)
    {
      string str = lines[l++].TrimStart();
      int length1 = CtbFile.smethod_6((IEnumerable<char>) str, l);
      switch (str[length1])
      {
        case '{':
          return (CtbFile.Interface45) new CtbFile.Class1009(str.Substring(0, length1));
        case '}':
          return (CtbFile.Interface45) new CtbFile.Class1010();
        default:
          string key = str.Substring(0, length1);
          string s1 = str.Substring(length1 + 1);
          if (s1[0] == '"')
            return (CtbFile.Interface45) new CtbFile.Class1005(key, s1.Substring(1));
          if ("TRUE".Equals(s1, StringComparison.InvariantCultureIgnoreCase))
            return (CtbFile.Interface45) new CtbFile.Class1006(key, true);
          if ("FALSE".Equals(s1, StringComparison.InvariantCultureIgnoreCase))
            return (CtbFile.Interface45) new CtbFile.Class1006(key, false);
          if (s1.Contains("."))
          {
            int length2;
            for (length2 = 0; length2 < s1.Length; ++length2)
            {
              char c = s1[length2];
              if (char.IsDigit(c) || c == '.')
              {
                ++length2;
                break;
              }
            }
            for (; length2 < s1.Length; ++length2)
            {
              char c = s1[length2];
              if (!char.IsDigit(c) && c != '.')
                break;
            }
            string s2 = s1;
            if (length2 < s1.Length)
              s2 = s1.Substring(0, length2);
            return (CtbFile.Interface45) new CtbFile.Class1008(key, double.Parse(s2, NumberStyles.Float, (IFormatProvider) CultureInfo.InvariantCulture.NumberFormat));
          }
          int length3;
          for (length3 = 0; length3 < s1.Length; ++length3)
          {
            if (char.IsDigit(s1[length3]))
            {
              ++length3;
              break;
            }
          }
          while (length3 < s1.Length && char.IsDigit(s1[length3]))
            ++length3;
          if (length3 < s1.Length)
            s1.Substring(0, length3);
          return (CtbFile.Interface45) new CtbFile.Class1007(key, int.Parse(s1));
      }
    }

    private static int smethod_6(IEnumerable<char> str, int line)
    {
      int num = 0;
      foreach (char ch in str)
      {
        switch (ch)
        {
          case '=':
          case '{':
          case '}':
            return num;
          default:
            ++num;
            continue;
        }
      }
      throw new IOException("CTB file format error: No separator [line " + (object) line + "]");
    }

    private static void smethod_7(Stream stream, uint value)
    {
      for (int index = 0; index < 4; ++index)
      {
        stream.WriteByte((byte) (value & (uint) byte.MaxValue));
        value >>= 8;
      }
    }

    private static uint smethod_8(Stream stream)
    {
      return (uint) ((int) CtbFile.smethod_9(stream) | (int) CtbFile.smethod_9(stream) << 8 | (int) CtbFile.smethod_9(stream) << 16 | (int) CtbFile.smethod_9(stream) << 24);
    }

    private static uint smethod_9(Stream stream)
    {
      int num = stream.ReadByte();
      if (num < 0)
        throw new IOException("CTB file format error: Unexpected end of file!");
      return (uint) num;
    }

    public enum DisplayUnit
    {
      Millimeter,
      Inch,
    }

    [Flags]
    public enum ColorPolicy
    {
      Dithering = 1,
      Grayscale = 2,
      YetUnknown = 4,
    }

    public enum SimpleLineType
    {
      Solid,
      Dashed,
      Dotted,
      DashDot,
      ShortDash,
      MediumDash,
      LongDash,
      ShortDashX2,
      MediumDashX2,
      LongDashX2,
      MediumLongDash,
      MediumDashShortDashShortDash,
      LongDashShortDash,
      LongDashDotDot,
      LongDashDot,
      MediumDashDotShortDashDot,
      SparseDot,
      IsoDash,
      IsoDashSpace,
      IsoLongDashDot,
      IsoLongDashDoubleDot,
      IsoLongDashTripleDot,
      IsoDot,
      IsoLongDashShortDash,
      IsoLongDashDoubleShortDash,
      IsoDashDot,
      IsoDoubleDashDot,
      IsoDashDoubleDot,
      IsoDoubleDashDoubleDot,
      IsoDashTripleDot,
      IsoDoubleDashTripleDot,
      ByObject,
    }

    public enum LineCapStyle
    {
      Butt,
      Square,
      Round,
      Diamond,
      ByObject,
    }

    public enum LineJoinStyle
    {
      Miter = 0,
      Bevel = 1,
      Round = 2,
      Diamond = 3,
      ByObject = 5,
    }

    internal struct Struct15
    {
      private readonly uint uint_0;

      internal Struct15(ArgbColor color, bool indexed)
      {
        this.uint_0 = (uint) ((indexed ? 195 : 194) << 24 | color.Rgb);
      }

      internal Struct15(uint data)
      {
        this.uint_0 = data;
      }

      internal ArgbColor RgbColor
      {
        get
        {
          if (!this.UseObjectColor)
            return new ArgbColor(4278190080U | this.uint_0);
          return ArgbColor.Empty;
        }
      }

      internal bool UseObjectColor
      {
        get
        {
          return this.uint_0 == 3288334335U;
        }
      }

      internal int Data
      {
        get
        {
          return (int) this.uint_0;
        }
      }
    }

    public class ColorEntry
    {
      private CtbFile.Struct15 struct15_0 = CtbFile.struct15_0;
      private CtbFile.Struct15 struct15_1 = CtbFile.struct15_0;
      private const string string_0 = "Description_";
      private const string string_1 = "Color_";
      private readonly CtbFile ctbFile_0;
      private readonly int int_0;
      private string string_2;
      private string string_3;
      private string string_4;
      private CtbFile.ColorPolicy colorPolicy_0;
      private int int_1;
      private int int_2;
      private int int_3;
      private double double_0;
      private CtbFile.SimpleLineType simpleLineType_0;
      private bool bool_0;
      private int int_4;
      private FillStyle fillStyle_0;
      private CtbFile.LineCapStyle lineCapStyle_0;
      private CtbFile.LineJoinStyle lineJoinStyle_0;

      internal ColorEntry(CtbFile parent, int index)
      {
        this.ctbFile_0 = parent;
        this.string_2 = "Color_" + (object) index;
        this.string_3 = this.string_2;
        this.string_4 = "Description_" + (object) index;
        this.int_0 = index;
      }

      public string Name
      {
        get
        {
          return this.string_2;
        }
        set
        {
          this.string_2 = value;
          if (this.string_3 != null)
            return;
          this.string_3 = value;
        }
      }

      public string LocalizedName
      {
        get
        {
          return this.string_3;
        }
        internal set
        {
          this.string_3 = value;
        }
      }

      public string Description
      {
        get
        {
          return this.string_4;
        }
        set
        {
          this.string_4 = value;
        }
      }

      public ArgbColor Color
      {
        get
        {
          return this.struct15_1.RgbColor;
        }
        set
        {
          if (value == ArgbColor.Empty)
          {
            this.struct15_1 = this.struct15_0 = CtbFile.struct15_0;
          }
          else
          {
            int bestMatchingIndex = (int) DxfIndexedColorSet.AcadWhiteBackgroundIndexedColors.GetBestMatchingIndex(value);
            ArgbColor backgroundIndexedColor = DxfIndexedColorSet.AcadWhiteBackgroundIndexedColors[bestMatchingIndex];
            bool flag;
            uint data = (uint) (((flag = backgroundIndexedColor == value) ? 195 : 194) << 24 | value.Rgb);
            if (flag)
            {
              this.struct15_1 = this.struct15_0 = new CtbFile.Struct15(data);
            }
            else
            {
              this.struct15_1 = new CtbFile.Struct15(data);
              this.struct15_0 = bestMatchingIndex == this.int_0 ? CtbFile.struct15_0 : new CtbFile.Struct15(backgroundIndexedColor, true);
            }
          }
        }
      }

      public ArgbColor IndexedColor
      {
        get
        {
          return this.struct15_0.RgbColor;
        }
      }

      public ArgbColor RgbColor
      {
        get
        {
          return this.struct15_1.RgbColor;
        }
      }

      public CtbFile.ColorPolicy ColorPolicySetting
      {
        get
        {
          return this.colorPolicy_0;
        }
        set
        {
          this.colorPolicy_0 = value;
        }
      }

      public int PhysicalPenNumber
      {
        get
        {
          return this.int_1;
        }
        set
        {
          if (value < 0 || value > 32)
            throw new ArgumentException("Physical pen number has to be between 0 and 32!");
          this.int_1 = value;
        }
      }

      public int VirtualPenNumber
      {
        get
        {
          return this.int_2;
        }
        set
        {
          if (value < 0 || value > (int) byte.MaxValue)
            throw new ArgumentException("Virtual pen number has to be between 0 and 255!");
          this.int_2 = value;
        }
      }

      public int Screening
      {
        get
        {
          return this.int_3;
        }
        set
        {
          if (value < 0 || value > 100)
            throw new ArgumentException("Screening has to be between 0 and 100!");
          this.int_3 = value;
        }
      }

      public double LinePatternSize
      {
        get
        {
          return this.double_0;
        }
        set
        {
          if (value < 0.1 || value > 10.0)
            throw new ArgumentException("LinePatternSize has to be between 0.1 and 10.0!");
          this.double_0 = value;
        }
      }

      public CtbFile.SimpleLineType LineType
      {
        get
        {
          return this.simpleLineType_0;
        }
        set
        {
          this.simpleLineType_0 = value;
        }
      }

      public bool IsAdaptiveLineType
      {
        get
        {
          return this.bool_0;
        }
        set
        {
          this.bool_0 = value;
        }
      }

      public int LineWeightIndex
      {
        get
        {
          return this.int_4;
        }
        set
        {
          if (this.int_4 < 0)
            throw new ArgumentException("LineWeightIndex has to be non-negative!");
          this.int_4 = value;
        }
      }

      public double? LineWeight
      {
        get
        {
          if (this.int_4 == 0)
            return new double?();
          return new double?(this.ctbFile_0.list_1[Math.Min(this.int_4, this.ctbFile_0.list_1.Count) - 1]);
        }
        set
        {
          if (!value.HasValue)
          {
            this.int_4 = 0;
          }
          else
          {
            double num = value.Value;
            for (int index = 0; index < this.ctbFile_0.list_1.Count; ++index)
            {
              if (this.ctbFile_0.list_1[index] == num)
              {
                this.int_4 = index + 1;
                return;
              }
            }
            throw new ArgumentException("Line weight is not valid, as there is no matching line weight in the custom line weights table!");
          }
        }
      }

      public FillStyle FillStyle
      {
        get
        {
          return this.fillStyle_0;
        }
        set
        {
          this.fillStyle_0 = value;
        }
      }

      public CtbFile.LineCapStyle CapStyle
      {
        get
        {
          return this.lineCapStyle_0;
        }
        set
        {
          this.lineCapStyle_0 = value;
        }
      }

      public CtbFile.LineJoinStyle JoinStyle
      {
        get
        {
          return this.lineJoinStyle_0;
        }
        set
        {
          this.lineJoinStyle_0 = value;
        }
      }

      internal void method_0(string[] lines, ref int l)
      {
        CtbFile.Interface45 token;
        while ((token = CtbFile.smethod_5(lines, ref l)).Type == CtbFile.Enum43.const_0)
        {
          switch (token.Key)
          {
            case "name":
              this.string_2 = token.imethod_0(l);
              continue;
            case "localized_name":
              this.string_3 = token.imethod_0(l);
              continue;
            case "description":
              this.string_4 = token.imethod_0(l);
              continue;
            case "color":
              this.struct15_0 = new CtbFile.Struct15((uint) token.imethod_2(l));
              continue;
            case "mode_color":
              this.struct15_1 = new CtbFile.Struct15((uint) token.imethod_2(l));
              continue;
            case "color_policy":
              this.colorPolicy_0 = (CtbFile.ColorPolicy) token.imethod_2(l);
              continue;
            case "physical_pen_number":
              this.int_1 = token.imethod_2(l);
              continue;
            case "virtual_pen_number":
              this.int_2 = token.imethod_2(l);
              continue;
            case "screen":
              this.int_3 = token.imethod_2(l);
              continue;
            case "linepattern_size":
              this.double_0 = token.imethod_1(l);
              continue;
            case "linetype":
              this.simpleLineType_0 = (CtbFile.SimpleLineType) token.imethod_2(l);
              continue;
            case "adaptive_linetype":
              this.bool_0 = token.imethod_3(1);
              continue;
            case "lineweight":
              this.int_4 = token.imethod_2(l);
              continue;
            case "fill_style":
              this.fillStyle_0 = (FillStyle) token.imethod_2(l);
              continue;
            case "end_style":
              this.lineCapStyle_0 = (CtbFile.LineCapStyle) token.imethod_2(l);
              continue;
            case "join_style":
              this.lineJoinStyle_0 = (CtbFile.LineJoinStyle) token.imethod_2(l);
              continue;
            default:
              throw new IOException("CTB file format error: Unknown value key " + token.Key + " [line " + (object) l + "]");
          }
        }
        CtbFile.smethod_4(token, l);
      }

      internal void WriteTo(CtbFile.Class1003 writer)
      {
        writer.Write((CtbFile.Interface45) new CtbFile.Class1005("name", this.string_2));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1005("localized_name", this.string_3));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1005("description", this.string_4));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1007("color", this.struct15_0.Data));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1007("mode_color", this.struct15_1.Data));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1007("color_policy", (int) this.colorPolicy_0));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1007("physical_pen_number", this.int_1));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1007("virtual_pen_number", this.int_2));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1007("screen", this.int_3));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1008("linepattern_size", this.double_0));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1007("linetype", (int) this.simpleLineType_0));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1006("adaptive_linetype", this.bool_0));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1007("lineweight", this.int_4));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1007("fill_style", (int) this.fillStyle_0));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1007("end_style", (int) this.lineCapStyle_0));
        writer.Write((CtbFile.Interface45) new CtbFile.Class1007("join_style", (int) this.lineJoinStyle_0));
      }
    }

    internal enum Enum43
    {
      const_0,
      const_1,
      const_2,
    }

    internal class Class1003
    {
      private string string_0 = "";
      private readonly Stream stream_0;

      internal Class1003(Stream stream)
      {
        this.stream_0 = stream;
      }

      internal void method_0(params object[] items)
      {
        this.Write(this.string_0);
        foreach (object obj in items)
          this.Write(obj.ToString());
        this.Write("\n");
      }

      internal void method_1(string name)
      {
        this.method_0((object) name, (object) '{');
        this.string_0 += " ";
      }

      internal void method_2()
      {
        this.string_0 = this.string_0.Substring(1);
        this.method_0((object) '}');
      }

      internal void Write(CtbFile.Interface45 token)
      {
        token.Write(this);
      }

      internal void method_3()
      {
        this.Write("\0");
      }

      internal void Write(string str)
      {
        byte[] bytes = Encodings.Ascii.GetBytes(str);
        this.stream_0.Write(bytes, 0, bytes.Length);
      }
    }

    internal interface Interface45
    {
      CtbFile.Enum43 Type { get; }

      string Key { get; }

      object Value { get; }

      void Write(CtbFile.Class1003 writer);

      string imethod_0(int line);

      double imethod_1(int line);

      int imethod_2(int line);

      bool imethod_3(int line);
    }

    private abstract class Class1004<T> : CtbFile.Interface45
    {
      private readonly string string_0;
      protected readonly T gparam_0;

      protected Class1004(string key, T value)
      {
        this.string_0 = key;
        this.gparam_0 = value;
      }

      public CtbFile.Enum43 Type
      {
        get
        {
          return CtbFile.Enum43.const_0;
        }
      }

      public string Key
      {
        get
        {
          return this.string_0;
        }
      }

      public object Value
      {
        get
        {
          return (object) this.gparam_0;
        }
      }

      public abstract void Write(CtbFile.Class1003 writer);

      public abstract string imethod_0(int line);

      public abstract double imethod_1(int line);

      public abstract int imethod_2(int line);

      public abstract bool imethod_3(int line);
    }

    private class Class1005 : CtbFile.Class1004<string>
    {
      public const char char_0 = '"';

      public Class1005(string key, string value)
        : base(key, value)
      {
      }

      public override void Write(CtbFile.Class1003 writer)
      {
        writer.method_0((object) this.Key, (object) '=', (object) '"', (object) this.gparam_0);
      }

      public override string imethod_0(int line)
      {
        return this.gparam_0;
      }

      public override double imethod_1(int line)
      {
        throw new IOException("CTB file format error: Expected double value, but got string [line " + (object) line + "]");
      }

      public override int imethod_2(int line)
      {
        throw new IOException("CTB file format error: Expected int value, but got string [line " + (object) line + "]");
      }

      public override bool imethod_3(int line)
      {
        throw new IOException("CTB file format error: Expected int value, but got string [line " + (object) line + "]");
      }
    }

    private class Class1006 : CtbFile.Class1004<bool>
    {
      public const string string_1 = "TRUE";
      public const string string_2 = "FALSE";

      public Class1006(string key, bool value)
        : base(key, value)
      {
      }

      public override void Write(CtbFile.Class1003 writer)
      {
        writer.method_0((object) this.Key, (object) '=', this.gparam_0 ? (object) "TRUE" : (object) "FALSE");
      }

      public override string imethod_0(int line)
      {
        throw new IOException("CTB file format error: Expected string value, but got bool [line " + (object) line + "]");
      }

      public override double imethod_1(int line)
      {
        throw new IOException("CTB file format error: Expected double value, but got bool [line " + (object) line + "]");
      }

      public override int imethod_2(int line)
      {
        throw new IOException("CTB file format error: Expected int value, but got bool [line " + (object) line + "]");
      }

      public override bool imethod_3(int line)
      {
        return this.gparam_0;
      }
    }

    private class Class1007 : CtbFile.Class1004<int>
    {
      public Class1007(string key, int value)
        : base(key, value)
      {
      }

      public override void Write(CtbFile.Class1003 writer)
      {
        writer.method_0((object) this.Key, (object) '=', (object) this.gparam_0);
      }

      public override string imethod_0(int line)
      {
        throw new IOException("CTB file format error: Expected string value, but got int [line " + (object) line + "]");
      }

      public override double imethod_1(int line)
      {
        return (double) this.gparam_0;
      }

      public override int imethod_2(int line)
      {
        return this.gparam_0;
      }

      public override bool imethod_3(int line)
      {
        throw new IOException("CTB file format error: Expected bool value, but got int [line " + (object) line + "]");
      }
    }

    private class Class1008 : CtbFile.Class1004<double>
    {
      private const string string_1 = "0.0";
      public const string string_2 = "0.0###";
      private readonly string string_3;

      public Class1008(string key, double value)
        : this("0.0", key, value)
      {
      }

      internal Class1008(string format, string key, double value)
        : base(key, value)
      {
        this.string_3 = format;
      }

      public override void Write(CtbFile.Class1003 writer)
      {
        writer.method_0((object) this.Key, (object) '=', (object) this.gparam_0.ToString(this.string_3, (IFormatProvider) CultureInfo.InvariantCulture.NumberFormat));
      }

      public override string imethod_0(int line)
      {
        throw new IOException("CTB file format error: Expected string value, but got double [line " + (object) line + "]");
      }

      public override double imethod_1(int line)
      {
        return this.gparam_0;
      }

      public override int imethod_2(int line)
      {
        throw new IOException("CTB file format error: Expected int value, but got double [line " + (object) line + "]");
      }

      public override bool imethod_3(int line)
      {
        throw new IOException("CTB file format error: Expected bool value, but got double [line " + (object) line + "]");
      }
    }

    private class Class1009 : CtbFile.Interface45
    {
      private readonly string string_0;

      public Class1009(string name)
      {
        this.string_0 = name;
      }

      public CtbFile.Enum43 Type
      {
        get
        {
          return CtbFile.Enum43.const_1;
        }
      }

      public string Key
      {
        get
        {
          return this.string_0;
        }
      }

      public object Value
      {
        get
        {
          return (object) null;
        }
      }

      public void Write(CtbFile.Class1003 writer)
      {
        writer.method_1(this.string_0);
      }

      public bool imethod_3(int line)
      {
        throw new IOException("CTB file format error: Expected value, but got open [line " + (object) line + "]");
      }

      public string imethod_0(int line)
      {
        throw new IOException("CTB file format error: Expected value, but got open [line " + (object) line + "]");
      }

      public double imethod_1(int line)
      {
        throw new IOException("CTB file format error: Expected value, but got open [line " + (object) line + "]");
      }

      public int imethod_2(int line)
      {
        throw new IOException("CTB file format error: Expected value, but got open [line " + (object) line + "]");
      }
    }

    private class Class1010 : CtbFile.Interface45
    {
      public CtbFile.Enum43 Type
      {
        get
        {
          return CtbFile.Enum43.const_2;
        }
      }

      public string Key
      {
        get
        {
          return (string) null;
        }
      }

      public object Value
      {
        get
        {
          return (object) null;
        }
      }

      public void Write(CtbFile.Class1003 writer)
      {
        writer.method_2();
      }

      public bool imethod_3(int line)
      {
        throw new IOException("CTB file format error: Expected value, but got close [line " + (object) line + "]");
      }

      public string imethod_0(int line)
      {
        throw new IOException("CTB file format error: Expected value, but got close [line " + (object) line + "]");
      }

      public double imethod_1(int line)
      {
        throw new IOException("CTB file format error: Expected value, but got close [line " + (object) line + "]");
      }

      public int imethod_2(int line)
      {
        throw new IOException("CTB file format error: Expected value, but got close [line " + (object) line + "]");
      }
    }
  }
}
