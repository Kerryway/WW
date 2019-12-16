// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.ShxFile
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns36;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WW.Cad.Base;
using WW.Text;

namespace WW.Cad.Model.Entities
{
  public class ShxFile
  {
    private static readonly Dictionary<string, Encoding> dictionary_0 = new Dictionary<string, Encoding>();
    private static readonly Dictionary<string, Encoding> dictionary_1 = new Dictionary<string, Encoding>();
    private static readonly Dictionary<string, CharRemapDelegate> dictionary_2 = new Dictionary<string, CharRemapDelegate>();
    private static readonly byte[] byte_0 = new byte[103]{ (byte) 65, (byte) 117, (byte) 116, (byte) 111, (byte) 67, (byte) 65, (byte) 68, (byte) 45, (byte) 56, (byte) 54, (byte) 32, (byte) 115, (byte) 104, (byte) 97, (byte) 112, (byte) 101, (byte) 115, (byte) 32, (byte) 49, (byte) 46, (byte) 49, (byte) 13, (byte) 10, (byte) 26, (byte) 130, (byte) 0, (byte) 134, (byte) 0, (byte) 5, (byte) 0, (byte) 130, (byte) 0, (byte) 13, (byte) 0, (byte) 131, (byte) 0, (byte) 7, (byte) 0, (byte) 132, (byte) 0, (byte) 10, (byte) 0, (byte) 133, (byte) 0, (byte) 10, (byte) 0, (byte) 134, (byte) 0, (byte) 10, (byte) 0, (byte) 84, (byte) 82, (byte) 65, (byte) 67, (byte) 75, (byte) 49, (byte) 0, (byte) 20, (byte) 2, (byte) 28, (byte) 1, (byte) 28, (byte) 0, (byte) 90, (byte) 73, (byte) 71, (byte) 0, (byte) 18, (byte) 30, (byte) 0, (byte) 66, (byte) 79, (byte) 88, (byte) 0, (byte) 20, (byte) 32, (byte) 44, (byte) 40, (byte) 20, (byte) 0, (byte) 67, (byte) 73, (byte) 82, (byte) 67, (byte) 49, (byte) 0, (byte) 10, (byte) 1, (byte) 192, (byte) 0, (byte) 66, (byte) 65, (byte) 84, (byte) 0, (byte) 37, (byte) 10, (byte) 2, (byte) 196, (byte) 43, (byte) 0, (byte) 69, (byte) 79, (byte) 70 };
    private static readonly Dictionary<string, ShxFile> dictionary_5 = new Dictionary<string, ShxFile>();
    private const string string_0 = "LTYPESHP.SHX";
    private static ShxFile shxFile_0;
    private readonly string string_1;
    private BinaryReader binaryReader_0;
    private readonly ShxFormat shxFormat_0;
    private string string_2;
    private int int_0;
    private int int_1;
    private int int_2;
    private int int_3;
    private int int_4;
    private int int_5;
    private int int_6;
    private readonly double double_0;
    private readonly double double_1;
    private readonly Dictionary<ushort, ShxShape> dictionary_3;
    private readonly Dictionary<char, ShxShape> dictionary_4;
    private readonly Encoding encoding_0;

    private ShxFile(string filename)
      : this(filename, (byte[]) null)
    {
    }

