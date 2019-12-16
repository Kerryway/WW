// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.PdfFontCreator
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns1;
using ns4;
using ns7;
using ns8;
using ns9;
using System;
using System.Collections.Generic;
using WW.Pdf.Filter;

namespace WW.Pdf.Font
{
  public static class PdfFontCreator
  {
    public static PdfFont AddFont(PdfBody body, string pdfFontID, WW.Pdf.Font.Font font)
    {
      PdfFont pdfFont;
      if (font is Class14)
      {
        Class14 base14 = (Class14) font;
        pdfFont = (PdfFont) PdfFontCreator.smethod_1(pdfFontID, base14);
      }
      else
      {
        IFontMetric fontMetric = PdfFontCreator.smethod_3(font);
        if (fontMetric is Class14)
        {
          Class14 base14 = (Class14) fontMetric;
          pdfFont = (PdfFont) PdfFontCreator.smethod_1(pdfFontID, base14);
        }
        else if (fontMetric is ns7.Class33)
        {
          ns7.Class33 ttf = (ns7.Class33) fontMetric;
          pdfFont = (PdfFont) PdfFontCreator.smethod_2(body, pdfFontID, font, ttf);
        }
        else
        {
          ns0.Class30 cidFont = (ns0.Class30) fontMetric;
          pdfFont = PdfFontCreator.smethod_0(body, pdfFontID, font, cidFont);
        }
      }
      if (pdfFont == null)
        throw new Exception("Unable to create Pdf font object for " + pdfFontID);
      body.Fonts.Add(pdfFont);
      return pdfFont;
    }

    private static PdfFont smethod_0(
      PdfBody body,
      string pdfFontID,
      WW.Pdf.Font.Font font,
      ns0.Class30 cidFont)
    {
      PdfIndirectObject<PdfFontFile> pdfIndirectObject1 = new PdfIndirectObject<PdfFontFile>(new PdfFontFile(font.Descriptor.FontData));
      Class40 class40 = PdfFontCreator.smethod_4(pdfFontID, (IFontMetric) cidFont);
      PdfIndirectObject<Class40> pdfIndirectObject2 = new PdfIndirectObject<Class40>(class40);
      class40.FontFile2 = pdfIndirectObject1;
      Class39 class39 = new Class39(cidFont.Registry, cidFont.Ordering, cidFont.Supplement);
      Class35 class35 = new Class35(PdfFontSubTypeEnum.CIDFontType2, font.FontName);
      class35.SystemInfo = class39;
      class35.Descriptor = pdfIndirectObject2;
      class35.DefaultWidth = cidFont.DefaultWidth;
      class35.Widths = cidFont.WArray;
      PdfCMap pdfCmap = new PdfCMap();
      pdfCmap.AddFilter((IFilter) new FlateFilter());
      pdfCmap.SystemInfo = class39;
      pdfCmap.AddBfRanges(cidFont.CMapEntries);
      PdfIndirectObject<PdfCMap> pdfIndirectObject3 = new PdfIndirectObject<PdfCMap>(pdfCmap);
      Class36 class36 = new Class36(pdfFontID, font.FontName);
      class36.Encoding = cidFont.Encoding;
      class36.Descendant = class35;
      class36.ToUnicode = pdfIndirectObject3;
      body.IndirectObjects.Add((IPdfIndirectObject) pdfIndirectObject2);
      body.IndirectObjects.Add((IPdfIndirectObject) class35);
      body.IndirectObjects.Add((IPdfIndirectObject) pdfIndirectObject3);
      body.IndirectObjects.Add((IPdfIndirectObject) pdfIndirectObject1);
      return (PdfFont) class36;
    }

    private static ns2.Class37 smethod_1(string pdfFontID, Class14 base14)
    {
      ns2.Class37 class37 = new ns2.Class37(pdfFontID, base14.FontName);
      class37.Encoding = base14.Encoding;
      return class37;
    }

    private static Class38 smethod_2(
      PdfBody body,
      string pdfFontID,
      WW.Pdf.Font.Font font,
      ns7.Class33 ttf)
    {
      PdfIndirectObject<Class40> pdfIndirectObject = new PdfIndirectObject<Class40>(PdfFontCreator.smethod_4(pdfFontID, (IFontMetric) ttf));
      Class38 class38 = new Class38(pdfFontID, font.FontName);
      class38.Encoding = "WinAnsiEncoding";
      class38.Descriptor = pdfIndirectObject;
      class38.FirstChar = ttf.FirstChar;
      class38.LastChar = ttf.LastChar;
      class38.Widths = ttf.Array;
      body.IndirectObjects.Add((IPdfIndirectObject) pdfIndirectObject);
      return class38;
    }

    private static IFontMetric smethod_3(WW.Pdf.Font.Font font)
    {
      if (font is Class29)
        return (IFontMetric) ((Class29) font).RealFont;
      return (IFontMetric) font;
    }

    private static Class40 smethod_4(string fontName, IFontMetric metrics)
    {
      IFontDescriptor descriptor = metrics.Descriptor;
      Class40 class40 = new Class40(fontName);
      class40.Ascent = metrics.Ascender;
      class40.CapHeight = metrics.CapHeight;
      class40.Descent = metrics.Descender;
      class40.Flags = descriptor.Flags;
      class40.ItalicAngle = descriptor.ItalicAngle;
      class40.StemV = descriptor.StemV;
      PdfArray pdfArray = new PdfArray();
      pdfArray.AddRange((IEnumerable<int>) descriptor.FontBBox);
      class40.FontBBox = pdfArray;
      return class40;
    }
  }
}
