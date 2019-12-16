// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.FontSetup
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns4;
using ns8;
using System.Collections.Generic;
using WW.Collections.Generic;
using WW.Pdf.Components;
using WW.Pdf.Font.Gdi;

namespace WW.Pdf.Font
{
  public class FontSetup
  {
    private int int_0 = 17;
    private readonly PdfFontInfo pdfFontInfo_0;

    public FontSetup(PdfFontInfo fontInfo, FontType proxyFontType)
    {
      this.pdfFontInfo_0 = fontInfo;
      this.method_1();
      this.method_0(proxyFontType);
    }

    private void method_0(FontType fontType)
    {
      Class54 class54 = new Class54(new Class53());
      foreach (string familyName in class54.FamilyNames)
      {
        if (!FontSetup.smethod_0(familyName))
        {
          FontStyles fontStyles = class54.method_0(familyName);
          if (fontStyles.RegularAvailable)
          {
            string nextAvailableName = this.GetNextAvailableName();
            this.pdfFontInfo_0.AddMetrics(nextAvailableName, (IFontMetric) new Class29(new FontProperties(familyName, false, false), fontType));
            this.pdfFontInfo_0.AddFontProperties(nextAvailableName, familyName, "normal", "normal");
          }
          if (fontStyles.BoldAvailable)
          {
            string nextAvailableName = this.GetNextAvailableName();
            this.pdfFontInfo_0.AddMetrics(nextAvailableName, (IFontMetric) new Class29(new FontProperties(familyName, true, false), fontType));
            this.pdfFontInfo_0.AddFontProperties(nextAvailableName, familyName, "normal", "bold");
          }
          if (fontStyles.ItalicAvailable)
          {
            string nextAvailableName = this.GetNextAvailableName();
            this.pdfFontInfo_0.AddMetrics(nextAvailableName, (IFontMetric) new Class29(new FontProperties(familyName, false, true), fontType));
            this.pdfFontInfo_0.AddFontProperties(nextAvailableName, familyName, "italic", "normal");
          }
          if (fontStyles.BoldItalicAvailable)
          {
            string nextAvailableName = this.GetNextAvailableName();
            this.pdfFontInfo_0.AddMetrics(nextAvailableName, (IFontMetric) new Class29(new FontProperties(familyName, true, true), fontType));
            this.pdfFontInfo_0.AddFontProperties(nextAvailableName, familyName, "italic", "bold");
          }
        }
      }
      this.pdfFontInfo_0.AddMetrics("F15", (IFontMetric) new Class29(new FontProperties("Monotype Corsiva", false, false), fontType));
      this.pdfFontInfo_0.AddFontProperties("F15", "cursive", "normal", "normal");
      this.pdfFontInfo_0.AddMetrics("F16", (IFontMetric) Class14.font_13);
      this.pdfFontInfo_0.AddFontProperties("F16", "fantasy", "normal", "normal");
    }

    private static bool smethod_0(string familyName)
    {
      switch (familyName)
      {
        case "any":
        case "sans-serif":
        case "serif":
        case "monospace":
        case "Helvetica":
        case "Times":
        case "Courier":
        case "Symbol":
        case "ZapfDingbats":
          return true;
        default:
          return false;
      }
    }

    public string GetNextAvailableName()
    {
      return string.Format("F{0}", (object) this.int_0++);
    }

