// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfWriter
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns11;
using ns3;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using WW.Pdf.Font;
using WW.Text;

namespace WW.Pdf
{
  public class PdfWriter
  {
    public static readonly Encoding StandardEncoding = Encodings.Ascii;
    private static readonly byte[] byte_0 = new byte[6]{ (byte) 37, (byte) 161, (byte) 162, (byte) 163, (byte) 164, (byte) 10 };
    private Encoding encoding_0 = Encodings.Ascii;
    private readonly PdfDocument pdfDocument_0;
    private int int_0;
    private readonly Stream stream_0;
    private int int_1;

    public PdfWriter(PdfDocument document, Stream stream)
      : this(document, stream, 15)
    {
    }

    public PdfWriter(PdfDocument document, Stream stream, int streamVersion)
    {
      this.pdfDocument_0 = document;
      this.stream_0 = stream;
      this.int_1 = streamVersion;
    }

    public void Write()
    {
      this.Write(true);
    }

    public void Write(bool closeStream)
    {
      this.method_0();
      foreach (PdfBody body in (List<PdfBody>) this.pdfDocument_0.Bodies)
      {
        List<Class65> objectPositions = this.method_1(body);
        long crossRefTablePosition = this.method_5(objectPositions);
        this.method_6(body, objectPositions, crossRefTablePosition);
      }
      if (!closeStream)
        return;
      this.stream_0.Close();
    }

    public static string EscapeSpecialChars(string s)
    {
      s = s.Replace("\\", "\\\\");
      s = s.Replace("(", "\\(");
      s = s.Replace(")", "\\)");
      return s;
    }

    private void method_0()
    {
      foreach (PdfBody body in (List<PdfBody>) this.pdfDocument_0.Bodies)
      {
        foreach (IPdfIndirectObject indirectObject in (List<IPdfIndirectObject>) body.IndirectObjects)
        {
          if (indirectObject.Number >= this.int_0)
            this.int_0 = indirectObject.Number + 1;
        }
      }
    }

    private List<Class65> method_1(PdfBody body)
    {
      body.EmbedFonts();
      this.method_2(body);
      if (this.int_1 == 13)
      {
        this.method_7("%PDF-1.3");
      }
      else
      {
        if (this.int_1 != 15)
          throw new ArgumentException("Unknown pdf version requested." + (object) this.int_1);
        this.method_7("%PDF-1.5");
      }
      this.stream_0.Write(PdfWriter.byte_0, 0, PdfWriter.byte_0.Length);
      Class64 bodyWriter = new Class64(this.stream_0);
      if (body.DocumentInformation != null)
        this.method_4((IPdfIndirectObject) body.DocumentInformation, bodyWriter);
      this.method_4((IPdfIndirectObject) body.Catalog, bodyWriter);
      this.method_4((IPdfIndirectObject) body.Outlines, bodyWriter);
      this.method_4((IPdfIndirectObject) body.Pages, bodyWriter);
      foreach (IPdfIndirectObject indirectObject in (List<IPdfIndirectObject>) body.IndirectObjects)
        this.method_4(indirectObject, bodyWriter);
      foreach (IPdfIndirectObject font in (List<PdfFont>) body.Fonts)
        this.method_4(font, bodyWriter);
      this.method_4((IPdfIndirectObject) body.ProcedureSetArray, bodyWriter);
      return bodyWriter.ObjectPositions;
    }

    private void method_2(PdfBody body)
    {
      if (body.DocumentInformation != null)
        this.method_3((IPdfIndirectObject) body.DocumentInformation);
      this.method_3((IPdfIndirectObject) body.Catalog);
      this.method_3((IPdfIndirectObject) body.Outlines);
      this.method_3((IPdfIndirectObject) body.Pages);
      foreach (IPdfIndirectObject indirectObject in (List<IPdfIndirectObject>) body.IndirectObjects)
        this.method_3(indirectObject);
      foreach (IPdfIndirectObject font in (List<PdfFont>) body.Fonts)
        this.method_3(font);
      this.method_3((IPdfIndirectObject) body.ProcedureSetArray);
    }

    private void method_3(IPdfIndirectObject obj)
    {
      if (obj.Number != 0)
        return;
      obj.Number = this.int_0;
      ++this.int_0;
    }

    private void method_4(IPdfIndirectObject obj, Class64 bodyWriter)
    {
      bodyWriter.ObjectPositions.Add(new Class65(obj, this.stream_0.Position));
      this.method_7(obj.Number.ToString((IFormatProvider) CultureInfo.InvariantCulture) + " " + obj.Generation.ToString((IFormatProvider) CultureInfo.InvariantCulture) + " obj");
      obj.Value.Write(new ExtendedPdfOutput((IPdfOutput) bodyWriter));
      this.method_8();
      this.method_7("endobj");
    }

    private long method_5(List<Class65> objectPositions)
    {
      long position = this.stream_0.Position;
      this.method_7("xref");
      this.method_7("0 " + (objectPositions.Count + 1).ToString((IFormatProvider) CultureInfo.InvariantCulture));
      this.method_7("0000000000 65535 f ");
      foreach (Class65 objectPosition in objectPositions)
        this.method_7(objectPosition.Position.ToString("0000000000", (IFormatProvider) CultureInfo.InvariantCulture) + " 00000 n ");
      return position;
    }

    private void method_6(PdfBody body, List<Class65> objectPositions, long crossRefTablePosition)
    {
      this.method_7("trailer");
      this.method_7("<< /Size " + (objectPositions.Count + 1).ToString((IFormatProvider) CultureInfo.InvariantCulture));
      this.method_7("/Root " + PdfWriter.GetReferenceString((IPdfIndirectObject) body.Catalog));
      if (body.DocumentInformation != null)
        this.method_7("/Info " + PdfWriter.GetReferenceString((IPdfIndirectObject) body.DocumentInformation));
      this.method_7(">>");
      this.method_7("startxref");
      this.method_7(crossRefTablePosition.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      this.method_7("%%EOF");
    }

    private void method_7(string s)
    {
      byte[] bytes = PdfWriter.StandardEncoding.GetBytes(s + "\n");
      this.stream_0.Write(bytes, 0, bytes.Length);
    }

    private void method_8()
    {
      byte[] bytes = PdfWriter.StandardEncoding.GetBytes("\n");
      this.stream_0.Write(bytes, 0, bytes.Length);
    }

    public static string GetReferenceString(IPdfIndirectObject referencedObject)
    {
      if (referencedObject == null)
        throw new ArgumentException("Referenced object is null.");
      return referencedObject.Number.ToString((IFormatProvider) CultureInfo.InvariantCulture) + " " + referencedObject.Generation.ToString((IFormatProvider) CultureInfo.InvariantCulture) + " R";
    }
  }
}