    private ShxFile(string filename, byte[] data)
    {
      this.string_1 = filename;
      this.dictionary_3 = new Dictionary<ushort, ShxShape>();
      this.dictionary_4 = new Dictionary<char, ShxShape>();
      using (Stream input = data == null ? (Stream) File.OpenRead(filename) : (Stream) new MemoryStream(data))
      {
        using (this.binaryReader_0 = new BinaryReader(input))
        {
          this.shxFormat_0 = this.method_9();
          Class2 class2;
          switch (this.shxFormat_0)
          {
            case ShxFormat.shx1_0:
              CharRemapDelegate charRemapper1;
              ShxFile.dictionary_2.TryGetValue(ShxFile.smethod_4(filename), out charRemapper1);
              class2 = new Class2(this.binaryReader_0, ShxFile.smethod_1(filename, DrawingCodePage.Dos437), charRemapper1, this);
              break;
            case ShxFormat.shx1_1:
              CharRemapDelegate charRemapper2;
              ShxFile.dictionary_2.TryGetValue(ShxFile.smethod_4(filename), out charRemapper2);
              class2 = new Class2(this.binaryReader_0, ShxFile.smethod_1(filename, DrawingCodePage.Ansi1252), charRemapper2, this);
              break;
            case ShxFormat.shxBigFont1_0:
              this.encoding_0 = ShxFile.smethod_0(filename);
              if (this.encoding_0 == null)
                throw new ShxFile.ShxUnknownEncodingException("Encoding of bigfont SHX file " + filename + " is unknown!");
              class2 = (Class2) new Class5(this.binaryReader_0, this.encoding_0, this);
              break;
            case ShxFormat.shxUnicode1_0:
              class2 = (Class2) new Class3(this.binaryReader_0, Encoding.UTF8, this);
              break;
            default:
              throw new InternalException("Unknown SHX file format!");
          }
          class2.Read();
        }
      }
      if (this.int_3 == 0)
        this.int_3 = this.int_1 + this.int_0;
      ShxShape shape = this.GetShape('\n');
      if (shape == null)
        return;
      WW.Math.Point2D endPoint;
      shape.GetGlyphShape(false, out endPoint);
      this.double_1 = endPoint.Y;
      shape.GetGlyphShape(true, out endPoint);
      this.double_0 = endPoint.X;
    }

    public string FileName
    {
      get
      {
        return this.string_1;
      }
    }

    public string Description
    {
      get
      {
        return this.string_2;
      }
    }

    public int Height
    {
      get
      {
        return this.int_3;
      }
    }

    public int Width
    {
      get
      {
        return this.int_4;
      }
    }

    public int Above
    {
      get
      {
        return this.int_0;
      }
    }

    public int Below
    {
      get
      {
        return this.int_1;
      }
    }

    public double HorizontalLinefeedAdvance
    {
      get
      {
        return this.double_0;
      }
    }

    public double VerticalLinefeedAdvance
    {
      get
      {
        return this.double_1;
      }
    }

    public static bool Exists(string filename, string[] path)
    {
      return ShxFile.smethod_3(filename, path) != null;
    }

    public static ShxFile GetShxFile(string filename, string[] path)
    {
      string str = ShxFile.smethod_3(filename, path);
      if (string.IsNullOrEmpty(str))
      {
        if (!"LTYPESHP.SHX".Equals(filename, StringComparison.InvariantCultureIgnoreCase))
          return (ShxFile) null;
        lock (ShxFile.byte_0)
        {
          if (ShxFile.shxFile_0 == null)
            ShxFile.shxFile_0 = new ShxFile("LTYPESHP.SHX", ShxFile.byte_0);
        }
        return ShxFile.shxFile_0;
      }
      ShxFile shxFile;
      lock (ShxFile.dictionary_5)
      {
        if (!ShxFile.dictionary_5.TryGetValue(str, out shxFile))
          shxFile = new ShxFile(str);
      }
      return shxFile;
    }

    public ShxShape GetShape(char unicode)
    {
      ShxShape shapeByIndex;
      if (!this.dictionary_4.TryGetValue(unicode, out shapeByIndex) && (this.shxFormat_0 == ShxFormat.shx1_0 || this.shxFormat_0 == ShxFormat.shx1_1))
        shapeByIndex = this.GetShapeByIndex((ushort) unicode);
      return shapeByIndex;
    }

    public ShxShape GetShapeByIndex(ushort index)
    {
      ShxShape shxShape;
      this.dictionary_3.TryGetValue(index, out shxShape);
      return shxShape;
    }

    public ushort? GetShapeIndexByDescription(string desc)
    {
      foreach (ShxShape shxShape in this.dictionary_3.Values)
      {
        if (shxShape.Description == desc)
          return new ushort?(shxShape.Index);
      }
      return new ushort?();
    }

    public override string ToString()
    {
      return this.string_2;
    }

    public static void AddBigfontEncoding(string filename, Encoding encoding)
    {
      string key = ShxFile.smethod_4(filename);
      lock (ShxFile.dictionary_0)
        ShxFile.dictionary_0.Add(key, encoding);
    }