    private void method_1()
    {
      this.pdfFontInfo_0.AddMetrics("F1", (IFontMetric) Class14.font_4);
      this.pdfFontInfo_0.AddMetrics("F2", (IFontMetric) Class14.font_6);
      this.pdfFontInfo_0.AddMetrics("F3", (IFontMetric) Class14.font_5);
      this.pdfFontInfo_0.AddMetrics("F4", (IFontMetric) Class14.font_7);
      this.pdfFontInfo_0.AddMetrics("F5", (IFontMetric) Class14.font_8);
      this.pdfFontInfo_0.AddMetrics("F6", (IFontMetric) Class14.font_10);
      this.pdfFontInfo_0.AddMetrics("F7", (IFontMetric) Class14.font_9);
      this.pdfFontInfo_0.AddMetrics("F8", (IFontMetric) Class14.font_11);
      this.pdfFontInfo_0.AddMetrics("F9", (IFontMetric) Class14.font_0);
      this.pdfFontInfo_0.AddMetrics("F10", (IFontMetric) Class14.font_2);
      this.pdfFontInfo_0.AddMetrics("F11", (IFontMetric) Class14.font_1);
      this.pdfFontInfo_0.AddMetrics("F12", (IFontMetric) Class14.font_3);
      this.pdfFontInfo_0.AddMetrics("F13", (IFontMetric) Class14.font_12);
      this.pdfFontInfo_0.AddMetrics("F14", (IFontMetric) Class14.font_13);
      this.pdfFontInfo_0.AddFontProperties("F5", "any", "normal", "normal");
      this.pdfFontInfo_0.AddFontProperties("F6", "any", "italic", "normal");
      this.pdfFontInfo_0.AddFontProperties("F6", "any", "oblique", "normal");
      this.pdfFontInfo_0.AddFontProperties("F7", "any", "normal", "bold");
      this.pdfFontInfo_0.AddFontProperties("F8", "any", "italic", "bold");
      this.pdfFontInfo_0.AddFontProperties("F8", "any", "oblique", "bold");
      this.pdfFontInfo_0.AddFontProperties("F1", "sans-serif", "normal", "normal");
      this.pdfFontInfo_0.AddFontProperties("F2", "sans-serif", "oblique", "normal");
      this.pdfFontInfo_0.AddFontProperties("F2", "sans-serif", "italic", "normal");
      this.pdfFontInfo_0.AddFontProperties("F3", "sans-serif", "normal", "bold");
      this.pdfFontInfo_0.AddFontProperties("F4", "sans-serif", "oblique", "bold");
      this.pdfFontInfo_0.AddFontProperties("F4", "sans-serif", "italic", "bold");
      this.pdfFontInfo_0.AddFontProperties("F5", "serif", "normal", "normal");
      this.pdfFontInfo_0.AddFontProperties("F6", "serif", "oblique", "normal");
      this.pdfFontInfo_0.AddFontProperties("F6", "serif", "italic", "normal");
      this.pdfFontInfo_0.AddFontProperties("F7", "serif", "normal", "bold");
      this.pdfFontInfo_0.AddFontProperties("F8", "serif", "oblique", "bold");
      this.pdfFontInfo_0.AddFontProperties("F8", "serif", "italic", "bold");
      this.pdfFontInfo_0.AddFontProperties("F9", "monospace", "normal", "normal");
      this.pdfFontInfo_0.AddFontProperties("F10", "monospace", "oblique", "normal");
      this.pdfFontInfo_0.AddFontProperties("F10", "monospace", "italic", "normal");
      this.pdfFontInfo_0.AddFontProperties("F11", "monospace", "normal", "bold");
      this.pdfFontInfo_0.AddFontProperties("F12", "monospace", "oblique", "bold");
      this.pdfFontInfo_0.AddFontProperties("F12", "monospace", "italic", "bold");
      this.pdfFontInfo_0.AddFontProperties("F1", "Helvetica", "normal", "normal");
      this.pdfFontInfo_0.AddFontProperties("F2", "Helvetica", "oblique", "normal");
      this.pdfFontInfo_0.AddFontProperties("F2", "Helvetica", "italic", "normal");
      this.pdfFontInfo_0.AddFontProperties("F3", "Helvetica", "normal", "bold");
      this.pdfFontInfo_0.AddFontProperties("F4", "Helvetica", "oblique", "bold");
      this.pdfFontInfo_0.AddFontProperties("F4", "Helvetica", "italic", "bold");
      this.pdfFontInfo_0.AddFontProperties("F5", "Times", "normal", "normal");
      this.pdfFontInfo_0.AddFontProperties("F6", "Times", "oblique", "normal");
      this.pdfFontInfo_0.AddFontProperties("F6", "Times", "italic", "normal");
      this.pdfFontInfo_0.AddFontProperties("F7", "Times", "normal", "bold");
      this.pdfFontInfo_0.AddFontProperties("F8", "Times", "oblique", "bold");
      this.pdfFontInfo_0.AddFontProperties("F8", "Times", "italic", "bold");
      this.pdfFontInfo_0.AddFontProperties("F9", "Courier", "normal", "normal");
      this.pdfFontInfo_0.AddFontProperties("F10", "Courier", "oblique", "normal");
      this.pdfFontInfo_0.AddFontProperties("F10", "Courier", "italic", "normal");
      this.pdfFontInfo_0.AddFontProperties("F11", "Courier", "normal", "bold");
      this.pdfFontInfo_0.AddFontProperties("F12", "Courier", "oblique", "bold");
      this.pdfFontInfo_0.AddFontProperties("F12", "Courier", "italic", "bold");
      this.pdfFontInfo_0.AddFontProperties("F13", "Symbol", "normal", "normal");
      this.pdfFontInfo_0.AddFontProperties("F14", "ZapfDingbats", "normal", "normal");
    }

    internal void method_2(PdfBody body)
    {
      IDictionary<string, IFontMetric> nameToFontMetric = this.pdfFontInfo_0.UsedNameToFontMetric;
      foreach (string key in (IEnumerable<string>) nameToFontMetric.Keys)
      {
        WW.Pdf.Font.Font font = (WW.Pdf.Font.Font) nameToFontMetric[key];
        PdfFont pdfFont = PdfFontCreator.AddFont(body, key, font);
        foreach (PdfReference kid in (ActiveList<IPdfObject>) body.Pages.Kids)
        {
          PdfPage referencedObject = (PdfPage) kid.ReferencedObject;
          IPdfObject pdfObject;
          PdfDictionary pdfDictionary;
          if (referencedObject.Resources.TryGetValue("Font", out pdfObject))
          {
            pdfDictionary = (PdfDictionary) pdfObject;
          }
          else
          {
            pdfDictionary = new PdfDictionary();
            referencedObject.Resources.Add("Font", (IPdfObject) pdfDictionary);
          }
          if (!pdfDictionary.ContainsKey(key))
            pdfDictionary.Add(key, (IPdfObject) new PdfReference((IPdfIndirectObject) pdfFont));
        }
      }
    }
  }
}
