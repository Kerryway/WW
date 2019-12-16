// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfCMap
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns1;
using ns2;
using ns8;
using System;
using System.Collections.Generic;

namespace WW.Pdf
{
  public class PdfCMap : PdfContentStream
  {
    internal const string string_0 = "Adobe-Identity-UCS";
    private Class39 class39_0;
    private readonly IDictionary<ushort, ushort> idictionary_0;

    public PdfCMap()
    {
      this.idictionary_0 = (IDictionary<ushort, ushort>) new Dictionary<ushort, ushort>();
    }

    internal Class39 SystemInfo
    {
      set
      {
        this.class39_0 = value;
      }
      get
      {
        return this.class39_0;
      }
    }

    public void AddBfRanges(IDictionary<ushort, char> map)
    {
      foreach (KeyValuePair<ushort, char> keyValuePair in (IEnumerable<KeyValuePair<ushort, char>>) map)
        this.AddBfRange(Convert.ToUInt16(keyValuePair.Key), Convert.ToUInt16(keyValuePair.Value));
    }

    public void AddBfRange(ushort glyphIndex, ushort unicodeValue)
    {
      this.idictionary_0.Add(glyphIndex, unicodeValue);
    }

    public IDictionary<ushort, ushort> Ranges
    {
      get
      {
        return this.idictionary_0;
      }
    }

    public override void Write(ExtendedPdfOutput output)
    {
      this.method_2();
      base.Write(output);
    }

    internal void method_2()
    {
      this.XOut.WriteLine("/CIDInit /ProcSet findresource begin");
      this.XOut.WriteLine("12 dict begin");
      this.XOut.WriteLine("begincmap");
      this.XOut.WriteLine("/CIDSystemInfo");
      this.XOut.WriteLine((IPdfObject) this.class39_0);
      this.XOut.WriteLine("def");
      this.XOut.WriteLine(string.Format("/CMapName /{0} def", (object) "Adobe-Identity-UCS"));
      this.XOut.WriteLine("/CMapType 2 def");
      if (this.idictionary_0.Count > 0)
      {
        Class81 entries = this.method_6();
        this.method_3(entries);
        this.method_4(entries);
        this.method_5(entries);
      }
      this.XOut.WriteLine("endcmap");
      this.XOut.WriteLine("CMapName currentdict /CMap defineresource pop");
      this.XOut.WriteLine("end");
      this.XOut.Write("end");
    }

    private void method_3(Class81 entries)
    {
      Class43 entry1 = entries[0];
      Class43 entry2 = entries[entries.Count - 1];
      this.XOut.WriteLine("1 begincodespacerange");
      this.XOut.WriteLine(string.Format("<{0:X4}> <{1:X4}>", (object) entry1.StartGlyphIndex, (object) entry2.EndGlyphIndex));
      this.XOut.WriteLine("endcodespacerange");
    }

    private void method_4(Class81 entries)
    {
      Class43[] chars = entries.Chars;
      int num1 = chars.Length / 100 + (chars.Length % 100 > 0 ? 1 : 0);
      for (int index1 = 0; index1 < num1; ++index1)
      {
        int num2 = index1 + 1 == num1 ? chars.Length - index1 * 100 : 100;
        this.XOut.WriteLine(string.Format("{0} beginbfchar", (object) num2));
        for (int index2 = 0; index2 < num2; ++index2)
        {
          Class43 class43 = chars[index1 * 100 + index2];
          this.XOut.WriteLine(string.Format("<{0:X4}> <{1:X4}>", (object) class43.StartGlyphIndex, (object) class43.UnicodeValue));
        }
        this.XOut.WriteLine("endbfchar");
      }
    }

    private void method_5(Class81 entries)
    {
      Class43[] ranges = entries.Ranges;
      int num1 = ranges.Length / 100 + (ranges.Length % 100 > 0 ? 1 : 0);
      for (int index1 = 0; index1 < num1; ++index1)
      {
        int num2 = index1 + 1 == num1 ? ranges.Length - index1 * 100 : 100;
        this.XOut.WriteLine(string.Format("{0} beginbfrange", (object) num2));
        for (int index2 = 0; index2 < num2; ++index2)
        {
          Class43 class43 = ranges[index1 * 100 + index2];
          this.XOut.WriteLine(string.Format("<{0:X4}> <{1:X4}> <{2:X4}>", (object) class43.StartGlyphIndex, (object) class43.EndGlyphIndex, (object) class43.UnicodeValue));
        }
        this.XOut.WriteLine("endbfrange");
      }
    }

    internal Class81 method_6()
    {
      Class81 class81 = new Class81();
      List<ushort> ushortList = new List<ushort>((IEnumerable<ushort>) this.idictionary_0.Keys);
      ushortList.Sort();
      ushort startIndex1 = ushortList[0];
      ushort unicodeValue1 = this.idictionary_0[startIndex1];
      Class43 entry = new Class43(startIndex1, unicodeValue1);
      class81.Add(entry);
      for (int index = 1; index < this.idictionary_0.Count; ++index)
      {
        ushort startIndex2 = ushortList[index];
        ushort unicodeValue2 = this.idictionary_0[startIndex2];
        if ((int) unicodeValue2 == (int) unicodeValue1 + 1 && (int) startIndex2 == (int) startIndex1 + 1)
        {
          entry.method_0();
        }
        else
        {
          entry = new Class43(startIndex2, unicodeValue2);
          class81.Add(entry);
        }
        startIndex1 = startIndex2;
        unicodeValue1 = unicodeValue2;
      }
      return class81;
    }
  }
}