    public static void AddOldShxEncoding(string filename, Encoding encoding)
    {
      string key = ShxFile.smethod_4(filename);
      lock (ShxFile.dictionary_1)
        ShxFile.dictionary_1.Add(key, encoding);
    }

    public static void AddFontCharRemapper(string filename, CharRemapDelegate charRemapDelegate)
    {
      string key = ShxFile.smethod_4(filename);
      lock (ShxFile.dictionary_2)
        ShxFile.dictionary_2.Add(key, charRemapDelegate);
    }

    internal ShxFormat ShxFormat
    {
      get
      {
        return this.shxFormat_0;
      }
    }

    internal Encoding FileEncoding
    {
      get
      {
        return this.encoding_0;
      }
    }

    internal void method_0(ShxShape shape)
    {
      this.dictionary_3[shape.Index] = shape;
      this.dictionary_4[shape.UnicodeCharIndex] = shape;
    }

    internal void method_1(string description)
    {
      this.string_2 = description;
    }

    internal void method_2(int above)
    {
      this.int_0 = above;
    }

    internal void method_3(int below)
    {
      this.int_1 = below;
    }

    internal void method_4(int mode)
    {
      this.int_2 = mode;
    }

    internal void method_5(int height)
    {
      this.int_3 = height;
    }

    internal void method_6(int width)
    {
      this.int_4 = width;
    }

    internal void method_7(int encoding)
    {
      this.int_5 = encoding;
    }

    internal void method_8(int type)
    {
      this.int_6 = type;
    }

    internal static Encoding smethod_0(string filename)
    {
      string key = ShxFile.smethod_4(filename);
      Encoding encoding;
      lock (ShxFile.dictionary_0)
        ShxFile.dictionary_0.TryGetValue(key, out encoding);
      return encoding;
    }

    internal static Encoding smethod_1(string filename, DrawingCodePage defaultCodepage)
    {
      string key = ShxFile.smethod_4(filename);
      Encoding encoding;
      lock (ShxFile.dictionary_1)
      {
        if (!ShxFile.dictionary_1.TryGetValue(key, out encoding))
          encoding = Encodings.GetEncoding((int) defaultCodepage);
      }
      return encoding;
    }

    internal static bool smethod_2(string filename, string[] path)
    {
      if (!filename.Equals("LTYPESHP.SHX", StringComparison.InvariantCultureIgnoreCase))
        return ShxFile.Exists(filename, path);
      return true;
    }

    private static string smethod_3(string filename, string[] path)
    {
      if (string.IsNullOrEmpty(filename))
        return (string) null;
      if (!filename.ToLower().EndsWith(".shx"))
        filename += ".shx";
      return Class1043.smethod_1(filename, path);
    }

    private ShxFormat method_9()
    {
      this.binaryReader_0.BaseStream.Position = 0L;
      if (this.method_10(Class1018.byte_2))
        return ShxFormat.shx1_0;
      this.binaryReader_0.BaseStream.Position = 0L;
      if (this.method_10(Class1018.byte_3))
        return ShxFormat.shx1_1;
      this.binaryReader_0.BaseStream.Position = 0L;
      if (this.method_10(Class1018.byte_4))
        return ShxFormat.shxBigFont1_0;
      this.binaryReader_0.BaseStream.Position = 0L;
      if (!this.method_10(Class1018.byte_5))
      {
        this.binaryReader_0.BaseStream.Position = 0L;
        throw new IOException("Unknown SHX format, file " + this.string_1 + ".");
      }
      return ShxFormat.shxUnicode1_0;
    }

    private bool method_10(byte[] headerToMatch)
    {
      for (int index = 0; index < headerToMatch.Length; ++index)
      {
        if ((int) this.binaryReader_0.ReadByte() != (int) headerToMatch[index])
          return false;
      }
      return true;
    }

    private static string smethod_4(string filename)
    {
      int num = filename.LastIndexOf('\\');
      if (num >= 0)
        filename = filename.Substring(num + 1);
      int length = filename.IndexOf('.');
      if (length >= 0)
        filename = filename.Substring(0, length);
      return filename.ToUpperInvariant();
    }

