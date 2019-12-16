// Decompiled with JetBrains decompiler
// Type: WW.WWF.WoutWareFont
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.IO;
using WW.IO.Compression;
using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace WW.WWF
{
  public class WoutWareFont : IWoutWareFont
  {
    private readonly byte[] byte_0 = new byte[4]{ (byte) 87, (byte) 87, (byte) 70, (byte) 0 };
    private byte byte_1 = 2;
    private readonly IDictionary<char, WoutWareGlyph> idictionary_1 = (IDictionary<char, WoutWareGlyph>) new Dictionary<char, WoutWareGlyph>();
    private double double_0;
    private double double_1;
    private IList<IShape2D> ilist_0;
    private IDictionary<uint, IList<int>> idictionary_0;

    public WoutWareFont()
    {
    }

    public WoutWareFont(Stream stream)
    {
      this.ReadFrom(stream);
    }

    public byte Version
    {
      get
      {
        return this.byte_1;
      }
    }

    public double Ascent
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public double Descent
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public ICanonicalGlyph GetGlyph(char letter)
    {
      return this.GetGlyph(letter, (ICanonicalGlyph) null);
    }

    public ICanonicalGlyph GetGlyph(char letter, ICanonicalGlyph fallbackGlyph)
    {
      WoutWareGlyph woutWareGlyph;
      if (!this.idictionary_1.TryGetValue(letter, out woutWareGlyph))
        return fallbackGlyph;
      return (ICanonicalGlyph) woutWareGlyph;
    }

    public IEnumerable<WoutWareGlyph> Glyphs
    {
      get
      {
        List<WoutWareGlyph> woutWareGlyphList = new List<WoutWareGlyph>((IEnumerable<WoutWareGlyph>) this.idictionary_1.Values);
        woutWareGlyphList.Sort((Comparison<WoutWareGlyph>) ((g1, g2) => g1.Letter.CompareTo(g2.Letter)));
        return (IEnumerable<WoutWareGlyph>) woutWareGlyphList;
      }
    }

    public int GlyphCount
    {
      get
      {
        return this.idictionary_1.Count;
      }
    }

    public void AddGlyph(WoutWareGlyph glyph)
    {
      if (glyph == null)
        return;
      this.idictionary_1.Add(glyph.Letter, glyph);
    }

    public void AddGlyph(char letter, IShape2D outline, Vector2D advance)
    {
      this.AddGlyph(new WoutWareGlyph(letter, outline, advance));
    }

    public void WriteTo(Stream stream)
    {
      stream.Write(this.byte_0, 0, this.byte_0.Length);
      stream.WriteByte(this.byte_1);
      switch (this.byte_1)
      {
        case 1:
          this.method_0(stream);
          break;
        case 2:
          using (ZlibCompressStream zlibCompressStream = new ZlibCompressStream(stream, true))
          {
            try
            {
              this.method_0((Stream) zlibCompressStream);
              break;
            }
            finally
            {
              zlibCompressStream.Flush();
            }
          }
        default:
          throw new InternalException("Undefined WWF version " + (object) this.byte_1 + "!");
      }
    }

    private void ReadFrom(Stream stream)
    {
      byte[] buffer = new byte[System.Math.Max(4, this.byte_0.Length)];
      stream.Read(buffer, 0, this.byte_0.Length);
      for (int index = 0; index < this.byte_0.Length; ++index)
      {
        if ((int) this.byte_0[index] != (int) buffer[index])
          throw new IOException("Not a WWF file: wrong magic header!");
      }
      this.byte_1 = (byte) stream.ReadByte();
      switch (this.byte_1)
      {
        case 1:
          this.method_1(stream, buffer);
          break;
        case 2:
          using (ZlibDecompressStream decompressStream = new ZlibDecompressStream(stream, true))
          {
            this.method_1((Stream) decompressStream, buffer);
            break;
          }
        default:
          throw new IOException("Cannot handle WWF format version " + (object) this.byte_1 + "!");
      }
    }

    private void method_0(Stream stream)
    {
      WoutWareFont.smethod_2(stream, (float) this.double_0);
      WoutWareFont.smethod_2(stream, (float) this.double_1);
      try
      {
        this.ilist_0 = (IList<IShape2D>) new List<IShape2D>();
        this.idictionary_0 = (IDictionary<uint, IList<int>>) new Dictionary<uint, IList<int>>();
        IList<Pair<WoutWareGlyph, IList<Pair<Matrix3D, int>>>> pendingGlyphs = (IList<Pair<WoutWareGlyph, IList<Pair<Matrix3D, int>>>>) new List<Pair<WoutWareGlyph, IList<Pair<Matrix3D, int>>>>();
        foreach (WoutWareGlyph glyph in this.Glyphs)
          this.method_2(glyph, pendingGlyphs);
        WoutWareFont.smethod_0(stream, this.ilist_0.Count);
        foreach (IShape2D shape in (IEnumerable<IShape2D>) this.ilist_0)
          WoutWareFont.smethod_10(stream, shape);
        WoutWareFont.smethod_0(stream, pendingGlyphs.Count);
        foreach (Pair<WoutWareGlyph, IList<Pair<Matrix3D, int>>> pair in (IEnumerable<Pair<WoutWareGlyph, IList<Pair<Matrix3D, int>>>>) pendingGlyphs)
          WoutWareFont.smethod_13(stream, pair.First, (IEnumerable<Pair<Matrix3D, int>>) pair.Second);
      }
      finally
      {
        this.ilist_0 = (IList<IShape2D>) null;
        this.idictionary_0 = (IDictionary<uint, IList<int>>) null;
      }
    }

    private void method_1(Stream stream, byte[] buffer)
    {
      this.double_0 = (double) WoutWareFont.smethod_3(stream, buffer);
      this.double_1 = (double) WoutWareFont.smethod_3(stream, buffer);
      int capacity = WoutWareFont.smethod_1(stream, buffer);
      this.ilist_0 = (IList<IShape2D>) new List<IShape2D>(capacity);
      try
      {
        while (--capacity >= 0)
          this.ilist_0.Add(WoutWareFont.smethod_11(stream, buffer));
        int num = WoutWareFont.smethod_1(stream, buffer);
        while (--num >= 0)
          this.AddGlyph(this.method_4(stream, buffer));
      }
      finally
      {
        this.ilist_0 = (IList<IShape2D>) null;
      }
    }

    private static void Write(Stream stream, byte[] bytes)
    {
      stream.Write(bytes, 0, bytes.Length);
    }

    private static void smethod_0(Stream stream, int value)
    {
      WoutWareFont.Write(stream, LittleEndianBitConverter.GetBytes(value));
    }

    private static int smethod_1(Stream stream, byte[] buffer)
    {
      stream.Read(buffer, 0, 4);
      return LittleEndianBitConverter.ToInt32(buffer);
    }

    private static void smethod_2(Stream stream, float value)
    {
      WoutWareFont.Write(stream, LittleEndianBitConverter.GetBytes(value));
    }

    private static float smethod_3(Stream stream, byte[] buffer)
    {
      stream.Read(buffer, 0, 4);
      return LittleEndianBitConverter.ToSingle(buffer);
    }

    private static void smethod_4(Stream stream, char value)
    {
      WoutWareFont.Write(stream, LittleEndianBitConverter.GetBytes(value));
    }

    private static char smethod_5(Stream stream, byte[] buffer)
    {
      stream.Read(buffer, 0, 2);
      return LittleEndianBitConverter.ToChar(buffer);
    }

    private static void smethod_6(Stream stream, Vector2D value)
    {
      WoutWareFont.smethod_2(stream, (float) value.X);
      WoutWareFont.smethod_2(stream, (float) value.Y);
    }

    private static Vector2D smethod_7(Stream stream, byte[] buffer)
    {
      return new Vector2D((double) WoutWareFont.smethod_3(stream, buffer), (double) WoutWareFont.smethod_3(stream, buffer));
    }

    private static void smethod_8(Stream stream, Point2D value)
    {
      WoutWareFont.smethod_2(stream, (float) value.X);
      WoutWareFont.smethod_2(stream, (float) value.Y);
    }

    private static Point2D smethod_9(Stream stream, byte[] buffer)
    {
      return new Point2D((double) WoutWareFont.smethod_3(stream, buffer), (double) WoutWareFont.smethod_3(stream, buffer));
    }

    private static void smethod_10(Stream stream, IShape2D shape)
    {
      Point2D[] points = new Point2D[3];
      ISegment2DIterator iterator = shape.CreateIterator();
      while (iterator.MoveNext())
      {
        switch (iterator.Current(points, 0))
        {
          case SegmentType.MoveTo:
            stream.WriteByte((byte) 77);
            WoutWareFont.smethod_8(stream, points[0]);
            continue;
          case SegmentType.LineTo:
            stream.WriteByte((byte) 76);
            WoutWareFont.smethod_8(stream, points[0]);
            continue;
          case SegmentType.QuadTo:
            stream.WriteByte((byte) 81);
            WoutWareFont.smethod_8(stream, points[0]);
            WoutWareFont.smethod_8(stream, points[1]);
            continue;
          case SegmentType.CubicTo:
            stream.WriteByte((byte) 67);
            WoutWareFont.smethod_8(stream, points[0]);
            WoutWareFont.smethod_8(stream, points[1]);
            WoutWareFont.smethod_8(stream, points[2]);
            continue;
          case SegmentType.Close:
            stream.WriteByte((byte) 46);
            continue;
          default:
            continue;
        }
      }
      stream.WriteByte((byte) 33);
    }

    private static IShape2D smethod_11(Stream stream, byte[] buffer)
    {
      GeneralShape2D generalShape2D = new GeneralShape2D();
      int num;
      while (true)
      {
        num = stream.ReadByte();
        if (num >= 0)
        {
          WoutWareFont.Enum11 enum11 = (WoutWareFont.Enum11) num;
          if ((uint) enum11 <= 46U)
          {
            if (enum11 != WoutWareFont.Enum11.const_5)
            {
              if (enum11 == WoutWareFont.Enum11.const_4)
                generalShape2D.Close();
              else
                goto label_15;
            }
            else
              goto label_12;
          }
          else
          {
            switch (enum11)
            {
              case WoutWareFont.Enum11.const_3:
                Point2D p1_1 = WoutWareFont.smethod_9(stream, buffer);
                Point2D p2_1 = WoutWareFont.smethod_9(stream, buffer);
                Point2D p3 = WoutWareFont.smethod_9(stream, buffer);
                generalShape2D.CubicTo(p1_1, p2_1, p3);
                continue;
              case WoutWareFont.Enum11.const_1:
                Point2D p1 = WoutWareFont.smethod_9(stream, buffer);
                generalShape2D.LineTo(p1);
                continue;
              case WoutWareFont.Enum11.const_0:
                Point2D p2 = WoutWareFont.smethod_9(stream, buffer);
                generalShape2D.MoveTo(p2);
                continue;
              case WoutWareFont.Enum11.const_2:
                Point2D p1_2 = WoutWareFont.smethod_9(stream, buffer);
                Point2D p2_2 = WoutWareFont.smethod_9(stream, buffer);
                generalShape2D.QuadTo(p1_2, p2_2);
                continue;
              default:
                goto label_15;
            }
          }
        }
        else
          break;
      }
      throw new IOException("Unexpected end of input!");
label_12:
      if (generalShape2D.HasSegments)
        generalShape2D.ShrinkWrap();
      else
        generalShape2D = (GeneralShape2D) null;
      return (IShape2D) generalShape2D;
label_15:
      throw new IOException("Invalid path operator " + (object) num);
    }

    private void method_2(
      WoutWareGlyph glyph,
      IList<Pair<WoutWareGlyph, IList<Pair<Matrix3D, int>>>> pendingGlyphs)
    {
      IShape2D path = glyph.Path;
      if (path.HasSegments)
      {
        List<Pair<Matrix3D, int>> pairList = new List<Pair<Matrix3D, int>>();
        foreach (IShape2D shape2D in ShapeTool.SplitIntoUnbroken(path))
        {
          bool flag = false;
          IList<int> intList = this.method_3(shape2D);
          foreach (int second in (IEnumerable<int>) intList)
          {
            Matrix3D? transformation = ShapeTool.GetTransformation(this.ilist_0[second], shape2D, 0.01);
            if (transformation.HasValue)
            {
              flag = true;
              pairList.Add(new Pair<Matrix3D, int>(transformation.Value, second));
              break;
            }
          }
          if (!flag)
          {
            pairList.Add(new Pair<Matrix3D, int>(Matrix3D.Identity, this.ilist_0.Count));
            intList.Add(this.ilist_0.Count);
            this.ilist_0.Add(shape2D);
          }
        }
        pendingGlyphs.Add(new Pair<WoutWareGlyph, IList<Pair<Matrix3D, int>>>(glyph, (IList<Pair<Matrix3D, int>>) pairList));
      }
      else
        pendingGlyphs.Add(new Pair<WoutWareGlyph, IList<Pair<Matrix3D, int>>>(glyph, (IList<Pair<Matrix3D, int>>) null));
    }

    private IList<int> method_3(IShape2D prototype)
    {
      uint key = WoutWareFont.smethod_14(prototype);
      IList<int> intList;
      if (!this.idictionary_0.TryGetValue(key, out intList))
      {
        intList = (IList<int>) new List<int>();
        this.idictionary_0.Add(key, intList);
      }
      return intList;
    }

    private static bool smethod_12(double value)
    {
      return System.Math.Abs(value) <= 1E-06;
    }

    private static void smethod_13(
      Stream stream,
      WoutWareGlyph glyph,
      IEnumerable<Pair<Matrix3D, int>> shapeRefs)
    {
      WoutWareFont.smethod_4(stream, glyph.Letter);
      WoutWareFont.smethod_6(stream, glyph.Advance);
      if (shapeRefs != null)
      {
        foreach (Pair<Matrix3D, int> shapeRef in shapeRefs)
        {
          Matrix3D first = shapeRef.First;
          WoutWareFont.Enum12 enum12_1;
          if (WoutWareFont.smethod_12(first.M01))
          {
            if (WoutWareFont.smethod_12(first.M10))
            {
              WoutWareFont.Enum12 enum12_2;
              if (WoutWareFont.smethod_12(first.M02) && WoutWareFont.smethod_12(first.M12))
              {
                if (WoutWareFont.smethod_12(first.M00) && WoutWareFont.smethod_12(first.M11))
                {
                  stream.WriteByte((byte) 100);
                  enum12_1 = WoutWareFont.Enum12.const_0;
                  goto label_19;
                }
                else
                {
                  stream.WriteByte((byte) 115);
                  enum12_2 = WoutWareFont.Enum12.const_2;
                }
              }
              else if (WoutWareFont.smethod_12(first.M00 - 1.0) && WoutWareFont.smethod_12(first.M11 - 1.0))
              {
                stream.WriteByte((byte) 116);
                enum12_2 = WoutWareFont.Enum12.const_1;
              }
              else
              {
                stream.WriteByte((byte) 109);
                enum12_2 = WoutWareFont.Enum12.const_3;
              }
              switch (enum12_2)
              {
                case WoutWareFont.Enum12.const_3:
                  WoutWareFont.smethod_2(stream, (float) first.M00);
                  WoutWareFont.smethod_2(stream, (float) first.M02);
                  WoutWareFont.smethod_2(stream, (float) first.M11);
                  WoutWareFont.smethod_2(stream, (float) first.M12);
                  goto label_19;
                case WoutWareFont.Enum12.const_2:
                  WoutWareFont.smethod_2(stream, (float) first.M00);
                  WoutWareFont.smethod_2(stream, (float) first.M11);
                  goto label_19;
                case WoutWareFont.Enum12.const_1:
                  WoutWareFont.smethod_2(stream, (float) first.M02);
                  WoutWareFont.smethod_2(stream, (float) first.M12);
                  goto label_19;
                default:
                  goto label_19;
              }
            }
            else
            {
              stream.WriteByte((byte) 99);
              enum12_1 = WoutWareFont.Enum12.const_4;
            }
          }
          else
          {
            stream.WriteByte((byte) 99);
            enum12_1 = WoutWareFont.Enum12.const_4;
          }
          WoutWareFont.smethod_2(stream, (float) first.M00);
          WoutWareFont.smethod_2(stream, (float) first.M01);
          WoutWareFont.smethod_2(stream, (float) first.M02);
          WoutWareFont.smethod_2(stream, (float) first.M10);
          WoutWareFont.smethod_2(stream, (float) first.M11);
          WoutWareFont.smethod_2(stream, (float) first.M12);
label_19:
          WoutWareFont.smethod_0(stream, shapeRef.Second);
        }
      }
      stream.WriteByte((byte) 33);
    }

    private WoutWareGlyph method_4(Stream stream, byte[] buffer)
    {
      char letter = WoutWareFont.smethod_5(stream, buffer);
      Vector2D advance = WoutWareFont.smethod_7(stream, buffer);
      GeneralShape2D generalShape2D = new GeneralShape2D();
      int num;
      while (true)
      {
        num = stream.ReadByte();
        if (num >= 0)
        {
          WoutWareFont.Enum12 enum12 = (WoutWareFont.Enum12) num;
          if ((uint) enum12 <= 100U)
          {
            switch (enum12)
            {
              case WoutWareFont.Enum12.const_5:
                goto label_11;
              case WoutWareFont.Enum12.const_4:
                double m00_1 = (double) WoutWareFont.smethod_3(stream, buffer);
                double m01 = (double) WoutWareFont.smethod_3(stream, buffer);
                double m02_1 = (double) WoutWareFont.smethod_3(stream, buffer);
                double m10 = (double) WoutWareFont.smethod_3(stream, buffer);
                double m11_1 = (double) WoutWareFont.smethod_3(stream, buffer);
                double m12_1 = (double) WoutWareFont.smethod_3(stream, buffer);
                generalShape2D.Append(this.ilist_0[WoutWareFont.smethod_1(stream, buffer)], false, new Matrix3D(m00_1, m01, m02_1, m10, m11_1, m12_1, 0.0, 0.0, 1.0));
                continue;
              case WoutWareFont.Enum12.const_0:
                generalShape2D.Append(this.ilist_0[WoutWareFont.smethod_1(stream, buffer)], false);
                continue;
              default:
                goto label_12;
            }
          }
          else
          {
            switch (enum12)
            {
              case WoutWareFont.Enum12.const_3:
                double m00_2 = (double) WoutWareFont.smethod_3(stream, buffer);
                double m02_2 = (double) WoutWareFont.smethod_3(stream, buffer);
                double m11_2 = (double) WoutWareFont.smethod_3(stream, buffer);
                double m12_2 = (double) WoutWareFont.smethod_3(stream, buffer);
                generalShape2D.Append(this.ilist_0[WoutWareFont.smethod_1(stream, buffer)], false, new Matrix3D(m00_2, 0.0, m02_2, 0.0, m11_2, m12_2, 0.0, 0.0, 1.0));
                continue;
              case WoutWareFont.Enum12.const_2:
                double x1 = (double) WoutWareFont.smethod_3(stream, buffer);
                double y1 = (double) WoutWareFont.smethod_3(stream, buffer);
                generalShape2D.Append(this.ilist_0[WoutWareFont.smethod_1(stream, buffer)], false, Transformation3D.Scaling(x1, y1));
                continue;
              case WoutWareFont.Enum12.const_1:
                double x2 = (double) WoutWareFont.smethod_3(stream, buffer);
                double y2 = (double) WoutWareFont.smethod_3(stream, buffer);
                generalShape2D.Append(this.ilist_0[WoutWareFont.smethod_1(stream, buffer)], false, Transformation3D.Translation(x2, y2));
                continue;
              default:
                goto label_12;
            }
          }
        }
        else
          break;
      }
      throw new IOException("Unexpected end of input!");
label_11:
      IShape2D outline = !generalShape2D.HasSegments ? (IShape2D) NullShape2D.Instance : (IShape2D) new CachedBoundsShape2D((IShape2D) generalShape2D);
      return new WoutWareGlyph(letter, outline, advance);
label_12:
      throw new IOException("Invalid reference operator " + (object) num);
    }

    private static uint smethod_14(IShape2D shape)
    {
      uint num = 0;
      ISegment2DIterator iterator = shape.CreateIterator();
      while (iterator.MoveNext())
        num = (uint) ((byte) (13 * (int) num) + iterator.CurrentType);
      return num;
    }

    private enum Enum11 : byte
    {
      const_5 = 33, // 0x21
      const_4 = 46, // 0x2E
      const_3 = 67, // 0x43
      const_1 = 76, // 0x4C
      const_0 = 77, // 0x4D
      const_2 = 81, // 0x51
    }

    private enum Enum12 : byte
    {
      const_5 = 33, // 0x21
      const_4 = 99, // 0x63
      const_0 = 100, // 0x64
      const_3 = 109, // 0x6D
      const_2 = 115, // 0x73
      const_1 = 116, // 0x74
    }
  }
}