    static ShxFile()
    {
      try
      {
        ShxFile.AddBigfontEncoding("@EXTFONT2", Encodings.Dos932);
        ShxFile.AddBigfontEncoding("EXTFONT2", Encodings.Dos932);
        ShxFile.AddBigfontEncoding("BIGFONT", Encodings.Dos932);
        ShxFile.AddBigfontEncoding("EXTFONT", Encodings.Dos932);
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
      try
      {
        ShxFile.AddBigfontEncoding("CHINESET", Encodings.Ansi950);
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
      try
      {
        ShxFile.AddBigfontEncoding("GBCBIG", Encodings.Gb2312);
        ShxFile.AddBigfontEncoding("HZTXT", Encodings.Gb2312);
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
      try
      {
        ShxFile.AddBigfontEncoding("WHGDTXT", Encodings.Ksc5601);
        ShxFile.AddBigfontEncoding("WHGTXT", Encodings.Ksc5601);
        ShxFile.AddBigfontEncoding("WHTGTXT", Encodings.Ksc5601);
        ShxFile.AddBigfontEncoding("WHTMTXT", Encodings.Ksc5601);
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
      try
      {
        Encoding encoding = Encodings.GetEncoding(437);
        ShxFile.AddOldShxEncoding("COMPLEX", encoding);
        ShxFile.AddOldShxEncoding("COMPLEX8", encoding);
        ShxFile.AddOldShxEncoding("GOTHICE", encoding);
        ShxFile.AddOldShxEncoding("GOTHICG", encoding);
        ShxFile.AddOldShxEncoding("GOTHICI", encoding);
        ShxFile.AddOldShxEncoding("GREEKC", encoding);
        ShxFile.AddOldShxEncoding("GREEKS", encoding);
        ShxFile.AddOldShxEncoding("ISOCP", encoding);
        ShxFile.AddOldShxEncoding("ISOCP2", encoding);
        ShxFile.AddOldShxEncoding("ISOCP3", encoding);
        ShxFile.AddOldShxEncoding("ISOCT", encoding);
        ShxFile.AddOldShxEncoding("ISOCT2", encoding);
        ShxFile.AddOldShxEncoding("ISOCT3", encoding);
        ShxFile.AddOldShxEncoding("ITALIC", encoding);
        ShxFile.AddOldShxEncoding("ITALICC", encoding);
        ShxFile.AddOldShxEncoding("ITALICT", encoding);
        ShxFile.AddOldShxEncoding("MONOTXT", encoding);
        ShxFile.AddOldShxEncoding("ROMANC", encoding);
        ShxFile.AddOldShxEncoding("ROMAND", encoding);
        ShxFile.AddOldShxEncoding("ROMANS", encoding);
        ShxFile.AddOldShxEncoding("ROMANT", encoding);
        ShxFile.AddOldShxEncoding("SCRIPTC", encoding);
        ShxFile.AddOldShxEncoding("SCRIPTS", encoding);
        ShxFile.AddOldShxEncoding("SIMPLEX", encoding);
        ShxFile.AddOldShxEncoding("SIMPLEX8", encoding);
        ShxFile.AddOldShxEncoding("SYASTRO", encoding);
        ShxFile.AddOldShxEncoding("SYMAP", encoding);
        ShxFile.AddOldShxEncoding("SYMATH", encoding);
        ShxFile.AddOldShxEncoding("SYMETEO", encoding);
        ShxFile.AddOldShxEncoding("SYMUSIC", encoding);
        ShxFile.AddOldShxEncoding("TXT", encoding);
        ShxFile.AddOldShxEncoding("TXT8", encoding);
        ShxFile.AddOldShxEncoding("ATIR", Encodings.GetEncoding(862));
        ShxFile.AddFontCharRemapper("ATIR", new CharRemapDelegate(new FontCharRemapper(Encodings.GetEncoding(862), Encodings.GetEncoding(1255)).Remap));
        ShxFile.AddOldShxEncoding("HEBTXT", Encodings.GetEncoding(862));
        ShxFile.AddFontCharRemapper("HEBTXT", new CharRemapDelegate(new FontCharRemapper(Encodings.GetEncoding(862), Encodings.GetEncoding(1255)).Remap));
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
      try
      {
        ShxFile.AddOldShxEncoding("P131", Encodings.Ansi1251);
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
    }

    public class ShxUnknownEncodingException : DxfException
    {
      public ShxUnknownEncodingException(string message)
        : base(message)
      {
      }
    }
  }
}
